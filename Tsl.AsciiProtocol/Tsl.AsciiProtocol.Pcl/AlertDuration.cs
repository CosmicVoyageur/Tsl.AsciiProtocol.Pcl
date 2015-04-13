// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AlertDuration
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll


namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// The set of values that are appropriate for the <see cref="P:TechnologySolutions.Rfid.AsciiProtocol.Commands.AlertCommand.AlertDuration"/>
  /// </summary>
  public enum AlertDuration
  {
    [EnumExtension("sho", "Short")] Short,
    [EnumExtension("med", "Medium")] Medium,
    [EnumExtension("lon", "Long")] Long,
  }
}
