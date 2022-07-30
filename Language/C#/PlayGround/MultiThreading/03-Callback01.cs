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
            // 这样虽然实现了异步，但是在业务逻辑上是错误的，异步方法还没有完成，就打印完成了
            Action<string> action = DoSomethingLong;
            action.BeginInvoke("DoSomethingLong", null, null);

            Console.WriteLine("********************Successed {{{0}}}********************", Thread.CurrentThread.ManagedThreadId.ToString("00"));

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
这样虽然实现了异步，但是在业务逻辑上是错误的，异步方法还没有完成，就打印完成了。

********************Successed {01}********************
********************DoSomethingLong start DoSomethingLong {03} 102459:574********************
********************DoSomethingLong   end DoSomethingLong {03} 102502:478 499999999500000000********************
*/