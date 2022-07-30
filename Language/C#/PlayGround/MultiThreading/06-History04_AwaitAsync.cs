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
            DoSomeThing1();
            Task task = DoSomeThing2();

            Console.ReadKey();
        }

        private static async void DoSomeThing1()
        {
            Console.WriteLine($"await+async 多线程的主线程开始 {{{Thread.CurrentThread.ManagedThreadId}}}");

            await Task.Run(() =>
            {
                Console.WriteLine($"This is await+async Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 16).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"{i}... ...");
                });
                Console.WriteLine($"This is await+async End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            });

            Console.WriteLine($"await+async 多线程的主线程结束 {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        private static async Task DoSomeThing2()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("hello world");
            });
        }
    }
}

/*
4、.NetFramework 4.5(C# 5.0、CLR 4.0)时代，使用await async
async可以单独使用，但是await必须出现在task前面，且必须和async同时使用；
await/async是个新语法，出现在.NetFramework 4.5中，只是一个语法糖，并不是一个全新的异步多线程方式
语法糖：就是编译器提供的新功能
await/async并不会产生新的线程，但是依托于Task而存在，所以在执行时，也是多线程的；

await+async 多线程的主线程开始 {1}
This is await+async Start {3}
1... ...
2... ...
3... ...
4... ...
5... ...
6... ...
7... ...
8... ...
9... ...
hello world
10... ...
11... ...
12... ...
13... ...
14... ...
15... ...
16... ...
This is await+async End   {3}
await+async 多线程的主线程结束 {3}
*/