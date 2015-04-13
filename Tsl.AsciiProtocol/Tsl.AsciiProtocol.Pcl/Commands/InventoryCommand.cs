// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.InventoryCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// ASCII commnad to perform an inventory
  /// 
  /// </summary>
  public class InventoryCommand : QuerySelectTransponderCommandBase, IAntennaParameters, ICommandParameters, IQAlgorithmParameters, IQueryParameters, IResponseParameters, ISelectParameters, ITransponderParameters
  {
    /// <summary>
    /// Parameter for QAlgrotihmn
    /// 
    /// </summary>
    private IParameterAndValue<QAlgorithm?> algorithm;
    /// <summary>
    /// Parameter for fast indenitier
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> fastIdentifier;
    /// <summary>
    /// Parameter for tag focus
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> tagFocus;

    /// <summary>
    /// Gets or sets the Q algorithm type
    /// 
    /// </summary>
    [Category("Parameters Q Algorithm")]
    [DefaultValue(null)]
    [Description("Specifies the algorithm used to inventory the transponders")]
    public QAlgorithm? QAlgorithm
    {
      get
      {
        return this.algorithm.Value;
      }
      set
      {
        this.algorithm.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the Impinj fast ID extension is enabled
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Description("Enables or disables the Impinj Fast-ID extension. When enabled transponders which support this feature will return their TID as part of their inventory response")]
    [Category("Parameters")]
    public TriState? FastIdentifier
    {
      get
      {
        return this.fastIdentifier.Value;
      }
      set
      {
        this.fastIdentifier.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the Impinj extension Tag Focus is enabled
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Description("Enables or disables the Impinj Tag Focus extension. Only effective when enabled and query select is session 1 and query target is A and if supported by the transponder")]
    [Category("Parameters Q Algorithm")]
    public TriState? TagFocus
    {
      get
      {
        return this.tagFocus.Value;
      }
      set
      {
        this.tagFocus.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the InventoryCommand class
    /// 
    /// </summary>
    public InventoryCommand()
      : base(".iv")
    {
      this.Parameters.Add((ICommandParameter) (this.algorithm = (IParameterAndValue<QAlgorithm?>) new ParameterEnum<QAlgorithm>("qa")));
      this.Parameters.Add((ICommandParameter) (this.fastIdentifier = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("fi")));
      this.Parameters.Add((ICommandParameter) (this.tagFocus = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("tf")));
      this.Parameters.Reset();
    }
  }
}
