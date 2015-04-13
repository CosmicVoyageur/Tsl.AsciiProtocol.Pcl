// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.TransponderData
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Text;

namespace PortableAscii2
{
  /// <summary>
  /// Represents a transponder response from an Inventory, read or write command
  /// 
  /// </summary>
  public class TransponderData
  {
    /// <summary>
    /// Gets the CRC part of an inventory response from a transponder
    ///             or null (Nothing in Visual Basic) if CRC output is not enabled
    /// 
    /// </summary>
    public int? Crc { get; private set; }

    /// <summary>
    /// Gets the EPC part of an inventory response from a transponder
    /// 
    /// </summary>
    public string Epc { get; private set; }

    /// <summary>
    /// Gets the Index of the transponder or null (Nothing in Visual Basic) if index output ("IX:") is not enabled
    /// 
    /// </summary>
    public int? Index { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the transponder was killed successfully
    /// 
    /// </summary>
    public bool IsKillSuccess { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the transponder was locked successfully
    /// 
    /// </summary>
    public bool IsLockSuccess { get; private set; }

    /// <summary>
    /// Gets the PC part of an inventory response from a transponder
    ///             or null (Nothing in Visual Basic) if PC output is not enabled
    /// 
    /// </summary>
    public int? Pc { get; private set; }

    /// <summary>
    /// Gets the data read from the transponder (only applicable when raise from read commands)
    /// 
    /// </summary>
    public string ReadData { get; private set; }

    /// <summary>
    /// Gets the RSSI of a transponder in an inventory response
    ///             or null (Nothing in Visual Basic) if RSSI output is not enabled
    /// 
    /// </summary>
    public int? Rssi { get; private set; }

    /// <summary>
    /// Gets the timestamp the transponder was read. This is the DT field if present of DateTime.MinValue if not available
    /// 
    /// </summary>
    public DateTime Timestamp { get; private set; }

    /// <summary>
    /// Gets the error code specified by the reader why the tag access operation on this transponder failed
    /// 
    /// </summary>
    public TransponderAccessErrorCode? TransponderAccessErrorCode { get; private set; }

    /// <summary>
    /// Gets the error code specified by the transponder why the tag access operation on this transponder failed
    /// 
    /// </summary>
    public TransponderBackscatterErrorCode? TransponderBackscatterErrorCode { get; private set; }

    /// <summary>
    /// Gets the transponder identifier reported as part of an inventory response when using Fast ID in the Impinj extensions
    /// 
    /// </summary>
    public string TransponderIdentifier { get; private set; }

    /// <summary>
    /// Gets the number of words written to the transponder (only applicable when raised from write commands)
    /// 
    /// </summary>
    public int? WordsWritten { get; private set; }

    /// <summary>
    /// Initializes a new instance of the TransponderData class
    /// 
    /// </summary>
    /// <param name="crc">The Crc value</param><param name="epc">The Epc value</param><param name="index">The Index value</param><param name="killed">True if the transponder was killed</param><param name="locked">True if the transponder was locked</param><param name="pc">The Pc value</param><param name="readData">The ReadData value</param><param name="rssi">The Rssi value</param><param name="transponderIdentifier">The transponder identifier reported as part of an Impinj Fast ID inventory response</param><param name="wordsWritten">The WordsWritten value</param>
    public TransponderData(int? crc, string epc, int? index, bool killed, bool locked, int? pc, string readData, int? rssi, string transponderIdentifier, int? wordsWritten)
      : this(crc, epc, index, killed, locked, pc, readData, rssi, DateTime.MinValue, new TransponderAccessErrorCode?(), new TransponderBackscatterErrorCode?(), transponderIdentifier, wordsWritten)
    {
    }

    /// <summary>
    /// Initializes a new instance of the TransponderData class
    /// 
    /// </summary>
    /// <param name="crc">The Crc value</param><param name="epc">The Epc value</param><param name="index">The Index value</param><param name="killed">True if the transponder was killed</param><param name="locked">True if the transponder was locked</param><param name="pc">The Pc value</param><param name="readData">The ReadData value</param><param name="rssi">The Rssi value</param><param name="timestamp">The timestamp the transponder was returned</param><param name="transponderAccessErrorCode">The error code returned from the reader why the transponder access failed</param><param name="transponderBackscatterErrorCode">The error code returned from the transponder why the transponder access failed</param><param name="transponderIdentifier">The transponder identifier reported as part of an Impinj Fast ID inventory response</param><param name="wordsWritten">The WordsWritten value</param>
    public TransponderData(int? crc, string epc, int? index, bool killed, bool locked, int? pc, string readData, int? rssi, DateTime timestamp, TransponderAccessErrorCode? transponderAccessErrorCode, TransponderBackscatterErrorCode? transponderBackscatterErrorCode, string transponderIdentifier, int? wordsWritten)
    {
      this.Crc = crc;
      this.Epc = epc;
      this.Index = index;
      this.IsKillSuccess = killed;
      this.IsLockSuccess = locked;
      this.Pc = pc;
      this.ReadData = readData;
      this.Rssi = rssi;
      this.Timestamp = timestamp;
      this.TransponderAccessErrorCode = transponderAccessErrorCode;
      this.TransponderBackscatterErrorCode = transponderBackscatterErrorCode;
      this.TransponderIdentifier = transponderIdentifier;
      this.WordsWritten = wordsWritten;
    }

    /// <summary>
    /// Appends the values of each property to the builder with an appropriate header if the property has a value
    /// 
    /// </summary>
    /// <param name="builder">The StringBuilder to append to</param>
    /// <returns>
    /// The builder instance
    /// </returns>
    public StringBuilder AppendTo(StringBuilder builder)
    {
      if (this.Pc.HasValue)
        builder.AppendFormat(" PC: {0:X4}", (object) this.Pc.Value);
      if (!string.IsNullOrEmpty(this.Epc))
        builder.AppendFormat(" EPC: {0}", (object) this.Epc);
      if (this.Crc.HasValue)
        builder.AppendFormat(" CRC: {0:X4}", (object) this.Crc.Value);
      if (this.Index.HasValue)
        builder.AppendFormat(" IX: {0:D4}", (object) this.Index.Value);
      if (!string.IsNullOrEmpty(this.ReadData))
        builder.AppendFormat(" Data: {0}", (object) this.ReadData);
      if (this.Rssi.HasValue)
        builder.AppendFormat(" RSSI: {0:D2}dBm", (object) this.Rssi.Value);
      if (this.TransponderAccessErrorCode.HasValue)
        builder.AppendFormat(" AccessError: {0:D3}={1}", (object) this.TransponderAccessErrorCode.Value, (object) EnumExtensions.Description((Enum) (ValueType) this.TransponderAccessErrorCode));
      if (this.TransponderBackscatterErrorCode.HasValue)
        builder.AppendFormat(" BackscatterError: {0:D3}={1}", (object) this.TransponderBackscatterErrorCode.Value, (object) EnumExtensions.Description((Enum) (ValueType) this.TransponderBackscatterErrorCode));
      if (!string.IsNullOrEmpty(this.TransponderIdentifier))
        builder.AppendFormat(" TID: {0}", (object) this.TransponderIdentifier);
      if (this.WordsWritten.HasValue)
        builder.AppendFormat(" Words Written: {0}", (object) this.WordsWritten);
      if (!DateTime.MinValue.Equals(this.Timestamp))
        builder.AppendFormat(" Timestamp: {0:s}", (object) this.Timestamp);
      return builder;
    }

    /// <summary>
    /// Returns a string representation of this instance using <see cref="M:PortableAscii2.TransponderData.AppendTo(System.Text.StringBuilder)"/>
    /// </summary>
    /// 
    /// <returns>
    /// A string representation of this instance
    /// </returns>
    public override string ToString()
    {
      return this.AppendTo(new StringBuilder()).ToString();
    }
  }
}
