using System;
using System.Collections.Generic;
using System.Diagnostics;

static class LanguageFeatures
{
    static void DisplayProcesses()
    {
        // Build up a list of the running processes
        List<String> processes = new List<String>();
        foreach (Process process in Process.GetProcesses())
            processes.Add(process.ProcessName);

        // Print out the list of processes to the console
        ObjectDumper.Write(processes);
    }

    static void Main()
    {
        DisplayProcesses();
    }
}