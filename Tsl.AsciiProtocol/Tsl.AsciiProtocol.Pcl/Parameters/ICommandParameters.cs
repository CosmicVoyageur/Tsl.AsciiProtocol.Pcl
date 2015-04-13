// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Parameters.ICommandParameters
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2.Parameters
{
  /// <summary>
  /// Parameters for generic control of ASCII commands
  /// 
  /// </summary>
  public interface ICommandParameters
  {
    /// <summary>
    /// Gets or sets a value indicating whether the command should request the response
    ///             includes a list of supported parameters and their current values
    /// 
    /// </summary>
    bool ReadParameters { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the command should reset all its parameters to default values
    /// 
    /// </summary>
    bool ResetParameters { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the command primary action should not be performed
    ///             (e.g. InventoryCommand will not perform the inventory action)
    ///             All other actions, such as setting parameters in the reader are performed
    /// 
    /// </summary>
    bool TakeNoAction { get; set; }
  }
}
