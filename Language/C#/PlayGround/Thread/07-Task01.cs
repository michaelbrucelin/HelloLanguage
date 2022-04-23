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
            Random random = new Random();

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => DoSomethingLong("Task1", random.Next(1000000000, 2000000000))));
            tasks.Add(Task.Run(() => DoSomethingLong("Task2", random.Next(1000000000, 2000000000))));
            tasks.Add(Task.Run(() => DoSomethingLong("Task3", random.Next(1000000000, 2000000000))));
            tasks.Add(Task.Run(() => DoSomethingLong("Task4", random.Next(1000000000, 2000000000))));

            // 阻塞当前线程，直到任意一个任务完成，由于主线程（UI线程）被阻塞，所以会卡界面
            Task.WaitAny(tasks.ToArray());
            Console.WriteLine("完成了一个线程");

            // 阻塞当前线程，直到所有任务全部都完成，由于主线程（UI线程）被阻塞，所以会卡界面
            // 既需要多线程来提高性能，又需要在所有线程全部完成后才能执行下一步操作时，可以这样使用
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("所有线程全部完成");

            Console.ReadKey();
        }

        private static void DoSomethingLong(string name, int times)
        {
            Console.WriteLine("********************{0}-{1} start {{{2}}} {3}********************",
                name, times, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"));

            long lResult = 0;
            for (int i = 0; i < times; i++)
            {
                lResult += i;
            }

            Console.WriteLine("********************{0}-{1}   end {{{2}}} {3} {4}********************",
               name, times, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("HHmmss:fff"), lResult);
        }
    }
}

/*
这里演示Task.WaitAny()、Task.WaitAll()、TaskFactory.ContinueWhenAny()、TaskFactory.ContinueWhenAll()四个方法，这四个方法之间由于线程的不可预测性，没有先后顺序，但是只要灵活应用，基本上能解决绝大多数多线程业务场景；
示例1、在使用多线程时，并等待多线程完成

********************Task1-1003222636 start {03} 161325:449********************
********************Task2-1872779859 start {04} 161325:449********************
********************Task3-1200987100 start {06} 161325:544********************
********************Task4-1489598375 start {05} 161325:544********************
********************Task1-1003222636   end {03} 161328:734 503227828189782930********************
完成了一个线程
********************Task3-1200987100   end {06} 161329:643 721185006582711450********************
********************Task4-1489598375   end {05} 161330:539 1109451658656521125********************
********************Task2-1872779859   end {04} 161331:798 1753652199201640011********************
所有线程全部完成
*/