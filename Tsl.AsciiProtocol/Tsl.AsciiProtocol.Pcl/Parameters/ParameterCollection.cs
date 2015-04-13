// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ParameterCollection
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tsl.AsciiProtocol.Pcl.Parameters
{
  /// <summary>
  /// Groups a collection of <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.ICommandParameter"/>s into a set to be used as a single <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.IParameterAction"/>s
  /// 
  /// </summary>
  public class ParameterCollection : IParameterAction, IEnumerable<ICommandParameter>, IEnumerable
  {
    /// <summary>
    /// The parameter collection
    /// 
    /// </summary>
    private IDictionary<string, ICommandParameter> parameters;

    /// <summary>
    /// Gets the <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.Parameters.ICommandParameter"/> with the specicifed identifier
    /// 
    /// </summary>
    /// <param name="parameterIdentifier">The character(s) used to identify the required parameter on the command line</param>
    /// <returns>
    /// The requested parameter
    /// </returns>
    public ICommandParameter this[string parameterIdentifier]
    {
      get
      {
        return this.parameters[parameterIdentifier];
      }
    }

    /// <summary>
    /// Initializes a new instance of the ParameterCollection class
    /// 
    /// </summary>
    public ParameterCollection()
    {
      this.parameters = (IDictionary<string, ICommandParameter>) new Dictionary<string, ICommandParameter>();
    }

    /// <summary>
    /// Adds a parameter to the set
    /// 
    /// </summary>
    /// <param name="value">The parameter to add</param>
    public void Add(ICommandParameter value)
    {
      this.parameters.Add(value.ParameterIdentifier, value);
    }

    /// <summary>
    /// Add parameters to the set
    /// 
    /// </summary>
    /// <param name="values">The parameters to add</param>
    public void AddRange(IEnumerable<ICommandParameter> values)
    {
      foreach (ICommandParameter commandParameter in values)
        this.Add(commandParameter);
    }

    /// <summary>
    /// Appends the parameters to the command line as required
    /// 
    /// </summary>
    /// <param name="line">The builder for the command line</param>
    /// <remarks>
    /// Most parameters have a not specified value which if set do not get output to the command line
    /// 
    /// </remarks>
    public void AppendToCommandLine(StringBuilder line)
    {
      foreach (IParameterAction parameterAction in this)
        parameterAction.AppendToCommandLine(line);
    }

    /// <summary>
    /// Returns true if parameter is successfully parsed as a parameter value
    /// 
    /// </summary>
    /// <param name="parameter">The parameter to parse</param>
    /// <returns>
    /// True if a parameter was matched and parsed successfully. False otherwise
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">If the value is outside the permitted range</exception><exception cref="T:System.FormatException">If the parameter is not in the expected format</exception>
    public bool ParseParameter(string parameter)
    {
      bool flag = false;
      foreach (IParameterAction parameterAction in this)
      {
        if (parameterAction.ParseParameter(parameter))
        {
          flag = true;
          break;
        }
      }
      return flag;
    }

    /// <summary>
    /// Removes a parameter from the set
    /// 
    /// </summary>
    /// <param name="parameterIdentifier">The character(s) used to identify the required parameter on the command line
    ///             </param>
    /// <returns>
    /// True if the parameter was removed
    /// </returns>
    public bool Remove(string parameterIdentifier)
    {
      return this.parameters.Remove(parameterIdentifier);
    }

    /// <summary>
    /// Resets the parameters to their reset values
    /// 
    /// </summary>
    public void Reset()
    {
      foreach (IParameterAction parameterAction in this)
        parameterAction.Reset();
    }

    /// <summary>
    /// Returns an enumerator to iterate through the parameters
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The enumerator
    /// </returns>
    public IEnumerator<ICommandParameter> GetEnumerator()
    {
      return this.parameters.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }
  }
}
