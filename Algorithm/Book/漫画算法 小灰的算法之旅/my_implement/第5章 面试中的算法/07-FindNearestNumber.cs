using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            int i = 0, x = 12345;
            while (x > 0 && i < 10)
            {
                Console.WriteLine($"{i++}: {x}");
                x = FindNearestNumber2(x);
            }
        }

        /// <summary>
        /// 题目：
        /// 给出一个正整数，找出这个正整数所有数字全排列的下一个数。
        /// 如果输入12345，则返回12354。
        /// 如果输入12354，则返回12435。
        /// 如果输入12435，则返回12453。
        /// 
        /// 原理：
        /// 如果是固定的几位数字，逆序排列的数字最大，逆序排列的数字最小。
        /// 
        /// 思路：
        /// 数字从右向左，找到最小（最短）的非逆序区域，假定长度为n，则n-1的区域是逆序区，那么调整这个区域即可。
        /// 1. 从后向前，找出最大的逆序区域
        /// 2. 让最大逆序区域的前一位与逆序区域中大于它的最小值交换位置
        /// 3. 然后将原逆序区域的数字调整为顺序区域即可
        /// 
        /// 将整型转为字符串实现
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int FindNearestNumber(int x)
        {
            if (x < 0) return -1;
            if (x < 10) return x;

            char[] xchars = x.ToString().ToCharArray();

            int border = xchars.Length - 2;
            for (; border >= 0 && xchars[border] >= xchars[border + 1]; border--) ;  // 如果i >= 0，则i为第1位非逆序区，如果i == -1，整个数字为逆序
            if (border == -1) return -1;

            char big = (char)((int)'9' + 1);  // 任意一个比'9'大的char即可，遍历后就是用来与border交换的数字
            int bigid = -1;                   // big的索引
            for (int i = border + 1; i < xchars.Length; i++)
            {
                if (xchars[i] > xchars[border] && xchars[i] < big)
                {
                    big = xchars[i];
                    bigid = i;
                }
            }

            // 交换border与big
            char temp = xchars[border];
            xchars[border] = xchars[bigid];
            xchars[bigid] = temp;

            // 对原逆序区域做顺序处理，这里从简处理
            var tails = xchars
                            .Where((c, i) => i > border)
                            .OrderBy(c => c);
            int index = border;
            foreach (char c in tails)
                xchars[++index] = c;

            return Convert.ToInt32(new string(xchars));
        }

        /// <summary>
        /// 给出一个正整数，找出这个正整数所有数字全排列的下一个数。
        /// 
        /// 用整型实现
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int FindNearestNumber2(int x)
        {
            if (x < 0) return -1;
            if (x < 10) return x;

            int x0 = x;

            List<int> x0tail = new List<int>(10);  // 整型的最大值为2147483647，长度为10

            x0tail.Add(x0 % 10);
            x0 /= 10;

            while (x0 > 0 && x0 % 10 >= x0tail[x0tail.Count - 1])
            {
                x0tail.Add(x0 % 10);
                x0 /= 10;
            }

            if (x0 == 0) return -1;                // x0 == 0，则整个数字逆序

            int border = x0 % 10;                  // 第1个非逆序的数字
            int big = 10;                          // 任意一个比9大的int即可，遍历后就是用来与border交换的数字
            int bigid = -1;                        // big的索引
            for (int i = 0; i < x0tail.Count; i++)
            {
                if (x0tail[i] > border && x0tail[i] < big)
                {
                    big = x0tail[i];
                    bigid = i;
                }
            }

            x0tail[bigid] = border;                // 将第1个非逆序数字放到逆序区域

            x0tail.Sort();
            return x / (int)Math.Pow(10, x0tail.Count + 1) * (int)Math.Pow(10, x0tail.Count + 1)
                   + big * (int)Math.Pow(10, x0tail.Count)
                   + Convert.ToInt32(string.Concat(x0tail));
        }
    }
}
