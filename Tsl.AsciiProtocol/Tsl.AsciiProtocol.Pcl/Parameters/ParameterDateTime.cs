// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ParameterDateTime
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// A parameter that represent a date and/or time value
  /// 
  /// </summary>
  public class ParameterDateTime : ParameterBase<DateTime?>
  {
    /// <summary>
    /// The format used with DateTime.ParseExact to extract the DateTime from a command line
    /// 
    /// </summary>
    private string parseFormat;

    /// <summary>
    /// Initializes a new instance of the ParameterDateTime class
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) used to identify the parameter on the command line</param><param name="parseFormat">A format string to extract the DateTime from the parameter</param>
    public ParameterDateTime(string identifier, string parseFormat)
      : base(identifier, new DateTime?())
    {
      if (string.IsNullOrEmpty(parseFormat))
        throw new ArgumentNullException("parseFormat");
      this.ParameterFormat = " -{0}{1:x}".Replace("x", parseFormat);
      this.parseFormat = parseFormat;
    }

    /// <summary>
    /// Attempt to parse the value from the command line and assign value to the parsed value
    /// 
    /// </summary>
    /// <param name="value">The value to parse</param><exception cref="T:System.ArgumentOutOfRangeException">If the value is outside the permitted range</exception><exception cref="T:System.FormatException">If the parameter is not in the expected format</exception>
    protected override void ParseValue(string value)
    {
      this.Value = new DateTime?(DateTime.ParseExact(value, this.parseFormat, Constants.CommandFormatProvider));
    }
  }
}
