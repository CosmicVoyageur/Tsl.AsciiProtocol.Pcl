// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.ActionCommandBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// Base class for commands that support -n -p -x
  /// 
  /// </summary>
  public abstract class ActionCommandBase : ParameterCommandBase, ICommandParameters
  {
    /// <summary>
    /// The take no action parameter
    /// 
    /// </summary>
    private ParameterBool takeNoAction;

    /// <summary>
    /// Gets or sets a value indicating whether the command should only update the parameters and not perform the action of the command
    /// 
    /// </summary>
    [DefaultValue(false)]
    [Category("Parameters Command")]
    [Description("When true only the parameters of the command are updated. The command primary action is not executed")]
    public bool TakeNoAction
    {
      get
      {
        return this.takeNoAction.Value;
      }
      set
      {
        this.takeNoAction.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the ActionCommandBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name</param>
    protected ActionCommandBase(string commandName)
      : base(commandName)
    {
      this.Parameters.Add((ICommandParameter) (this.takeNoAction = new ParameterBool("n")));
    }
  }
}
