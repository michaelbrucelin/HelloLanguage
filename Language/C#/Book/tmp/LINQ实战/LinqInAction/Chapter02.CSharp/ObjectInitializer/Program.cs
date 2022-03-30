using System;
using System.Collections.Generic;
using System.Diagnostics;

static class LanguageFeatures
{
  class ProcessData
  {
    public Int32 Id { get; set; }
    public Int64 Memory { get; set; }
    public String Name { get; set; }
  }

  static void DisplayProcesses()
  {
    var processes = new List<ProcessData>();
    foreach (var process in Process.GetProcesses())
    {
      processes.Add(new ProcessData { Id = process.Id,
        Name = process.ProcessName, Memory = process.WorkingSet64 });
    }

    ObjectDumper.Write(processes);
  }

  static void Main(string[] args)
  {
    DisplayProcesses();
  }
}