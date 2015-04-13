// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// Defines an ASCII command that can be performed on any device supporting the TSL ASCII 2.0 Protocol
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// A TSLAsciiCommand can be executed using any object that implements the TSLAsciiCommandExecuting protocol.
  ///             The command can be executed either asynchronously or synchronously (by setting synchronousCommandResponder prior to execution).
  ///             Synchronous commands prevent the issue of subsequent commands until the command’s response has been received.
  /// 
  /// </remarks>
  public interface IAsciiCommand
  {
    /// <summary>
    /// Gets the Ascii command identifier e.g. ‘.vr’ or ‘.da’
    /// 
    /// </summary>
    string CommandName { get; }

    /// <summary>
    /// Gets or sets the maximum time in seconds to wait for this command to complete when invoked synchronously
    /// 
    /// </summary>
    double MaxSynchronousWaitTime { get; set; }

    /// <summary>
    /// Returns the Ascii command line (including terminators) to be sent to the device to execute the command
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The ASCII command line to execute the command
    /// 
    /// </returns>
    string CommandLine();
  }
}
