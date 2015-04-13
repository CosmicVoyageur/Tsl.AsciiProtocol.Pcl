// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ParameterInt
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Globalization;

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Defines a parameter that is an optional integar
  /// 
  /// </summary>
  public class ParameterInt : ParameterBase<int?>
  {
    /// <summary>
    /// Gets the maximum permitted value
    /// 
    /// </summary>
    public int Maximum { get; private set; }

    /// <summary>
    /// Gets the minimum permitted value
    /// 
    /// </summary>
    public int Minimum { get; private set; }

    /// <summary>
    /// Initializes a new instance of the ParameterInt class for decimal values
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) that identify the parameter on the command line</param><param name="minimum">The maximum permitted value when not null</param><param name="maximum">The minimum permitted value when not null</param>
    public ParameterInt(string identifier, int minimum, int maximum)
      : this(identifier, minimum, maximum, "D")
    {
    }

    /// <summary>
    /// Initializes a new instance of the ParameterInt class
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) that identify the parameter on the command line</param><param name="parseFormat">A format string to output the value to the command line. This also indicates whether the value should
    ///             be parsed as hex (e.g. "X2" or decimal "D")
    ///             </param>
    public ParameterInt(string identifier, string parseFormat)
      : this(identifier, 0, ParameterInt.MaximumOf(parseFormat), parseFormat)
    {
    }

    /// <summary>
    /// Initializes a new instance of the ParameterInt class
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) that identify the parameter on the command line</param><param name="minimum">The maximum permitted value when not null</param><param name="maximum">The minimum permitted value when not null</param><param name="parseFormat">A format string to output the value to the command line. This also indicates whether the value should
    ///             be parsed as hex ("X" or decimal "D")
    ///             </param>
    private ParameterInt(string identifier, int minimum, int maximum, string parseFormat)
      : base(identifier, new int?())
    {
      if (maximum < minimum)
        throw new ArgumentOutOfRangeException("maximum", "maximum is less than minumum");
      this.Maximum = maximum;
      this.Minimum = minimum;
      this.ParameterFormat = " -{0}{1:x}".Replace("x", parseFormat);
    }

    /// <summary>
    /// Checks that value is within the accepted range if the value is not null
    /// 
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <returns>
    /// The checked value
    /// </returns>
    protected override int? CheckValue(int? value)
    {
      if (value.HasValue && (value.Value < this.Minimum || value.Value > this.Maximum))
        throw new ArgumentOutOfRangeException("value", string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0} is outside the range {1} to {2}", (object) value.Value, (object) this.Minimum, (object) this.Maximum));
      return value;
    }

    /// <summary>
    /// Attempt to parse the value from the command line and assign value to the parsed value
    /// 
    /// </summary>
    /// <param name="value">The value to parse</param><exception cref="T:System.ArgumentOutOfRangeException">If the value is outside the permitted range</exception><exception cref="T:System.FormatException">If the parameter is not in the expected format</exception>
    protected override void ParseValue(string value)
    {
      if (this.ParameterFormat.IndexOf("X", StringComparison.OrdinalIgnoreCase) > 0)
        this.Value = new int?(int.Parse(value, NumberStyles.HexNumber, Constants.CommandFormatProvider));
      else
        this.Value = new int?(int.Parse(value, Constants.CommandFormatProvider));
    }

    /// <summary>
    /// Returns the maximum value permitted for a hex value based on the parse format
    /// 
    /// </summary>
    /// <param name="parseFormat">The parse format for the value</param>
    /// <returns>
    /// The maximum value for the int based on the parse format
    /// </returns>
    private static int MaximumOf(string parseFormat)
    {
      if (parseFormat.StartsWith("x", StringComparison.OrdinalIgnoreCase))
        return (int) Math.Pow(16.0, (double) int.Parse(parseFormat.Substring(1), (IFormatProvider) CultureInfo.InvariantCulture)) - 1;
      throw new ArgumentOutOfRangeException("parseFormat", "parseFormat is X2 or X4");
    }
  }
}
