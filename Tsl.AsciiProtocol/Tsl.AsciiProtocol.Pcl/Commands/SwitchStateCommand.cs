// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.SwitchStateCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// ASCII command to query the switch state
  /// 
  /// </summary>
  public class SwitchStateCommand : AsciiCommandBase
  {
    /// <summary>
    /// Gets the last switch state received from the device
    /// 
    /// </summary>
    [Description("The received switch state")]
    [Category("Response")]
    public SwitchState State
    {
      get
      {
        return AsciiResponseExtensions.ValueByHeader<SwitchState>((IAsciiResponse) this.Response, "SW");
      }
    }

    /// <summary>
    /// Initializes a new instance of the SwitchStateCommand class
    /// 
    /// </summary>
    public SwitchStateCommand()
      : base(".ss")
    {
      AsciiResponseExtensions.AddHeaders(this.Response, "CS: SW: ER: ME: OK:");
    }
  }


}
