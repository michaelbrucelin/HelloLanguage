using System;
using System.Diagnostics;
using System.Linq;

namespace QueryExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            // Method syntax (dot-notation)
            var processes1 = Process.GetProcesses()
                .Where(process => process.WorkingSet64 > 20 * 1024 * 1024)
                .OrderByDescending(process => process.WorkingSet64)
                .Select(process => new { process.Id, Name = process.ProcessName });

            Console.WriteLine("With method syntax:");
            foreach (var process in processes1)
                Console.WriteLine(process);

            Console.WriteLine();

            // Query expression
            var processes2 = from process in Process.GetProcesses()
                             where process.WorkingSet64 > 20 * 1024 * 1024
                             orderby process.WorkingSet64 descending
                             select new { process.Id, Name = process.ProcessName };

            Console.WriteLine("With query expression:");
            foreach (var process in processes2)
                Console.WriteLine(process);
        }
    }
}
