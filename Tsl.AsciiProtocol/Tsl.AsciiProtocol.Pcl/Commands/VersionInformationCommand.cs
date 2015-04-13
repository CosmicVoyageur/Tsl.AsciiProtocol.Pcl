// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.VersionInformationCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Commands
{
  /// <summary>
  /// A command to query the reader for version information
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// Since ASCII Protocol v2.2 the version command also reports the Bluetooth address
  /// 
  /// </remarks>
  public class VersionInformationCommand : AsciiCommandBase
  {
    /// <summary>
    /// Gets the manufacturer name retrived from the reader
    /// 
    /// </summary>
    [Description("The manufacturer")]
    [Category("Response")]
    public string Manufacturer
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "MF");
      }
    }

    /// <summary>
    /// Gets the serial number retrived from the reader
    /// 
    /// </summary>
    [Description("The serial number")]
    [Category("Response")]
    public string SerialNumber
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "US");
      }
    }

    /// <summary>
    /// Gets the FirmwareVersion retrived from the reader
    /// 
    /// </summary>
    [Description("The control firmware version")]
    [Category("Response")]
    public string FirmwareVersion
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "UF");
      }
    }

    /// <summary>
    /// Gets the bootloader verion name retrived from the reader
    /// 
    /// </summary>
    [Category("Response")]
    [Description("The control bootloader version")]
    public string BootloaderVersion
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "UB");
      }
    }

    /// <summary>
    /// Gets the radio serial number retrived from the reader
    /// 
    /// </summary>
    [Description("The radio serial number")]
    [Category("Response")]
    public string RadioSerialNumber
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "RS");
      }
    }

    /// <summary>
    /// Gets the radio firmware version retrived from the reader
    /// 
    /// </summary>
    [Description("The radio firmware version")]
    [Category("Response")]
    public string RadioFirmwareVersion
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "RF");
      }
    }

    /// <summary>
    /// Gets the radio bootloader version retrived from the reader
    /// 
    /// </summary>
    [Description("The radio bootloader version")]
    [Category("Response")]
    public string RadioBootloaderVersion
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "RB");
      }
    }

    /// <summary>
    /// Gets the antenna serial number retrived from the reader
    /// 
    /// </summary>
    [Category("Response")]
    [Description("The serial number of the installed antenna")]
    public string AntennaSerialNumber
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "AS");
      }
    }

    /// <summary>
    /// Gets the ASCII protocol retrived from the reader
    /// 
    /// </summary>
    [Description("The version of ASCII protocol supported by the reader")]
    [Category("Response")]
    public string AsciiProtocol
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "PV");
      }
    }

    /// <summary>
    /// Gets the Bluetooth Address of the reader (ASCII Protocol 2.2 or higher)
    /// 
    /// </summary>
    public string BluetoothAddress
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderText((IAsciiResponse) this.Response, "BA");
      }
    }

    /// <summary>
    /// Initializes a new instance of the VersionInformationCommand class
    /// 
    /// </summary>
    public VersionInformationCommand()
      : base(".vr")
    {
      this.Parameters.Reset();
      AsciiResponseExtensions.AddHeaders(this.Response, "CS: AS: BA: MF: PV: RB: RF: RS: UB: UF: US: ER: ME: OK:");
    }
  }
}
