// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.TransponderParameterCollection
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace Tsl.AsciiProtocol.Pcl.Parameters
{
  /// <summary>
  /// Helper class for implementing <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.ITransponderParameters"/>
  /// </summary>
  public class TransponderParameterCollection : ParameterCollection, ITransponderParameters
  {
    /// <summary>
    /// Backing field for IncludeChecksum
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> includeChecksum;
    /// <summary>
    /// Backing field for IncludeIndex
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> includeIndex;
    /// <summary>
    /// Backing field for IncludePC
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> includePc;
    /// <summary>
    /// Backing field for IncludeTransponderRssi
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> includeTransponderRssi;

    /// <summary>
    /// Gets or sets a value indicating whether to include the checksum for transponder responses
    /// 
    /// </summary>
    public TriState? IncludeChecksum
    {
      get
      {
        return this.includeChecksum.Value;
      }
      set
      {
        this.includeChecksum.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to include the index for transponder responses
    /// 
    /// </summary>
    public TriState? IncludeIndex
    {
      get
      {
        return this.includeIndex.Value;
      }
      set
      {
        this.includeIndex.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value imdicating whether to include the PC for transponder responses
    /// 
    /// </summary>
    public TriState? IncludePC
    {
      get
      {
        return this.includePc.Value;
      }
      set
      {
        this.includePc.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to include transponder RSSI for transponder responses
    /// 
    /// </summary>
    public TriState? IncludeTransponderRssi
    {
      get
      {
        return this.includeTransponderRssi.Value;
      }
      set
      {
        this.includeTransponderRssi.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the TransponderParameterCollection class
    /// 
    /// </summary>
    public TransponderParameterCollection()
    {
      this.Add((ICommandParameter) (this.includeChecksum = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("c")));
      this.Add((ICommandParameter) (this.includeIndex = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("ix")));
      this.Add((ICommandParameter) (this.includePc = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("e")));
      this.Add((ICommandParameter) (this.includeTransponderRssi = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("r")));
    }
  }
}
