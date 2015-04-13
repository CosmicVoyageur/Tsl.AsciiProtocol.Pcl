// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ParameterText
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Globalization;

namespace Tsl.AsciiProtocol.Pcl.Parameters
{
  /// <summary>
  /// Represents a command line parameter that has a text value
  /// 
  /// </summary>
  public class ParameterText : ParameterBase<string>
  {
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.ParameterText.MaximumLength"/>
    /// </summary>
    private int maximumLength = 1023;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.ParameterText.MinimumLength"/>
    /// </summary>
    private int minimumLength;

    /// <summary>
    /// Gets or sets a value indicating whether the value output to the command line is surrounded in double quotes
    /// 
    /// </summary>
    public bool IsQuoted { get; set; }

    /// <summary>
    /// Gets or sets the minimum length of the text in characters
    /// 
    /// </summary>
    public int MinimumLength
    {
      get
      {
        return this.minimumLength;
      }
      set
      {
        if (value < 0 || value > this.maximumLength)
          throw new ArgumentException("value should be greater or equal to 0 and less than or equal to MaximumLength");
        this.minimumLength = value;
      }
    }

    /// <summary>
    /// Gets or sets the maximum length of the text in characters
    /// 
    /// </summary>
    public int MaximumLength
    {
      get
      {
        return this.maximumLength;
      }
      set
      {
        if (value < this.minimumLength || value > 1023)
          throw new ArgumentException("value should be greater or equal to MinimumLength and less than or equal to 1023");
        this.maximumLength = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the ParameterText class
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) that identify the parameter on the command line</param><param name="minimumLength">The minimum length of the string</param><param name="maximumLength">The maximum length of the string</param>
    public ParameterText(string identifier, int minimumLength, int maximumLength)
      : this(identifier, minimumLength, maximumLength, false)
    {
    }

    /// <summary>
    /// Initializes a new instance of the ParameterText class
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) that identify the parameter on the command line</param><param name="minimumLength">The minimum length of the string</param><param name="maximumLength">The maximum length of the string</param><param name="quoted">True if the string is output surrounded with double quotes on the command line</param>
    public ParameterText(string identifier, int minimumLength, int maximumLength, bool quoted)
      : base(identifier, string.Empty)
    {
      this.IsQuoted = quoted;
      this.MaximumLength = maximumLength;
      this.MinimumLength = minimumLength;
      if (!this.IsQuoted)
        return;
      this.ParameterFormat = " -{0}\"{1}\"";
    }

    /// <summary>
    /// Attempt to parse the value from the command line and assign value to the parsed value
    /// 
    /// </summary>
    /// <param name="value">The value to parse</param><exception cref="T:System.ArgumentOutOfRangeException">If the value is outside the permitted range</exception><exception cref="T:System.FormatException">If the parameter is not in the expected format</exception>
    protected override void ParseValue(string value)
    {
      if (this.IsQuoted)
      {
        if (!value.StartsWith("\"") || !value.EndsWith("\""))
          throw new FormatException("Parameter value requires quote marks (\")");
        this.Value = value.Substring(1, value.Length - 2);
      }
      else
        this.Value = value;
    }

    /// <summary>
    /// Checks the text is within the length constraints as the Value property is assigned
    /// 
    /// </summary>
    /// <param name="value">The value to test</param>
    /// <returns>
    /// The value to assign to the value
    /// </returns>
    protected override string CheckValue(string value)
    {
      if (!string.IsNullOrEmpty(value) && (value.Length < this.MinimumLength || value.Length > this.MaximumLength))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "value ({0}) text length {1} is outside the range of values ({2} to {3})", (object) value, (object) value.Length, (object) this.MinimumLength, (object) this.MaximumLength));
      return value;
    }
  }
}
