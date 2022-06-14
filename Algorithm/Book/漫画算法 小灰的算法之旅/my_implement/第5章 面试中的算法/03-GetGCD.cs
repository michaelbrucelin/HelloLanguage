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
            Console.WriteLine(GetGCD3(1680, 640));
        }

        /// <summary>
        /// 计算两个整数的最大公约数
        /// 使用辗转相除法，弊端：当两个整数较大时，取模（求余）运算的性能比较差
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int GetGCD(int x, int y)
        {
            int big = x > y ? x : y;
            int small = x > y ? y : x;

            if (big % small == 0)
                return small;

            return GetGCD(big % small, small);
        }

        /// <summary>
        /// 计算两个整数的最大公约数
        /// 使用更相减损术，出自《九章算术》
        /// 优点：对于两个大整数，减法运算比取模（求余）运算更快
        /// 缺点：如果两个整数相差较大，递归的层数太多，例如GetGCD2(1, 10000)，需要递归9999次
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int GetGCD2(int x, int y)
        {
            if (x == y)
                return x;

            int big = x > y ? x : y;
            int small = x > y ? y : x;
            return GetGCD2(big - small, small);
        }

        /// <summary>
        /// 计算两个整数的最大公约数
        /// 结合使用辗转相除法与更相减损术的优势，在更相减损术基础上通过移位运算来加速
        /// 思路：
        ///       1. 如果x，y都是偶数，GCD(x, y) = 2*GCD(x/2, y/2)
        ///       2. 如果x是偶数，y是奇数，GCD(x, y) = GCD(x/2, y)
        ///       3. 如果x是奇数，y是偶数，GCD(x, y) = GCD(x, y/2)
        ///       4. 如果x是奇数，y是奇数，GCD(x, y) = GCD(x-y, y)  假定x > y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int GetGCD3(int x, int y)
        {
            if (x == y)
                return x;

            if ((x & 1) == 0 && (y & 1) == 0)
                return GetGCD3(x >> 1, y >> 1) << 1;
            else if ((x & 1) == 0 && (y & 1) == 1)
                return GetGCD3(x >> 1, y);
            else if ((x & 1) == 1 && (y & 1) == 0)
                return GetGCD3(x, y >> 1);
            else
            {
                if (x > y)
                    return GetGCD3(x - y, y);
                else
                    return GetGCD3(x, y - x);
            }
        }
    }
}
