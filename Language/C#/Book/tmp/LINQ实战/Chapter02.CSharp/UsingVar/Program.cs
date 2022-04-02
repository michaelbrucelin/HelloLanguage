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
            var data = new ProcessData();
            data.Id = process.Id;
            data.Name = process.ProcessName;
            data.Memory = process.WorkingSet64;
            processes.Add(data);
        }

        ObjectDumper.Write(processes);
    }

    static void Main(string[] args)
    {
        DisplayProcesses();
    }
}