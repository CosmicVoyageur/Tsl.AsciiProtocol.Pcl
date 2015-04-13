// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.TransponderAccessErrorCode
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// Codes returned from the reader when a transponder access operation fails (Header = "EA")
  /// 
  /// </summary>
  public enum TransponderAccessErrorCode
  {
    [EnumExtension("001", "Handle mismatch")] HandleMismatch = 1,
    [EnumExtension("002", "CRC error on transponder response.")] CrcErrorOnTransponderResponse = 2,
    [EnumExtension("003", "No transponder reply.")] NoTransponderReply = 3,
    [EnumExtension("004", "Invalid password.")] InvalidPassword = 4,
    [EnumExtension("005", "Zero kill password.")] ZeroKillPassword = 5,
    [EnumExtension("006", "Transponder lost.")] TransponderLost = 6,
    [EnumExtension("007", "Command format error.")] CommandFormatError = 7,
    [EnumExtension("008", "Read count invalid.")] ReadCountInvalid = 8,
    [EnumExtension("009", "Out of retries.")] OutOfRetries = 9,
    [EnumExtension("255", "Operation failed.")] OperationFailed = 255,
  }
}
