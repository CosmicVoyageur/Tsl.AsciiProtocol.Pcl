// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.TransponderMemoryCommandBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.Collections.Generic;
using System.ComponentModel;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// Base class for commands that read or write transponder memory
  /// 
  /// </summary>
  public abstract class TransponderMemoryCommandBase : TransponderAccessCommandBase, IAntennaParameters, ICommandParameters, IDatabankParameters, IResponseParameters, ISelectParameters, ITransponderParameters
  {
    /// <summary>
    /// Holds the databank parameters
    /// 
    /// </summary>
    private DatabankParameterCollection databankParameters;

    /// <summary>
    /// Gets or sets the transponder data bank to be used
    /// 
    /// </summary>
    [Category("Parameters Databank")]
    [Description("The memory bank to read to or write from")]
    [DefaultValue(null)]
    public Databank? Bank
    {
      get
      {
        return this.databankParameters.Bank;
      }
      set
      {
        this.databankParameters.Bank = value;
      }
    }

    /// <summary>
    /// Gets or sets the length in words of the data to write
    /// 
    /// </summary>
    [Description("The number of words to read or write")]
    [Category("Parameters Databank")]
    [DefaultValue(null)]
    public int? Length
    {
      get
      {
        return this.databankParameters.Length;
      }
      set
      {
        this.databankParameters.Length = value;
      }
    }

    /// <summary>
    /// Gets or sets the offset, in 16 bit words, from the start of the memory bank to where the data will be written
    /// 
    /// </summary>
    [Category("Parameters Databank")]
    [Description("The offset in words into the memory bank to start to read from or write to")]
    [DefaultValue(null)]
    public int? Offset
    {
      get
      {
        return this.databankParameters.Offset;
      }
      set
      {
        this.databankParameters.Offset = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the TransponderMemoryCommandBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name (e.g. ".iv" for inventory)</param>
    protected TransponderMemoryCommandBase(string commandName)
      : base(commandName)
    {
      this.Parameters.AddRange((IEnumerable<ICommandParameter>) (this.databankParameters = new DatabankParameterCollection()));
    }
  }
}
