// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.IParameterAction
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.Text;

namespace Tsl.AsciiProtocol.Pcl.Parameters
{
  /// <summary>
  /// Defines actions common to all parameters to read from or write to a command line
  /// 
  /// </summary>
  public interface IParameterAction
  {
    /// <summary>
    /// Appends the parameter to the command line as required
    /// 
    /// </summary>
    /// <param name="line">The builder for the command line</param>
    /// <remarks>
    /// Most parameters have a not specified value which if set do not get output to the command line
    /// 
    /// </remarks>
    void AppendToCommandLine(StringBuilder line);

    /// <summary>
    /// Resets the parameter to its not specified value
    /// 
    /// </summary>
    void Reset();

    /// <summary>
    /// Parse the string to extract the parameter value
    /// 
    /// </summary>
    /// <param name="parameter">The parameter to parse</param>
    /// <returns>
    /// True if the parameter is for this instance and the value was parsed successfully. False otherwise
    /// 
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">If the value is outside the permitted range</exception><exception cref="T:System.FormatException">If the parameter is not in the expected format</exception>
    bool ParseParameter(string parameter);
  }
}
