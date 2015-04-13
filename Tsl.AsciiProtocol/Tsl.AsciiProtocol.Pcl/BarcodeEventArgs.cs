// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.BarcodeEventArgs
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Globalization;

namespace PortableAscii2
{
  /// <summary>
  /// EventArgs where a barcode has been scanned
  /// 
  /// </summary>
  public class BarcodeEventArgs : EventArgs
  {
    /// <summary>
    /// Gets the barcode scanned
    /// 
    /// </summary>
    public string Barcode { get; private set; }

    /// <summary>
    /// Gets the timestamp when the barcode was received or <see cref="F:System.DateTime.MinValue"/> if not timestamped
    /// 
    /// </summary>
    public DateTime Timestamp { get; private set; }

    /// <summary>
    /// Initializes a new instance of the BarcodeEventArgs class
    /// 
    /// </summary>
    /// <param name="barcode">The barcode scanned</param><param name="timestamp">The timestamp the barcode was recived or DateTime.MinValue if not timestamped</param>
    public BarcodeEventArgs(string barcode, DateTime timestamp)
    {
      this.Barcode = barcode;
      this.Timestamp = timestamp;
    }

    /// <summary>
    /// Returns a string representation of this instance
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// A string represenation of the barcode data
    /// </returns>
    public override string ToString()
    {
      if (this.Timestamp == DateTime.MinValue)
        return string.Format((IFormatProvider) CultureInfo.CurrentUICulture, "Barcode: {0}", new object[1]
        {
          (object) this.Barcode
        });
      return string.Format((IFormatProvider) CultureInfo.CurrentUICulture, "Barcode: {0} scanned {1:g}", new object[2]
      {
        (object) this.Barcode,
        (object) this.Timestamp
      });
    }
  }
}
