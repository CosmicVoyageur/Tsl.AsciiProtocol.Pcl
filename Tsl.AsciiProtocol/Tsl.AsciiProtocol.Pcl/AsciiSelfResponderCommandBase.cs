// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AsciiSelfResponderCommandBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using System.Text;
using PortableAscii2.Commands;

namespace PortableAscii2
{
  /// <summary>
  /// Base class for commands that receive their own reponses
  /// 
  /// </summary>
  public abstract class AsciiSelfResponderCommandBase : AsciiCommandLibraryResponderBase, IAsciiCommand
  {
    /// <summary>
    /// Gets or sets a value indicating whether each command sent is given a sequential identifier.
    ///             Also affects the responder to only respond to the command with the specific identifier
    /// 
    /// </summary>
    [Category("Command")]
    [DefaultValue(true)]
    [Description("Appends an index to each command sent and ensure only the response with the appropriate index is received")]
    public bool IsIndexedCommand { get; set; }

    /// <summary>
    /// Gets or sets the maximum time to wait for this command to complete when invoked synchronously
    /// 
    /// </summary>
    [Category("Command")]
    [Description("The maximum time in seconds to wait for the response to this as a synchronous command")]
    [DefaultValue(3.0)]
    public double MaxSynchronousWaitTime { get; set; }

    /// <summary>
    /// Initializes a new instance of the AsciiSelfResponderCommandBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name e.g. ".iv" for Inventory</param>
    protected AsciiSelfResponderCommandBase(string commandName)
      : base(commandName)
    {
      this.MaxSynchronousWaitTime = 3.0;
      this.IsIndexedCommand = true;
    }

    /// <summary>
    /// Returns a string representation of this instance
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The name of the command
    /// </returns>
    public override string ToString()
    {
      return this.GetType().Name;
    }

    /// <summary>
    /// Inserts a sequential identifier into the command line if <see cref="P:PortableAscii2.AsciiSelfResponderCommandBase.IsIndexedCommand"/> is true
    /// 
    /// </summary>
    /// <param name="commandLine">The command line to append to</param>
    protected override void BuildCommandLine(StringBuilder commandLine)
    {
      base.BuildCommandLine(commandLine);
      if (!this.IsIndexedCommand)
        return;
      commandLine.AppendFormat(" {0:D6}", (object) CommandSequencer.CommandIdentifier);
    }
  }
}
