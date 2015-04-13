// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.Commands.LicenceKeyCommand
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.ComponentModel;
using PortableAscii2.Parameters;

namespace PortableAscii2.Commands
{
  /// <summary>
  /// This command reads, writes and deletes the Licence Key stored in the reader’s non-volatile memory.
  ///             The Licence Key can be up to 127 characters long and can contain any printable characters with the exception of double quotes (").
  ///             How the licence key function is used is up to the programmer, it could be used to store a simple password or some form of
  ///             hashing could be used with the two unique strings, the serial number and Bluetooth address, returned from the .vr command.
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// Added for ASCII Protocol 2.2
  /// </remarks>
  public class LicenceKeyCommand : AsciiCommandBase
  {
    /// <summary>
    /// Backing field for the read parameters parameter
    /// 
    /// </summary>
    private IParameterAndValue<bool> readParameters;
    /// <summary>
    /// Backing field for DeleteKey
    /// 
    /// </summary>
    private IParameterAndValue<Deletion?> deleteKey;
    /// <summary>
    /// Backing field for licence key
    /// 
    /// </summary>
    private IParameterAndValue<string> licenceKey;

    /// <summary>
    /// Gets or sets a value that when set to yes will erase the current licence key if present
    /// 
    /// </summary>
    public Deletion? DeleteKey
    {
      get
      {
        return this.deleteKey.Value;
      }
      set
      {
        this.deleteKey.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the response to the command should report all supported parameters abd their current values
    /// 
    /// </summary>
    [Description("When true returns the parameters supported by the command and where supported their current values")]
    [Category("Parameters Command")]
    [DefaultValue(false)]
    public bool ReadParameters
    {
      get
      {
        return this.readParameters.Value;
      }
      set
      {
        this.readParameters.Value = value;
      }
    }

    /// <summary>
    /// Gets or sets the licence key to write to the reader.
    ///             After the command is executed returns the key read from the reader
    /// 
    /// </summary>
    public string LicenceKey
    {
      get
      {
        return this.licenceKey.Value;
      }
      set
      {
        this.licenceKey.Value = value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the LicenceKeyCommand class
    /// 
    /// </summary>
    public LicenceKeyCommand()
      : base(".lk")
    {
      this.Parameters.Add((ICommandParameter) (this.deleteKey = (IParameterAndValue<Deletion?>) new ParameterEnum<Deletion>("d")));
      this.Parameters.Add((ICommandParameter) (this.readParameters = (IParameterAndValue<bool>) new ParameterBool("p")));
      this.Parameters.Add((ICommandParameter) (this.licenceKey = (IParameterAndValue<string>) new ParameterText("s", 1, (int) sbyte.MaxValue, true)));
      this.Parameters.Reset();
      AsciiResponseExtensions.AddHeaders(this.Response, "CS: ER: LK: ME: OK: PR:");
      this.Response.ReceivedLine += (EventHandler<AsciiLineEventArgs>) ((sender, e) =>
      {
        if (!AsciiResponseExtensions.HasHeader(e.Line, "LK"))
          return;
        this.LicenceKey = e.Line.Value;
      });
    }
  }
}
