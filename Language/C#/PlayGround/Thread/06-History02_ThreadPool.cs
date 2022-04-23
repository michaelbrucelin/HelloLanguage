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
            Console.WriteLine($"ThreadPool 多线程的主线程开始 {{{Thread.CurrentThread.ManagedThreadId}}}");

            WaitCallback waitCallback = o =>
            {
                Console.WriteLine($"This is ThreadPool Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 16).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"{i}... ...");
                });
                Console.WriteLine($"This is ThreadPool End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };
            ThreadPool.QueueUserWorkItem(waitCallback);

            Console.WriteLine($"ThreadPool 多线程的主线程结束 {{{Thread.CurrentThread.ManagedThreadId}}}");

            Console.ReadKey();
        }
    }
}

/*
2、.NetFramework 2.0时代（新的CLR），使用ThreadPool
ThreadPool，池化资源管理设计思想，线程是一种资源，在Thread时代，每次使用线程，都需要向操作系统申请，使用完后再释放掉；
池化就是做一个容器，容器提前申请n个线程，当程序需要使用线程时，直接去容器中获取，用完后再放回容器，避免频繁申请和销毁；
容器管理着每个线程的控制状态（闲置，忙碌等），容器还会根据当前闲置线程的数量，主动申请（扩容）和释放线程资源；
优点：1、线程复用；2、可以限制最大线程数量
缺点：API太少了，线程的等待、顺序控制太弱（可以通过MRE，ManualResetEvent控制），影响了实战
    API：
    ThreadPool.GetMaxThreads();
    ThreadPool.GetMinThreads();
    ThreadPool.SetMaxThreads();
    ThreadPool.SetMinThreads();

ThreadPool 多线程的主线程开始 {1}
ThreadPool 多线程的主线程结束 {1}
This is ThreadPool Start {3}
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
This is ThreadPool End   {3}
*/