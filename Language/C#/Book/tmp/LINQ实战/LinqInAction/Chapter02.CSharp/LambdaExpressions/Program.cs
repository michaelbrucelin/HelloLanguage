using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

static class LanguageFeatures
{
    class Customer
    {
        public String Name { get; set; }
    }

    class Person
    {
        public Int32 Age { get; set; }
        public String City { get; set; }
    }

    class ProcessData
    {
        public Int32 Id { get; set; }
        public Int64 Memory { get; set; }
        public String Name { get; set; }
    }

    class Program
    {
        static void DisplayProcesses(Predicate<Process> match)
        {
            var processes = new List<ProcessData>();
            foreach (var process in Process.GetProcesses())
            {
                if (match(process))
                {
                    processes.Add(new ProcessData
                    {
                        Id = process.Id,
                        Name = process.ProcessName,
                        Memory = process.WorkingSet64
                    });
                }
            }

            ObjectDumper.Write(processes);
        }

        static void Main(string[] args)
        {
            DisplayProcesses(process => process.WorkingSet64 >= 20 * 1024 * 1024);

            //
            // Sample lambda expressions declared as delegates
            //

            Func<int, int> lambda1 = x => x + 1;                    // Implicitly typed, expression body
            Func<int, int> lambda2 = x => { return x + 1; };        // Implicitly typed, statement body
            Func<int, int> lambda3 = (int x) => x + 1;              // Explicitly typed, expression body
            Func<int, int> lambda4 = (int x) => { return x + 1; };  // Explicitly typed, statement body
            Func<int, int, int> lambda5 = (x, y) => x * y;          // Multiple parameters
            Func<int> lambda6 = () => 1;                            // No parameters, expression body
            Action lambda7 = () => Console.WriteLine();             // No parameters, statement body
            Func<Customer, String> lambda8 = customer => customer.Name;
            Func<Person, Boolean> lambda9 = person => person.City == "Paris";
            Func<Person, Int32, Boolean> lambda10 = (person, minAge) => person.Age >= minAge;

            // lambda expression without parameter
            Func<DateTime> getDateTime = () => DateTime.Now;

            // lambda expression with an implicitly-typed string parameter
            Action<string> printImplicit = s => Console.WriteLine(s);

            // lambda expression with an explicitly-typed string parameter
            Action<string> printExplicit = (string s) => Console.WriteLine(s);

            // lambda expression with two implicitly-typed parameters
            Func<int, int, int> sumInts = (x, y) => x + y;

            // Predicate<T> and Func<T, Boolean> are equivalent (but not compatible)
            Predicate<int> equalsOne1 = x => x == 1;
            Func<int, bool> equalsOne2 = x => x == 1;

            // these lambda expressions have expression bodies
            Func<int, int> incInt = x => x + 1;
            Func<int, double> incIntAsDouble = x => x + 1;

            // lambda expression with a statement body and explicitly-typed parameters
            Func<int, int, int> comparer = (int x, int y) =>
            {
                if (x > y) return 1;
                if (x < y) return -1;
                return 0;
            };
        }
    }
}