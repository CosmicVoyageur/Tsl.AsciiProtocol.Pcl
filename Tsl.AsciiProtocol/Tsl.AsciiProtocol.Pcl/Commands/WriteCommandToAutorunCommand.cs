// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.WriteCommandToAutorunCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System.ComponentModel;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// Writes an ASCII command to the Autorun file
  /// 
  /// </summary>
  public class WriteCommandToAutorunCommand : AsciiCommandBase
  {
    /// <summary>
    /// Backing field for the Autorun parameter
    /// 
    /// </summary>
    private IParameterAndValue<string> command;

    /// <summary>
    /// Gets or sets the valid ASCII command line that is to be written to the Autorun file
    /// 
    /// </summary>
    [DefaultValue(null)]
    [Description("The ASCII command to append to the autorun file")]
    [Category("Parameters")]
    public string Command
    {
      get
      {
        return this.command.Value;
      }
      set
      {
        this.command.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the WriteCommandToAutorunCommand class
    /// 
    /// </summary>
    public WriteCommandToAutorunCommand()
      : base(".wa")
    {
      this.IsIndexedCommand = false;
      this.IsLibraryCommand = false;
      ParameterCollection parameters = this.Parameters;
      ParameterText parameterText = new ParameterText("command", 3, 20);
      parameterText.ParameterFormat = " {1}";
      IParameterAndValue<string> parameterAndValue = this.command = (IParameterAndValue<string>) parameterText;
      parameters.Add((ICommandParameter) parameterAndValue);
      this.Parameters.Reset();
    }
  }
}
