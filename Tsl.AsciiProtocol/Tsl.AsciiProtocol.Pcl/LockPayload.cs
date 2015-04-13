// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.LockPayload
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;

namespace PortableAscii2
{
  /// <summary>
  /// Encapsulates the restrictions available to protect an EPC C1G2 transponder
  /// 
  /// </summary>
  public class LockPayload
  {
    /// <summary>
    /// Restrictions for the kill password
    /// 
    /// </summary>
    private PasswordRestriction killPasswordRestriction;
    /// <summary>
    /// Restrictions for the access password
    /// 
    /// </summary>
    private PasswordRestriction accessPasswordRestriction;
    /// <summary>
    /// Restrictions for the epc memory bank
    /// 
    /// </summary>
    private MemoryBankRestriction epcMemoryBankRestriction;
    /// <summary>
    /// Restrictions for the tid memory bank
    /// 
    /// </summary>
    private MemoryBankRestriction tidMemoryBankRestriction;
    /// <summary>
    /// Restrictions for the user memory bank
    /// 
    /// </summary>
    private MemoryBankRestriction userMemoryBankRestriction;

    /// <summary>
    /// Gets or sets how the kill password (in the reserved memory bank) can be modified
    /// 
    /// </summary>
    public PasswordRestriction KillPasswordRestriction
    {
      get
      {
        return this.killPasswordRestriction;
      }
      set
      {
        this.killPasswordRestriction = value;
      }
    }

    /// <summary>
    /// Gets or sets how the access password (in the reserved memory bank) can be modified
    /// 
    /// </summary>
    public PasswordRestriction AccessPasswordRestriction
    {
      get
      {
        return this.accessPasswordRestriction;
      }
      set
      {
        this.accessPasswordRestriction = value;
      }
    }

    /// <summary>
    /// Gets or sets how the EPC memory bank can be modified
    /// 
    /// </summary>
    public MemoryBankRestriction EpcMemoryBankRestriction
    {
      get
      {
        return this.epcMemoryBankRestriction;
      }
      set
      {
        this.epcMemoryBankRestriction = value;
      }
    }

    /// <summary>
    /// Gets or sets how the TID memory bank can be modified
    /// 
    /// </summary>
    public MemoryBankRestriction TidMemoryBankRestriction
    {
      get
      {
        return this.tidMemoryBankRestriction;
      }
      set
      {
        this.tidMemoryBankRestriction = value;
      }
    }

    /// <summary>
    /// Gets or sets how the User memory bank can be modified
    /// 
    /// </summary>
    public MemoryBankRestriction UserMemoryBankRestriction
    {
      get
      {
        return this.userMemoryBankRestriction;
      }
      set
      {
        this.userMemoryBankRestriction = value;
      }
    }

    /// <summary>
    /// Gets or sets all the restrictions as a Lock Command Payload
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// 
    /// <para>
    /// See the EPC Global Class 1 Generation 2 specification for the lock command payload bitmask
    /// 
    /// </para>
    /// 
    /// <para>
    /// The set accessor only accepts changing the restriction on a per memory/password basis.
    ///             i.e. If you adjust a permsission you must change both bits
    /// 
    /// </para>
    /// 
    /// </remarks>
    /// <exception cref="T:System.ArgumentOutOfRangeException">If the mask bits for a particular section is not set together (i.e. mask bits are not 00 or 11)</exception>
    public int Payload
    {
      get
      {
        return LockPayload.ToPayload(this);
      }
      set
      {
        LockPayload lockPayload = LockPayload.Parse(value);
        this.AccessPasswordRestriction = lockPayload.AccessPasswordRestriction;
        this.KillPasswordRestriction = lockPayload.KillPasswordRestriction;
        this.EpcMemoryBankRestriction = lockPayload.EpcMemoryBankRestriction;
        this.TidMemoryBankRestriction = lockPayload.TidMemoryBankRestriction;
        this.UserMemoryBankRestriction = lockPayload.UserMemoryBankRestriction;
      }
    }

    /// <summary>
    /// Initializes a new instance of the LockPayload class with no change restrictions
    /// 
    /// </summary>
    public LockPayload()
    {
      this.accessPasswordRestriction = PasswordRestriction.NoChange;
      this.epcMemoryBankRestriction = MemoryBankRestriction.NoChange;
      this.killPasswordRestriction = PasswordRestriction.NoChange;
      this.tidMemoryBankRestriction = MemoryBankRestriction.NoChange;
      this.userMemoryBankRestriction = MemoryBankRestriction.NoChange;
    }

