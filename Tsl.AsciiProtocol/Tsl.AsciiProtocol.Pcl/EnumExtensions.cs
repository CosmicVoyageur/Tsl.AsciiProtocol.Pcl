// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.EnumExtensions
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

//using log4net;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PortableAscii2
{
  /// <summary>
  /// Extension methods for the parameter Enums
  /// 
  /// </summary>
  public static class EnumExtensions
  {
    /// <summary>
    /// Provides logging for this class
    /// 
    /// </summary>
    //private static ILog log = LogManager.GetLogger(typeof (EnumExtensions));
    /// <summary>
    /// Holds a cache of all the values of all the enums where the values have the <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.EnumExtensionAttribute"/>
    /// </summary>
    private static IEnumerable<EnumExtensions.ReflectedEnumValue> values;

    /// <summary>
    /// Gets all the values of all the enums where the values have the <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.EnumExtensionAttribute"/>
    /// </summary>
    private static IEnumerable<EnumExtensions.ReflectedEnumValue> Values
    {
      get
      {
        if (EnumExtensions.values == null)
          EnumExtensions.values = EnumExtensions.ReflectValues();
        return EnumExtensions.values;
      }
    }

    /// <summary>
    /// Returns the first value of the specified enum type that has a matching parameter
    /// 
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum required</typeparam><param name="parameter">The parameter value to match</param>
    /// <returns>
    /// The first value in the enum that has a matching parameter
    /// </returns>
    /// <exception cref="T:System.FormatException">If parameter is not recognised for that enum</exception>
    public static TEnum ParseParameterAs<TEnum>(this string parameter)
    {
      parameter = parameter.Trim();
      Type enumType = typeof (TEnum);
      foreach (EnumExtensions.ReflectedEnumValue reflectedEnumValue in Enumerable.Where<EnumExtensions.ReflectedEnumValue>(EnumExtensions.Values, (Func<EnumExtensions.ReflectedEnumValue, bool>) (x => x.EnumType.Equals(enumType))))
      {
        if (reflectedEnumValue.Parameter.Equals(parameter))
          return (TEnum) reflectedEnumValue.Value;
      }
      throw new FormatException(string.Format(Constants.ErrorFormatProvider, "Parameter '{0}' is not a value of Enum {1}", new object[2]
      {
        (object) parameter,
        (object) enumType.Name
      }));
    }

    /// <summary>
    /// Returns a value indicating whether value is defined in the Enum
    /// 
    /// </summary>
    /// <param name="value">The value to test</param>
    /// <returns>
    /// True if the value is defined in the Enum
    /// </returns>
    public static bool IsValid(this Enum value)
    {
      return Enum.IsDefined(value.GetType(), (object) value);
    }

    /// <summary>
    /// Throws an ArgumentOutOfRangeException is value is not one of the values of the enum
    /// 
    /// </summary>
    /// <param name="value">The value to test</param><exception cref="T:System.ArgumentOutOfRangeException">If value is not a defined value</exception>
    public static void Validate(this Enum value)
    {
      if (!EnumExtensions.IsValid(value))
        throw new ArgumentOutOfRangeException("value", string.Format(Constants.ErrorFormatProvider, "{0} is not a valid value for {1}", new object[2]
        {
          (object) value,
          (object) value.GetType().Name
        }));
    }

    /// <summary>
    /// Returns the parameter for the specified value
    /// 
    /// </summary>
    /// <param name="value">The value of interest</param>
    /// <returns>
    /// The parameter for the value
    /// </returns>
    public static string Parameter(this Enum value)
    {
      EnumExtensions.ReflectedEnumValue reflectedEnumValue = Enumerable.First<EnumExtensions.ReflectedEnumValue>(Enumerable.Where<EnumExtensions.ReflectedEnumValue>(EnumExtensions.Values, (Func<EnumExtensions.ReflectedEnumValue, bool>) (x => x.Value.Equals((object) value))));
      if (!reflectedEnumValue.Value.Equals((object) value))
        throw new NotSupportedException(string.Format(Constants.ErrorFormatProvider, "Enum {0} value {1} does not have a parameter", new object[2]
        {
          (object) value.GetType().Name,
          (object) value
        }));
      return reflectedEnumValue.Parameter;
    }

    /// <summary>
    /// Returns the desctription for the specified value
    /// 
    /// </summary>
    /// <param name="value">The value of interest</param>
    /// <returns>
    /// The description for the value
    /// </returns>
    public static string Description(this Enum value)
    {
      EnumExtensions.ReflectedEnumValue reflectedEnumValue = Enumerable.First<EnumExtensions.ReflectedEnumValue>(Enumerable.Where<EnumExtensions.ReflectedEnumValue>(EnumExtensions.Values, (Func<EnumExtensions.ReflectedEnumValue, bool>) (x => x.Value.Equals((object) value))));
      if (!reflectedEnumValue.Value.Equals((object) value))
        throw new NotSupportedException(string.Format(Constants.ErrorFormatProvider, "Enum {0} value {1} does not have a description", new object[2]
        {
          (object) value.GetType().Name,
          (object) value
        }));
      return reflectedEnumValue.Description;
    }

    /// <summary>
    /// Discover all the Enum types in the assembly and build a cache of all Enum values that support the EnumExtensionAttribute
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The Enum values that support the EnumExtensionAttribute
    /// </returns>
    private static IEnumerable<EnumExtensions.ReflectedEnumValue> ReflectValues()
    {
      //EnumExtensions.log.Info((object) "ReflectValues+");
        // changed to Assembly.DefinedTypes
      IEnumerable<Type> enumerable = Enumerable.Where((IEnumerable<Type>) typeof(EnumExtensions).GetTypeInfo().Assembly.DefinedTypes, (x => x.GetTypeInfo().IsEnum));
      List<EnumExtensions.ReflectedEnumValue> list = new List<EnumExtensions.ReflectedEnumValue>();
      foreach (Type type in enumerable)
      {
        //EnumExtensions.log.DebugFormat(Constants.LogFormatProvider, "Check Enum {0}", new object[1]
        //{
        //  (object) type.FullName
        //});
        object obj = (object) null;
        foreach (FieldInfo fieldInfo in type.GetRuntimeFields())
        {
          object[] customAttributes = fieldInfo.GetCustomAttributes(typeof (EnumExtensionAttribute), false).ToArray();
          if (customAttributes.Length > 0)
          {
            if (obj == null)
              obj = Activator.CreateInstance(type);
            EnumExtensionAttribute extensionAttribute = customAttributes[0] as EnumExtensionAttribute;
            EnumExtensions.ReflectedEnumValue reflectedEnumValue = new EnumExtensions.ReflectedEnumValue(type, fieldInfo.GetValue(obj), extensionAttribute.Parameter, extensionAttribute.Description);
            list.Add(reflectedEnumValue);
            //EnumExtensions.log.DebugFormat(Constants.LogFormatProvider, "Add {0}.{1} '{2}' '{3}'", (object) reflectedEnumValue.EnumType.Name, reflectedEnumValue.Value, (object) reflectedEnumValue.Parameter, (object) reflectedEnumValue.Description);
          }
        }
      }
      //EnumExtensions.log.Info((object) "ReflectValues-");
      return (IEnumerable<EnumExtensions.ReflectedEnumValue>) list;
    }

    /// <summary>
    /// Private struct to collect extended information about the parameters enumerations
    /// 
    /// </summary>
    private struct ReflectedEnumValue
    {
      /// <summary>
      /// Gets the Type of the enum value
      /// 
      /// </summary>
      public readonly Type EnumType;
      /// <summary>
      /// Gets the value of the enum value
      /// 
      /// </summary>
      public readonly object Value;
      /// <summary>
      /// Gets the parameter string of the enum value
      /// 
      /// </summary>
      public readonly string Parameter;
      /// <summary>
      /// Gets the description of the enum value
      /// 
      /// </summary>
      public readonly string Description;

      /// <summary>
      /// Initializes a new instance of the ReflectedEnumValue struct
      /// 
      /// </summary>
      /// <param name="enumType">The type of the Enum</param><param name="value">The value of the enum</param><param name="parameter">The value of this enum as a parameter</param><param name="description">The description of this parameter value</param>
      public ReflectedEnumValue(Type enumType, object value, string parameter, string description)
      {
        this.Description = description;
        this.EnumType = enumType;
        this.Parameter = parameter;
        this.Value = value;
      }
    }
  }
}
