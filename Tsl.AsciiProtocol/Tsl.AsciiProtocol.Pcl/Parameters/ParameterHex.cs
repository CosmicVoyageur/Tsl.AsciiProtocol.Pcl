// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ParameterHex
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Tsl.AsciiProtocol.Pcl.Parameters
{
  /// <summary>
  /// Represents a parameter on the command line that is represented as an ASCII hex string
  /// 
  /// </summary>
  public class ParameterHex : ParameterText
  {
    /// <summary>
    /// Characters that can be used to make up the hex value
    /// 
    /// </summary>
    private static char[] hexCharacters = new char[22]
    {
      '0',
      '1',
      '2',
      '3',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9',
      'a',
      'b',
      'c',
      'd',
      'e',
      'f',
      'A',
      'B',
      'C',
      'D',
      'E',
      'F'
    };

    /// <summary>
    /// Initializes a new instance of the ParameterHex class
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) that identify the parameter on the command line</param><param name="minimumLength">The minimum length of the string</param><param name="maximumLength">The maximum length of the string</param>
    public ParameterHex(string identifier, int minimumLength, int maximumLength)
      : base(identifier, minimumLength, maximumLength)
    {
    }

    /// <summary>
    /// Checks the value is valid as the Value property is assigned
    /// 
    /// </summary>
    /// <param name="value">The value to check</param>
    /// <returns>
    /// The checked value
    /// </returns>
    protected override string CheckValue(string value)
    {
      base.CheckValue(value);
      if (!string.IsNullOrEmpty(value))
      {
        if (value.Length % 2 != 0)
          throw new ArgumentException("value must be a even number of characters to represent a hex string");
        foreach (char ch in value)
        {
          if (!Enumerable.Contains<char>((IEnumerable<char>) ParameterHex.hexCharacters, ch))
            throw new ArgumentException("value contains a non-hex character " + (object) ch);
        }
      }
      return value;
    }
  }
}
