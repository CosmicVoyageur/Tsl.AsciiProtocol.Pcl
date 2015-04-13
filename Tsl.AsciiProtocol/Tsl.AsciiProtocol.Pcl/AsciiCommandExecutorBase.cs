// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AsciiCommandExecutorBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

//using log4net;

using System;
using System.Collections.Generic;
using System.Threading;

namespace PortableAscii2
{
  /// <summary>
  /// A base class that implements responder chain management
  /// 
  /// </summary>
  public abstract class AsciiCommandExecutorBase : IAsciiCommandExecuting, IDisposable
  {
    /// <summary>
    /// Provides logging for this class
    /// 
    /// </summary>
    //private static ILog log = LogManager.GetLogger(typeof (AsciiCommandExecutorBase));
    /// <summary>
    /// Used to synchronize acccess to the responder chain
    /// 
    /// </summary>
    private object responderLock = new object();
    /// <summary>
    /// Provides synchronization to command execution
    /// 
    /// </summary>
    private object commandSync = new object();
    /// <summary>
    /// True once this instance is disposed
    /// 
    /// </summary>
    private bool disposed;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.AsciiCommandExecutorBase.ResponderChain"/>
    /// </summary>
    private List<IAsciiCommandResponder> responderChain;
    /// <summary>
    /// Holds the synchronous responder instance that relays to synchronous commands
    /// 
    /// </summary>
    private SynchronousDispatchResponder synchronousResponder;
    /// <summary>
    /// True while waiting for a response to a synchronous command
    /// 
    /// </summary>
    private bool awaitingCommandResponse;
    /// <summary>
    /// True once a response is received
    /// 
    /// </summary>
    private bool responseReceived;
    /// <summary>
    /// Signalled when a command completes
    /// 
    /// </summary>
    private AutoResetEvent commandCondition;

    /// <summary>
    /// Gets a value indicating whether the last command completed as expected i.e. did not timeout.
    /// 
    /// </summary>
    public bool IsResponsive { get; private set; }

    /// <summary>
    /// Gets or sets the time of the readers last activity (send or receive)
    /// 
    /// </summary>
    public DateTime LastActivityTime { get; protected set; }

    /// <summary>
    /// Gets the last command line sent
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Because TSLAsciiCommands add a unique id number each time their commandLine property is accessed this property can be used
    ///             (primarily for debugging) to get the actual command line issued (if examined immediately after the command is executed)
    /// 
    /// </remarks>
    public string LastCommandLine { get; private set; }

    /// <summary>
    /// Gets the chain of responders that handle responses to commands
    /// 
    /// </summary>
    public IEnumerable<IAsciiCommandResponder> ResponderChain
    {
      get
      {
        return (IEnumerable<IAsciiCommandResponder>) this.responderChain;
      }
    }

    /// <summary>
    /// Gets a value indicating whether the chain has a synchronous responder
    /// 
    /// </summary>
    public bool HasSynchronousResponder
    {
      get
      {
        return this.synchronousResponder != null;
      }
    }

    /// <summary>
    /// Initializes a new instance of the AsciiCommandExecutorBase class
    /// 
    /// </summary>
    protected AsciiCommandExecutorBase()
    {
      this.commandCondition = new AutoResetEvent(false);
      this.awaitingCommandResponse = false;
      this.responseReceived = false;
      this.responderChain = new List<IAsciiCommandResponder>();
    }

    /// <summary>
    /// Send the given string as a CrLf terminated string, to the reader.
    ///             This method waits until the command has been successfuly sent
    /// 
    /// </summary>
    /// <param name="line">line The ASCII string to send to the device</param><exception cref="T:System.InvalidOperationException">if no device is connected  </exception>
    public virtual void Send(string line)
    {
      if (string.IsNullOrEmpty(line))
        throw new ArgumentNullException("line");
      if (line.Length > 254)
        throw new ArgumentException("line exceeds maximum length. Command line total must be 256 characters or less including terminator(s)");
      CommandSequencer.NextCommandIdentifier();
      //AsciiCommandExecutorBase.log.DebugFormat("Send ={0}", (object) line);
    }

