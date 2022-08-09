using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();

            int x = random.Next(16, 64);
            int y = random.Next(16, 64);

            Console.WriteLine($"x = {x}, y = {y}");
            swap(ref x, ref y);
            Console.WriteLine($"x = {x}, y = {y}");

            string s1 = GetRandomString(6);
            string s2 = GetRandomString(8);

            Console.WriteLine($"s1 = {s1}, s2 = {s2}");
            swap<string>(ref s1, ref s2);
            Console.WriteLine($"s1 = {s1}, s2 = {s2}");
        }

        /// <summary>
        /// 适用于整型的交换变量的方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void swap(ref int x, ref int y)
        {
            x = x ^ y;
            y = x ^ y;
            x = x ^ y;
        }

        /// <summary>
        /// 通用的交换变量方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void swap<T>(ref T x, ref T y)
        {
            T t = x;
            x = y;
            y = t;
        }

        /// <summary>
        /// 通过元组实现的通用的交换变量方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void swap2<T>(ref T x, ref T y)
        {
            (x, y) = (y, x);
        }

        /// <summary>
        /// 生成随机字符串用于测试
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GetRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
