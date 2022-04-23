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
            Console.WriteLine("********************Sync Function start {{{0}}}********************", Thread.CurrentThread.ManagedThreadId.ToString("00"));

            Action<string> action = DoSomethingLong;
            for (int i = 0; i < 5; i++)
            {
                string name = $"Sync Function_{i}";
                action.Invoke(name);  // action.Invoke()是同步调用，这里等价于直接这样使用DoSomethingLong(name);
            }
            /*
            action.Invoke()是同步调用，其实这里不需要委托，直接像下面这样写是一样的（而且更直观），只是为了和后面的异步代码一致，才这么写的
            for (int i = 0; i < 5; i++)
            {
                DoSomethingLong($"Sync Function_{i}");
            }
            */

            Console.WriteLine("********************Sync Function end {{{0}}}********************", Thread.CurrentThread.ManagedThreadId.ToString("00"));

            Console.WriteLine("主线程执行完毕，如果是WinForm项目，界面会一直卡死，直到此刻界面才恢复。");
            Console.ReadKey();
        }

        private static void DoSomethingLong(string name)
        {
            Console.WriteLine("********************DoSomethingLong start {0} {{{1}}} {2}********************",
                name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"));

            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }

            Console.WriteLine("********************DoSomethingLong   end {0} {{{1}}} {2} {3}********************",
                name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"), lResult);
        }
    }
}

/*
传统同步执行的代码，主线程会出现“卡死”的现象，例如如果是WinForm程序，就会出现卡界面的情况。
而且5个计算过程是按照顺序执行的。

********************Sync Function start {01}********************
********************DoSomethingLong start Sync Function_0 {01} 100918:801********************
********************DoSomethingLong   end Sync Function_0 {01} 100921:410 499999999500000000********************
********************DoSomethingLong start Sync Function_1 {01} 100921:411********************
********************DoSomethingLong   end Sync Function_1 {01} 100923:940 499999999500000000********************
********************DoSomethingLong start Sync Function_2 {01} 100923:940********************
********************DoSomethingLong   end Sync Function_2 {01} 100926:034 499999999500000000********************
********************DoSomethingLong start Sync Function_3 {01} 100926:034********************
********************DoSomethingLong   end Sync Function_3 {01} 100928:392 499999999500000000********************
********************DoSomethingLong start Sync Function_4 {01} 100928:392********************
********************DoSomethingLong   end Sync Function_4 {01} 100930:881 499999999500000000********************
********************Sync Function end {01}********************
主线程执行完毕，如果是WinForm项目，界面会一直卡死，直到此刻界面才恢复。
*/