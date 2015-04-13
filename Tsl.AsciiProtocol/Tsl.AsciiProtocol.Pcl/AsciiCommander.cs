// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.AsciiCommander
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

//using log4net;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// TSLAsciiCommander provides methods to communicate with TSL devices that use the TSL ASCII 2.0 Protocol
  ///             Instances of this class support:
  ///             •connection and disconnection from any TSL Reader connected via a comm port
  ///             •execution of an IAsciiCommand either synchronously or asynchronously
  ///             •management of the responder chain for data received from the TSL device
  /// 
  /// </summary>
  public class AsciiCommander : AsciiCommandExecutorBase, IDisposable
  {
    /// <summary>
    /// Provides logging for this class
    /// 
    /// </summary>
    //private static ILog log = LogManager.GetLogger(typeof (AsciiCommander));
    /// <summary>
    /// Provides synchronization to receive processing
    /// 
    /// </summary>
    private object receiveSyncLock = new object();
    /// <summary>
    /// True when an instance is disposed
    /// 
    /// </summary>
    private bool disposed;
    /// <summary>
    /// Used to communicate with the reader
    /// 
    /// </summary>
    private IAsciiSerialPort reader;

    /// <summary>
    /// Gets a value indicating whether a reader is connected
    /// 
    /// </summary>
    public bool IsConnected
    {
      get
      {
        return this.reader != null;
      }
    }

    /// <summary>
    /// Connect the AsciiCommander to the given reader
    /// 
    /// </summary>
    /// <param name="reader">The UHF Reader that supports the TSL ASCII 2.0 protocol</param>
    /// <returns>
    /// True if successfully connected
    /// </returns>
    public bool Connect(IAsciiSerialPort reader)
    {
      //AsciiCommander.log.Info((object) "Connect+");
      if (reader == null)
        throw new ArgumentNullException("reader");
      if (this.reader != null)
        this.Disconnect();
      this.reader = reader;
      this.reader.Received += new EventHandler(this.Reader_Received);
      this.LastActivityTime = DateTime.Now;
      //AsciiCommander.log.InfoFormat("Connect- {0}", this.IsConnected);
      return this.IsConnected;
    }

    /// <summary>
    /// Disconnects from the current device
    /// 
    /// </summary>
    public void Disconnect()
    {
      //AsciiCommander.log.Info((object) "Disconnect+");
      if (this.reader != null)
      {
        this.reader.Received -= new EventHandler(this.Reader_Received);
        try
        {
          this.reader.Dispose();
        }
        catch (Exception ex)
        {
          //AsciiCommander.log.Error((object) "failed to dispose reader", ex);
        }
        finally
        {
          this.reader = (IAsciiSerialPort) null;
        }
      }
      this.LastActivityTime = DateTime.Now;
      //AsciiCommander.log.Info((object) "Disconnect-");
    }

    /// <summary>
    /// Sends the signal to the accessory to permanently disconnect
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Once issued this will require reconnecting to the reader to use the accessory again. This may require switching to the iOS Settings App
    ///             This is a convenience method and is equivalent to sending a TSLSleepCommand to the reader
    /// 
    /// </remarks>
    public void PermanentlyDisconnect()
    {
      if (!this.IsConnected)
        return;
      this.Send(".sl");
        
      
      Task.Delay(200);
      this.Disconnect();
    }

    /// <summary>
    /// Send the given string as a CrLf terminated string, to the reader.
    ///             This method waits until the command has been successfuly sent
    /// 
    /// </summary>
    /// <param name="line">line The ASCII string to send to the device</param><exception cref="T:System.InvalidOperationException">if no device is connected  </exception>
    public override void Send(string line)
    {
      base.Send(line);
      if (!this.IsConnected)
        throw new InvalidOperationException("Reader not connected");
      this.reader.WriteLine(line);
    }

    /// <summary>
    /// Disposes an instance of the AsciiCommander class
    /// 
    /// </summary>
    /// <param name="disposing">True to dispose managed as well as unmanaged resources</param>
    protected override void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
          this.Disconnect();
        this.disposed = true;
      }
      base.Dispose(disposing);
    }

    /// <summary>
    /// Data was received from the reader. Report all the complete lines to the ASCII commander by calling
    ///             <see cref="M:TechnologySolutions.Rfid.AsciiProtocol.AsciiCommandExecutorBase.ProcessReceivedLines(System.Collections.Generic.ICollection{System.String})"/>
    /// </summary>
    /// <param name="sender">The event source</param><param name="e">Data provided for the event</param>
    private void Reader_Received(object sender, EventArgs e)
    {
      lock (this.receiveSyncLock)
      {
        List<string> local_0 = new List<string>();
        try
        {
          IAsciiSerialPort local_2;
          while ((local_2 = this.reader) != null)
          {
            if (local_2.IsDataAvailable)
            {
              string local_1 = local_2.ReadLine();
              local_0.Add(local_1);
            }
            else
              break;
          }
        }
        catch (TimeoutException exception_0)
        {
          //AsciiCommander.log.Error((object) "SessionDataReceived", (Exception) exception_0);
        }
        this.ProcessReceivedLines((ICollection<string>) local_0);
      }
      this.LastActivityTime = DateTime.Now;
    }
  }
}
