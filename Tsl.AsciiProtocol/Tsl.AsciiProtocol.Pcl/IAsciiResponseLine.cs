// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.IAsciiResponseLine
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2
{
  /// <summary>
  /// Represents a single line of ASCII response with a header, colon separator and value (e.g. ME: this is a message)
  /// 
  /// </summary>
  public interface IAsciiResponseLine
  {
    /// <summary>
    /// Gets the full line
    /// 
    /// </summary>
    string FullLine { get; }

    /// <summary>
    /// Gets the two character header without the colon
    /// 
    /// </summary>
    string Header { get; }

    /// <summary>
    /// Gets the value of the line. The value after the colon with whitespace from the start and end removed
    /// 
    /// </summary>
    string Value { get; }
  }
}
