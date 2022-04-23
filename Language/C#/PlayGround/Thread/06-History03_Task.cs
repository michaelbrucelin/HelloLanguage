using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Task 多线程的主线程开始 {{{Thread.CurrentThread.ManagedThreadId}}}");

            Action action = () =>
            {
                Console.WriteLine($"This is Task Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 16).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"{i}... ...");
                });
                Console.WriteLine($"This is Task End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };
            Task task = new Task(action);
            task.Start();

            Console.WriteLine($"Task 多线程的主线程结束 {{{Thread.CurrentThread.ManagedThreadId}}}");

            Console.ReadKey();
        }
    }
}

/*
3.1、.NetFramework 3.0时代，使用Task与Parallel
Task被称之为C#多线程的最佳实践
Task线程全部来自于线程池，同时提供了丰富的api，非常适合开发实战

Task 多线程的主线程开始 {1}
Task 多线程的主线程结束 {1}
This is Task Start {3}
1... ...
2... ...
3... ...
4... ...
5... ...
6... ...
7... ...
8... ...
9... ...
10... ...
11... ...
12... ...
13... ...
14... ...
15... ...
16... ...
This is Task End   {3}
*/