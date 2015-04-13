// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AsciiResponseLine
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// Represents an ASCII response line (e.g. ME: message)
  /// 
  /// </summary>
  public class AsciiResponseLine : IAsciiResponseLine
  {
    /// <summary>
    /// The line header for Command Started "CS"
    /// 
    /// </summary>
    public const string HeaderCommandStarted = "CS";
    /// <summary>
    /// The line header for Parameters "PR"
    /// 
    /// </summary>
    public const string HeaderParameters = "PR";
    /// <summary>
    /// The line header for message "ME"
    /// 
    /// </summary>
    public const string HeaderMessage = "ME";
    /// <summary>
    /// The line header for OK "OK"
    /// 
    /// </summary>
    public const string HeaderOk = "OK";
    /// <summary>
    /// The line header for Error "ER"
    /// 
    /// </summary>
    public const string HeaderError = "ER";
    /// <summary>
    /// Backing field for Header
    /// 
    /// </summary>
    private string header;
    /// <summary>
    /// Backing field for Value
    /// 
    /// </summary>
    private string value;

    /// <summary>
    /// Gets the full line
    /// 
    /// </summary>
    public string FullLine { get; private set; }

    /// <summary>
    /// Gets the two character header without the colon
    /// 
    /// </summary>
    public string Header
    {
      get
      {
        if (this.header == null)
          this.ParseFullLine();
        return this.header;
      }
    }

    /// <summary>
    /// Gets the value of the line. The value after the colon with whitespace from the start and end removed
    /// 
    /// </summary>
    public string Value
    {
      get
      {
        if (this.value == null)
          this.ParseFullLine();
        return this.value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the AsciiResponseLine class
    /// 
    /// </summary>
    /// <param name="fullLine">The fullline containing header and value received from the reader</param>
    public AsciiResponseLine(string fullLine)
    {
      this.FullLine = fullLine;
    }

    /// <summary>
    /// Splits the <see cref="P:PortableAscii2.AsciiResponseLine.FullLine"/> into <see cref="P:PortableAscii2.AsciiResponseLine.Header"/> and <see cref="P:PortableAscii2.AsciiResponseLine.Value"/>
    /// </summary>
    private void ParseFullLine()
    {
      string str = this.FullLine.Trim();
      if (str.IndexOf(":", StringComparison.OrdinalIgnoreCase) == 2)
      {
        this.header = str.Substring(0, 2);
        this.value = str.Substring(3).Trim();
      }
      else
      {
        this.header = string.Empty;
        this.value = string.Empty;
      }
    }
  }
}
