// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.IAsciiResponse
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.Collections.Generic;

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// A response to as <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommand"/>
  /// </summary>
  public interface IAsciiResponse
  {
    /// <summary>
    /// Gets the error code or an empty string if none
    /// 
    /// </summary>
    string ErrorCode { get; }

    /// <summary>
    /// Gets a value indicating whether the command executed successfully
    /// 
    /// </summary>
    bool IsSuccessful { get; }

    /// <summary>
    /// Gets the messages received from the last response
    /// 
    /// </summary>
    IEnumerable<string> Messages { get; }

    /// <summary>
    /// Gets the parameters received from the last responde
    /// 
    /// </summary>
    IEnumerable<string> Parameters { get; }

    /// <summary>
    /// Gets all the lines as received from the last response
    /// 
    /// </summary>
    IEnumerable<IAsciiResponseLine> Response { get; }
  }
}
