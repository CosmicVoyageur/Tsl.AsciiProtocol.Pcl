// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.KillCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// A command to kill transponders that match the specified select criteria
  /// 
  /// </summary>
  public class KillCommand : TransponderAccessCommandBase
  {
    /// <summary>
    /// Parameter for kill password
    /// 
    /// </summary>
    private IParameterAndValue<string> killPassword;

    /// <summary>
    /// Gets or sets the kill password
    /// 
    /// </summary>
    [Description("Gets or sets the kill password")]
    [Category("Parameters")]
    [DefaultValue(null)]
    public string KillPassword
    {
      get
      {
        return this.killPassword.Value;
      }
      set
      {
        this.killPassword.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the KillCommand class
    /// 
    /// </summary>
    public KillCommand()
      : base(".ki")
    {
      this.IsAlertSupported = false;
      this.Parameters.Remove("al");
      this.Parameters.Add((ICommandParameter) (this.killPassword = (IParameterAndValue<string>) new ParameterHex("kp", 8, 8)));
      this.Parameters.Reset();
    }
  }
}
