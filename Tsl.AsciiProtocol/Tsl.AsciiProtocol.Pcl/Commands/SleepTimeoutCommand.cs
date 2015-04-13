// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.SleepTimeoutCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// Sets the timeout before the reader sleeps if there are no connections to the reader
  /// 
  /// </summary>
  public class SleepTimeoutCommand : ParameterCommandBase
  {
    /// <summary>
    /// The sleep timeout parameter
    /// 
    /// </summary>
    private IParameterAndValue<int?> duration;

    /// <summary>
    /// Gets or sets the sleep timeout in seconds (15 .. 999) after a disconnect when the reader will sleep
    /// 
    /// </summary>
    [Category("Parameters")]
    [Description("The duration in seconds (15 .. 999) before the reader will sleep after a connection is dropped")]
    [DefaultValue(null)]
    public int? SleepTimeout
    {
      get
      {
        return this.duration.Value;
      }
      set
      {
        this.duration.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the SleepTimeoutCommand class
    /// 
    /// </summary>
    public SleepTimeoutCommand()
      : base(".st")
    {
      this.Parameters.Add((ICommandParameter) (this.duration = (IParameterAndValue<int?>) new ParameterInt("t", 15, 999)));
      this.Parameters.Reset();
    }
  }
}
