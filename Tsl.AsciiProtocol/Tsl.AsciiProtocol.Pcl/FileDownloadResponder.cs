// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.FileDownloadResponder
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.IO;

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// An implementation of the <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommandResponder"/> to capture the Autorun and Log files from a device. This responder
  ///             should be inserted at the top of the responder chain as this responder is high traffic and will consume all the file (marking each
  ///             line as proccessed) so it does not have to 'visit' all the responders in the chain.
  ///             On seeing the start of a download a temporary file is created. All the lines are written out to the file until the download is complete.
  ///             Then an event is raised with the filename to be copied to a sensible location
  /// 
  /// </summary>
  public class FileDownloadResponder : IAsciiCommandResponder, IDisposable
  {
    /// <summary>
    /// True once an instance is disposed
    /// 
    /// </summary>
    private bool disposed;
    /// <summary>
    /// The file being written to
    /// 
    /// </summary>
    private TextWriter writer;

    /// <summary>
    /// Gets the header that indicates the start of the file download
    /// 
    /// </summary>
    public string FileBeginHeader { get; private set; }

    /// <summary>
    /// Gets the header that indicates the end of the file download
    /// 
    /// </summary>
    public string FileEndHeader { get; private set; }

    /// <summary>
    /// Gets the name of the last file that was downloaded from the unit
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// This provides the name of the file created when the <see cref="E:PortableAscii2.FileDownloadResponder.DownloadComplete"/> event is raised
    /// 
    /// </remarks>
    public string FileName { get; private set; }

    /// <summary>
    /// Gets the number of lines downloaded
    /// 
    /// </summary>
    public int LineCount { get; private set; }

    /// <summary>
    /// Gets a value indicating whether a file is currently being written
    /// 
    /// </summary>
    private bool IsWithinFile
    {
      get
      {
        return this.writer != null;
      }
    }

    /// <summary>
    /// Event raised when a file download is completed
    /// 
    /// </summary>
    public event EventHandler DownloadComplete;

    /// <summary>
    /// Event raised periodically while a file is downloading
    /// 
    /// </summary>
    public event EventHandler Downloading;

    /// <summary>
    /// Event raised when a file download is started
    /// 
    /// </summary>
    public event EventHandler DownloadStarted;

    /// <summary>
    /// Initializes a new instance of the FileDownloadResponder class
    /// 
    /// </summary>
    /// <param name="fileBeginHeader">The header that indicates the start of the file contents e.g. "AB" or "LB"</param><param name="fileEndHeader">The header that indicates the end of the file contents e.g. "AE" or "LE"</param>
    public FileDownloadResponder(string fileBeginHeader, string fileEndHeader)
    {
      if (string.IsNullOrEmpty(fileBeginHeader))
        throw new ArgumentNullException("fileBeginHeader");
      if (fileBeginHeader.Length != 2)
        throw new ArgumentException("headers are two characters in length", "fileBeginHeader");
      if (string.IsNullOrEmpty(fileEndHeader))
        throw new ArgumentNullException("fileEndHeader");
      if (fileEndHeader.Length != 2)
        throw new ArgumentException("headers are two characters in length", "fileEndHeader");
      this.FileBeginHeader = fileBeginHeader.ToUpper();
      this.FileEndHeader = fileEndHeader.ToUpper();
    }

    /// <summary>
    /// Returns a <see cref="T:Tsl.AsciiProtocol.Pcl.FileDownloadResponder"/> to capture an autorun file
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The instance to capture an Autorun file to a file
    /// </returns>
    public static FileDownloadResponder AutorunFileDownloader()
    {
      return new FileDownloadResponder("AB", "AE");
    }

    /// <summary>
    /// Returns a <see cref="T:Tsl.AsciiProtocol.Pcl.FileDownloadResponder"/> to capture a log file
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The instance to capture a log from the device to a file
    /// </returns>
    public static FileDownloadResponder LogFileDownloader()
    {
      return new FileDownloadResponder("LB", "LE");
    }

    /// <summary>
    /// Disposes an instance of the FileDownloadResponder class
    /// 
    /// </summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    /// <summary>
    /// Captures output from the file download command to a temporary file. Raises an event as the file is closed
    /// 
    /// </summary>
    /// <param name="line">The line to record</param><param name="moreLinesAvailable">True if more lines are going to be passed to this method</param>
    /// <returns>
    /// False to allow other IAsciiCommandResponders to process the responses also
    /// </returns>
    public bool ProcessReceivedLine(IAsciiResponseLine line, bool moreLinesAvailable)
    {
      bool flag = false;
      if (AsciiResponseExtensions.HasHeader(line, this.FileBeginHeader))
      {
        this.CreateLogFile();
        flag = true;
        this.OnDownloadStarted();
        this.LineCount = 0;
      }
      else if (AsciiResponseExtensions.HasHeader(line, this.FileEndHeader))
      {
        this.CloseFile();
        flag = true;
        this.OnDownloadComplete();
      }
      else if (this.IsWithinFile)
      {
        this.writer.WriteLine(line.FullLine);
        flag = true;
        ++this.LineCount;
        if (this.LineCount % 100 == 0)
          this.OnDownloading();
      }
      return flag;
    }

    /// <summary>
    /// Disposes an instance of the FileDownloadResponder class
    /// 
    /// </summary>
    /// <param name="disposing">True to dispose managed and well as native resources</param>
    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing)
        this.CloseFile();
      this.disposed = true;
    }

    /// <summary>
    /// Raises the <see cref="E:PortableAscii2.FileDownloadResponder.DownloadComplete"/> event
    /// 
    /// </summary>
    protected virtual void OnDownloadComplete()
    {
      EventHandler eventHandler = this.DownloadComplete;
      if (eventHandler == null)
        return;
      eventHandler((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="E:PortableAscii2.FileDownloadResponder.Downloading"/> event
    /// 
    /// </summary>
    protected virtual void OnDownloading()
    {
      EventHandler eventHandler = this.Downloading;
      if (eventHandler == null)
        return;
      eventHandler((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Raises the <see cref="E:PortableAscii2.FileDownloadResponder.DownloadStarted"/> event
    /// 
    /// </summary>
    protected virtual void OnDownloadStarted()
    {
      EventHandler eventHandler = this.DownloadStarted;
      if (eventHandler == null)
        return;
      eventHandler((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Closes any previously open file and starts a new download
    /// 
    /// </summary>
    private void CreateLogFile()
    {
        // PCL cannot create a log file
      throw new NotImplementedException("Removed for cross platform");
    }

    /// <summary>
    /// Closes any open file and raises the <see cref="E:PortableAscii2.FileDownloadResponder.DownloadComplete"/> event
    /// 
    /// </summary>
    private void CloseFile()
    {
      if (this.writer == null)
        return;
      this.writer.Dispose();
      this.writer = (TextWriter) null;
    }
  }
}
