// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.SleepCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Commands
{
  /// <summary>
  /// A command to send the reader to sleep as soon as it has responded to this command
  ///             Note: this will disconnect the reader from the terminal
  /// 
  /// </summary>
  public class SleepCommand : AsciiCommandBase
  {
    /// <summary>
    /// Initializes a new instance of the SleepCommand class
    /// 
    /// </summary>
    public SleepCommand()
      : base(".sl")
    {
    }
  }
}
