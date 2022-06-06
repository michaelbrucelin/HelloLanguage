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
            Console.WriteLine(GetGCD(1680, 640));
        }

        /// <summary>
        /// 使用递归来实现计算两个整型的最大公约数
        /// 思路：
        ///       1. 如果x，y都是偶数，GCD(x, y) = 2*GCD(x/2, y/2)
        ///       2. 如果x是偶数，y是奇数，GCD(x, y) = GCD(x/2, y)
        ///       3. 如果x是奇数，y是偶数，GCD(x, y) = GCD(x, y/2)
        ///       4. 如果x是奇数，y是奇数，GCD(x, y) = GCD(x-y, y)  假定x > y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int GetGCD(int x, int y)
        {
            if (x == y)
                return x;

            if ((x & 1) == 0 && (y & 1) == 0)
                return 2 * GetGCD(x >> 1, y >> 1);
            else if ((x & 1) == 1 && (y & 1) == 0)
                return GetGCD(x, y >> 1);
            else if ((x & 1) == 0 && (y & 1) == 1)
                return GetGCD(x >> 1, y);
            else
            {
                if (x > y)
                    return GetGCD(x - y, y);
                else
                    return GetGCD(x, y - x);
            }
        }
    }
}
