using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string x = "426709752318";
            string y = "95481253129";

            Console.WriteLine($"{x,20}");
            Console.WriteLine($"+{y,19}");
            Console.WriteLine($"={BigNumberSum(x, y),19}");
        }

        /// <summary>
        /// 计算两个超大整数的和
        /// 这里是逐位运算的，
        /// 其实可以优化为每9位作为一组运算，因为9位int（int最长10位）是不会溢出的，
        /// 甚至可以考虑用long来优化，这里就不做这个优化了
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static string BigNumberSum(string x, string y)
        {
            if (!Regex.IsMatch(x, @"^\d+$")) return string.Empty;
            if (!Regex.IsMatch(y, @"^\d+$")) return string.Empty;

            int len = x.Length >= y.Length ? x.Length : y.Length;
            int[] buffer = new int[len + 1];  // 结果数组

            int[] xint = new int[len];
            x.Reverse().AsParallel().Select((c, i) => (i, c)).ForAll(e => xint[e.i] = (int)e.c - 48);
            int[] yint = new int[len];
            y.Reverse().AsParallel().Select((c, i) => (i, c)).ForAll(e => yint[e.i] = (int)e.c - 48);

            for (int i = 0; i < len; i++)
            {
                if (xint[i] + yint[i] + buffer[i] < 10)
                    buffer[i] += xint[i] + yint[i];
                else
                {
                    buffer[i] = xint[i] + yint[i] + buffer[i] - 10;
                    buffer[i + 1] = 1;
                }
            }

            buffer = buffer.Reverse().ToArray();
            int start = 0;
            for (; buffer[start] == 0 && start < buffer.Length; start++) ;  // 找出第一个不是0的位置

            string result = buffer.Where((e, i) => i >= start).Select(e => e.ToString()).Aggregate((s1, s2) => s1 + s2);

            return result;
        }
    }
}
