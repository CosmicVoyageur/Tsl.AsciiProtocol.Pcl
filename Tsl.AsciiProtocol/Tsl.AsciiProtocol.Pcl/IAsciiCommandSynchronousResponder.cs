// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommandSynchronousResponder
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

//using TechnologySolutions.Rfid.AsciiProtocol;


namespace PortableAscii2
{
  /// <summary>
  /// Extends <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommandResponder"/> to provide properties and methods required for synchronous execution
  /// 
  /// </summary>
  public interface IAsciiCommandSynchronousResponder : IAsciiCommandResponder
  {
    /// <summary>
    /// Gets a value indicating whether the response is complete (i.e. received OK: or ER:)
    /// 
    /// </summary>
    bool IsResponseFinished { get; }

    /// <summary>
    /// Clears the values from the last response
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Derived classes must call super class to ensure correct operation
    /// 
    /// </remarks>
    void ClearLastResponse();
  }
}
