using System;
using System.Collections.Generic;
using System.Diagnostics;

static class LanguageFeatures
{
  static void DisplayProcesses(Func<Process, Boolean> match)
  {
    var processes = new List<Object>();
    foreach (var process in Process.GetProcesses())
    {
      if (match(process))
      {
        processes.Add( new { process.Id, Name=process.ProcessName,
          Memory=process.WorkingSet64 } );
      }
    }

    ObjectDumper.Write(processes);
  }

  static void Main(string[] args)
  {
    DisplayProcesses(process => process.WorkingSet64 >= 20 * 1024 * 1024);
  }
}