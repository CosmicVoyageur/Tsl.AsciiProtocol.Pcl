// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AsciiCommandLibraryResponderBase
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using System.Text;
using PortableAscii2.Commands;

namespace PortableAscii2
{
  /// <summary>
  /// Base class for library commands
  ///             This is identical to the <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.AsciiCommandResponderBase"/> except, by default, it will only
  ///             repond to commands containing the TSL_LibraryCommandId
  /// 
  /// </summary>
  public abstract class AsciiCommandLibraryResponderBase : AsciiCommandResponderBase
  {
    /// <summary>
    /// The value inserted into the command line to identify the command as a library command
    /// 
    /// </summary>
    public const string LibraryCommandIdentifier = "LCMD";

    /// <summary>
    /// Gets or sets a value indicating whether to insert a value into the command to identify the command as a libary command.
    ///             This also sets up the responder to only respond to commands that have the library command
    /// 
    /// </summary>
    [DefaultValue(true)]
    [Category("Command")]
    [Description("When true appends a value to each command that indicates the command is sent from this library. Ensures the responder only responds to library commands")]
    public bool IsLibraryCommand { get; set; }

    /// <summary>
    /// Initializes a new instance of the AsciiCommandLibraryResponderBase class
    /// 
    /// </summary>
    /// <param name="commandName">The command name e.g. '.iv' for Inventory or string.Empty to respond to all commands</param>
    protected AsciiCommandLibraryResponderBase(string commandName)
      : base(commandName)
    {
      this.IsLibraryCommand = true;
    }

    /// <summary>
    /// Appends <see cref="F:PortableAscii2.AsciiCommandLibraryResponderBase.LibraryCommandIdentifier"/> to the command line after CommandName and before the parameters
    ///             if <see cref="P:PortableAscii2.AsciiCommandLibraryResponderBase.IsLibraryCommand"/> is true
    /// 
    /// </summary>
    /// <param name="commandLine">The command line to append to</param>
    protected override void BuildCommandLine(StringBuilder commandLine)
    {
      base.BuildCommandLine(commandLine);
      if (!this.IsLibraryCommand)
        return;
      commandLine.Append(" ");
      commandLine.Append("LCMD");
    }
  }
}
