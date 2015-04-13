// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.EchoCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// This command determines whether the command sent is echoed back to the host or not
  /// 
  /// </summary>
  public class EchoCommand : ParameterCommandBase
  {
    /// <summary>
    /// Backing field for the EchoEnabled command
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> echoEnabled;

    /// <summary>
    /// Gets or sets a value indicating whether the commands are echoed by the reader before sending the response. Null to use the current value
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Description("Determines whether the reader should echo the command before sending the response")]
    [Category("Parameters")]
    public TriState? EchoEnabled
    {
      get
      {
        return this.echoEnabled.Value;
      }
      set
      {
        this.echoEnabled.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the EchoCommand class
    /// 
    /// </summary>
    public EchoCommand()
      : base(".ec")
    {
      this.Parameters.Add((ICommandParameter) (this.echoEnabled = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("e")));
      this.Parameters.Reset();
    }
  }
}
