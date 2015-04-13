// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.AsciiCommandBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Commands
{
  /// <summary>
  /// Base class for all ASCII commands
  /// 
  /// </summary>
  public abstract class AsciiCommandBase : AsciiSelfResponderCommandBase
  {
    /// <summary>
    /// Initializes a new instance of the AsciiCommandBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name (e.g. ".iv" for inventory)</param>
    protected AsciiCommandBase(string commandName)
      : base(commandName)
    {
    }
  }
}
