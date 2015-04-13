// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Constants
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Globalization;

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// Global constants for the library
  /// 
  /// </summary>
  public static class Constants
  {
    /// <summary>
    /// Gets the format provider to use for number and string parsing
    /// 
    /// </summary>
    public static IFormatProvider CommandFormatProvider
    {
      get
      {
        return (IFormatProvider) CultureInfo.InvariantCulture;
      }
    }

    /// <summary>
    /// Gets the format provider to use for log message formatting
    /// 
    /// </summary>
    public static IFormatProvider LogFormatProvider
    {
      get
      {
        return (IFormatProvider) CultureInfo.InvariantCulture;
      }
    }

    /// <summary>
    /// Gets the format provider to use for exception message formatting
    /// 
    /// </summary>
    public static IFormatProvider ErrorFormatProvider
    {
      get
      {
        return (IFormatProvider) CultureInfo.CurrentUICulture;
      }
    }
  }
}
