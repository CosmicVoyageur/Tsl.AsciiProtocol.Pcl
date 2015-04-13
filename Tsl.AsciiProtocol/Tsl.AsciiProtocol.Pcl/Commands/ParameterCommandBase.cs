// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.ParameterCommandBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// Base class for commands that have parameters (i.e. support -p -x)
  /// 
  /// </summary>
  public abstract class ParameterCommandBase : AsciiCommandBase
  {
    /// <summary>
    /// The reset to defaults parameter
    /// 
    /// </summary>
    private ParameterBool resetParameters;
    /// <summary>
    /// The read parameters parameter
    /// 
    /// </summary>
    private ParameterBool readParameters;

    /// <summary>
    /// Gets or sets a value indicating whether to set all parameters to their default values before executing the command
    /// 
    /// </summary>
    [DefaultValue(false)]
    [Category("Parameters Command")]
    [Description("When true before executing the command (including parsing parameters) all parameters for the command are reset to their default values")]
    public bool ResetParameters
    {
      get
      {
        return this.resetParameters.Value;
      }
      set
      {
        this.resetParameters.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the response to the command should report all supported parameters abd their current values
    /// 
    /// </summary>
    [Category("Parameters Command")]
    [Description("When true returns the parameters supported by the command and where supported their current values")]
    [DefaultValue(false)]
    public bool ReadParameters
    {
      get
      {
        return this.readParameters.Value;
      }
      set
      {
        this.readParameters.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the ParameterCommandBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name</param>
    protected ParameterCommandBase(string commandName)
      : base(commandName)
    {
      this.Parameters.Add((ICommandParameter) (this.resetParameters = new ParameterBool("x")));
      this.Parameters.Add((ICommandParameter) (this.readParameters = new ParameterBool("p")));
    }
  }
}
