// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.SwitchState
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// Defines the switch current state
  /// 
  /// </summary>
  public enum SwitchState
  {
    [EnumExtension("off", "Off")] Off,
    [EnumExtension("single", "Single press")] Single,
    [EnumExtension("double", "Double press")] Double,
  }
}
