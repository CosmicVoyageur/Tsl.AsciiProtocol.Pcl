// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ITransponderParameters
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Parameters related to the Transponder information in command responses
  /// 
  /// </summary>
  /// <seealso cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.TransponderParameterCollection"/>
  public interface ITransponderParameters
  {
    /// <summary>
    /// Gets or sets a value indicating whether to include checksum information in reader responses
    /// 
    /// </summary>
    TriState? IncludeChecksum { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to include index numbers for multiple values in reader responses
    /// 
    /// </summary>
    TriState? IncludeIndex { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to include the EPC PC value in reader responses
    /// 
    /// </summary>
    TriState? IncludePC { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to include RSSI value in reader responses
    /// 
    /// </summary>
    TriState? IncludeTransponderRssi { get; set; }
  }
}
