// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.TransponderWriteExtension
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2
{
  /// <summary>
  /// Defines the Impinj Extension options for the BlockWrite command as used with <see cref="F:TechnologySolutions.Rfid.AsciiProtocol.TransponderWriteMode.BlockWrite"/>
  /// </summary>
  public enum TransponderWriteExtension
  {
    [EnumExtension("a", "Auto. The reader will select the most appropriate mode")] Auto,
    [EnumExtension("1", "Force 1. Block write will always write one word at a time")] ForceOne,
    [EnumExtension("2", "Force 2. Block write will always write two words at a time")] ForceTwo,
  }
}
