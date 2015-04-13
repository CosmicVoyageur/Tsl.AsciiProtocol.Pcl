// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.ReadTransponderCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// A command to read data from the memory banks of one or more transponders
  /// 
  /// </summary>
  public class ReadTransponderCommand : TransponderMemoryCommandBase
  {
    /// <summary>
    /// Initializes a new instance of the ReadTransponderCommand class
    /// 
    /// </summary>
    public ReadTransponderCommand()
      : base(".rd")
    {
      this.Parameters.Reset();
    }
  }
}
