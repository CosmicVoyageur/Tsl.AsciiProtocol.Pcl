// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.SelectParameterCollection
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Helper class for implementing <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.ISelectParameters"/>
  /// </summary>
  public class SelectParameterCollection : ParameterCollection, ISelectParameters
  {
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.SelectParameterCollection.InventoryOnly"/>
    /// </summary>
    private IParameterAndValue<TriState?> inventoryOnly;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.SelectParameterCollection.SelectAction"/>
    /// </summary>
    private IParameterAndValue<SelectAction?> selectAction;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.SelectParameterCollection.SelectBank"/>
    /// </summary>
    private IParameterAndValue<Databank?> selectBank;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.SelectParameterCollection.SelectData"/>
    /// </summary>
    private IParameterAndValue<string> selectData;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.SelectParameterCollection.SelectLength"/>
    /// </summary>
    private IParameterAndValue<int?> selectLength;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.SelectParameterCollection.SelectOffset"/>
    /// </summary>
    private IParameterAndValue<int?> selectOffset;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.SelectParameterCollection.SelectTarget"/>
    /// </summary>
    private IParameterAndValue<SelectTarget?> selectTarget;

    /// <summary>
    /// Gets or sets a value indicating whether only the inventory should be performed (no select)
    /// 
    /// </summary>
    public TriState? InventoryOnly
    {
      get
      {
        return this.inventoryOnly.Value;
      }
      set
      {
        this.inventoryOnly.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the select action
    /// 
    /// </summary>
    public SelectAction? SelectAction
    {
      get
      {
        return this.selectAction.Value;
      }
      set
      {
        this.selectAction.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the Databank used for the select mask
    /// 
    /// </summary>
    public Databank? SelectBank
    {
      get
      {
        return this.selectBank.Value;
      }
      set
      {
        this.selectBank.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the data used for the select mask
    /// 
    /// </summary>
    public string SelectData
    {
      get
      {
        return this.selectData.Value;
      }
      set
      {
        this.selectData.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the number of bits used in the select mask
    /// 
    /// </summary>
    public int? SelectLength
    {
      get
      {
        return this.selectLength.Value;
      }
      set
      {
        this.selectLength.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the offset in bits into the Databank to compare to the select mask
    /// 
    /// </summary>
    public int? SelectOffset
    {
      get
      {
        return this.selectOffset.Value;
      }
      set
      {
        this.selectOffset.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the select target
    /// 
    /// </summary>
    public SelectTarget? SelectTarget
    {
      get
      {
        return this.selectTarget.Value;
      }
      set
      {
        this.selectTarget.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the SelectParameterCollection class
    /// 
    /// </summary>
    public SelectParameterCollection()
    {
      this.Add((ICommandParameter) (this.inventoryOnly = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("io")));
      this.Add((ICommandParameter) (this.selectAction = (IParameterAndValue<SelectAction?>) new ParameterEnum<SelectAction>("sa")));
      this.Add((ICommandParameter) (this.selectBank = (IParameterAndValue<Databank?>) new ParameterEnum<Databank>("sb")));
      this.Add((ICommandParameter) (this.selectData = (IParameterAndValue<string>) new ParameterHex("sd", 0, 64)));
      this.Add((ICommandParameter) (this.selectLength = (IParameterAndValue<int?>) new ParameterInt("sl", "X2")));
      this.Add((ICommandParameter) (this.selectOffset = (IParameterAndValue<int?>) new ParameterInt("so", "X4")));
      this.Add((ICommandParameter) (this.selectTarget = (IParameterAndValue<SelectTarget?>) new ParameterEnum<SelectTarget>("st")));
    }
  }
}
