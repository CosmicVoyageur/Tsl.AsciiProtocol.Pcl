// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.SelectAction
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2
{
  /// <summary>
  /// Specifies the action to perform on an inventoried transponder in <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.ISelectParameters"/>
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
  public enum SelectAction
  {
    [EnumExtension("0", "Match: Assert Select / Set Session A  Non Match: Deassert Select / Set Session B")] AssertSetANotDeassertSetB,
    [EnumExtension("1", "Match: Assert Select / Set Session A  Non Match: Nothing / Nothing")] AssertSetANotNothingNothing,
    [EnumExtension("2", "Match: Nothing / Nothing  Non Match: Deassert Select / Set Session B")] NothingNothingNotDeassertSetB,
    [EnumExtension("3", "Match: Toggle / Toggle  Non Match: Nothing / Nothing")] ToggleToggleNotNothingNothing,
    [EnumExtension("4", "Match: Deassert Select / Set Session B  Non Match: Assert Select / Set Session A")] DeassertSetBNotAssertSetA,
    [EnumExtension("5", "Match: Deassert Select / Set Session B  Non Match: Nothing / Nothing")] DeassertSetBNotNothingNothing,
    [EnumExtension("6", "Match: Nothing / Nothing  Non Match: Assert Select / Set Session A")] NothingNothingNotAssertSetA,
    [EnumExtension("7", "Match: Nothing / Nothing  Non Match: Toggle / Toggle")] NothingNothingNotToggleToggle,
  }
}
