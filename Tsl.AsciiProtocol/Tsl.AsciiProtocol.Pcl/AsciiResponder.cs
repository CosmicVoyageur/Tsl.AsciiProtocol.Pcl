// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AsciiResponder
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;

namespace PortableAscii2
{
  /// <summary>
  /// Extends the AsciiResponse to actually respond to commands
  /// 
  /// </summary>
  public class AsciiResponder : AsciiResponse, IAsciiCommandSynchronousResponder, IAsciiCommandResponder, IAsciiResponseResponder, IAsciiResponse, IAsciiResponder
  {
    /// <summary>
    /// Set to true while the response is being received
    /// 
    /// </summary>
    private bool responseStarted;

    /// <summary>
    /// Gets or sets the partial command line that should be matched by the value of the CS line to indicate a command has started.
    ///             For example to match any reponse to a type of command ".iv" or to match only library inventory commands ".iv LCMD"
    /// 
    /// </summary>
    public string MatchCommandLine { get; set; }

    /// <summary>
    /// Gets the collection of headers accepted by this response. Lists the headers of the <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.IAsciiResponse"/> lines
    ///             that will be captured into the <see cref="P:TechnologySolutions.Rfid.AsciiProtocol.IAsciiResponse.Response"/>
    /// </summary>
    public ICollection<string> AcceptedHeaders { get; private set; }

    /// <summary>
    /// Raised when a command completed
    /// 
    /// </summary>
    public event EventHandler CommandComplete;

    /// <summary>
    /// Raised when a command started
    /// 
    /// </summary>
    public event EventHandler CommandStarted;

    /// <summary>
    /// Raised when a line is received
    /// 
    /// </summary>
    public event EventHandler<AsciiLineEventArgs> ReceivedLine;

    /// <summary>
    /// Initializes a new instance of the AsciiResponder class
    /// 
    /// </summary>
    public AsciiResponder()
    {
      this.AcceptedHeaders = (ICollection<string>) new List<string>((IEnumerable<string>) new string[4]
      {
        "CS",
        "ME",
        "ER",
        "OK"
      });
    }

    /// <summary>
    /// Each correctly terminated line from the device is passed to this method for processing
    /// 
    /// </summary>
    /// <param name="line">The line to be processed</param><param name="moreLinesAvailable">When true indictates there are additional lines to be processed (and will also be passed to this method)
    ///             </param>
    /// <returns>
    /// True if this line should not be passed to any other responder
    /// </returns>
    public bool ProcessReceivedLine(IAsciiResponseLine line, bool moreLinesAvailable)
    {
      bool flag = false;
      if (!this.responseStarted)
      {
        if (AsciiResponseExtensions.IsCommandStarted(line) && !string.IsNullOrEmpty(this.MatchCommandLine) && line.Value.StartsWith(this.MatchCommandLine, StringComparison.OrdinalIgnoreCase))
        {
          this.ClearLastResponse();
          this.responseStarted = true;
          this.AppendToResponse(line);
          this.OnCommandStarted();
          this.OnProcessReceivedLine(line, moreLinesAvailable);
          flag = true;
        }
      }
      else
      {
        if (this.OnProcessReceivedLine(line, moreLinesAvailable))
          flag = true;
        else if (AsciiResponseExtensions.IsOk(line) || AsciiResponseExtensions.IsError(line))
          flag = true;
        else if (this.AcceptedHeaders.Contains(line.Header) || this.AcceptedHeaders.Count == 0)
          flag = true;
        if (flag)
        {
          this.AppendToResponse(line);
          if (this.IsResponseFinished)
          {
            this.responseStarted = false;
            this.OnCommandComplete();
          }
        }
      }
      return flag;
    }

    /// <summary>
    /// Clears the response ready to receive a new one
    /// 
    /// </summary>
    public override void ClearLastResponse()
    {
      base.ClearLastResponse();
      this.responseStarted = false;
    }

    /// <summary>
    /// Raises the <see cref="E:PortableAscii2.AsciiResponder.CommandComplete"/> event
    /// 
    /// </summary>
    protected virtual void OnCommandComplete()
    {
      EventHandler eventHandler = this.CommandComplete;
      if (eventHandler == null)
        return;
      eventHandler((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="E:PortableAscii2.AsciiResponder.CommandStarted"/> event
    /// 
    /// </summary>
    protected virtual void OnCommandStarted()
    {
      EventHandler eventHandler = this.CommandStarted;
      if (eventHandler == null)
        return;
      eventHandler((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="E:PortableAscii2.AsciiResponder.ReceivedLine"/> event
    /// 
    /// </summary>
    /// <param name="line">The line recived</param><param name="moreToFollow">True if more lines are already buffered</param>
    /// <returns>
    /// True if a listener handled the response
    /// </returns>
    protected virtual bool OnProcessReceivedLine(IAsciiResponseLine line, bool moreToFollow)
    {
      AsciiLineEventArgs e = new AsciiLineEventArgs(line, moreToFollow);
      EventHandler<AsciiLineEventArgs> eventHandler = this.ReceivedLine;
      if (eventHandler != null)
        eventHandler((object) this, e);
      return e.Handled;
    }
  }
}
