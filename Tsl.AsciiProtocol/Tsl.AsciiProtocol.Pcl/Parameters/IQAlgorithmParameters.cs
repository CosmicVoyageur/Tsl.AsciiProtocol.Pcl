// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.IQAlgorithmParameters
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace Tsl.AsciiProtocol.Pcl.Parameters
{
  /// <summary>
  /// Provides properties to control the Q algorithm and value
  /// 
  /// </summary>
  public interface IQAlgorithmParameters
  {
    /// <summary>
    /// Gets or sets the Q algorithm type
    /// 
    /// </summary>
    QAlgorithm? QAlgorithm { get; set; }

    /// <summary>
    /// Gets or sets the Q value for fixed Q operations (0-15)
    /// 
    /// </summary>
    int? QValue { get; set; }
  }
}
