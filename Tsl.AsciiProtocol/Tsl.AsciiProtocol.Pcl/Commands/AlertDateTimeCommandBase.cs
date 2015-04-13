// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.AlertDateTimeCommandBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// Base class for commands that support -n -p -x -al -dt
  /// 
  /// </summary>
  public abstract class AlertDateTimeCommandBase : ActionCommandBase, IResponseParameters
  {
    /// <summary>
    /// Gets a value indicating whether the alert is sounded when a barcode is read
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> performAlert;
    /// <summary>
    /// Gets a value indicating whether the date and time is included in the response when a barcode is read
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> includeDateTime;

    /// <summary>
    /// Gets or sets a value indicating whether the alert is sounded when a barcode is read.
    ///             Set to null to not change the value
    /// 
    /// </summary>
    [Description("When set to true performs an alert as the command completes successfully. When false does not. If null the current setting is unchanged")]
    [Category("Parameters Response")]
    [DefaultValue(null)]
    public TriState? UseAlert
    {
      get
      {
        return this.performAlert.Value;
      }
      set
      {
        if (value.HasValue && !this.IsAlertSupported)
          throw new NotSupportedException("UseAlert is not supported for this command");
        this.performAlert.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the date and time is included in the response when a barcode is read
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters Response")]
    [Description("When set to true performs includes a timestamp for each item in the response. When false does not. If null the current setting is unchanged")]
    public TriState? IncludeDateTime
    {
      get
      {
        return this.includeDateTime.Value;
      }
      set
      {
        this.includeDateTime.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the <see cref="P:PortableAscii2.Commands.AlertDateTimeCommandBase.UseAlert"/> property is supported for this command
    /// 
    /// </summary>
    protected bool IsAlertSupported { get; set; }

    /// <summary>
    /// Initializes a new instance of the AlertDateTimeCommandBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name</param>
    protected AlertDateTimeCommandBase(string commandName)
      : base(commandName)
    {
      this.Parameters.Add((ICommandParameter) (this.performAlert = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("al")));
      this.Parameters.Add((ICommandParameter) (this.includeDateTime = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("dt")));
      this.IsAlertSupported = true;
    }
  }
}
