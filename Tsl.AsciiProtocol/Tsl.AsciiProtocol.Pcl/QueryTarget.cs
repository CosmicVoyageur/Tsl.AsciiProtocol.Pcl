// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.QueryTarget
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// Specifies the query target in <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.IQueryParameters"/>
  /// </summary>
  /// 
  /// <remarks>
  /// select( TSL_QueryTarget_NotSpecified = 0,  @"",      @"Not specified"     )\
  ///             select( TSL_QueryTarget_A,                 @"a",     @"A"         )\
  ///             select( TSL_QueryTarget_B,                 @"b",     @"B"         )
  /// 
  /// </remarks>
  public enum QueryTarget
  {
    [EnumExtension("a", "A")] TargetA,
    [EnumExtension("b", "B")] TargetB,
  }
}
