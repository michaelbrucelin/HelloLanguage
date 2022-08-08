using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1. Parallel.For(1, 11, i => Console.Write($\"{i} \"));");
            Parallel.For(1, 11, i => Console.Write($"{i} "));
            Console.WriteLine();

            Console.WriteLine("2. Parallel.ForEach(range, i => Console.Write($\"{i} \"));");
            var range = Enumerable.Range(1, 10);
            Parallel.ForEach(range, i => Console.Write($"{i} "));
            Console.WriteLine();

            Console.WriteLine("3. Parallel.Invoke(actions);");
            Action[] actions = new Action[10];
            for (int i = 0; i < 10; i++)
            {
                int j = i + 1;
                actions[i] = () => Console.Write($"{j} ");
            }
            Parallel.Invoke(actions);
        }
    }
}
