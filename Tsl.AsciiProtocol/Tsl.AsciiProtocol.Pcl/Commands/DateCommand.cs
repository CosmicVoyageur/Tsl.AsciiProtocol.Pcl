// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.DateCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.ComponentModel;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// A command to obtain or set the date of the reader's real time clock
  /// 
  /// </summary>
  public class DateCommand : AsciiCommandBase
  {
    /// <summary>
    /// The date parameter
    /// 
    /// </summary>
    private IParameterAndValue<DateTime?> date;

    /// <summary>
    /// Gets or sets the date to read or write (time is ignored)
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters")]
    [Description("Gets or sets the date to set the radio to or the date read from the radio")]
    public DateTime? Date
    {
      get
      {
        return this.date.Value;
      }
      set
      {
        this.date.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the DateCommand class
    /// 
    /// </summary>
    public DateCommand()
      : base(".da")
    {
      this.Parameters.Add((ICommandParameter) (this.date = (IParameterAndValue<DateTime?>) new ParameterDateTime("s", "yyMMdd")));
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
        this.Date = new DateTime?();
      }
      else
      {
        if (!AsciiResponseExtensions.HasHeader(e.Line, "DA"))
          return;
        this.Date = new DateTime?(DateTime.ParseExact(e.Line.Value, "yyyy-MM-dd", Constants.CommandFormatProvider));
        e.Handled = true;
      }
    }
  }
}
