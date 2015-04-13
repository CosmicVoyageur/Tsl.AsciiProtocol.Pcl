// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.IAsciiResponder
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace PortableAscii2
{
  /// <summary>
  /// Provides an event to notify listeners as lines are received as part of a command response
  /// 
  /// </summary>
  public interface IAsciiResponder
  {
    /// <summary>
    /// Raised when the command receives the OK or ER response
    /// 
    /// </summary>
    event EventHandler CommandComplete;

    /// <summary>
    /// Raised when the command receives the CS header
    /// 
    /// </summary>
    event EventHandler CommandStarted;

    /// <summary>
    /// Raised as each line of a response is received
    /// 
    /// </summary>
    event EventHandler<AsciiLineEventArgs> ReceivedLine;
  }
}
