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
            // 一种比较笨的办法，获取一个异步操作是否完成
            // 这种操作方式会有延迟，即下面while循环中的Thread.Sleep的时间
            Action<string> action = DoSomethingLong;
            IAsyncResult asyncResult = action.BeginInvoke("uploading...", null, null);

            int i = 0;
            while (!asyncResult.IsCompleted)
            {
                Thread.Sleep(100);
                Console.WriteLine(new string('.', ++i % 10));
            }
            Console.WriteLine("Completed.");

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
通过IAsyncResult，action.BeginInvoke()的返回值判断异步操作是否完成，但是这样实现代码不够优雅，而且有延迟，或者不slepp理论上延迟可以忽略不计，但是性能可能会有影响。

********************DoSomethingLong start uploading... {03} 104610:752********************
.
..
...
....
.....
......
.......
........
.........

.
..
...
....
.....
......
.......
........
.........

.
..
...
....
.....
......
.......
........
********************DoSomethingLong   end uploading... {03} 104613:629 499999999500000000********************
.........
Completed.
*/