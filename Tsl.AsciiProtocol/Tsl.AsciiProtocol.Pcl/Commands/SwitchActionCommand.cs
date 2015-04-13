// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.SwitchActionCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// A command to set the action of the reader's switch
  /// 
  /// </summary>
  public class SwitchActionCommand : ParameterCommandBase
  {
    /// <summary>
    /// The single press parameter
    /// 
    /// </summary>
    private IParameterAndValue<SwitchAction?> singlePressAction;
    /// <summary>
    /// The double press parameter
    /// 
    /// </summary>
    private IParameterAndValue<SwitchAction?> doublePressAction;
    /// <summary>
    /// The report switch action parameter
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> reportingEnabled;
    /// <summary>
    /// Backing field for DoublePressRepeatDelay
    /// 
    /// </summary>
    private IParameterAndValue<int?> doublePressRepeatDelay;
    /// <summary>
    /// Backing field for SinglePressRepeatDelay
    /// 
    /// </summary>
    private IParameterAndValue<int?> singlePressRepeatDelay;

    /// <summary>
    /// Gets or sets a value indicating whether asynchronous switch status reports should be reported.
    ///             When set to NotSpecified the asynchronous reporting state is unchanged.
    ///             If readParameters is specified then after execution this property will reflect the current state
    /// 
    /// </summary>
    [Description("When set to true notifications are sent to the host for changes in the switch state")]
    [Category("Parameters")]
    [DefaultValue(null)]
    public TriState? AsynchronousReportingEnabled
    {
      get
      {
        return this.reportingEnabled.Value;
      }
      set
      {
        this.reportingEnabled.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the aciotn to perform for a single press of trigger
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters")]
    [Description("The action performed when the switch is in single press")]
    public SwitchAction? SinglePressAction
    {
      get
      {
        return this.singlePressAction.Value;
      }
      set
      {
        this.singlePressAction.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the aciotn to perform for a double press of trigger
    /// 
    /// </summary>
    [Description("The action performed when the switch is in double press")]
    [DefaultValue(null)]
    [Category("Parameters")]
    public SwitchAction? DoublePressAction
    {
      get
      {
        return this.doublePressAction.Value;
      }
      set
      {
        this.doublePressAction.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the delay in milliseconds before the double press switch action is repeated (1 to 999 ms)
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Added for ASCII Protocol v2.2 and higher
    /// 
    /// </remarks>
    public int? DoublePressRepeatDelay
    {
      get
      {
        return this.doublePressRepeatDelay.Value;
      }
      set
      {
        this.doublePressRepeatDelay.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the delay in milliseconds before the single press switch action is repeated (1 to 999 ms)
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Added for ASCII Protocol v2.2 and higher
    /// 
    /// </remarks>
    public int? SinglePressRepeatDelay
    {
      get
      {
        return this.singlePressRepeatDelay.Value;
      }
      set
      {
        this.singlePressRepeatDelay.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the SwitchActionCommand class
    /// 
    /// </summary>
    public SwitchActionCommand()
      : base(".sa")
    {
      this.Parameters.Add((ICommandParameter) (this.doublePressAction = (IParameterAndValue<SwitchAction?>) new ParameterEnum<SwitchAction>("d")));
      this.Parameters.Add((ICommandParameter) (this.reportingEnabled = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("a")));
      this.Parameters.Add((ICommandParameter) (this.singlePressAction = (IParameterAndValue<SwitchAction?>) new ParameterEnum<SwitchAction>("s")));
      this.Parameters.Add((ICommandParameter) (this.doublePressRepeatDelay = (IParameterAndValue<int?>) new ParameterInt("rd", 1, 999)));
      this.Parameters.Add((ICommandParameter) (this.singlePressRepeatDelay = (IParameterAndValue<int?>) new ParameterInt("rs", 1, 999)));
      this.Parameters.Reset();
    }
  }
}
