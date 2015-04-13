// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.WriteSingleTransponderCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// A command to write data to the memory banks of a single transponder only
  /// 
  /// </summary>
  public class WriteSingleTransponderCommand : TranspondersCommandBase
  {
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Commands.WriteSingleTransponderCommand.AccessPassword"/>
    /// </summary>
    private IParameterAndValue<string> accessPassword;
    /// <summary>
    /// Backing field for <see cref="P:PortableAscii2.Commands.WriteSingleTransponderCommand.Data"/>
    /// </summary>
    private IParameterAndValue<string> data;
    /// <summary>
    /// Holds the databank parameters
    /// 
    /// </summary>
    private DatabankParameterCollection databankParameters;
    /// <summary>
    /// Holds the select parameters
    /// 
    /// </summary>
    private SelectParameterCollection selectParameters;

    /// <summary>
    /// Gets a value indicating whether a transponder responded to the command
    /// 
    /// </summary>
    [Description("True if a transponder is found to write to")]
    [DefaultValue(false)]
    [Category("Response")]
    public bool IsTransponderFound
    {
      get
      {
        return Enumerable.Count<TransponderData>(this.Transponders) == 1;
      }
    }

    /// <summary>
    /// Gets the number of words successfully written to the transponder
    /// 
    /// </summary>
    [Category("Response")]
    [Description("The number of words successfully written to the transponder")]
    [DefaultValue(0)]
    public int WordsWritten
    {
      get
      {
        using (IEnumerator<TransponderData> enumerator = this.Transponders.GetEnumerator())
        {
          if (enumerator.MoveNext())
          {
            TransponderData current = enumerator.Current;
            return current.WordsWritten.HasValue ? current.WordsWritten.Value : 0;
          }
        }
        return 0;
      }
    }

    /// <summary>
    /// Gets or sets the password required to access transponders
    /// 
    /// </summary>
    [Category("Parameters")]
    [Description("Gets or sets the access password")]
    [DefaultValue(null)]
    public string AccessPassword
    {
      get
      {
        return this.accessPassword.Value;
      }
      set
      {
        this.accessPassword.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the transponder data bank to be used
    /// 
    /// </summary>
    [Category("Parameters Databank")]
    [DefaultValue(null)]
    [Description("The memory bank to read to or write from")]
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
    [DefaultValue(null)]
    [Description("The number of words to read or write")]
    [Category("Parameters Databank")]
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
    [Description("The offset in words into the memory bank to start to read from or write to")]
    [Category("Parameters Databank")]
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
    /// Gets or sets the data read from or written to a transponder memory bank
    /// 
    /// </summary>
    [Category("Parameters Databank")]
    [Description("The data to write to the memory bank")]
    [DefaultValue(null)]
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
    /// Gets or sets the Bank to use for the select mask
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Category("Parameters Select")]
    [Description("the Bank to use for the select mask")]
    public Databank? SelectBank
    {
      get
      {
        return this.selectParameters.SelectBank;
      }
      set
      {
        this.selectParameters.SelectBank = value;
      }
    }

    /// <summary>
    /// Gets or sets the select mask data in 2 character ASCII Hex pairs padded to ensure full bytes
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Description("the select mask data in 2 character ASCII Hex pairs padded to ensure full bytes")]
    [Category("Parameters Select")]
    public string SelectData
    {
      get
      {
        return this.selectParameters.SelectData;
      }
      set
      {
        this.selectParameters.SelectData = value;
      }
    }

    /// <summary>
    /// Gets or sets the length in bits of the select mask
    /// 
    /// </summary>
    [Description("the length in bits of the select mask")]
    [DefaultValue(null)]
    [Category("Parameters Select")]
    public int? SelectLength
    {
      get
      {
        return this.selectParameters.SelectLength;
      }
      set
      {
        this.selectParameters.SelectLength = value;
      }
    }

    /// <summary>
    /// Gets or sets the number of bits from the start of the block to the start of the select mask
    /// 
    /// </summary>
    [Category("Parameters Select")]
    [Description("the number of bits from the start of the block to the start of the select mask")]
    [DefaultValue(null)]
    public int? SelectOffset
    {
      get
      {
        return this.selectParameters.SelectOffset;
      }
      set
      {
        this.selectParameters.SelectOffset = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the WriteSingleTransponderCommand class
    /// 
    /// </summary>
    public WriteSingleTransponderCommand()
      : base(".ws")
    {
      this.IsIncludeIndexSupported = false;
      this.Parameters.Add((ICommandParameter) (this.accessPassword = (IParameterAndValue<string>) new ParameterHex("ap", 8, 8)));
      this.Parameters.Add((ICommandParameter) (this.data = (IParameterAndValue<string>) new ParameterHex("da", 0, 128)));
      this.Parameters.AddRange((IEnumerable<ICommandParameter>) (this.databankParameters = new DatabankParameterCollection()));
      this.selectParameters = new SelectParameterCollection();
      this.Parameters.AddRange(Enumerable.Where<ICommandParameter>((IEnumerable<ICommandParameter>) this.selectParameters, (Func<ICommandParameter, bool>) (x => "io sa st".IndexOf(x.ParameterIdentifier, StringComparison.OrdinalIgnoreCase) < 0)));
      this.Parameters.Remove("ix");
      this.Parameters.Reset();
    }
  }
}
