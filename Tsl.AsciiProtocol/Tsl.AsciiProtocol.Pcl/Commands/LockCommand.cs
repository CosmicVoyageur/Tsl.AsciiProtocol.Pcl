// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.LockCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// A command to lock transponders that match the specified select criteria
  /// 
  /// </summary>
  public class LockCommand : TransponderAccessCommandBase
  {
    /// <summary>
    /// Parameter for lock payload
    /// 
    /// </summary>
    private IParameterAndValue<int?> lockPayload;

    /// <summary>
    /// Gets or sets the lock payload
    /// 
    /// </summary>
    /// <seealso cref="P:PortableAscii2.Commands.LockCommand.LockPayload"/>
    [DefaultValue(null)]
    [Description("Gets or sets the 20 bit lock payload refer to the standard for more information")]
    [Category("Parameters")]
    public int? LockPayload
    {
      get
      {
        return this.lockPayload.Value;
      }
      set
      {
        this.lockPayload.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the LockCommand class
    /// 
    /// </summary>
    public LockCommand()
      : base(".lo")
    {
      this.IsAlertSupported = false;
      this.Parameters.Remove("al");
      this.Parameters.Add((ICommandParameter) (this.lockPayload = (IParameterAndValue<int?>) new ParameterInt("lp", "X5")));
      this.Parameters.Reset();
    }
  }
}
