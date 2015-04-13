// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.TransponderResponder
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;
using System.Globalization;

namespace PortableAscii2
{
  /// <summary>
  /// Processes responses looking for transponder header and collects into a transponder.
  ///             Calls the TransponderReceivedHandler for each transponder received
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// 
  /// <para>
  /// Captures the EP CR PC RI responses to form a <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.TransponderData"/> instance.
  ///             Captures WW as WordsWritten and RD as data read
  ///             Captures OK ER to raise TransponderReceived at the end of a response;
  /// 
  /// </para>
  /// 
  /// <para>
  /// The delegate is called if:
  ///             - A new EPC is received and the current EPC is valid (moreAvailable = true). Just received the EPC of the next response
  ///             - OK or ER is received and the current EPC is valid (moreAvailable = false). End of the command
  ///             - TransponderComplete is called. This is provided for when a base class handles OR or ER and needs to complete a transponder
  /// 
  /// </para>
  /// 
  /// </remarks>
    public class TransponderResponder
  {
    /// <summary>
    /// Cache of transponders seen since last command start
    /// 
    /// </summary>
    private IList<TransponderData> transponders;

    /// <summary>
    /// Gets the last received transponder CRC
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The reader will only output this value if the command is enabled to do so.
    ///             This will return null (Nothing in Visual Basic) if not received for the current transponder
    /// 
    /// </remarks>
    public int? Crc { get; private set; }

    /// <summary>
    /// Gets the last received transponder EPC
    /// 
    /// </summary>
    public string Epc { get; private set; }

