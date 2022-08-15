using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Utils
    {
        private static Random random = new Random();

        public static void DoSomethingLong(string name)
        {
            Console.WriteLine($"DoSomethingLong start {name} {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}} {DateTime.Now.ToString("HHmmss:fff")}");

            // 下面的计算耗CPU，可能会导致CPU响应不过来而无法拖动窗口，演示效果不好
            // long lResult = 0;
            // for (int i = 0; i < 1000000000; i++)
            // {
            //     lResult += i;
            // }
            int rint = random.Next(1000, 5000);
            Console.WriteLine($"Start sleep {rint} milliseconds;");
            Thread.Sleep(rint);

            // Console.WriteLine($"DoSomethingLong   end {name} {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}} {DateTime.Now.ToString("HHmmss:fff")} {lResult}");
            Console.WriteLine($"DoSomethingLong   end {name} {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}} {DateTime.Now.ToString("HHmmss:fff")}");
        }

        public async static Task DoSomethingLongAsync(string name)
        {
            Console.WriteLine($"DoSomethingLong start {name} {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}} {DateTime.Now.ToString("HHmmss:fff")}");

            // 下面的计算耗CPU，可能会导致CPU响应不过来而无法拖动窗口，演示效果不好
            // long lResult = 0;
            // for (int i = 0; i < 1000000000; i++)
            // {
            //     lResult += i;
            // }
            await Task.Run(() =>
            {
                int rint = random.Next(1000, 5000);
                Console.WriteLine($"Start sleep {rint} milliseconds;");
                Thread.Sleep(rint);
            });

            // Console.WriteLine($"DoSomethingLong   end {name} {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}} {DateTime.Now.ToString("HHmmss:fff")} {lResult}");
            Console.WriteLine($"DoSomethingLong   end {name} {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}} {DateTime.Now.ToString("HHmmss:fff")}");
        }

        public static long DoSomethingLong2(long l)
        {
            long r = 0;
            for (int i = 0; i < l; i++)
                r += i;

            return r;
        }

        /// <summary>
        /// 在一个没有返回值的方法内部开启一个Task线程
        /// </summary>
        public static void TaskInFuncSync()
        {
            Console.WriteLine($"This is Function Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            Task.Run(() =>
            {
                Console.WriteLine($"This is Function's Task Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 32).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.Write($"{i} ");
                });
                Console.WriteLine();
                Console.WriteLine($"This is Function's Task End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            });

            Console.WriteLine($"This is Function End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// 在一个没有返回值的方法内部开启一个Task线程
        /// </summary>
        public async static Task TaskInFuncAsync()
        {
            Console.WriteLine($"This is Function Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            await Task.Run(() =>
            {
                Console.WriteLine($"This is Function's Task Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 32).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.Write($"{i} ");
                });
                Console.WriteLine();
                Console.WriteLine($"This is Function's Task End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            });

            Console.WriteLine($"This is Function End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// 与TaskInFuncAsync完全一样，只是返回值由void改为了Task
        /// </summary>
        public async static Task TaskInFuncAsync2()
        {
            Console.WriteLine($"This is Function Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            await Task.Run(() =>
            {
                Console.WriteLine($"This is Function's Task Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 32).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.Write($"{i} ");
                });
                Console.WriteLine();
                Console.WriteLine($"This is Function's Task End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            });

            Console.WriteLine($"This is Function End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        public static void ClearTerminal()
        {
            for (int i = 0; i < 16; i++)
                Console.WriteLine();
        }
    }
}
