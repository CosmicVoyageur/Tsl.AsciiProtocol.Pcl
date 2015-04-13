// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ParameterBool
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Represents a parameter which is either present or not and does not have an associated value. For example take no action '-n'
  /// 
  /// </summary>
  public class ParameterBool : ParameterBase<bool>
  {
    /// <summary>
    /// Initializes a new instance of the ParameterBool class
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) that identify the parameter on the command line</param>
    public ParameterBool(string identifier)
      : base(identifier, false)
    {
      this.ParameterFormat = " -{0}";
    }

    /// <summary>
    /// Attempt to parse the value from the command line and assign value to the parsed value
    /// 
    /// </summary>
    /// <param name="value">The value to parse</param><exception cref="T:System.ArgumentOutOfRangeException">If the value is outside the permitted range</exception><exception cref="T:System.FormatException">If the parameter is not in the expected format</exception>
    /// <remarks>
    /// The ParameterBool is a special case. If the parameter identifier is present on the command line
    ///             the value is true. This requires the value being reset to false before attempting to parse the value
    /// 
    /// </remarks>
    protected override void ParseValue(string value)
    {
      if (!string.IsNullOrEmpty(value))
        throw new FormatException("parameter value is expected to be empty");
      this.Value = true;
    }
  }
}
