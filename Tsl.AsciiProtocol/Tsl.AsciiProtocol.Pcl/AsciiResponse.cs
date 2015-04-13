// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AsciiResponse
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

//using log4net;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PortableAscii2
{
  /// <summary>
  /// Provides a base implementation of <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.IAsciiResponse"/>
  /// </summary>
  public class AsciiResponse : IAsciiResponse
  {
    /// <summary>
    /// Provides logging for this class
    /// 
    /// </summary>
    //private static ILog log = LogManager.GetLogger(typeof (AsciiResponse));
    /// <summary>
    /// Handles the special case of a log download where OK or ER is not the end of response but part of the log
    /// 
    /// </summary>
    private bool withinLog;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.AsciiResponse.Response"/>
    /// </summary>
    private List<IAsciiResponseLine> response;

    /// <summary>
    /// Gets the error code received. Once as response has been cleared this will return null until OK or ER is received.
    ///             If OK is received the value is set to string.Empty. If ER is received the value is set to the error code
    /// 
    /// </summary>
    public string ErrorCode { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the response is successfull (Ended with OK:)
    /// 
    /// </summary>
    public bool IsSuccessful
    {
      get
      {
        if (this.ErrorCode != null)
          return this.ErrorCode.Length == 0;
        return false;
      }
    }

    /// <summary>
    /// Gets a value indicating whether the response has received OK: or ER:
    /// 
    /// </summary>
    public bool IsResponseFinished
    {
      get
      {
        return this.ErrorCode != null;
      }
    }

    /// <summary>
    /// Gets the messages received during the response
    /// 
    /// </summary>
    public IEnumerable<string> Messages
    {
      get
      {
        return Enumerable.Select<IAsciiResponseLine, string>(Enumerable.Where<IAsciiResponseLine>((IEnumerable<IAsciiResponseLine>) this.response, (Func<IAsciiResponseLine, bool>) (x => AsciiResponseExtensions.IsMessage(x))), (Func<IAsciiResponseLine, string>) (x => x.Value));
      }
    }

    /// <summary>
    /// Gets the parameters received during the response
    /// 
    /// </summary>
    public IEnumerable<string> Parameters
    {
      get
      {
        IAsciiResponseLine asciiResponseLine = Enumerable.FirstOrDefault<IAsciiResponseLine>(Enumerable.Where<IAsciiResponseLine>(this.Response, (Func<IAsciiResponseLine, bool>) (x => AsciiResponseExtensions.HasHeader(x, "PR"))));
        if (asciiResponseLine == null)
          return (IEnumerable<string>) new string[0];
        return (IEnumerable<string>) CommandHelper.SplitParameters(asciiResponseLine.Value);
      }
    }

    /// <summary>
    /// Gets the lines received during the response
    /// 
    /// </summary>
    public IEnumerable<IAsciiResponseLine> Response
    {
      get
      {
        return (IEnumerable<IAsciiResponseLine>) this.response;
      }
    }

    /// <summary>
    /// Initializes a new instance of the AsciiResponse class
    /// 
    /// </summary>
    public AsciiResponse()
    {
      this.response = new List<IAsciiResponseLine>();
    }

    /// <summary>
    /// Clears the response ready to receive a new one
    /// 
    /// </summary>
    public virtual void ClearLastResponse()
    {
      this.ErrorCode = (string) null;
      this.response.Clear();
      this.withinLog = false;
    }

    /// <summary>
    /// Append the given string to the current <see cref="P:PortableAscii2.AsciiResponse.Response"/>
    /// </summary>
    /// <param name="line">The line to append to the current response</param>
    protected virtual void AppendToResponse(IAsciiResponseLine line)
    {
      //AsciiResponse.log.DebugFormat("AppendToResponse {0}", (object) line);
      this.response.Add(line);
      if (AsciiResponseExtensions.HasHeader(line, "LB"))
        this.withinLog = true;
      else if (AsciiResponseExtensions.HasHeader(line, "LE"))
        this.withinLog = false;
      else if (!this.withinLog && AsciiResponseExtensions.IsOk(line))
      {
        this.ErrorCode = string.Empty;
      }
      else
      {
        if (this.withinLog || !AsciiResponseExtensions.IsError(line))
          return;
        this.ErrorCode = line.Value;
      }
    }
  }
}
