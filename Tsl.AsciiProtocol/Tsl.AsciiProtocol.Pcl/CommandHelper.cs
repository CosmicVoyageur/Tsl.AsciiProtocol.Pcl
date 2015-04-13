// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.CommandHelper
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PortableAscii2
{
  /// <summary>
  /// Provides utilty methods for helping with commands
  /// 
  /// </summary>
  public static class CommandHelper
  {
    /// <summary>
    /// Parses a command line or PR: value and outputs the parameters in the case where a single -s parameter is expected
    ///             Returns validation messages for any errors encountered
    /// 
    /// </summary>
    /// <param name="parameterLine">The parameters to parse</param><param name="parameters">output the parameter line split into individual parameters</param>
    /// <returns>
    /// Any validtion messages arising from parsing the parameter line
    /// </returns>
    /// <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Commands.SwitchSinglePressUserActionCommand"/><see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Commands.SwitchDoublePressUserActionCommand"/>
    public static ICollection<string> ValidateAndParseSwitchParameter(string parameterLine, out IEnumerable<string> parameters)
    {
      List<string> list = new List<string>();
      Match match = Regex.Match(parameterLine, "^[^\\r\\n-]*(?<switch>-s)[ \\t]*(?<command>\\.[a-z]{2}[^\\r\\n]*)?");
      ICollection<string> collection;
      if (!match.Success)
      {
        list.Add(parameterLine);
        collection = (ICollection<string>) new string[0];
      }
      else if (match.Groups.Count == 3)
      {
        int index = match.Groups["switch"].Index;
        string str1 = parameterLine.Substring(0, index).Trim();
        if (!string.IsNullOrEmpty(str1))
          list.Add(str1);
        string str2 = parameterLine.Substring(index + 2).Trim();
        if (!string.IsNullOrEmpty(str2))
          list.Add(str2);
        collection = (ICollection<string>) new string[0];
      }
      else
      {
        list.Add(parameterLine);
        collection = (ICollection<string>) new string[1]
        {
          "command supports only a single -s parameter which is a valid command"
        };
      }
      parameters = (IEnumerable<string>) list;
      return collection;
    }

    /// <summary>
    /// Splits the given line into parameters separated by '-' but preserving quoted ("like - this") strings
    /// 
    /// </summary>
    /// <param name="value">The parameters to parse</param>
    /// <returns>
    /// The individual parameters parsed from the line
    /// </returns>
    public static ICollection<string> SplitParameters(string value)
    {
      List<string> list = new List<string>();
      if (value != null)
      {
        if (value.IndexOf('"') < 0)
        {
          string str1 = value;
          char[] chArray = new char[1]
          {
            '-'
          };
          foreach (string str2 in str1.Split(chArray))
          {
            string str3 = str2.Trim();
            if (!string.IsNullOrEmpty(str3))
              list.Add(str3);
          }
        }
        else
        {
          int startIndex = 0;
          string str1 = string.Empty;
          int index = CommandHelper.NextQuoteDash(value, startIndex);
          while (startIndex < value.Length)
          {
            if (index < 0)
            {
              string str2 = value.Substring(startIndex).Trim();
              if (!string.IsNullOrEmpty(str2))
                list.Add(str2);
              startIndex = value.Length;
            }
            else if ((int) value[index] == 34)
            {
              index = value.IndexOf('"', index + 1);
              if (index >= 0)
                index = CommandHelper.NextQuoteDash(value, index + 1);
            }
            else if ((int) value[index] == 39)
            {
              index = value.IndexOf('\'', index + 1);
              if (index >= 0)
                index = CommandHelper.NextQuoteDash(value, index + 1);
            }
            else
            {
              string str2 = value.Substring(startIndex, index - startIndex).Trim();
              if (!string.IsNullOrEmpty(str2))
                list.Add(str2);
              startIndex = index + 1;
              index = CommandHelper.NextQuoteDash(value, startIndex);
            }
          }
        }
      }
      return (ICollection<string>) list;
    }

    /// <summary>
    /// Returns the index of the next quote, double quote or dash in value after strartIndex
    /// 
    /// </summary>
    /// <param name="value">The string to search</param><param name="startIndex">The index to search from</param>
    /// <returns>
    /// The index of the first character found after startIndex or -1 if no character found
    /// </returns>
    private static int NextQuoteDash(string value, int startIndex)
    {
      char[] chArray = new char[3]
      {
        '\'',
        '"',
        '-'
      };
      int num1 = int.MaxValue;
      for (int index = 0; index < chArray.Length; ++index)
      {
        int num2 = value.IndexOf(chArray[index], startIndex);
        if (num2 >= 0 && num2 < num1)
          num1 = num2;
      }
      if (num1 != int.MaxValue)
        return num1;
      return -1;
    }
  }
}
