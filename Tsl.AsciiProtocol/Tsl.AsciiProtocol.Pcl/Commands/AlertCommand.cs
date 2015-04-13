// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.AlertCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// An alert command to send to the reader to sound an alert and/or update the alert settings
  /// 
  /// </summary>
  public class AlertCommand : ActionCommandBase
  {
    /// <summary>
    /// The alert duration parameter
    /// 
    /// </summary>
    private IParameterAndValue<AlertDuration?> alertDuration;
    /// <summary>
    /// The buzzer tone parameter
    /// 
    /// </summary>
    private IParameterAndValue<BuzzerTone?> buzzerTone;
    /// <summary>
    /// The vibrate enabled parameter
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> vibrateEnabled;
    /// <summary>
    /// The buzzer enabled parameter
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> buzzerEnabled;

    /// <summary>
    /// Gets or sets the alert duration
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters")]
    [Description("The duration of the alert")]
    public AlertDuration? AlertDuration
    {
      get
      {
        return this.alertDuration.Value;
      }
      set
      {
        this.alertDuration.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the buzzer tone
    /// 
    /// </summary>
    [Category("Parameters")]
    [DefaultValue(null)]
    [Description("The tone of the buzzer")]
    public BuzzerTone? BuzzerTone
    {
      get
      {
        return this.buzzerTone.Value;
      }
      set
      {
        this.buzzerTone.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether buzzer is enabled.
    ///             Set to null (Nothing is Visual Basic) to not affect the current value
    /// 
    /// </summary>
    [Category("Parameters")]
    [Description("Set to true to enable the buzzer, set to false to disable the buzzer, set to null (empty string) to not change the current setting")]
    [DefaultValue(null)]
    public TriState? BuzzerEnabled
    {
      get
      {
        return this.buzzerEnabled.Value;
      }
      set
      {
        this.buzzerEnabled.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether vibrate is enabled.
    ///             Set to null (Nothing is Visual Basic) to not affect the current value
    /// 
    /// </summary>
    [Description("Set to true to enable the vibrate, set to false to disable the vibrate, set to null (empty string) to not change the current setting")]
    [Category("Parameters")]
    [DefaultValue(null)]
    public TriState? VibrateEnabled
    {
      get
      {
        return this.vibrateEnabled.Value;
      }
      set
      {
        this.vibrateEnabled.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the AlertCommand class
    /// 
    /// </summary>
    public AlertCommand()
      : base(".al")
    {
      this.Parameters.Add((ICommandParameter) (this.alertDuration = (IParameterAndValue<AlertDuration?>) new ParameterEnum<AlertDuration>("d")));
      this.Parameters.Add((ICommandParameter) (this.buzzerTone = (IParameterAndValue<BuzzerTone?>) new ParameterEnum<BuzzerTone>("t")));
      this.Parameters.Add((ICommandParameter) (this.vibrateEnabled = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("v")));
      this.Parameters.Add((ICommandParameter) (this.buzzerEnabled = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("b")));
      this.Parameters.Reset();
      AsciiResponseExtensions.AddHeaders(this.Response, "CS: ER: ME: OK: PR:");
    }
  }
}
