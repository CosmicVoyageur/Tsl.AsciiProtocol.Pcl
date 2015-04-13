// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.IResponseParameters
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace Tsl.AsciiProtocol.Pcl.Parameters
{
  /// <summary>
  /// Generic parameters for command responses
  /// 
  /// </summary>
  public interface IResponseParameters
  {
    /// <summary>
    /// Gets or sets a value indicating whether DateTime stamps appear in reader responses
    /// 
    /// </summary>
    TriState? IncludeDateTime { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether alerts are enabled for the executing commands
    /// 
    /// </summary>
    TriState? UseAlert { get; set; }
  }
}