    /// <summary>
    /// Execute the given command.
    /// 
    /// </summary>
    /// <param name="command">The command to be executed</param><param name="synchronousResponder">For command to execute synchronously (not return until complete) set this to a responder to receive the command response.
    ///             To execute the command asynchronously and let the responder chain handle the events set this to null
    ///             </param>
    /// <remarks>
    /// Command execution is asynchronous unless the command has a (non-nil) synchronousCommandResponder then
    ///             the command will be executed synchronously. Synchronous behaviour requires prior call to addSynchronousResponder.
    ///             Warning: derived classes must call the base implementation to ensure synchronous commands work correctly
    /// 
    /// </remarks>
    public virtual void ExecuteCommand(IAsciiCommand command, IAsciiCommandSynchronousResponder synchronousResponder)
    {
      if (command == null)
        throw new ArgumentNullException("command");
      if (synchronousResponder != null)
      {
        lock (this.responderLock)
        {
          if (this.synchronousResponder == null)
            throw new InvalidOperationException("no synchronous command relay in chain");
          if (this.synchronousResponder.SynchronousCommandResponder != null)
            throw new InvalidOperationException("There is already a synchronous command executing");
          this.synchronousResponder.SynchronousCommandResponder = synchronousResponder;
          this.synchronousResponder.ClearLastResponse();
        }
      }
      try
      {
        this.ExecuteCommand(command.CommandLine(), synchronousResponder != null, Convert.ToInt32(command.MaxSynchronousWaitTime * 1000.0));
      }
      finally
      {
        lock (this.responderLock)
        {
          if (this.synchronousResponder != null)
            this.synchronousResponder.SynchronousCommandResponder = (IAsciiCommandSynchronousResponder) null;
        }
      }
    }

    /// <summary>
    /// Add a responder to the responder chain
    /// 
    /// </summary>
    /// <param name="responder">The responder to add</param>
    public void AddResponder(IAsciiCommandResponder responder)
    {
      if (responder == null)
        throw new ArgumentNullException("responder");
      lock (this.responderLock)
        this.responderChain.Add(responder);
    }

    /// <summary>
    /// Remove a responder from the responder chain
    /// 
    /// </summary>
    /// <param name="responder">The responder to remove</param>
    public void RemoveResponder(IAsciiCommandResponder responder)
    {
      if (responder == null)
        throw new ArgumentNullException("responder");
      lock (this.responderLock)
        this.responderChain.Remove(responder);
    }

    /// <summary>
    /// Add the synchronous responder into the chain
    /// 
    /// </summary>
    public void AddSynchronousResponder()
    {
      lock (this.responderLock)
      {
        if (this.synchronousResponder != null)
          return;
        this.synchronousResponder = new SynchronousDispatchResponder();
        this.AddResponder((IAsciiCommandResponder) this.synchronousResponder);
      }
    }

    /// <summary>
    /// Remove the synchronous responder from the chain
    /// 
    /// </summary>
    public void RemoveSynchronousResponder()
    {
      lock (this.responderLock)
      {
        if (this.synchronousResponder == null)
          return;
        this.RemoveResponder((IAsciiCommandResponder) this.synchronousResponder);
        this.synchronousResponder = (SynchronousDispatchResponder) null;
      }
    }

    /// <summary>
    /// Clear all responders from the responder chain
    /// 
    /// </summary>
    public void ClearResponders()
    {
      lock (this.responderLock)
      {
        this.responderChain.Clear();
        this.synchronousResponder = (SynchronousDispatchResponder) null;
      }
    }

