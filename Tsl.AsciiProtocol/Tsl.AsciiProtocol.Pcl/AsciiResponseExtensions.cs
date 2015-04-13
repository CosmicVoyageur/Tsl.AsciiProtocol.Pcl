// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AsciiResponseExtensions
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// Extensions methods for the <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.IAsciiResponseLine"/>
  /// </summary>
  public static class AsciiResponseExtensions
  {
    /// <summary>
    /// Returns a value indicating whether the line has the specified header
    /// 
    /// </summary>
    /// <param name="line">The line to test</param><param name="header">The header to test for (e.g. ME)</param>
    /// <returns>
    /// True if the line has the specified header
    /// </returns>
    public static bool HasHeader(this IAsciiResponseLine line, string header)
    {
      if (line != null)
        return line.Header.Equals(header, StringComparison.OrdinalIgnoreCase);
      return false;
    }

    /// <summary>
    /// Returns a value indicating whether the line has an "CS" header
    /// 
    /// </summary>
    /// <param name="line">The line to test</param>
    /// <returns>
    /// True if the line starts with the CS header
    /// </returns>
    public static bool IsCommandStarted(this IAsciiResponseLine line)
    {
      return AsciiResponseExtensions.HasHeader(line, "CS");
    }

    /// <summary>
    /// Returns a value indicating whether the line has an "ER" header
    /// 
    /// </summary>
    /// <param name="line">The line to test</param>
    /// <returns>
    /// True if the line starts with the ER header
    /// </returns>
    public static bool IsError(this IAsciiResponseLine line)
    {
      return AsciiResponseExtensions.HasHeader(line, "ER");
    }

    /// <summary>
    /// Returns a value indicating whether the line has an "OK" header
    /// 
    /// </summary>
    /// <param name="line">The line to test</param>
    /// <returns>
    /// True if the line starts with the OK header
    /// </returns>
    public static bool IsOk(this IAsciiResponseLine line)
    {
      return AsciiResponseExtensions.HasHeader(line, "OK");
    }

    /// <summary>
    /// Returns a value indicating whether the line has an "PR" header
    /// 
    /// </summary>
    /// <param name="line">The line to test</param>
    /// <returns>
    /// True if the line starts with the PR header
    /// </returns>
    public static bool IsParameters(this IAsciiResponseLine line)
    {
      return AsciiResponseExtensions.HasHeader(line, "PR");
    }

    /// <summary>
    /// Returns a value indication whether the line has an "ME" header
    /// 
    /// </summary>
    /// <param name="line">The line to test</param>
    /// <returns>
    /// True if the line starts with the ME header
    /// </returns>
    public static bool IsMessage(this IAsciiResponseLine line)
    {
      return AsciiResponseExtensions.HasHeader(line, "ME");
    }

    /// <summary>
    /// Returns the value of the first line in the response with the specified header or null if header is not found
    /// 
    /// </summary>
    /// <param name="response">The response to search</param><param name="header">The header to search for</param>
    /// <returns>
    /// The value of the line or null (Nothing in visual basic) if a line with that header is not found
    /// </returns>
    public static string ValueByHeader(this IAsciiResponse response, string header)
    {
      return Enumerable.FirstOrDefault<string>(Enumerable.Select<IAsciiResponseLine, string>(Enumerable.Where<IAsciiResponseLine>(response.Response, (Func<IAsciiResponseLine, bool>) (x => AsciiResponseExtensions.HasHeader(x, header))), (Func<IAsciiResponseLine, string>) (x => x.Value)));
    }

    /// <summary>
    /// Returns the value of the first line in the response with the specified header or string.Empty if header is not found
    /// 
    /// </summary>
    /// <param name="response">The response to search</param><param name="header">The header to search for</param>
    /// <returns>
    /// The value of the line or "" if a line with that header is not found
    /// </returns>
    public static string ValueByHeaderText(this IAsciiResponse response, string header)
    {
      return AsciiResponseExtensions.ValueByHeader(response, header) ?? string.Empty;
    }

    /// <summary>
    /// Returns the value of the first line in the response with the specified header parsed as a date and or time
    ///             or DateTime.MinValue if header is not found
    /// 
    /// </summary>
    /// <param name="response">The response to search</param><param name="header">The header to search for</param>
    /// <returns>
    /// The value of the line or DateTime.MinValue if a line with that header is not found
    /// </returns>
    public static DateTime ValueByHeaderDateTime(this IAsciiResponse response, string header)
    {
      string s = AsciiResponseExtensions.ValueByHeaderText(response, header);
      bool flag1 = s.IndexOf("-", StringComparison.OrdinalIgnoreCase) > 0;
      bool flag2 = s.IndexOf(":", StringComparison.OrdinalIgnoreCase) > 0;
      return !flag1 || !flag2 ? (!flag1 ? (!flag2 ? DateTime.MinValue : DateTime.ParseExact(s, "hh:mm:ss", Constants.CommandFormatProvider)) : DateTime.ParseExact(s, "yyyy-MM-dd", Constants.CommandFormatProvider)) : DateTime.ParseExact(s, "s", Constants.CommandFormatProvider);
    }

    /// <summary>
    /// Returns the value of the first line in the response with the specified header parsed as a number
    /// 
    /// </summary>
    /// <param name="response">The response to search</param><param name="header">The header to search for</param>
    /// <returns>
    /// The value of the line or DateTime.MinValue if a line with that header is not found
    /// </returns>
    public static int ValueByHeaderNumber(this IAsciiResponse response, string header)
    {
      string s = AsciiResponseExtensions.ValueByHeaderText(response, header);
      if (s.EndsWith("%", StringComparison.OrdinalIgnoreCase))
        s = s.Substring(0, s.Length - 1);
      return int.Parse(s, Constants.CommandFormatProvider);
    }

    /// <summary>
    /// Returns the value of the first line in the response with the specified header parsed as the Enum type specified
    /// 
    /// </summary>
    /// <typeparam name="TEnum">The Enum type expected</typeparam><param name="response">The response to search</param><param name="header">The header to search for</param>
    /// <returns>
    /// The value of the line
    /// </returns>
    public static TEnum ValueByHeader<TEnum>(this IAsciiResponse response, string header)
    {
      string str = AsciiResponseExtensions.ValueByHeaderText(response, header);
      if (!string.IsNullOrEmpty(str))
        return (TEnum) Enum.Parse(typeof (TEnum), str, true);
      return default (TEnum);
    }

    /// <summary>
    /// Adds the header specified to the list of AcceptedHeaders
    /// 
    /// </summary>
    /// <param name="response">The response that will accept the header</param><param name="header">The header to add</param>
    public static void AddHeader(this IAsciiResponseResponder response, string header)
    {
      if (response.AcceptedHeaders.Contains(header))
        return;
      response.AcceptedHeaders.Add(header);
    }

    /// <summary>
    /// Adds the headers specified to the list of AcceptedHeaders
    /// 
    /// </summary>
    /// <param name="response">The response that will accept the headers</param><param name="headers">The accepted headers</param>
    public static void AddHeaders(this IAsciiResponseResponder response, IEnumerable<string> headers)
    {
      foreach (string str in headers)
      {
        string header = str.Trim();
        if (!string.IsNullOrEmpty(header) && header.Length == 2)
          AsciiResponseExtensions.AddHeader(response, header);
      }
    }

    /// <summary>
    /// Adds the comma, colon and/or space separated two-character headers to AcceptedHeaders
    /// 
    /// </summary>
    /// <param name="response">The response that will accept the headers</param><param name="headers">The accepted headers</param>
    public static void AddHeaders(this IAsciiResponseResponder response, string headers)
    {
      AsciiResponseExtensions.AddHeaders(response, (IEnumerable<string>) headers.Split(new char[3]
      {
        ',',
        ':',
        ' '
      }));
    }
  }
}
