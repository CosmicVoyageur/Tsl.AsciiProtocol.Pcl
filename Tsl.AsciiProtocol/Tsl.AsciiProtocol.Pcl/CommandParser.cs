// Decompiled with JetBrains decompiler
// Type: TechnologySolutions.Rfid.AsciiProtocol.CommandParser
// Assembly: TechnologySolutions.Rfid.AsciiProtocol.FX35, Version=1.1.5423.27429, Culture=neutral, PublicKeyToken=null
// MVID: 9C1072D5-BA32-4CFB-BB8E-6AC565EFDF12
// Assembly location: F:\Visual Studio\Repositories\IlukaOreSampleTracking\lib\Ascii 2 Windows\TechnologySolutions.Rfid.AsciiProtocol.FX35.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PortableAscii2
{
  /// <summary>
  /// Provides operations for commands
  /// 
  /// </summary>
  public static class CommandParser
  {
    /// <summary>
    /// Provides sync for the static creation of objects
    /// 
    /// </summary>
    private static object sync = new object();
    /// <summary>
    /// The cache of available commands
    /// 
    /// </summary>
    private static IEnumerable<IAsciiCommand> availableCommands;

    /// <summary>
    /// Gets the list of commands defined in this library
    /// 
    /// </summary>
    public static IEnumerable<IAsciiCommand> AvailableCommands
    {
        get           //This method was changed significantly
      {
          lock (CommandParser.sync)
          {
              if (CommandParser.availableCommands == null)
              {
                  Enumerable.ToArray(Enumerable.Where((IEnumerable<Type>)typeof(IAsciiCommand).GetTypeInfo().Assembly.DefinedTypes, (x =>
                  {if (x.GetTypeInfo().IsPublic && x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract)
                          return typeof(IAsciiCommand).GetTypeInfo().IsAssignableFrom(x.GetTypeInfo());
                      return false;
                  })));
                  availableCommands = Enumerable.ToList(Enumerable.OrderBy(Enumerable.Select(Enumerable.Where((IEnumerable<Type>)typeof(IAsciiCommand).GetTypeInfo().Assembly.DefinedTypes, (x =>
                  {
                      if (x.GetTypeInfo().IsPublic && x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract)
                          return typeof(IAsciiCommand).GetTypeInfo().IsAssignableFrom(x.GetTypeInfo());
                      return false;
                  })), (x => (IAsciiCommand)Activator.CreateInstance(x))), (x => x.GetType().Name)));
              }
          }
          return availableCommands;
          
      }
    }

    /// <summary>
    /// Parses commandLine into an <see cref="T:TechnologySolutions.Rfid.AsciiProtocol.IAsciiCommand"/> instance. Returns null if the command is not recognised
    /// 
    /// </summary>
    /// <param name="commandLine">The command</param>
    /// <returns>
    /// A command instance with the parameters parsed from the command line or null if the command was not recgnised
    /// </returns>
    public static IAsciiCommand ParseCommandLine(string commandLine)
    {
      IAsciiCommand result;
      CommandParser.TryParseCommandLine(out result, commandLine);
      return result;
    }

    /// <summary>
    /// Attempts to parse commandLine and output as result. Returns a list of validation errors if any
    /// 
    /// </summary>
    /// <param name="result">The command identified from the command line</param><param name="commandLine">the command line to parse</param>
    /// <returns>
    /// Validation messages indicating errors from the command line if any
    /// </returns>
    public static IEnumerable<string> TryParseCommandLine(out IAsciiCommand result, string commandLine)
    {
      ICollection<string> collection = (ICollection<string>) new List<string>();
      result = (IAsciiCommand) null;
      try
      {
        result = Enumerable.FirstOrDefault<IAsciiCommand>(Enumerable.Where<IAsciiCommand>(CommandParser.AvailableCommands, (Func<IAsciiCommand, bool>) (x => commandLine.StartsWith(x.CommandName, StringComparison.OrdinalIgnoreCase))));
        if (result == null)
        {
          collection.Add("no matching commands found");
        }
        else
        {
          AsciiSelfResponderCommandBase responderCommandBase;
          if ((responderCommandBase = result as AsciiSelfResponderCommandBase) == null)
            collection.Add("command instance does not support parsing parameters");
          else
            collection = responderCommandBase.ValidateAndParseParameters(commandLine);
        }
      }
      catch (Exception ex)
      {
        collection.Add("Unexpected error parsing command");
        collection.Add(ex.Message);
      }
      return (IEnumerable<string>) collection;
    }
  }
}
