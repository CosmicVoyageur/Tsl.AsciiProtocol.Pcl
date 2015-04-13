// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ParameterBase`1
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

//using log4net;

using System;
using System.Globalization;
using System.Text;

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Base class for parameters
  /// 
  /// </summary>
  /// <typeparam name="TParameter">The value type for the parameter</typeparam>
  public abstract class ParameterBase<TParameter> : IParameterAndValue<TParameter>, IParameterValue<TParameter>, ICommandParameter, IParameterAction
  {
    /// <summary>
    /// Provides logging for this class
    /// 
    /// </summary>
    //private static ILog log = LogManager.GetLogger(typeof (ParameterBase<TParameter>));
    /// <summary>
    /// The current value of the parameter
    /// 
    /// </summary>
    private TParameter value;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Parameters.ParameterBase`1.ParameterFormat"/>
    /// </summary>
    private string parameterFormat;

    /// <summary>
    /// Gets the value that represnts the NotSpecified value.
    ///             i.e. When equal to this value the parameter does not get sent to the reader
    /// 
    /// </summary>
    public TParameter NotSpecifiedValue { get; private set; }

    /// <summary>
    /// Gets the character(s) that identify this parameter on the command line (e.g. "qs" for "-qs" query select)
    /// 
    /// </summary>
    public string ParameterIdentifier { get; private set; }

    /// <summary>
    /// Gets or sets the format string to write this parameter to the command line.
    ///             By default this is " -{0}{1}" to insert the swtich followed by <see cref="P:PortableAscii2.Parameters.ParameterBase`1.ParameterIdentifier"/> then <see cref="P:PortableAscii2.Parameters.ParameterBase`1.Value"/>
    /// </summary>
    public string ParameterFormat
    {
      get
      {
        return this.parameterFormat;
      }
      set
      {
        try
        {
          string.Format(Constants.CommandFormatProvider, value, new object[2]
          {
            (object) this.ParameterIdentifier,
            (object) this.NotSpecifiedValue
          });
        }
        catch (FormatException ex)
        {
          throw new ArgumentException("parameterFormat is not a valid format string", (Exception) ex);
        }
        this.parameterFormat = value;
      }
    }

    /// <summary>
    /// Gets or sets the current value of the parameter
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Override <see cref="M:PortableAscii2.Parameters.ParameterBase`1.CheckValue(`0)"/> and throw an ArgumentOutOrRangeException to ensure it is set to a correct value
    /// 
    /// </remarks>
    public TParameter Value
    {
      get
      {
        return this.value;
      }
      set
      {
        this.value = this.CheckValue(value);
      }
    }

    /// <summary>
    /// Gets the type of the <see cref="P:PortableAscii2.Parameters.ParameterBase`1.ParameterValue"/>
    /// </summary>
    public Type ParameterType
    {
      get
      {
        return typeof (TParameter);
      }
    }

    /// <summary>
    /// Gets or sets the current value of the parameter
    /// 
    /// </summary>
    public object ParameterValue
    {
      get
      {
        return (object) this.Value;
      }
      set
      {
        this.Value = (TParameter) value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the ParameterBase class
    /// 
    /// </summary>
    /// <param name="identifier">The character(s) that identify the parameter on the command line</param><param name="notSpecifiedValue">The value for the parameter when it should not be output to the command line</param>
    protected ParameterBase(string identifier, TParameter notSpecifiedValue)
    {
      if (string.IsNullOrEmpty(identifier))
        throw new ArgumentNullException("identifier");
      this.NotSpecifiedValue = notSpecifiedValue;
      this.ParameterIdentifier = identifier;
      this.ParameterFormat = " -{0}{1}";
      this.value = this.NotSpecifiedValue;
    }

    /// <summary>
    /// Appends the parameter to the command line if the current value is not <see cref="P:PortableAscii2.Parameters.ParameterBase`1.NotSpecifiedValue"/>
    /// </summary>
    /// <param name="line">The builder for the command line</param>
    public virtual void AppendToCommandLine(StringBuilder line)
    {
      if ((object) this.Value == null || this.Value.Equals((object) this.NotSpecifiedValue))
        return;
      line.AppendFormat(Constants.CommandFormatProvider, this.ParameterFormat, new object[2]
      {
        (object) this.ParameterIdentifier,
        (object) this.Value
      });
    }

    /// <summary>
    /// Resets the parameter to not specified
    /// 
    /// </summary>
    public void Reset()
    {
      this.value = this.NotSpecifiedValue;
    }

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
    public bool ParseParameter(string parameter)
    {
      bool flag = false;
      try
      {
        if (parameter.StartsWith(this.ParameterIdentifier, StringComparison.Ordinal))
        {
          string str = parameter.Substring(this.ParameterIdentifier.Length).Trim();
          //ParameterBase<TParameter>.log.DebugFormat("ParseParameter+ '{0}' value='{1}'", (object) parameter, (object) str);
          this.ParseValue(str);
          flag = true;
        }
      }
      catch (ArgumentOutOfRangeException ex)
      {
        //ParameterBase<TParameter>.log.Error((object) "ParseParameter ArgumentOutOfRangeException", (Exception) ex);
        throw new ArgumentOutOfRangeException(this.ParameterFailMessage(ex.Message, parameter), (Exception) ex);
      }
      catch (FormatException ex)
      {
        //ParameterBase<TParameter>.log.Error((object) "ParseParameter FormatException", (Exception) ex);
        throw new FormatException(this.ParameterFailMessage(ex.Message, parameter), (Exception) ex);
      }
      return flag;
    }

    /// <summary>
    /// Attempt to parse the value from the command line and assign value to the parsed value
    /// 
    /// </summary>
    /// <param name="value">The value to parse</param><exception cref="T:System.ArgumentOutOfRangeException">If the value is outside the permitted range</exception><exception cref="T:System.FormatException">If the parameter is not in the expected format</exception>
    protected abstract void ParseValue(string value);

    /// <summary>
    /// When overridden in derived classes should check that the value is appropriate. Called when the <see cref="P:PortableAscii2.Parameters.ParameterBase`1.Value"/>
    ///             property is assigned.
    /// 
    /// </summary>
    /// <param name="value">The new value</param>
    /// <returns>
    /// The value to assign to the property
    /// </returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">If the value is out of range or accepted values</exception>
    protected virtual TParameter CheckValue(TParameter value)
    {
      return value;
    }

    /// <summary>
    /// Returns a human readable error message to display to the user
    /// 
    /// </summary>
    /// <param name="reason">The error message thrown when the parameter is parsed</param><param name="parameterValue">The value that throw an exception</param>
    /// <returns>
    /// The error message
    /// </returns>
    private string ParameterFailMessage(string reason, string parameterValue)
    {
      return string.Format((IFormatProvider) CultureInfo.CurrentUICulture, "'{0}' is not valid for -{1}. {2}", (object) parameterValue, (object) this.ParameterIdentifier, (object) reason);
    }
  }
}
