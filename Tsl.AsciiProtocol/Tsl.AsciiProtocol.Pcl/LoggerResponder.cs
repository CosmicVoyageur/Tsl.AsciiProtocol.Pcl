// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.LoggerResponder
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

//using log4net;

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// A simple responder that inserts every line it sees, preceded by '&gt;', into the standard log file
  /// 
  /// </summary>
  public class LoggerResponder : IAsciiCommandResponder
  {
    /// <summary>
    /// Provides logging for this class
    /// 
    /// </summary>
    //private static ILog log = LogManager.GetLogger(typeof (LoggerResponder));

    /// <summary>
    /// Captures the line to the log
    /// 
    /// </summary>
    /// <param name="line">The line to log</param><param name="moreLinesAvailable">True if more lines are going to be passed to this method</param>
    /// <returns>
    /// False to allow other IAsciiCommandResponders to process the responses also
    /// </returns>
    public bool ProcessReceivedLine(IAsciiResponseLine line, bool moreLinesAvailable)
    {
      //LoggerResponder.log.InfoFormat(">{0}", (object) line.FullLine);
      return false;
    }
  }
}
