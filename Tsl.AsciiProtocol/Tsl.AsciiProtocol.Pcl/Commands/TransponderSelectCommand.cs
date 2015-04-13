// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.TransponderSelectCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// This command is used to set the state of transponders.
  ///             It pushes matching and non-matching transponders in to the state determined by the -sa parameter.
  ///             This command can only be used with persistent target sessions as the carrier will be turned off after the command.
  /// 
  /// </summary>
  public class TransponderSelectCommand : ActionCommandBase, IAntennaParameters
  {
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Commands.TransponderSelectCommand.OutputPower"/>
    /// </summary>
    private IParameterAndValue<int?> antennaParameter;
    /// <summary>
    /// Holds the set of select parameters
    /// 
    /// </summary>
    private SelectParameterCollection selectParameters;

    /// <summary>
    /// Gets or sets the output power
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Valid power range is 10 - 29.
    ///             Use AntennaParameters.OutputPowerNotSpecified to read the output power.
    /// 
    /// </remarks>
    [Description("Specify the output power in dBm (10-29) or null to use the reader's current value")]
    [DefaultValue(null)]
    [Category("Parameters Antenna")]
    public int? OutputPower
    {
      get
      {
        return this.antennaParameter.Value;
      }
      set
      {
        this.antennaParameter.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the action to perform in the Select operation
    /// 
    /// </summary>
    [Category("Parameters Select")]
    [Description("the action to perform in the Select operation")]
    [DefaultValue(null)]
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
    [DefaultValue(null)]
    [Description("the Bank to use for the select mask")]
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
    [Description("the select mask data in 2 character ASCII Hex pairs padded to ensure full bytes")]
    [Category("Parameters Select")]
    [DefaultValue(null)]
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
    [DefaultValue(null)]
    [Category("Parameters Select")]
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
    [DefaultValue(null)]
    [Category("Parameters Select")]
    [Description("the number of bits from the start of the block to the start of the select mask")]
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
    /// Initializes a new instance of the TransponderSelectCommand class
    /// 
    /// </summary>
    public TransponderSelectCommand()
      : base(".ts")
    {
      this.Parameters.Add((ICommandParameter) (this.antennaParameter = (IParameterAndValue<int?>) new ParameterInt("o", 10, 29)));
      this.selectParameters = new SelectParameterCollection();
      this.Parameters.AddRange(Enumerable.Where<ICommandParameter>((IEnumerable<ICommandParameter>) this.selectParameters, (Func<ICommandParameter, bool>) (x => !x.ParameterIdentifier.Equals("io"))));
      this.Parameters.Reset();
    }
  }
}
