// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AsciiLineEventArgs
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace PortableAscii2
{
  /// <summary>
  /// Prodives data for a received line
  /// 
  /// </summary>
  public class AsciiLineEventArgs : EventArgs
  {
    /// <summary>
    /// Gets the line that was received
    /// 
    /// </summary>
    public IAsciiResponseLine Line { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether this line has been used by a listener
    /// 
    /// </summary>
    public bool Handled { get; set; }

    /// <summary>
    /// Gets a value indicating whether there are more lines buffered to be signalled
    /// 
    /// </summary>
    public bool MoreToFollow { get; private set; }

    /// <summary>
    /// Initializes a new instance of the AsciiLineEventArgs class
    /// 
    /// </summary>
    /// <param name="line">The received line</param><param name="moreToFollow">True if more lines are buffered to follow</param>
    public AsciiLineEventArgs(IAsciiResponseLine line, bool moreToFollow)
    {
      this.Line = line;
      this.MoreToFollow = moreToFollow;
    }
  }
}
