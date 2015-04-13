// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.SelectTarget
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2
{
  /// <summary>
  /// Specifies the session to target in <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.ISelectParameters"/>
  /// </summary>
  /// 
  /// <remarks>
  /// select( TSL_SelectTarget_NotSpecified = 0,  @"",       @"Not specified"     )\
  ///             select( TSL_SelectTarget_S0,                @"s0",     @"Session 0"         )\
  ///             select( TSL_SelectTarget_S1,                @"s1",     @"Session 1"         )\
  ///             select( TSL_SelectTarget_S2,                @"s2",     @"Session 2"         )\
  ///             select( TSL_SelectTarget_S3,                @"s3",     @"Session 3"         )\
  ///             select( TSL_SelectTarget_SL,                @"sl",     @"Select"            )
  /// 
  /// </remarks>
  public enum SelectTarget
  {
    [EnumExtension("s0", "Session 0")] S0,
    [EnumExtension("s1", "Session 1")] S1,
    [EnumExtension("s2", "Session 2")] S2,
    [EnumExtension("s3", "Session 3")] S3,
    [EnumExtension("sl", "Select")] SL,
  }
}
