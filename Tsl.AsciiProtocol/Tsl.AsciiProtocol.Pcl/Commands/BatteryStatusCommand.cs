// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.BatteryStatusCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Commands
{
  /// <summary>
  /// A command to query the reader for battery status information
  ///             Note: This does not yet expose the charging status via a property but the 'CH:' line is captured in the response property
  /// 
  /// </summary>
  public class BatteryStatusCommand : AsciiCommandBase
  {
    /// <summary>
    /// Gets the battery level retrieved from the reader.
    /// 
    /// </summary>
    [Description("The current battery level as a percentage of full charge")]
    [Category("Response")]
    public int BatteryLevel
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeaderNumber((IAsciiResponse) this.Response, "BP");
      }
    }

    /// <summary>
    /// Gets the charge status retrived from the reader.
    /// 
    /// </summary>
    [Description("Indicates the current charge activitity")]
    [Category("Response")]
    public ChargeStatus ChargeStatus
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeader<ChargeStatus>((IAsciiResponse) this.Response, "CH");
      }
    }

    /// <summary>
    /// Initializes a new instance of the BatteryStatusCommand class
    /// 
    /// </summary>
    public BatteryStatusCommand()
      : base(".bl")
    {
      AsciiResponseExtensions.AddHeaders(this.Response, "CH: CS: BP: ER: ME: OK:");
    }
  }
}
