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
            Parallel.For(0, 100, i => Console.Write($"{i} "));     // for(int i = 0; i < 100; i++) Console.Write($"{i} ") 的并行版本（使用线程池线程并行处理）
            Console.WriteLine();

            Console.WriteLine("2. Parallel.ForEach(range, i => Console.Write($\"{i} \"));");
            var range = Enumerable.Range(0, 100);
            Parallel.ForEach(range, i => Console.Write($"{i} "));  // foreach(int i in range) Console.Write($"{i} ") 的并行版本（使用线程池线程并行处理）
            Console.WriteLine();

            Console.WriteLine("3. Parallel.Invoke(actions);");
            Action[] actions = new Action[100];
            for (int i = 0; i < actions.Length; i++)
            {
                int j = i + 1;
                actions[i] = () => Console.Write($"{j} ");
            }
            Parallel.Invoke(actions);                              // actions[0](); actions[1](); ... actions[99](); 的并行版本（使用线程池线程并行处理）
        }
    }
}

/*
Parallel类内部使用的是Task对象。
*/
