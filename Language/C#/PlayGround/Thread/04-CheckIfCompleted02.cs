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
            // 通过信号量来探测多线程操作是否完成
            Action<string> action = DoSomethingLong;
            IAsyncResult asyncResult = action.BeginInvoke("uploading...", null, null);

            // 阻塞当前进程，直到收到信号量，信号量从asyncResult中发出，无延迟
            asyncResult.AsyncWaitHandle.WaitOne();
            Console.WriteLine("Completed.");

            // asyncResult.AsyncWaitHandle.WaitOne(-1);    // 一直等待，与WaitOne()相同
            // asyncResult.AsyncWaitHandle.WaitOne(1000);  // 阻塞当前线程，等待且最多等待1000ms，超时就放弃阻塞
            // 这个通常用在做超时处理，当一个操作（比如连接服务器）超时，就切换任务（连接另外一个服务器），或者放弃操作、报异常、提示结果等操作

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
使用信号量来探测多线程操作是否完成，但是这里例子并不好，因为这样做和单线程同步操作并没有什么不同，还不如直接同步执行了。

********************DoSomethingLong start uploading... {03} 105550:000********************
********************DoSomethingLong   end uploading... {03} 105552:713 499999999500000000********************
Completed.
*/