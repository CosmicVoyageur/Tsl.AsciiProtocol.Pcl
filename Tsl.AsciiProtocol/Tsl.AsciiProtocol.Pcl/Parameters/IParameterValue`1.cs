// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.IParameterValue`1
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace Tsl.AsciiProtocol.Pcl.Parameters
{
  /// <summary>
  /// Represents a command line parameter for a command
  /// 
  /// </summary>
  /// <typeparam name="TParameter">The value of the parameter</typeparam>
  public interface IParameterValue<TParameter>
  {
    /// <summary>
    /// Gets or sets the current value of the parameter
    /// 
    /// </summary>
    TParameter Value { get; set; }
  }
}
