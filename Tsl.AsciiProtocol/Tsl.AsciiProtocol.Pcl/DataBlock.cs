// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.DataBlock
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Tsl.AsciiProtocol.Pcl
{
  /// <summary>
  /// Represents a block of binary data (byte array)
  /// 
  /// </summary>
  public class DataBlock
  {
    /// <summary>
    /// Cache of the hex representation of the data
    /// 
    /// </summary>
    private string hex;
    /// <summary>
    /// Cache of the byte array representation of the data
    /// 
    /// </summary>
    private byte[] data;

    /// <summary>
    /// Gets the datablock as a Base16 (hex) string
    /// 
    /// </summary>
    public string Base16
    {
      get
      {
        if (this.hex == null)
          this.hex = DataBlock.Base16Encoding.ToBase16(this.data);
        return this.hex;
      }
    }

    /// <summary>
    /// Gets the length of the data block in bits
    /// 
    /// </summary>
    public int LengthBits
    {
      get
      {
        return this.LengthBytes * 8;
      }
    }

    /// <summary>
    /// Gets the length of the data block in bytes
    /// 
    /// </summary>
    public int LengthBytes
    {
      get
      {
        if (this.data != null)
          return this.data.Length;
        if (string.IsNullOrEmpty(this.hex))
          return this.hex.Length / 2;
        return 0;
      }
    }

    /// <summary>
    /// Gets the length of the data block in words
    /// 
    /// </summary>
    public int LengthWords
    {
      get
      {
        return this.LengthBytes / 2;
      }
    }

    /// <summary>
    /// Initializes a new instance of the DataBlock class
    /// 
    /// </summary>
    /// <param name="hex">The data represented as a hex string</param>
    public DataBlock(string hex)
    {
      try
      {
        this.data = DataBlock.Base16Encoding.Parse(hex);
        this.hex = (string) null;
      }
      catch (FormatException ex)
      {
        throw new ArgumentException(ex.Message);
      }
      if (string.IsNullOrEmpty(hex))
      {
        this.data = new byte[0];
      }
      else
      {
        try
        {
          this.data = DataBlock.Base16Encoding.Parse(hex);
        }
        catch (FormatException ex)
        {
          throw new ArgumentException(ex.Message, (Exception) ex);
        }
      }
    }

    /// <summary>
    /// Initializes a new instance of the DataBlock class
    /// 
    /// </summary>
    /// <param name="data">The data of the datablock</param>
    public DataBlock(byte[] data)
      : this(data, 0, data == null ? 0 : data.Length)
    {
    }

    /// <summary>
    /// Initializes a new instance of the DataBlock class
    /// 
    /// </summary>
    /// <param name="data">The array to copy the data from</param><param name="offset">The offset into the array to start from</param><param name="length">The number of bytes to copy</param>
    public DataBlock(byte[] data, int offset, int length)
    {
      if (data == null)
        this.data = new byte[0];
      if (offset < 0 || offset > data.Length)
        throw new ArgumentOutOfRangeException("offset");
      if (length < 0 || offset + length > data.Length)
        throw new ArgumentOutOfRangeException("length");
      this.data = new byte[length];
      Buffer.BlockCopy((Array) data, offset, (Array) this.data, 0, length);
    }

    /// <summary>
    /// Returns the value of the DataBlock as a byte array
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The value of the DataBlock as a byte array
    /// </returns>
    public byte[] ToArray()
    {
      byte[] numArray;
      if (this.data == null)
      {
        numArray = new byte[0];
      }
      else
      {
        numArray = new byte[this.data.Length];
        Buffer.BlockCopy((Array) this.data, 0, (Array) numArray, 0, this.data.Length);
      }
      return numArray;
    }

    /// <summary>
    /// Provides methods to convert to and from Base16 encoding
    /// 
    /// </summary>
    private static class Base16Encoding
    {
      /// <summary>
      /// Used to synchronise access to HexCharacters
      /// 
      /// </summary>
      private static object syncLock = new object();
      /// <summary>
      /// Cache of accepted hex characters
      /// 
      /// </summary>
      private static IDictionary<char, int> hexCharacters;

      /// <summary>
      /// Gets the accepted hex characters
      /// 
      /// </summary>
      private static IDictionary<char, int> HexCharacters
      {
        get
        {
          lock (DataBlock.Base16Encoding.syncLock)
          {
            if (DataBlock.Base16Encoding.hexCharacters == null)
            {
              DataBlock.Base16Encoding.hexCharacters = (IDictionary<char, int>) new Dictionary<char, int>();
              DataBlock.Base16Encoding.hexCharacters.Add('0', 0);
              DataBlock.Base16Encoding.hexCharacters.Add('1', 1);
              DataBlock.Base16Encoding.hexCharacters.Add('2', 2);
              DataBlock.Base16Encoding.hexCharacters.Add('3', 3);
              DataBlock.Base16Encoding.hexCharacters.Add('4', 4);
              DataBlock.Base16Encoding.hexCharacters.Add('5', 5);
              DataBlock.Base16Encoding.hexCharacters.Add('6', 6);
              DataBlock.Base16Encoding.hexCharacters.Add('7', 7);
              DataBlock.Base16Encoding.hexCharacters.Add('8', 8);
              DataBlock.Base16Encoding.hexCharacters.Add('9', 9);
              DataBlock.Base16Encoding.hexCharacters.Add('a', 10);
              DataBlock.Base16Encoding.hexCharacters.Add('A', 10);
              DataBlock.Base16Encoding.hexCharacters.Add('b', 11);
              DataBlock.Base16Encoding.hexCharacters.Add('B', 11);
              DataBlock.Base16Encoding.hexCharacters.Add('c', 12);
              DataBlock.Base16Encoding.hexCharacters.Add('C', 12);
              DataBlock.Base16Encoding.hexCharacters.Add('d', 13);
              DataBlock.Base16Encoding.hexCharacters.Add('D', 13);
              DataBlock.Base16Encoding.hexCharacters.Add('e', 14);
              DataBlock.Base16Encoding.hexCharacters.Add('E', 14);
              DataBlock.Base16Encoding.hexCharacters.Add('f', 15);
              DataBlock.Base16Encoding.hexCharacters.Add('F', 15);
            }
          }
          return DataBlock.Base16Encoding.hexCharacters;
        }
      }

      /// <summary>
      /// Parses a Base16 (hex) string and returns the byte array
      /// 
      /// </summary>
      /// <param name="hex">The value to convert</param>
      /// <returns>
      /// The value as a byte array
      /// </returns>
      public static byte[] Parse(string hex)
      {
        List<byte> list = new List<byte>();
        int num = 0;
        bool flag = true;
        for (int index1 = 0; index1 < hex.Length; ++index1)
        {
          char index2 = hex[index1];
          if (DataBlock.Base16Encoding.HexCharacters.ContainsKey(index2))
          {
            if (flag)
            {
              flag = false;
              num = DataBlock.Base16Encoding.HexCharacters[index2] * 16;
            }
            else
            {
              flag = true;
              num += DataBlock.Base16Encoding.HexCharacters[index2];
              list.Add((byte) num);
            }
          }
          else if (!char.IsWhiteSpace(index2))
            throw new FormatException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Character at position {0} is not considered as a hex character or whitespace", new object[1]
            {
              (object) index1
            }));
        }
        if (!flag)
          throw new FormatException("An additional hex digit is required to complete the value");
        return list.ToArray();
      }

      /// <summary>
      /// Converts the array to a Base16 (hex) representation
      /// 
      /// </summary>
      /// <param name="data">The data to convert</param>
      /// <returns>
      /// The Base16 equivalent of the data
      /// </returns>
      public static string ToBase16(byte[] data)
      {
        return DataBlock.Base16Encoding.ToBase16(data, 0, data == null ? 0 : data.Length);
      }

      /// <summary>
      /// Converts the array to a Base16 (hex) representation
      /// 
      /// </summary>
      /// <param name="data">The data to convert</param><param name="offset">The offset into the array to convert from</param><param name="length">The number of bytes to convert</param>
      /// <returns>
      /// The Base16 equivalent of the data
      /// </returns>
      public static string ToBase16(byte[] data, int offset, int length)
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (data != null)
        {
          if (offset < 0 || offset > data.Length)
            throw new ArgumentOutOfRangeException("offset");
          if (length < 0 || offset + length > data.Length)
            throw new ArgumentOutOfRangeException("length");
          for (int index = 0; index < length; ++index)
            stringBuilder.AppendFormat("{0:X2}", (object) data[index + offset]);
        }
        return stringBuilder.ToString();
      }
    }
  }
}
