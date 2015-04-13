// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.QuerySelectTransponderCommandBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.Collections.Generic;
using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// Base class for commands that query and select transponders
  /// 
  /// </summary>
  public abstract class QuerySelectTransponderCommandBase : TranspondersCommandBase, IAntennaParameters, ICommandParameters, IQueryParameters, IResponseParameters, ISelectParameters, ITransponderParameters
  {
    /// <summary>
    /// Holds the select parameters
    /// 
    /// </summary>
    private SelectParameterCollection selectParameters;
    /// <summary>
    /// Parameter for Q value
    /// 
    /// </summary>
    private IParameterAndValue<int?> valueOfQ;
    /// <summary>
    /// Parameter for query select
    /// 
    /// </summary>
    private IParameterAndValue<QuerySelect?> querySelect;
    /// <summary>
    /// Parameter for query session
    /// 
    /// </summary>
    private IParameterAndValue<QuerySession?> querySession;
    /// <summary>
    /// Parameter for query target
    /// 
    /// </summary>
    private IParameterAndValue<QueryTarget?> queryTarget;

    /// <summary>
    /// Gets or sets the Q value for fixed Q operations (0-15)
    /// 
    /// </summary>
    [Description("Specifies the initial (for dynamic) or value (for fixed) of Q for the algorithm")]
    [Category("Parameters Q Algorithm")]
    [DefaultValue(7)]
    public int? QValue
    {
      get
      {
        return this.valueOfQ.Value;
      }
      set
      {
        this.valueOfQ.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the transponders to include based on the select flag state
    /// 
    /// </summary>
    [Description("Specifies the selected state of the transponders to return")]
    [DefaultValue(null)]
    [Category("Parameters Query")]
    public QuerySelect? QuerySelect
    {
      get
      {
        return this.querySelect.Value;
      }
      set
      {
        this.querySelect.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the transponders to include based on the select flag state
    /// 
    /// </summary>
    [Description("Specifies the session to match the QueryTraget to for the transponders to return")]
    [Category("Parameters Query")]
    [DefaultValue(null)]
    public QuerySession? QuerySession
    {
      get
      {
        return this.querySession.Value;
      }
      set
      {
        this.querySession.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the session state of the transponders to be included in this operation
    /// 
    /// </summary>
    [Category("Parameters Query")]
    [DefaultValue(null)]
    [Description("Specifies the session state of the transponders to return")]
    public QueryTarget? QueryTarget
    {
      get
      {
        return this.queryTarget.Value;
      }
      set
      {
        this.queryTarget.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether only the inventory is performed (the select operation is not performed before the inventory when set to Yes)
    /// 
    /// </summary>
    [Category("Parameters Select")]
    [DefaultValue(null)]
    [Description("a value indicating whether only the inventory is performed (the select operation is not performed before the inventory when set to Yes)")]
    public TriState? InventoryOnly
    {
      get
      {
        return this.selectParameters.InventoryOnly;
      }
      set
      {
        this.selectParameters.InventoryOnly = value;
      }
    }

    /// <summary>
    /// Gets or sets the action to perform in the Select operation
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters Select")]
    [Description("the action to perform in the Select operation")]
    public SelectAction? SelectAction
    {
      get
      {
        return this.selectParameters.SelectAction;
      }
      set
      {
        this.selectParameters.SelectAction = value;
      }
    }

    /// <summary>
    /// Gets or sets the Bank to use for the select mask
    /// 
    /// </summary>
    [Description("the Bank to use for the select mask")]
    [DefaultValue(null)]
    [Category("Parameters Select")]
    public Databank? SelectBank
    {
      get
      {
        return this.selectParameters.SelectBank;
      }
      set
      {
        this.selectParameters.SelectBank = value;
      }
    }

    /// <summary>
    /// Gets or sets the select mask data in 2 character ASCII Hex pairs padded to ensure full bytes
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters Select")]
    [Description("the select mask data in 2 character ASCII Hex pairs padded to ensure full bytes")]
    public string SelectData
    {
      get
      {
        return this.selectParameters.SelectData;
      }
      set
      {
        this.selectParameters.SelectData = value;
      }
    }

    /// <summary>
    /// Gets or sets the length in bits of the select mask
    /// 
    /// </summary>
    [Description("the length in bits of the select mask")]
    [Category("Parameters Select")]
    [DefaultValue(null)]
    public int? SelectLength
    {
      get
      {
        return this.selectParameters.SelectLength;
      }
      set
      {
        this.selectParameters.SelectLength = value;
      }
    }

    /// <summary>
    /// Gets or sets the number of bits from the start of the block to the start of the select mask
    /// 
    /// </summary>
    [Category("Parameters Select")]
    [Description("the number of bits from the start of the block to the start of the select mask")]
    [DefaultValue(null)]
    public int? SelectOffset
    {
      get
      {
        return this.selectParameters.SelectOffset;
      }
      set
      {
        this.selectParameters.SelectOffset = value;
      }
    }

    /// <summary>
    /// Gets or sets the target flag for the Select operation
    /// 
    /// </summary>
    [Description("the target flag for the Select operation")]
    [DefaultValue(null)]
    [Category("Parameters Select")]
    public SelectTarget? SelectTarget
    {
      get
      {
        return this.selectParameters.SelectTarget;
      }
      set
      {
        this.selectParameters.SelectTarget = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the QuerySelectTransponderCommandBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name (e.g. ".iv" for inventory)</param>
    protected QuerySelectTransponderCommandBase(string commandName)
      : base(commandName)
    {
      this.Parameters.Add((ICommandParameter) (this.valueOfQ = (IParameterAndValue<int?>) new ParameterInt("qv", 0, 15)));
      this.Parameters.Add((ICommandParameter) (this.querySelect = (IParameterAndValue<QuerySelect?>) new ParameterEnum<QuerySelect>("ql")));
      this.Parameters.Add((ICommandParameter) (this.querySession = (IParameterAndValue<QuerySession?>) new ParameterEnum<QuerySession>("qs")));
      this.Parameters.Add((ICommandParameter) (this.queryTarget = (IParameterAndValue<QueryTarget?>) new ParameterEnum<QueryTarget>("qt")));
      this.Parameters.AddRange((IEnumerable<ICommandParameter>) (this.selectParameters = new SelectParameterCollection()));
      this.Parameters.Reset();
    }
  }
}
