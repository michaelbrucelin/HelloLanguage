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

        public static long DoSomethingLong2(long l)
        {
            long r = 0;
            for (int i = 0; i < l; i++)
                r += i;

            return r;
        }

        public static void ClearTerminal()
        {
            for (int i = 0; i < 16; i++)
                Console.WriteLine();
        }
    }
}
