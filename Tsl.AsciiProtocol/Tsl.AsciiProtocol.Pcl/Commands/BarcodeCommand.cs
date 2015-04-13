// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.BarcodeCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.ComponentModel;
using System.Text;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// A command to scan a barcode
  /// 
  /// </summary>
  public class BarcodeCommand : AlertDateTimeCommandBase
  {
    /// <summary>
    /// The barcode escaped parameter
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> barcodeEscaped;
    /// <summary>
    /// The scan time parameter
    /// 
    /// </summary>
    private IParameterAndValue<int?> scanTime;

    /// <summary>
    /// Gets or sets a value indicating whether the barcode response is escaped to escape '\' (0x5c) for Cr Lf and itself.
    ///             Set to null to not change the current value
    /// 
    /// </summary>
    [Description("True to escape '' (0x5c), Cr (0x0D) and Lf (0x0A) if the barcode response line, false to return the barcode as is. Null to leave the current value unchanged")]
    [Category("Parameters")]
    [DefaultValue(null)]
    public TriState? IsBarcodeEscaped
    {
      get
      {
        return this.barcodeEscaped.Value;
      }
      set
      {
        this.barcodeEscaped.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the maximum time to wait for a barcode to be scanned 1 to 9 seconds
    /// 
    /// </summary>
    [Category("Parameters")]
    [Description("The maximum time in seconds to wait for a barcode to scan or null to use the current parameter value")]
    [DefaultValue(null)]
    public int? ScanTime
    {
      get
      {
        return this.scanTime.Value;
      }
      set
      {
        this.scanTime.Value = value;
        if (!this.scanTime.Value.HasValue)
          return;
        this.MaxSynchronousWaitTime = (double) (this.scanTime.Value.Value + 2);
      }
    }

    /// <summary>
    /// Gets the timestamp when the barcode was scanned if date and time stamp is enabled
    /// 
    /// </summary>
    [Description("The timestamp when the barcode was scanned (if timestamp is enabled)")]
    [Category("Response")]
    public DateTime Timestamp
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderDateTime((IAsciiResponse) this.Response, "DT");
      }
    }

    /// <summary>
    /// Gets the barcode scanned if the command was successful
    /// 
    /// </summary>
    [Description("The barcode scanned")]
    [Category("Response")]
    public string Barcode
    {
      get
      {
        string str = AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "BC");
        return string.IsNullOrEmpty(str) ? AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "BR") : BarcodeCommand.BarcodeEscape(str);
      }
    }

    /// <summary>
    /// Raised when a barcode is received
    /// 
    /// </summary>
    public event EventHandler<BarcodeEventArgs> BarcodeReceived;

    /// <summary>
    /// Initializes a new instance of the BarcodeCommand class
    /// 
    /// </summary>
    public BarcodeCommand()
      : base(".bc")
    {
      this.Parameters.Add((ICommandParameter) (this.barcodeEscaped = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("e")));
      this.Parameters.Add((ICommandParameter) (this.scanTime = (IParameterAndValue<int?>) new ParameterInt("t", 1, 9)));
      this.Parameters.Reset();
      this.MaxSynchronousWaitTime = 11.0;
      AsciiResponseExtensions.AddHeaders(this.Response, "BC: BR: CS: DT: ER: ME: OK: PR:");
      this.Response.CommandComplete += new EventHandler(this.Response_CommandComplete);
    }

    /// <summary>
    /// Utility function to remove the escape characters from an escaped barcode response
    /// 
    /// </summary>
    /// <param name="value">The barcode response to remove the escape sequences from</param>
    /// <returns>
    /// The barcode response without the escapes
    /// </returns>
    public static string BarcodeEscape(string value)
    {
      bool flag = false;
      StringBuilder stringBuilder = new StringBuilder();
      foreach (char ch in value)
      {
        if (flag)
        {
          stringBuilder.Append(ch);
          flag = false;
        }
        else if ('\x001B'.Equals(ch))
          flag = true;
        else
          stringBuilder.Append(ch);
      }
      return stringBuilder.ToString();
    }

    /// <summary>
    /// Raises the <see cref="E:PortableAscii2.Commands.BarcodeCommand.BarcodeReceived"/> event
    /// 
    /// </summary>
    /// <param name="barcode">The barcode received</param><param name="timestamp">The timestamp received</param>
    protected virtual void OnBarcodeReceived(string barcode, DateTime timestamp)
    {
      EventHandler<BarcodeEventArgs> eventHandler = this.BarcodeReceived;
      if (eventHandler == null)
        return;
      eventHandler((object) this, new BarcodeEventArgs(barcode, timestamp));
    }

    /// <summary>
    /// When the command completes, if a barcode has been scanned successfully, raise the BarcodeReceived event
    /// 
    /// </summary>
    /// <param name="sender">The event source</param><param name="e">Data provided for the event</param>
    private void Response_CommandComplete(object sender, EventArgs e)
    {
      if (!this.Response.IsSuccessful)
        return;
      this.OnBarcodeReceived(this.Barcode, this.Timestamp);
    }
  }
}
