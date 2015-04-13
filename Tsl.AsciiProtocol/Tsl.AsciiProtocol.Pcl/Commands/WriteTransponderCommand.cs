// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.WriteTransponderCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// A command to write data to the memory banks of one or more transponders
  /// 
  /// </summary>
  public class WriteTransponderCommand : TransponderMemoryCommandBase
  {
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Commands.WriteTransponderCommand.Data"/>
    /// </summary>
    private IParameterAndValue<string> data;
    /// <summary>
    /// Parameter write mode
    /// 
    /// </summary>
    private IParameterAndValue<TransponderWriteMode?> writeMode;
    /// <summary>
    /// Parameter write extensions
    /// 
    /// </summary>
    private IParameterAndValue<TransponderWriteExtension?> writeExtensions;

    /// <summary>
    /// Gets or sets the data read from or written to a transponder memory bank
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters Databank")]
    [Description("The data to write to the memory bank")]
    public string Data
    {
      get
      {
        return this.data.Value;
      }
      set
      {
        this.data.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the write mode used to write to the transponder
    /// 
    /// </summary>
    [Category("Parameters")]
    [DefaultValue(null)]
    [Description("Gets or sets the C1G2 command used to write to the transponder Write or BlockWrite")]
    public TransponderWriteMode? WriteMode
    {
      get
      {
        return this.writeMode.Value;
      }
      set
      {
        this.writeMode.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the Impinj extension setting for the BlockWrite command
    /// 
    /// </summary>
    [Category("Parameters")]
    [Description("Gets or sets the Impinj extension setting for the BlockWrite command")]
    [DefaultValue(null)]
    public TransponderWriteExtension? WriteExtensions
    {
      get
      {
        return this.writeExtensions.Value;
      }
      set
      {
        this.writeExtensions.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the WriteTransponderCommand class
    /// 
    /// </summary>
    public WriteTransponderCommand()
      : base(".wr")
    {
      this.Parameters.Add((ICommandParameter) (this.data = (IParameterAndValue<string>) new ParameterHex("da", 0, 128)));
      this.Parameters.Add((ICommandParameter) (this.writeMode = (IParameterAndValue<TransponderWriteMode?>) new ParameterEnum<TransponderWriteMode>("wm")));
      this.Parameters.Add((ICommandParameter) (this.writeExtensions = (IParameterAndValue<TransponderWriteExtension?>) new ParameterEnum<TransponderWriteExtension>("wx")));
      this.Parameters.Reset();
    }
  }
}
