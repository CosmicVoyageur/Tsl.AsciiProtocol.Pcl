// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.EnumExtensionAttribute
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace PortableAscii2
{
  /// <summary>
  /// An attribute to extend an Enum value to have a parameter and description
  /// 
  /// </summary>
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
  public sealed class EnumExtensionAttribute : Attribute
  {
    /// <summary>
    /// Gets the parameter for the value
    /// 
    /// </summary>
    public string Parameter { get; private set; }

    /// <summary>
    /// Gets the description for the value
    /// 
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Initializes a new instance of the EnumExtensionAttribute class
    /// 
    /// </summary>
    /// <param name="parameter">The parameter equivalent for the value</param><param name="description">The description of the value</param>
    public EnumExtensionAttribute(string parameter, string description)
    {
      this.Parameter = parameter;
      this.Description = description;
    }
  }
}
