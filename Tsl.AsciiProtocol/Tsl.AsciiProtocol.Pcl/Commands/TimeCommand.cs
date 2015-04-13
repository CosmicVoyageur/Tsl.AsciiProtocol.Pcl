// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.TimeCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.ComponentModel;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// A command to obtain or set the time of the reader's real-time clock
  /// 
  /// </summary>
  public class TimeCommand : AsciiCommandBase
  {
    /// <summary>
    /// The time parameter
    /// 
    /// </summary>
    private IParameterAndValue<DateTime?> time;

    /// <summary>
    /// Gets or sets the time to write to the reader.
    ///             Set to null (Nothing in Visual Basic) to read the current time
    /// 
    /// </summary>
    [Category("Parameters")]
    [DefaultValue(null)]
    [Description("Gets or sets the time to set the radio to or the time read from the radio")]
    public DateTime? Time
    {
      get
      {
        return this.time.Value;
      }
      set
      {
        this.time.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the TimeCommand class
    /// 
    /// </summary>
    public TimeCommand()
      : base(".tm")
    {
      this.Parameters.Add((ICommandParameter) (this.time = (IParameterAndValue<DateTime?>) new ParameterDateTime("s", "HHmmss")));
      this.Parameters.Reset();
      this.Response.ReceivedLine += new EventHandler<AsciiLineEventArgs>(this.Response_ReceivedLine);
    }

    /// <summary>
    /// Captures from the response the date read from the device
    /// 
    /// </summary>
    /// <param name="sender">The event source</param><param name="e">Data provided for the event</param>
    private void Response_ReceivedLine(object sender, AsciiLineEventArgs e)
    {
      if (AsciiResponseExtensions.IsCommandStarted(e.Line))
      {
        this.Time = new DateTime?();
      }
      else
      {
        if (!AsciiResponseExtensions.HasHeader(e.Line, "TM"))
          return;
        this.Time = new DateTime?(DateTime.ParseExact(e.Line.Value, "HH:mm:ss", Constants.CommandFormatProvider));
        e.Handled = true;
      }
    }
  }
}
