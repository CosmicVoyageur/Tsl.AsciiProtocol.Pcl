// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.DatabankParameterCollection
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Implements <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.IDatabankParameters"/> and can be used by a command to provide the values with range checking
  /// 
  /// </summary>
  public class DatabankParameterCollection : ParameterCollection, IDatabankParameters
  {
    /// <summary>
    /// Backing field for Bank
    /// 
    /// </summary>
    private IParameterAndValue<Databank?> bank;
    /// <summary>
    /// Backing field for Length
    /// 
    /// </summary>
    private IParameterAndValue<int?> length;
    /// <summary>
    /// Backing field for Offset
    /// 
    /// </summary>
    private IParameterAndValue<int?> offset;

    /// <summary>
    /// Gets or sets the transponder data bank to be used
    /// 
    /// </summary>
    public Databank? Bank
    {
      get
      {
        return this.bank.Value;
      }
      set
      {
        this.bank.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the length in words of the data to write
    /// 
    /// </summary>
    public int? Length
    {
      get
      {
        return this.length.Value;
      }
      set
      {
        this.length.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the offset, in 16 bit words, from the start of the memory bank to where the data will be written
    /// 
    /// </summary>
    public int? Offset
    {
      get
      {
        return this.offset.Value;
      }
      set
      {
        this.offset.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the DatabankParameterCollection class
    /// 
    /// </summary>
    public DatabankParameterCollection()
    {
      this.Add((ICommandParameter) (this.bank = (IParameterAndValue<Databank?>) new ParameterEnum<Databank>("db")));
      this.Add((ICommandParameter) (this.length = (IParameterAndValue<int?>) new ParameterInt("dl", "X2")));
      this.Add((ICommandParameter) (this.offset = (IParameterAndValue<int?>) new ParameterInt("do", "X4")));
    }
  }
}
