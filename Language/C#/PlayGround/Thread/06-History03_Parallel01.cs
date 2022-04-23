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
            Console.WriteLine($"Parallel 多线程的主线程开始 {{{Thread.CurrentThread.ManagedThreadId}}}");

            Action action1 = () =>
            {
                Console.WriteLine($"This is Parallel 1 Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 4).ToList().ForEach(i =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"{{1}}=={i}... ...");
                });
                Console.WriteLine($"This is Parallel 1 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };
            Action action2 = () =>
            {
                Console.WriteLine($"This is Parallel 2 Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 4).ToList().ForEach(i =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"{{2}}=={i}... ...");
                });
                Console.WriteLine($"This is Parallel 2 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };
            Action action3 = () =>
            {
                Console.WriteLine($"This is Parallel 3 Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 4).ToList().ForEach(i =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"{{3}}=={i}... ...");
                });
                Console.WriteLine($"This is Parallel 3 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };
            Action action4 = () =>
            {
                Console.WriteLine($"This is Parallel 4 Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 4).ToList().ForEach(i =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"{{4}}=={i}... ...");
                });
                Console.WriteLine($"This is Parallel 4 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };

            Parallel.Invoke(action1, action2, action3, action4);

            Console.WriteLine($"Parallel 多线程的主线程结束 {{{Thread.CurrentThread.ManagedThreadId}}}");

            Console.ReadKey();
        }
    }
}

/*
3.2、.NetFramework 3.0时代，使用Task与Parallel
Parallel可以启动多线程，主线程也参与运算，所以可以节约一个线程
可以通过ParallelOptions轻松控制最大并发数量
    API：
    Parallel.For()
    Parallel.ForEach()
    Parallel.Invoke()

Parallel 多线程的主线程开始 {1}
This is Parallel 3 Start {4}
This is Parallel 2 Start {3}
This is Parallel 4 Start {5}
This is Parallel 1 Start {1}
{3}==1... ...
{2}==1... ...
{1}==1... ...
{4}==1... ...
{2}==2... ...
{4}==2... ...
{1}==2... ...
{3}==2... ...
{2}==3... ...
{4}==3... ...
{1}==3... ...
{3}==3... ...
{2}==4... ...
This is Parallel 2 End   {3}
{4}==4... ...
This is Parallel 4 End   {5}
{1}==4... ...
This is Parallel 1 End   {1}
{3}==4... ...
This is Parallel 3 End   {4}
Parallel 多线程的主线程结束 {1}
*/