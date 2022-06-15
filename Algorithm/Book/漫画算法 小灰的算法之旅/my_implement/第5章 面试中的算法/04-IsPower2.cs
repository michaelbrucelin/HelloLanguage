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
            int x = 255;
            Console.WriteLine($"{x} is {IsPower2(x)}");

            x = 256;
            Console.WriteLine($"{x} is {IsPower2(x)}");
        }

        /// <summary>
        /// 验证一个整数是不是2的整数次幂
        /// 原理：
        ///     如果一个整数x是2的整数次幂，必然满足下面两点
        ///         1. x的二进制必然第1位是1，其余位是0
        ///         2. x-1必然所有位均为1，且x-1的二进制比x的二进制短1位
        ///     如果一个整数不是2的整数次幂，必然不满足上面两点
        ///     所以，判断一个整数x是不是2的整数次幂，只要判断x&(x-1)是不是0即可
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPower2(int x)
        {
            return (x & (x - 1)) == 0;
        }
    }
}
