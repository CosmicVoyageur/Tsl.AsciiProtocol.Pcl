// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ICommandParameter
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Defines a command line parameter for a command
  /// 
  /// </summary>
  public interface ICommandParameter : IParameterAction
  {
    /// <summary>
    /// Gets the character(s) used to identify the parameter on the command line
    /// 
    /// </summary>
    string ParameterIdentifier { get; }

    /// <summary>
    /// Gets the type of the <see cref="P:PortableAscii2.Parameters.ICommandParameter.ParameterValue"/>
    /// </summary>
    Type ParameterType { get; }

    /// <summary>
    /// Gets or sets the current value of the parameter
    /// 
    /// </summary>
    object ParameterValue { get; set; }
  }
}