    /// <summary>
    /// Disposes an instance of the AsciiCommandExecutorBase class
    /// 
    /// </summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    /// <summary>
    /// Disposes an instance of the AsciiCommandExecutorBase class
    /// 
    /// </summary>
    /// <param name="disposing">True to dispose managed as well as native resources</param>
    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing)
        this.commandCondition.Dispose();
      this.disposed = true;
    }

    /// <summary>
    /// This should be called when new data is received from the reader
    /// 
    /// </summary>
    /// <param name="receivedLines">A number of complete lines received from the reader</param>
    protected virtual void ProcessReceivedLines(ICollection<string> receivedLines)
    {
      int num = 0;
      //AsciiCommandExecutorBase.log.Debug((object) "ProcessReceivedLines+");
      foreach (string line in (IEnumerable<string>) receivedLines)
      {
        bool moreAvailable = num < receivedLines.Count - 1;
        this.ProcessReceivedLine(line, num++, moreAvailable);
      }
      //AsciiCommandExecutorBase.log.Debug((object) "ProcessReceivedLines-");
    }

    /// <summary>
    /// Called from <see cref="M:PortableAscii2.AsciiCommandExecutorBase.ProcessReceivedLines(System.Collections.Generic.ICollection{System.String})"/> to process each line received from the reader
    /// 
    /// </summary>
    /// <param name="line">The received line</param><param name="lineNumber">The line number in the set of lines being processed</param><param name="moreAvailable">True if not the last line in the set</param>
    protected virtual void ProcessReceivedLine(string line, int lineNumber, bool moreAvailable)
    {
      //AsciiCommandExecutorBase.log.DebugFormat("ProcessReceivedLine('{0}', Num={1}, More={2}", (object) line, (object) lineNumber, moreAvailable);
      IAsciiResponseLine line1 = (IAsciiResponseLine) new AsciiResponseLine(line);
      foreach (IAsciiCommandResponder commandResponder in this.ResponderChain)
      {
        try
        {
          if (commandResponder.ProcessReceivedLine(line1, moreAvailable))
          {
            //AsciiCommandExecutorBase.log.DebugFormat("Handled by {0}", (object) commandResponder.GetType());
            break;
          }
        }
        catch (Exception ex)
        {
          //AsciiCommandExecutorBase.log.ErrorFormat("Unhandled exception in responder ({0}): {0}", (object) commandResponder.GetType().FullName, (object) ex.Message);
          throw;
        }
      }
      if (this.synchronousResponder == null || !this.synchronousResponder.IsResponseFinished)
        return;
      this.responseReceived = true;
      this.commandCondition.Set();
    }

    /// <summary>
    /// Execute the given command.
    /// 
    /// </summary>
    /// <param name="commandLine">The command line to be executed</param><param name="waitResponse">When true the method blocks until the command completes or the timeoutMilliseconds is reached (synchronous command)
    ///             When false the method returns after sending the command to the reader (asynchronous command)
    ///             </param><param name="timeoutMilliseconds">The time in milliseconds to wait for a response when executing a synchronous command</param>
    /// <remarks>
    /// Command execution is asynchronous unless the command has a (non-nil) synchronousCommandResponder then
    ///             the command will be executed synchronously. Synchronous behaviour requires prior call to addSynchronousResponder.
    ///             Warning: derived classes must call the base implementation to ensure synchronous commands work correctly
    /// 
    /// </remarks>
    private void ExecuteCommand(string commandLine, bool waitResponse, int timeoutMilliseconds)
    {
      if (timeoutMilliseconds < 10)
        throw new ArgumentOutOfRangeException("timeoutMilliseconds", "Timeout must be greater than 10 milliseconds");
      try
      {
        if (this.awaitingCommandResponse && waitResponse)
          throw new InvalidOperationException("Already executing a command");
        if (waitResponse)
        {
          if (!this.HasSynchronousResponder)
          {
            //AsciiCommandExecutorBase.log.Error((object) "!!! No synchronous responder in the responder chain !!!");
            throw new InvalidOperationException("No synchronous responder in the responder chain");
          }
        }
        try
        {
          this.LastCommandLine = commandLine;
          this.Send(this.LastCommandLine);
          lock (this.commandSync)
          {
            this.IsResponsive = true;
            this.awaitingCommandResponse = waitResponse;
            this.responseReceived = !waitResponse;
            bool local_0 = false;
            while (!this.responseReceived && !local_0)
            {
              //AsciiCommandExecutorBase.log.Debug((object) "ExecuteCommand = wait for response");
              local_0 = !this.commandCondition.WaitOne(timeoutMilliseconds);
              //AsciiCommandExecutorBase.log.DebugFormat("ExecuteCommand = wait released. timeOut={0}", local_0 );
            }
            if (!local_0)
              return;
            this.IsResponsive = false;
          }
        }
        catch (Exception ex)
        {
          //AsciiCommandExecutorBase.log.Error((object) "Command failed", ex);
          throw;
        }
        finally
        {
          this.awaitingCommandResponse = false;
        }
      }
      catch (Exception ex)
      {
        //AsciiCommandExecutorBase.log.Error((object) "ExecuteCommand failed", ex);
        throw;
      }
    }
  }
}
