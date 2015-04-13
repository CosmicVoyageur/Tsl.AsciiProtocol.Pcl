// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.IDatabankParameters
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Parameters related to Data Banks in commands and responses
  /// 
  /// </summary>
  /// <seealso cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.DatabankParameterCollection"/>
  public interface IDatabankParameters
  {
    /// <summary>
    /// Gets or sets the transponder data bank to be used
    /// 
    /// </summary>
    Databank? Bank { get; set; }

    /// <summary>
    /// Gets or sets the length in words of the data to write
    /// 
    /// </summary>
    int? Length { get; set; }

    /// <summary>
    /// Gets or sets the offset, in 16 bit words, from the start of the memory bank to where the data will be written
    /// 
    /// </summary>
    int? Offset { get; set; }
  }
}
