// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommandResponder
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll



namespace PortableAscii2
{
  /// <summary>
  /// The interface for classes that handle responses from ASCII 2.x commands
  /// 
  /// </summary>
  public interface IAsciiCommandResponder
  {
    /// <summary>
    /// Each correctly terminated line from the device is passed to this method for processing
    /// 
    /// </summary>
    /// <param name="line">The line to be processed</param><param name="moreLinesAvailable">When true indictates there are additional lines to be processed (and will also be passed to this method)</param>
    /// <returns>
    /// True if this line should not be passed to any other responder
    /// </returns>
    bool ProcessReceivedLine(IAsciiResponseLine line, bool moreLinesAvailable);
  }
}
