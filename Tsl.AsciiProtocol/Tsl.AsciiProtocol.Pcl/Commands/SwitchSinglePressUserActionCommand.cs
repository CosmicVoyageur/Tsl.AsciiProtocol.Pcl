// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.SwitchSinglePressUserActionCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;
using System.Linq;
using Tsl.AsciiProtocol.Pcl.Parameters;

namespace Tsl.AsciiProtocol.Pcl.Commands
{
  /// <summary>
  /// Command to set the "usr" action of the switch single press
  /// 
  /// </summary>
  public class SwitchSinglePressUserActionCommand : AsciiCommandBase
  {
    /// <summary>
    /// Backing field for SinglePressUserAction
    /// 
    /// </summary>
    private IParameterAndValue<string> singlePressUserAction;

    /// <summary>
    /// Gets or sets the single command to perform when the switch is in the single press state (e.g. ".bc")
    /// 
    /// </summary>
    public string SinglePressUserAction
    {
      get
      {
        return this.singlePressUserAction.Value;
      }
      set
      {
        this.singlePressUserAction.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the SwitchSinglePressUserActionCommand class
    /// 
    /// </summary>
    public SwitchSinglePressUserActionCommand()
      : base(".sp")
    {
      this.Parameters.Add((ICommandParameter) (this.singlePressUserAction = (IParameterAndValue<string>) new ParameterText("s", 1, 256)));
      this.Parameters.Reset();
      this.Response.ReceivedLine += new EventHandler<AsciiLineEventArgs>(this.Response_ReceivedLine);
    }

    /// <summary>
    /// Parses a command line or PR: value and updates the commands parameter to match.
    ///             Returns validation messages for any errors encountered
    /// 
    /// </summary>
    /// <param name="parameterLine">The parameters to parse</param><param name="parameters">output the parameter line split into individual parameters</param>
    /// <returns>
    /// Any validtion messages arising from parsing the parameter line
    /// </returns>
    protected override ICollection<string> ValidateAndParseParameters(string parameterLine, out IEnumerable<string> parameters)
    {
      ICollection<string> collection = CommandHelper.ValidateAndParseSwitchParameter(parameterLine, out parameters);
      if (parameters != null && Enumerable.Count<string>(parameters) == 2)
        this.SinglePressUserAction = Enumerable.ElementAt<string>(parameters, 1);
      return collection;
    }

    /// <summary>
    /// Captures the value from the responder
    /// 
    /// </summary>
    /// <param name="sender">The event source</param><param name="e">Data provided for the event</param>
    private void Response_ReceivedLine(object sender, AsciiLineEventArgs e)
    {
      if (!AsciiResponseExtensions.HasHeader(e.Line, "SP"))
        return;
      this.SinglePressUserAction = e.Line.Value;
      e.Handled = true;
    }
  }
}
