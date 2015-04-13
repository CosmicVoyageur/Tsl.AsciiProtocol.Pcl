// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.BluetoothCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// A command to configure of read the Bluetooth parameters
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// The Bluetooth command is currently only supported over USB to change the Bluetooth connection parameters.
  ///             The command has a default timeout of around 20s
  ///             - Reading the Bluetooth can take about 5 seconds
  ///             - Writing the Bluetooth can take about 10 seconds
  ///             - Resetting the Bluetooth can take about 15 seconds
  /// 
  /// </remarks>
  public class BluetoothCommand : ParameterCommandBase
  {
    /// <summary>
    /// Backing field for BundleIdentifier
    /// 
    /// </summary>
    private IParameterAndValue<string> bundleIdentifier;
    /// <summary>
    /// Backing field for BundleSeed
    /// 
    /// </summary>
    private IParameterAndValue<string> bundleSeed;
    /// <summary>
    /// Backing field for BluetoothFriendlyName
    /// 
    /// </summary>
    private IParameterAndValue<string> friendlyName;
    /// <summary>
    /// Backing field for PairingCode
    /// 
    /// </summary>
    private IParameterAndValue<string> pairingCode;

    /// <summary>
    /// Gets or sets the bundle identifier used in iOS applications to program to the reader
    /// 
    /// </summary>
    [Category("Parameters Bluetooth")]
    [DefaultValue("")]
    [Description("The bundle identifier")]
    public string BundleIdentifier
    {
      get
      {
        return this.bundleIdentifier.Value;
      }
      set
      {
        this.bundleIdentifier.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the bundle seed indentifier used in iOS applications to program to the reader
    /// 
    /// </summary>
    [DefaultValue("")]
    [Category("Parameters Bluetooth")]
    [Description("The bundle seed")]
    public string BundleSeed
    {
      get
      {
        return this.bundleSeed.Value;
      }
      set
      {
        this.bundleSeed.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the Bluetooth friendly name to program to the reader
    /// 
    /// </summary>
    [DefaultValue("")]
    [Category("Parameters Bluetooth")]
    [Description("Get or sets the value to set as the Bluetooth friendly name of the reader")]
    public string BluetoothFriendlyName
    {
      get
      {
        return this.friendlyName.Value;
      }
      set
      {
        this.friendlyName.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the four digit pairing code to program to the reader
    /// 
    /// </summary>
    [Description("Gets or sets the four digit pairing code")]
    [DefaultValue("")]
    [Category("Parameters Bluetooth")]
    public string PairingCode
    {
      get
      {
        return this.pairingCode.Value;
      }
      set
      {
        this.pairingCode.Value = value;
      }
    }

    /// <summary>
    /// Gets the result of the Authentication chip self test
    /// 
    /// </summary>
    [DefaultValue("")]
    [Category("Response")]
    [Description("Indicates whether the authentication chip is functional")]
    public AuthenticationChipStatus AuthenticationChip
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeader<AuthenticationChipStatus>((IAsciiResponse) this.Response, "AC");
      }
    }

    /// <summary>
    /// Gets the Bluetooth address as read from the reader
    /// 
    /// </summary>
    [Description("The Bluetooth(r) address of the reader")]
    [DefaultValue("")]
    [Category("Response")]
    public string BluetoothAddress
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "BA");
      }
    }

    /// <summary>
    /// Initializes a new instance of the BluetoothCommand class
    /// 
    /// </summary>
    public BluetoothCommand()
      : base(".bt")
    {
      this.Parameters.Add((ICommandParameter) (this.bundleIdentifier = (IParameterAndValue<string>) new ParameterText("bi", 0, 80, true)));
      this.Parameters.Add((ICommandParameter) (this.bundleSeed = (IParameterAndValue<string>) new ParameterText("bs", 0, 10, true)));
      this.Parameters.Add((ICommandParameter) (this.friendlyName = (IParameterAndValue<string>) new ParameterText("f", 0, 20, true)));
      this.Parameters.Add((ICommandParameter) (this.pairingCode = (IParameterAndValue<string>) new ParameterText("w", 4, 4)));
      this.Parameters.Reset();
      AsciiResponseExtensions.AddHeaders(this.Response, "AC: BA: CS: ER: FN: ME: OK: PR:");
      this.Response.ReceivedLine += new EventHandler<AsciiLineEventArgs>(this.Response_ReceivedLine);
      this.MaxSynchronousWaitTime = 20.0;
    }

    /// <summary>
    /// Captures the bluetooth friendly name read
    /// 
    /// </summary>
    /// <param name="sender">The event source</param><param name="e">Data provided for the event</param>
    private void Response_ReceivedLine(object sender, AsciiLineEventArgs e)
    {
      if (AsciiResponseExtensions.IsCommandStarted(e.Line))
      {
        this.BluetoothFriendlyName = string.Empty;
      }
      else
      {
        if (!AsciiResponseExtensions.HasHeader(e.Line, "FN"))
          return;
        this.BluetoothFriendlyName = e.Line.Value;
      }
    }
  }
}
