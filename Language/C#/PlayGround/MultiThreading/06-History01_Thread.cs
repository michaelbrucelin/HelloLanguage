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
            Console.WriteLine($"Thread 多线程的主线程开始 {{{Thread.CurrentThread.ManagedThreadId}}}");

            ThreadStart threadStart = () =>
            {
                Console.WriteLine($"This is Thread Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 16).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"{i}... ...");
                });
                Console.WriteLine($"This is Thread End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };
            Thread thread = new Thread(threadStart);
            thread.Start();

            Console.WriteLine($"Thread 多线程的主线程结束 {{{Thread.CurrentThread.ManagedThreadId}}}");

            Console.ReadKey();
        }
    }
}

/*
.NetFramework有N多个版本，有M多个多线程的使用方式。
1、.NetFramework 1.0和1.1时代，使用Thread
    Thread的API特别丰富，可以玩的很花哨，但是一般人根本玩不好，主要是因为线程资源是操作系统管理的，响应并不灵敏，所以不好控制
    Thread启动线程没有控制，真的可以一个循环启动100W个线程，导致系统死机
    Thread就像给了一个四岁小孩一把热武器，威力很大，但是造成的破坏可能更大
    thread.Suspend();     // 挂起线程
    thread.Resume();      // 恢复线程
    thread.Join();        // 等待线程
    thread.IsBackground;  // 设置前后台线程
    thread.Abort();       // 销毁线程
    Thread.ResetAbort();  // 将销毁的线程恢复

Thread 多线程的主线程开始 {1}
Thread 多线程的主线程结束 {1}
This is Thread Start {3}
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
This is Thread End   {3}
*/