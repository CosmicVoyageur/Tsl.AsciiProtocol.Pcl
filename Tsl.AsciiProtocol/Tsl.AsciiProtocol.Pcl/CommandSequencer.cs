// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.CommandSequencer
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

namespace PortableAscii2
{
  /// <summary>
  /// Provides a unique command identifier for each command sent (where commands are indexed)
  /// 
  /// </summary>
  public static class CommandSequencer
  {
    /// <summary>
    /// Provides synchronisation for this object
    /// 
    /// </summary>
    private static object syncLock = new object();
    /// <summary>
    /// Backing field for CommandIdentifier
    /// 
    /// </summary>
    private static int commandIdentifier;

    /// <summary>
    /// Gets the current CommandIdentifier value
    /// 
    /// </summary>
    public static int CommandIdentifier
    {
      get
      {
        lock (CommandSequencer.syncLock)
          return CommandSequencer.commandIdentifier;
      }
    }

    /// <summary>
    /// Advances the index to the next value
    /// 
    /// </summary>
    public static void NextCommandIdentifier()
    {
      lock (CommandSequencer.syncLock)
        ++CommandSequencer.commandIdentifier;
    }
  }
}
