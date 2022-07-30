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
            // 这样既实现了异步，有实现了再异步方法完成后，再打印完成
            Action<string> action = DoSomethingLong;
            AsyncCallback callback = ar =>
            {
                Console.WriteLine(ar.AsyncState);
                Console.WriteLine("********************Successed {{{0}}}********************", Thread.CurrentThread.ManagedThreadId.ToString("00"));
            };

            action.BeginInvoke("DoSomethingLong", callback, "设定异步任务的执行状态");

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
使用回调函数，可以实现在异步任务完成后，去执行一个指定的方法。

********************DoSomethingLong start DoSomethingLong {03} 103115:587********************
********************DoSomethingLong   end DoSomethingLong {03} 103118:541 499999999500000000********************
设定异步任务的执行状态
********************Successed {03}********************
*/