using System;
using System.Collections.Generic;
using System.Diagnostics;

static class LanguageFeatures
{
  class ProcessData
  {
    public Int32 Id;
    public Int64 Memory;
    public String Name;
  }

  static void DisplayProcesses()
  {
    // Build up a list of the running processes
    List<ProcessData> processes = new List<ProcessData>();
    foreach (Process process in Process.GetProcesses())
    {
      ProcessData data = new ProcessData();
      data.Id = process.Id;
      data.Name = process.ProcessName;
      data.Memory = process.WorkingSet64;
      processes.Add(data);
    }

    // Print out the list of processes to the console
    ObjectDumper.Write(processes);
  }

  static void Main()
  {
    DisplayProcesses();
  }
}