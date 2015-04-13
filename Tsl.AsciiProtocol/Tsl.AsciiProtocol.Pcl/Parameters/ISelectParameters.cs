// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ISelectParameters
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Parameters for Select operations in commands and responses
  /// 
  /// </summary>
  /// <seealso cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.SelectParameterCollection"/>
  public interface ISelectParameters
  {
    /// <summary>
    /// Gets or sets a value indicating whether only the inventory is performed (the select operation is not performed before the inventory when set to Yes)
    /// 
    /// </summary>
    TriState? InventoryOnly { get; set; }

    /// <summary>
    /// Gets or sets the action to perform in the Select operation
    /// 
    /// </summary>
    SelectAction? SelectAction { get; set; }

    /// <summary>
    /// Gets or sets the Bank to use for the select mask
    /// 
    /// </summary>
    Databank? SelectBank { get; set; }

    /// <summary>
    /// Gets or sets the select mask data in 2 character ASCII Hex pairs padded to ensure full bytes
    /// 
    /// </summary>
    string SelectData { get; set; }

    /// <summary>
    /// Gets or sets the length in bits of the select mask
    /// 
    /// </summary>
    int? SelectLength { get; set; }

    /// <summary>
    /// Gets or sets the number of bits from the start of the block to the start of the select mask
    /// 
    /// </summary>
    int? SelectOffset { get; set; }

    /// <summary>
    /// Gets or sets the target flag for the Select operation
    /// 
    /// </summary>
    SelectTarget? SelectTarget { get; set; }
  }
}