    /// <summary>
    /// Initializes a new instance of the LockPayload class with the specified payload
    /// 
    /// </summary>
    /// <param name="payload">The payload for the lock restrictions</param>
    public LockPayload(int payload)
    {
      this.Payload = payload;
    }

    /// <summary>
    /// Convert the restriction to a C1G2 compatible payload value
    /// 
    /// </summary>
    /// <param name="payload">The restriction to convert to a payload</param>
    /// <returns>
    /// The lock payload
    /// </returns>
    public static int ToPayload(LockPayload payload)
    {
      int num = 0;
      if (payload.UserMemoryBankRestriction != MemoryBankRestriction.NoChange)
        num = (int) ((MemoryBankRestriction) num | payload.UserMemoryBankRestriction & MemoryBankRestriction.AlwaysNotWritable | (MemoryBankRestriction) 3072);
      if (payload.TidMemoryBankRestriction != MemoryBankRestriction.NoChange)
        num = num | (int) (payload.TidMemoryBankRestriction & MemoryBankRestriction.AlwaysNotWritable) << 2 | 12288;
      if (payload.EpcMemoryBankRestriction != MemoryBankRestriction.NoChange)
        num = num | (int) (payload.EpcMemoryBankRestriction & MemoryBankRestriction.AlwaysNotWritable) << 4 | 49152;
      if (payload.AccessPasswordRestriction != PasswordRestriction.NoChange)
        num = num | (int) (payload.AccessPasswordRestriction & PasswordRestriction.AlwaysNotAccessible) << 6 | 196608;
      if (payload.KillPasswordRestriction != PasswordRestriction.NoChange)
        num = num | (int) (payload.KillPasswordRestriction & PasswordRestriction.AlwaysNotAccessible) << 8 | 786432;
      return num;
    }

    /// <summary>
    /// Parse the restrictions from a C1G2 payload
    /// 
    /// </summary>
    /// <param name="payload">The payload to parse</param>
    /// <returns>
    /// The restriction from the payload
    /// </returns>
    public static LockPayload Parse(int payload)
    {
      LockPayload lockPayload = new LockPayload();
      lockPayload.UserMemoryBankRestriction = (MemoryBankRestriction) (payload & 3);
      lockPayload.TidMemoryBankRestriction = (MemoryBankRestriction) (payload >> 2 & 3);
      lockPayload.EpcMemoryBankRestriction = (MemoryBankRestriction) (payload >> 4 & 3);
      lockPayload.AccessPasswordRestriction = (PasswordRestriction) (payload >> 6 & 3);
      lockPayload.KillPasswordRestriction = (PasswordRestriction) (payload >> 8 & 3);
      int num1 = payload >> 10 & 3;
      if (num1 != 3)
      {
        lockPayload.UserMemoryBankRestriction = MemoryBankRestriction.NoChange;
        if (num1 != 0)
          throw new ArgumentOutOfRangeException("payload", "Invalid user memory bank restriction");
      }
      int num2 = payload >> 12 & 3;
      if (num2 != 3)
      {
        lockPayload.TidMemoryBankRestriction = MemoryBankRestriction.NoChange;
        if (num2 != 0)
          throw new ArgumentOutOfRangeException("payload", "Invalid TID memory bank restriction");
      }
      int num3 = payload >> 14 & 3;
      if (num3 != 3)
      {
        lockPayload.EpcMemoryBankRestriction = MemoryBankRestriction.NoChange;
        if (num3 != 0)
          throw new ArgumentOutOfRangeException("payload", "Invalid EPC memory bank restriction");
      }
      int num4 = payload >> 16 & 3;
      if (num4 != 3)
      {
        lockPayload.AccessPasswordRestriction = PasswordRestriction.NoChange;
        if (num4 != 0)
          throw new ArgumentOutOfRangeException("payload", "Invalid access password restriction");
      }
      int num5 = payload >> 18 & 3;
      if (num5 != 3)
      {
        lockPayload.KillPasswordRestriction = PasswordRestriction.NoChange;
        if (num5 != 0)
          throw new ArgumentOutOfRangeException("payload", "Invalid kill password restriction");
      }
      return lockPayload;
    }
  }
}
