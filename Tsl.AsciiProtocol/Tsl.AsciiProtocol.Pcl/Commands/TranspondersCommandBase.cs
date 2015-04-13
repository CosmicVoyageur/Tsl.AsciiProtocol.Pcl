// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.TranspondersCommandBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// Base class for commands that return one or more transponders
  /// 
  /// </summary>
  public abstract class TranspondersCommandBase : AlertDateTimeCommandBase, IAntennaParameters, ITransponderParameters
  {
    /// <summary>
    /// Handles responses relating to a transponder
    /// 
    /// </summary>
    private TransponderResponder transponderResponder;
    /// <summary>
    /// Holds the antenna parameter
    /// 
    /// </summary>
    private IParameterAndValue<int?> antennaParameter;
    /// <summary>
    /// Holds the transponder parameters
    /// 
    /// </summary>
    private TransponderParameterCollection transponderParameters;

    /// <summary>
    /// Gets or sets the output power
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Valid power range is 10 - 29.
    ///             Use AntennaParameters.OutputPowerNotSpecified to read the output power.
    /// 
    /// </remarks>
    [Description("Specify the output power in dBm (10-29) or null to use the reader's current value")]
    [DefaultValue(null)]
    [Category("Parameters Antenna")]
    public int? OutputPower
    {
      get
      {
        return this.antennaParameter.Value;
      }
      set
      {
        this.antennaParameter.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to include checksum information in reader responses
    /// 
    /// </summary>
    [Description("True to include the checksum for each transponder found, false to exclude it. Null to use the current setting")]
    [Category("Parameters Transponder")]
    [DefaultValue(null)]
    public TriState? IncludeChecksum
    {
      get
      {
        return this.transponderParameters.IncludeChecksum;
      }
      set
      {
        this.transponderParameters.IncludeChecksum = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to include index numbers for multiple values in reader responses
    /// 
    /// </summary>
    [Category("Parameters Transponder")]
    [Description("True to include the index for each transponder found, false to exclude it. Null to use the current setting")]
    [DefaultValue(null)]
    public TriState? IncludeIndex
    {
      get
      {
        return this.transponderParameters.IncludeIndex;
      }
      set
      {
        if (value.HasValue && !this.IsIncludeIndexSupported)
          throw new NotSupportedException("IncludeIndex is not supported for this command");
        this.transponderParameters.IncludeIndex = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to include the EPC PC value in reader responses
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters Transponder")]
    [Description("True to include the PC for each transponder found, false to exclude it. Null to use the current setting")]
    public TriState? IncludePC
    {
      get
      {
        return this.transponderParameters.IncludePC;
      }
      set
      {
        this.transponderParameters.IncludePC = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to include RSSI value in reader responses
    /// 
    /// </summary>
    [Description("True to include the RSSI for each transponder found, false to exclude it. Null to use the current setting")]
    [DefaultValue(null)]
    [Category("Parameters Transponder")]
    public TriState? IncludeTransponderRssi
    {
      get
      {
        return this.transponderParameters.IncludeTransponderRssi;
      }
      set
      {
        this.transponderParameters.IncludeTransponderRssi = value;
      }
    }

    /// <summary>
    /// Gets the transponders received since the start of the last command
    /// 
    /// </summary>
    [Description("The transponders received")]
    [Category("Response")]
    public IEnumerable<TransponderData> Transponders
    {
      get
      {
        return this.transponderResponder.Transponders;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the <see cref="P:PortableAscii2.Commands.TranspondersCommandBase.IncludeIndex"/> property is supported by this command
    /// 
    /// </summary>
    protected bool IsIncludeIndexSupported { get; set; }

    /// <summary>
    /// Raised when a transponder is received
    /// 
    /// </summary>
    public event EventHandler<TransponderDataEventArgs> TransponderReceived;

    /// <summary>
    /// Initializes a new instance of the TranspondersCommandBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name (e.g. ".iv" for inventory)</param>
    protected TranspondersCommandBase(string commandName)
      : base(commandName)
    {
      this.IsIncludeIndexSupported = true;
      this.Parameters.Add((ICommandParameter) (this.antennaParameter = (IParameterAndValue<int?>) new ParameterInt("o", 10, 29)));
      this.Parameters.AddRange((IEnumerable<ICommandParameter>) (this.transponderParameters = new TransponderParameterCollection()));
      this.transponderResponder = new TransponderResponder();
      this.transponderResponder.TransponderReceived += new EventHandler<TransponderDataEventArgs>(this.TransponderResponder_TransponderReceived);
      this.Response.ReceivedLine += new EventHandler<AsciiLineEventArgs>(this.Response_ReceivedLine);
    }

    /// <summary>
    /// Called for each transponder received in the response
    /// 
    /// </summary>
    /// <param name="e">The data about the transponder received</param>
    protected virtual void OnTransponderReceived(TransponderDataEventArgs e)
    {
      EventHandler<TransponderDataEventArgs> eventHandler = this.TransponderReceived;
      if (eventHandler == null)
        return;
      eventHandler((object) this, e);
    }

    /// <summary>
    /// Relays the received transponder to the event of this command
    /// 
    /// </summary>
    /// <param name="sender">The event source</param><param name="e">Data provided for the event</param>
    private void TransponderResponder_TransponderReceived(object sender, TransponderDataEventArgs e)
    {
      this.OnTransponderReceived(e);
    }

    /// <summary>
    /// Relays a received line to the transponderResponder for transponder processing
    /// 
    /// </summary>
    /// <param name="sender">The event source</param><param name="e">Data provided for the event</param>
    private void Response_ReceivedLine(object sender, AsciiLineEventArgs e)
    {
      if (AsciiResponseExtensions.IsCommandStarted(e.Line))
      {
        this.transponderResponder.ClearLastResponse();
        e.Handled = true;
      }
      else
      {
        if (!this.transponderResponder.ProcessReceivedLine(e.Line.Header, e.Line.Value))
          return;
        e.Handled = true;
      }
    }
  }
}
