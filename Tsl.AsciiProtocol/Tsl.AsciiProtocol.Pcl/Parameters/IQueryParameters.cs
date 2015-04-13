// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.IQueryParameters
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Specifies properties to select transponders into distinct groups
  /// 
  /// </summary>
  public interface IQueryParameters
  {
    /// <summary>
    /// Gets or sets the transponders to include based on the select flag state
    /// 
    /// </summary>
    QuerySelect? QuerySelect { get; set; }

    /// <summary>
    /// Gets or sets the transponders to include based on the select flag state
    /// 
    /// </summary>
    QuerySession? QuerySession { get; set; }

    /// <summary>
    /// Gets or sets the session state of the transponders to be included in this operation
    /// 
    /// </summary>
    QueryTarget? QueryTarget { get; set; }
  }
}
