// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.TransponderDataEventArgs
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Text;

namespace PortableAscii2
{
  /// <summary>
  /// EventArgs when a transponder is reported from an inventory
  /// 
  /// </summary>
  public class TransponderDataEventArgs : EventArgs
  {
    /// <summary>
    /// Gets a value indicating whether more transponders are to be reported
    /// 
    /// </summary>
    public bool MoreAvailable { get; private set; }

    /// <summary>
    /// Gets the transponder reported
    /// 
    /// </summary>
    public TransponderData Transponder { get; private set; }

    /// <summary>
    /// Initializes a new instance of the TransponderDataEventArgs class
    /// 
    /// </summary>
    /// <param name="transponder">The transponder to report</param><param name="moreAvailable">True if more transponders are expected to be reported after this event</param>
    public TransponderDataEventArgs(TransponderData transponder, bool moreAvailable)
    {
      this.MoreAvailable = moreAvailable;
      this.Transponder = transponder;
    }

    /// <summary>
    /// Returns a string representation of this instance
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// A string representation of this instance
    /// </returns>
    public override string ToString()
    {
      StringBuilder builder = new StringBuilder();
      this.Transponder.AppendTo(builder);
      builder.AppendFormat(" More: {0}", this.MoreAvailable);
      return builder.ToString();
    }
  }
}
