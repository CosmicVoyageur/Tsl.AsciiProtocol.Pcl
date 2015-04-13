// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.ReadLogFileCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.ComponentModel;
using System.Text;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// A command to read the log file from the device
  /// 
  /// </summary>
  public class ReadLogFileCommand : ActionCommandBase
  {
    /// <summary>
    /// Backing field for IsCommandLoggingEnabled
    /// 
    /// </summary>
    private IParameterAndValue<TriState?> commandLoggingEnabled;
    /// <summary>
    /// Backing field for DeleteFile
    /// 
    /// </summary>
    private IParameterAndValue<Deletion?> deleteFile;
    /// <summary>
    /// Used to determine when responses are within the log file
    /// 
    /// </summary>
    private bool withinLog;

    /// <summary>
    /// Gets or sets a value indicating whether to command logging is enabled. Set to null to not change the current value
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters")]
    [Description("Gets or sets a value indicating whether command logging is enabled. Set to null to not change the current value")]
    public TriState? IsCommandLoggingEnabled
    {
      get
      {
        return this.commandLoggingEnabled.Value;
      }
      set
      {
        this.commandLoggingEnabled.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to delete the file from the device
    /// 
    /// </summary>
    [DefaultValue(false)]
    [Category("Parameters")]
    [Description("Set to true to delete the file from the device")]
    public Deletion? DeleteFile
    {
      get
      {
        return this.deleteFile.Value;
      }
      set
      {
        this.deleteFile.Value = value;
      }
    }

    /// <summary>
    /// Gets the contents of the file
    /// 
    /// </summary>
    [Category("Response")]
    [Description("The log file read from the device")]
    public string LogFile
    {
      get
      {
        bool flag = false;
        StringBuilder stringBuilder = new StringBuilder();
        foreach (IAsciiResponseLine line in this.Response.Response)
        {
          if (AsciiResponseExtensions.HasHeader(line, "LB"))
            flag = true;
          else if (AsciiResponseExtensions.HasHeader(line, "LE"))
            flag = false;
          else if (flag)
            stringBuilder.AppendLine(line.FullLine);
        }
        return stringBuilder.ToString();
      }
    }

    /// <summary>
    /// Initializes a new instance of the ReadLogFileCommand class
    /// 
    /// </summary>
    public ReadLogFileCommand()
      : base(".rl")
    {
      this.Parameters.Add((ICommandParameter) (this.commandLoggingEnabled = (IParameterAndValue<TriState?>) new ParameterEnum<TriState>("c")));
      this.Parameters.Add((ICommandParameter) (this.deleteFile = (IParameterAndValue<Deletion?>) new ParameterEnum<Deletion>("d")));
      this.Parameters.Reset();
      AsciiResponseExtensions.AddHeaders(this.Response, "CS: ER: LB: LE: ME: OK: PR:");
      this.Response.ReceivedLine += new EventHandler<AsciiLineEventArgs>(this.Response_ReceivedLine);
    }

    /// <summary>
    /// Process the response including the entire log into the response
    /// 
    /// </summary>
    /// <param name="sender">The event source</param><param name="e">Data provided for the event</param>
    private void Response_ReceivedLine(object sender, AsciiLineEventArgs e)
    {
      if (AsciiResponseExtensions.HasHeader(e.Line, "LB"))
      {
        this.withinLog = true;
        e.Handled = true;
      }
      else if (AsciiResponseExtensions.HasHeader(e.Line, "LE"))
      {
        this.withinLog = false;
        e.Handled = true;
      }
      else
      {
        if (!this.withinLog)
          return;
        e.Handled = true;
      }
    }
  }
}
