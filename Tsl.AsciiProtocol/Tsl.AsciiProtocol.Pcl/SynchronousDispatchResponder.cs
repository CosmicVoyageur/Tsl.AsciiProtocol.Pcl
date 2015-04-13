// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.SynchronousDispatchResponder
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2
{
  /// <summary>
  /// This is a special TSLAsciiCommandResponder that is inserted into the responder chain to handle synchronous commands.
  ///             This responder uses its synchronousCommandDelegate to find the currently executing synchronous command.
  ///             If such a command exists then this responder forwards calls to processReceivedLine:moreLinesAvailable: to the synchronous command's synchronousCommandResponder
  /// 
  /// </summary>
  public class SynchronousDispatchResponder : IAsciiCommandSynchronousResponder, IAsciiCommandResponder
  {
    /// <summary>
    /// Gets or sets the <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommandResponder"/> of the currently executing synchronous <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommand"/>
    /// </summary>
    /// 
    /// <remarks>
    /// This property should be set to a synchronous command while it is executing and set to null once the command is complete
    /// 
    /// </remarks>
    public IAsciiCommandSynchronousResponder SynchronousCommandResponder { get; set; }

    /// <summary>
    /// Gets a value indicating whether the response is complete (i.e. received OK: or ER:)
    /// 
    /// </summary>
    public bool IsResponseFinished
    {
      get
      {
        IAsciiCommandSynchronousResponder commandResponder = this.SynchronousCommandResponder;
        if (commandResponder != null)
          return commandResponder.IsResponseFinished;
        return false;
      }
    }

    /// <summary>
    /// Clears the values from the last response
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Derived classes must call super class to ensure correct operation
    /// 
    /// </remarks>
    public void ClearLastResponse()
    {
      IAsciiCommandSynchronousResponder commandResponder = this.SynchronousCommandResponder;
      if (commandResponder == null)
        return;
      commandResponder.ClearLastResponse();
    }

    /// <summary>
    /// Each correctly terminated line from the device is passed to this method for processing
    /// 
    /// </summary>
    /// <param name="line">The line to be processed</param><param name="moreLinesAvailable">When YES indictates there are additional lines to be processed (and will also be passed to this method)</param>
    /// <returns>
    /// YES if this line should not be passed to any other responder
    /// </returns>
    public bool ProcessReceivedLine(IAsciiResponseLine line, bool moreLinesAvailable)
    {
      IAsciiCommandResponder commandResponder = (IAsciiCommandResponder) this.SynchronousCommandResponder;
      if (commandResponder != null)
        return commandResponder.ProcessReceivedLine(line, moreLinesAvailable);
      return false;
    }
  }
}
