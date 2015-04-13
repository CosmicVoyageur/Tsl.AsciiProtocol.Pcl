// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.IAsciiSerialPort
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace PortableAscii2
{
  /// <summary>
  /// Provides methods and properties to access ASCII data via  serial port
  /// 
  /// </summary>
  public interface IAsciiSerialPort : IDisposable
  {
    /// <summary>
    /// Gets a value indicating whether there is more data to read
    /// 
    /// </summary>
    bool IsDataAvailable { get; }

    /// <summary>
    /// Raised when new data is available to read
    /// 
    /// </summary>
    event EventHandler Received;

    /// <summary>
    /// Sends the line to the port appending the appropriate line end
    /// 
    /// </summary>
    /// <param name="value">The line to write</param>
    void WriteLine(string value);

    /// <summary>
    /// Reads a line from the port removing the terminator
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The line read
    /// </returns>
    string ReadLine();
  }
}
