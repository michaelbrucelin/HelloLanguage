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
            Console.WriteLine("********************Async Function start {{{0}}}********************", Thread.CurrentThread.ManagedThreadId.ToString("00"));

            Action<string> action = DoSomethingLong;
            for (int i = 0; i < 5; i++)
            {
                string name = $"Async Function_{i}";
                action.BeginInvoke(name, null, null);  // action.BeginInvoke()是异步调用
            }

            Console.WriteLine("********************Async Function end {{{0}}}********************", Thread.CurrentThread.ManagedThreadId.ToString("00"));

            Console.WriteLine("上面的运算（子线程）并没有执行完，主线程就直接往下执行了，如果是WinForm项目，界面不会出现卡死的现象。");
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
异步执行，这里可以看到，5个计算任务（子线程）并没有完成，甚至都还没有开始，主线程就向下继续执行了，如果是WinForm程序，就不会出现界面卡死的现象。
而且观察结果也可以发现5个子线程也没有按照代码顺序执行。

********************Async Function start {01}********************
********************Async Function end {01}********************
上面的运算（子线程）并没有执行完，主线程就直接往下执行了，如果是WinForm项目，界面不会出现卡死的现象。
********************DoSomethingLong start Async Function_3 {05} 100834:553********************
********************DoSomethingLong start Async Function_0 {04} 100834:553********************
********************DoSomethingLong start Async Function_1 {06} 100834:553********************
********************DoSomethingLong start Async Function_2 {03} 100834:553********************
********************DoSomethingLong   end Async Function_2 {03} 100838:043 499999999500000000********************
********************DoSomethingLong start Async Function_4 {03} 100838:043********************
********************DoSomethingLong   end Async Function_3 {05} 100838:070 499999999500000000********************
********************DoSomethingLong   end Async Function_1 {06} 100838:151 499999999500000000********************
********************DoSomethingLong   end Async Function_0 {04} 100838:386 499999999500000000********************
********************DoSomethingLong   end Async Function_4 {03} 100840:803 499999999500000000********************
*/