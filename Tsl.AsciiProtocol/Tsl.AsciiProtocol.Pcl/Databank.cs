// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Databank
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.Diagnostics.CodeAnalysis;

namespace PortableAscii2
{
  /// <summary>
  /// Sepcify the databank to use in <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.IDatabankParameters"/>
  /// </summary>
  /// 
  /// <remarks>
  /// select( TSL_DataBank_NotSpecified = 0,        @"",        @"Not specified"            )\
  ///             select( TSL_DataBank_ElectronicProductCode,   @"epc",     @"Electronic Product Code"  )\
  ///             select( TSL_DataBank_TransponderIdentifier,   @"tid",     @"Transponder Identifier"   )\
  ///             select( TSL_DataBank_User,                    @"usr",     @"User"                     )\
  ///             select( TSL_DataBank_Reserved,                @"res",     @"Reserved"                 )
  /// 
  /// </remarks>
  public enum Databank
  {
    [EnumExtension("epc", "Electronic Product Code")] ElectronicProductCode,
    [EnumExtension("tid", "Transponder Identifier")] TransponderIdentifier,
    [EnumExtension("usr", "User")] User,
    [SuppressMessage("Microsoft.Naming", "CA1700:DoNotNameEnumValuesReserved", Justification = "Memory bank is named reserved it is not reserved for future use"), EnumExtension("res", "Reserved")] Reserved,
  }
}