    /// <summary>
    /// Gets the last received transponder index
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The reader will only output this value if the command is enabled to do so.
    ///             This will return null (Nothing in Visual Basic) if not received for the current transponder
    /// 
    /// </remarks>
    public int? Index { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the transponder was killed successfully
    /// 
    /// </summary>
    public bool IsKillSuccess { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the transponder was locked successfully
    /// 
    /// </summary>
    public bool IsLockSuccess { get; private set; }

    /// <summary>
    /// Gets the last received transponder PC
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The reader will only output this value if the command is enabled to do so.
    ///             This will return null (Nothing in Visual Basic) if not received for the current transponder
    /// 
    /// </remarks>
    public int? Pc { get; private set; }

    /// <summary>
    /// Gets the last received transponder RSSI
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The reader will only output this value if the command is enabled to do so.
    ///             This will return null (Nothing in Visual Basic) if not received for the current transponder
    /// 
    /// </remarks>
    public int? Rssi { get; private set; }

    /// <summary>
    /// Gets the data read from the transponder in hex
    /// 
    /// </summary>
    public string ReadData { get; private set; }

    /// <summary>
    /// Gets the timestamp reported by the reader if reported as DT otherwise DateTime.MinValue
    /// 
    /// </summary>
    public DateTime Timestamp { get; private set; }

    /// <summary>
    /// Gets the error code specified by the reader why the tag access operation on this transponder failed
    /// 
    /// </summary>
    public TransponderAccessErrorCode? TransponderAccessErrorCode { get; private set; }

    /// <summary>
    /// Gets the error code specified by the transponder why the tag access operation on this transponder failed
    /// 
    /// </summary>
    public TransponderBackscatterErrorCode? TransponderBackscatterErrorCode { get; private set; }

    /// <summary>
    /// Gets the transponder identifier reported as part of an inventory response when using Fast ID in the Impinj extensions
    /// 
    /// </summary>
    public string TransponderIdentifier { get; private set; }

    /// <summary>
    /// Gets the number of words successfully written to the transponder
    /// 
    /// </summary>
    public int? WordsWritten { get; private set; }

    /// <summary>
    /// Gets the transponders received since the last call to <see cref="M:PortableAscii2.TransponderResponder.ClearLastResponse"/>
    /// </summary>
    public IEnumerable<TransponderData> Transponders
    {
      get
      {
        return (IEnumerable<TransponderData>) this.transponders;
      }
    }

    /// <summary>
    /// Raised for each transponder received
    /// 
    /// </summary>
    public event EventHandler<TransponderDataEventArgs> TransponderReceived;

    /// <summary>
    /// Initializes a new instance of the TransponderResponder class
    /// 
    /// </summary>
    public TransponderResponder()
    {
      this.ClearLastResponse();
    }

    /// <summary>
    /// Clears the list of transponders seen and the current transponder
    /// 
    /// </summary>
    public void ClearLastResponse()
    {
      this.transponders = (IList<TransponderData>) new List<TransponderData>();
      this.ClearLastTransponder();
    }

    /// <summary>
    /// Clears the cache of values ready to receive a new transponder
    /// 
    /// </summary>
    public void ClearLastTransponder()
    {
      this.Crc = new int?();
      this.Epc = string.Empty;
      this.Index = new int?();
      this.IsKillSuccess = false;
      this.IsLockSuccess = false;
      this.Pc = new int?();
      this.ReadData = (string) null;
      this.Rssi = new int?();
      this.TransponderAccessErrorCode = new TransponderAccessErrorCode?();
      this.TransponderBackscatterErrorCode = new TransponderBackscatterErrorCode?();
      this.TransponderIdentifier = string.Empty;
      this.WordsWritten = new int?();
    }

    /// <summary>
    /// Each correctly terminated line from the device is passed to this method for processing
    /// 
    /// </summary>
    /// <param name="header">The response line header excluding the colon e.g. 'CS' for a command started response</param><param name="value">The response line following the colon e.g. '.iv'</param>
    /// <returns>
    /// Return true if this line should NOT be passed to any other responder.
    /// 
    /// </returns>
    public bool ProcessReceivedLine(string header, string value)
    {
      bool flag = true;
      if ("OK".Equals(header))
      {
        this.TransponderComplete(false);
        flag = false;
      }
      else if ("ER".Equals(header))
      {
        this.TransponderComplete(false);
        flag = false;
      }
      else if ("DT".Equals(header))
        this.Timestamp = DateTime.ParseExact(value, "s", Constants.CommandFormatProvider);
      else if ("EA".Equals(header))
        this.TransponderAccessErrorCode = new TransponderAccessErrorCode?(EnumExtensions.ParseParameterAs<TransponderAccessErrorCode>(value));
      else if ("EB".Equals(header))
        this.TransponderBackscatterErrorCode = new TransponderBackscatterErrorCode?(EnumExtensions.ParseParameterAs<TransponderBackscatterErrorCode>(value));
      else if ("EP".Equals(header))
      {
        if (!string.IsNullOrEmpty(this.Epc))
          this.TransponderComplete(true);
        this.Epc = value;
      }
      else if ("CR".Equals(header))
        this.Crc = new int?((int) ushort.Parse(value, NumberStyles.HexNumber, Constants.CommandFormatProvider));
      else if ("PC".Equals(header))
        this.Pc = new int?((int) ushort.Parse(value, NumberStyles.HexNumber, Constants.CommandFormatProvider));
      else if ("IX".Equals(header))
        this.Index = new int?((int) ushort.Parse(value, NumberStyles.HexNumber, Constants.CommandFormatProvider));
      else if ("RI".Equals(header))
        this.Rssi = new int?(int.Parse(value, NumberStyles.Integer, Constants.CommandFormatProvider));
      else if ("RD".Equals(header))
        this.ReadData = value;
      else if ("TD".Equals(header))
        this.TransponderIdentifier = value;
      else if ("WW".Equals(header))
        this.WordsWritten = new int?(int.Parse(value, Constants.CommandFormatProvider));
      else if ("KS".Equals(header))
        this.IsKillSuccess = true;
      else if ("LS".Equals(header))
        this.IsLockSuccess = true;
      else
        flag = false;
      return flag;
    }

    /// <summary>
    /// When called this method checks to see if the Epc is not empty. If the EPC is valid then <see cref="M:TechnologySolutions.Rfid.AsciiProtocol.TransponderResponder.OnTransponderComplete(TechnologySolutions.Rfid.AsciiProtocol.TransponderData,System.Boolean)"/>
    ///             if called to notify the delegate of the transponder received. Once called the response is reset with <see cref="M:TechnologySolutions.Rfid.AsciiProtocol.TransponderResponder.ClearLastResponse"/>
    /// </summary>
    /// <param name="moreAvailable">True if more transponders are pending to be notified</param>
    public void TransponderComplete(bool moreAvailable)
    {
      if (!string.IsNullOrEmpty(this.Epc))
      {
        TransponderData transponder = new TransponderData(this.Crc, this.Epc, this.Index, this.IsKillSuccess, this.IsLockSuccess, this.Pc, this.ReadData, this.Rssi, this.Timestamp, this.TransponderAccessErrorCode, this.TransponderBackscatterErrorCode, this.TransponderIdentifier, this.WordsWritten);
        this.transponders.Add(transponder);
        this.OnTransponderComplete(transponder, moreAvailable);
      }
      this.ClearLastTransponder();
      if (moreAvailable)
        return;
      this.Timestamp = DateTime.MinValue;
    }

    /// <summary>
    /// Raises the <see cref="E:PortableAscii2.TransponderResponder.TransponderReceived"/>  event
    /// 
    /// </summary>
    /// <param name="transponder">The transponder properties</param><param name="moreAvailable">True if more transponders are buffered to be notified</param>
    protected virtual void OnTransponderComplete(TransponderData transponder, bool moreAvailable)
    {
      EventHandler<TransponderDataEventArgs> eventHandler = this.TransponderReceived;
      if (eventHandler == null)
        return;
      eventHandler((object) this, new TransponderDataEventArgs(transponder, moreAvailable));
    }
  }
}
