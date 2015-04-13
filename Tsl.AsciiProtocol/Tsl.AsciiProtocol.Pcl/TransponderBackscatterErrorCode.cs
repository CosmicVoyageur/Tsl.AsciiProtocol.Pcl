// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.TransponderBackscatterErrorCode
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2
{
  /// <summary>
  /// Codes returned from the transponder when a tag access operation fails
  /// 
  /// </summary>
  public enum TransponderBackscatterErrorCode
  {
    [EnumExtension("000", "General error.")] GeneralError = 0,
    [EnumExtension("003", "Memory does not exist or the PC value is not supported.")] MemoryDoesNotExistOrThePcValueIsNotSupported = 3,
    [EnumExtension("004", "Memory is lock or permalocked.")] MemoryIsLockedOrPermalocked = 4,
    [EnumExtension("011", "Transponder has insufficient power.")] TransponderHasInsufficientPower = 11,
    [EnumExtension("015", "Transponder does not support error specific codes.")] TransponderDoesNotSupportErrorSpecificCodes = 15,
  }
}
