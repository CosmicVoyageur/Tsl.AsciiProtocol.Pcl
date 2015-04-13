// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.ReadAutorunFileCommand
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
  /// A command to read the Autorun file from the device
  /// 
  /// </summary>
  public class ReadAutorunFileCommand : AsciiCommandBase
  {
    /// <summary>
    /// Backing field for DeleteFile
    /// 
    /// </summary>
    private IParameterAndValue<Deletion?> deleteFile;
    /// <summary>
    /// True while within the autorun file in the output
    /// 
    /// </summary>
    private bool inAutorunFile;

    /// <summary>
    /// Gets or sets a value indicating whether to delete the file from the device
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters")]
    [Description("Set to yes to delete the file from the device")]
    public Deletion? DeleteFile
    {
      get
      {
        return this.deleteFile.Value;
      }
      set
      {
        this.deleteFile.Value = value;
      }
    }

    /// <summary>
    /// Gets the contents of the file
    /// 
    /// </summary>
    [Category("Response")]
    [Description("The autorun file read from the device")]
    public string AutorunFile
    {
      get
      {
        bool flag = false;
        StringBuilder stringBuilder = new StringBuilder();
        foreach (IAsciiResponseLine line in this.Response.Response)
        {
          if (AsciiResponseExtensions.HasHeader(line, "AB"))
            flag = true;
          else if (AsciiResponseExtensions.HasHeader(line, "AE"))
            flag = false;
          else if (flag)
            stringBuilder.AppendLine(line.FullLine);
        }
        return stringBuilder.ToString();
      }
    }

    /// <summary>
    /// Initializes a new instance of the ReadAutorunFileCommand class
    /// 
    /// </summary>
    public ReadAutorunFileCommand()
      : base(".ra")
    {
      this.Parameters.Add((ICommandParameter) (this.deleteFile = (IParameterAndValue<Deletion?>) new ParameterEnum<Deletion>("d")));
      this.Parameters.Reset();
      AsciiResponseExtensions.AddHeaders(this.Response, "CS: ER: AB: AE: ME: OK:");
      this.Response.ReceivedLine += new EventHandler<AsciiLineEventArgs>(this.Response_ReceivedLine);
    }

    /// <summary>
    /// Additional processing for lines within the commands response
    /// 
    /// </summary>
    /// <param name="sender">The event source</param><param name="e">Data provided for the event</param>
    /// <remarks>
    /// The contents of the autorun file is one command per line (i.e. not a well formed header line)
    ///             Once we have seen the AB header and until we see the AE footer we want to signal to capture
    ///             all these lines are part of the response
    /// 
    /// </remarks>
    private void Response_ReceivedLine(object sender, AsciiLineEventArgs e)
    {
      if (AsciiResponseExtensions.IsCommandStarted(e.Line))
      {
        this.inAutorunFile = false;
        e.Handled = true;
      }
      else if (AsciiResponseExtensions.HasHeader(e.Line, "AB"))
      {
        this.inAutorunFile = true;
        e.Handled = true;
      }
      else if (AsciiResponseExtensions.HasHeader(e.Line, "AE"))
      {
        this.inAutorunFile = false;
        e.Handled = true;
      }
      else
      {
        if (!this.inAutorunFile)
          return;
        e.Handled = true;
      }
    }
  }
}
