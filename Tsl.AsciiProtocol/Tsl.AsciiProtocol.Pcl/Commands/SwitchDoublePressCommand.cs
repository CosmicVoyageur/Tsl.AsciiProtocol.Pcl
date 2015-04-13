// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.SwitchDoublePressCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// A command that activates the double press switch action for the specified number of seconds
  /// 
  /// </summary>
  public class SwitchDoublePressCommand : ActionCommandBase
  {
    /// <summary>
    /// The press duration parameter
    /// 
    /// </summary>
    private IParameterAndValue<int?> duration;

    /// <summary>
    /// Gets or sets the duration in seconds the switch remains active
    /// 
    /// </summary>
    [Description("The duration in seconds (0 .. 99) the switch remains active")]
    [Category("Parameters")]
    [DefaultValue(null)]
    public int? PressDuration
    {
      get
      {
        return this.duration.Value;
      }
      set
      {
        this.duration.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the SwitchDoublePressCommand class
    /// 
    /// </summary>
    public SwitchDoublePressCommand()
      : base(".pd")
    {
      this.Parameters.Add((ICommandParameter) (this.duration = (IParameterAndValue<int?>) new ParameterInt("t", 0, 99)));
      this.Parameters.Reset();
    }
  }
}
