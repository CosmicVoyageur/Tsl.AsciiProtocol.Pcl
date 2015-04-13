// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.TransponderAccessCommandBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// Base class for transponders that perform tag access (require access password -ap)
  /// 
  /// </summary>
  public abstract class TransponderAccessCommandBase : QuerySelectTransponderCommandBase
  {
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Commands.TransponderAccessCommandBase.AccessPassword"/>
    /// </summary>
    private IParameterAndValue<string> accessPassword;

    /// <summary>
    /// Gets or sets the password required to access transponders
    /// 
    /// </summary>
    [Category("Parameters")]
    [Description("Gets or sets the access password")]
    [DefaultValue(null)]
    public string AccessPassword
    {
      get
      {
        return this.accessPassword.Value;
      }
      set
      {
        this.accessPassword.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the TransponderAccessCommandBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name (e.g. ".iv" for inventory)</param>
    protected TransponderAccessCommandBase(string commandName)
      : base(commandName)
    {
      this.Parameters.Add((ICommandParameter) (this.accessPassword = (IParameterAndValue<string>) new ParameterHex("ap", 8, 8)));
    }
  }
}
