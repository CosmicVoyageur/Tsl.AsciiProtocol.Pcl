// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommandExecuting
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.Collections.Generic;

namespace PortableAscii2
{
  /// <summary>
  /// Defines the responsibilities of classes that can execute and respond to a TSLAsciiCommand
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// Responses to an executed TSLAsciiCommand (see executeCommand:) are handled through a responder chain (see responderChain)
  ///             The responder chain is an ordered list of TSLAsciiCommandResponder that is traversed from the first responder added to the last.
  ///             Each correctly terminated response line that has been received is passed to the TSLAsciiCommandResponder’s processReceivedLine: method.
  ///             If a responder returns YES from the processReceivedLine method then the traversal ends otherwise it continues until all responders have been visited.
  /// 
  /// </remarks>
  public interface IAsciiCommandExecuting
  {
    /// <summary>
    /// Gets the chain of TSLAsciiCommandResponders
    /// 
    /// </summary>
    IEnumerable<IAsciiCommandResponder> ResponderChain { get; }

    /// <summary>
    /// Add a responder to the responder chain
    /// 
    /// </summary>
    /// <param name="responder">The responder to add to the chain</param>
    void AddResponder(IAsciiCommandResponder responder);

    /// <summary>
    /// Add the synchronous responder into the chain
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// This is a special responder that despatches responses through a command’s synchronousCommandResponder property
    ///             There will only ever be one of these in the command chain
    /// 
    /// </remarks>
    void AddSynchronousResponder();

    /// <summary>
    /// Clear all responders from the responder chain
    /// 
    /// </summary>
    void ClearResponders();

    /// <summary>
    /// Execute the given command.
    /// 
    /// </summary>
    /// <param name="command">The command to be executed</param><param name="synchronousResponder">For command to execute synchronously (not return until complete) set this to a responder to receive the command response.
    ///             To execute the command asynchronously and let the responder chain handle the events set this to null
    ///             </param>
    /// <remarks>
    /// Warning: derived classes must call the base implementation to ensure synchronous commands work correctly
    /// 
    /// </remarks>
    void ExecuteCommand(IAsciiCommand command, IAsciiCommandSynchronousResponder synchronousResponder);

    /// <summary>
    /// Remove a responder from the responder chain
    /// 
    /// </summary>
    /// <param name="responder">The responder to remove from the chain</param>
    void RemoveResponder(IAsciiCommandResponder responder);

    /// <summary>
    /// Remove the synchronous responder from the chain
    /// 
    /// </summary>
    void RemoveSynchronousResponder();
  }
}
