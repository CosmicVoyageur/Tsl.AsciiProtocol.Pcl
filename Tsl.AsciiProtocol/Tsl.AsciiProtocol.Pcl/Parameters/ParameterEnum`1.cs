// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ParameterEnum`1
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Text;

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Defines a parameter that is derived from a specific set of values defined by an Enum (with appropriate extensions)
  /// 
  /// </summary>
  /// <typeparam name="TEnum">The type of the enum</typeparam>
  public class ParameterEnum<TEnum> : ParameterBase<TEnum?> where TEnum : struct
  {
    /// <summary>
    /// Initializes a new instance of the ParameterEnum class
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) that identify the parameter on the command line</param>
    public ParameterEnum(string identifier)
      : base(identifier, new TEnum?())
    {
    }

    /// <summary>
    /// Appends the parameter to the command line if the value is not NotSpecified
    /// 
    /// </summary>
    /// <param name="line">The command line to append to</param>
    public override void AppendToCommandLine(StringBuilder line)
    {
      if (!this.Value.HasValue || this.NotSpecifiedValue.Equals((object) this.Value))
        return;
      line.AppendFormat(Constants.CommandFormatProvider, this.ParameterFormat, new object[2]
      {
        (object) this.ParameterIdentifier,
        (object) EnumExtensions.Parameter((ValueType) this.Value.Value as Enum)
      });
    }

    /// <summary>
    /// Attempt to parse the value from the command line and assign value to the parsed value
    /// 
    /// </summary>
    /// <param name="value">The value to parse</param><exception cref="T:System.ArgumentOutOfRangeException">If the value is outside the permitted range</exception><exception cref="T:System.FormatException">If the parameter is not in the expected format</exception>
    protected override void ParseValue(string value)
    {
      this.Value = new TEnum?(EnumExtensions.ParseParameterAs<TEnum>(value));
    }

    /// <summary>
    /// Called when setting value to ensure the new value is valid
    /// 
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <returns>
    /// The new value to store
    /// </returns>
    /// <exception cref="T:System.ArgumentException">If the value assigned is not valid</exception>
    protected override TEnum? CheckValue(TEnum? value)
    {
      if (value.HasValue && !Enum.IsDefined(typeof (TEnum), (object) value.Value))
        throw new ArgumentOutOfRangeException(string.Format(Constants.ErrorFormatProvider, "{0} is not a defined value for {1}", new object[2]
        {
          (object) value,
          (object) typeof (TEnum).Name
        }));
      return value;
    }
  }
}
