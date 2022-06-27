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
            Random random = new Random();
            string[] arr = new string[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = GetRandomString(5));

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");

            RadixSort2(arr);

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");
        }

        /// <summary>
        /// 基数排序
        /// 基数排序就是将数组中的每一项都“补齐”到相同的“宽度”，然后逐位进行比较。
        /// 基数排序既可以从高位优先进行排序（Most Significant Digit first，简称MSD），
        ///         也可以从低位优先进行排序（Least Significant Digit first，简称LSD）。
        /// 个人理解就是字符串排序法
        /// 
        /// 下面简单描述一下LSD：
        /// bda, cfd, qwe, yui, abc, rrr, uue  // 原始数组
        /// bda, abc, cfd, qwe, uue, yui, rrr  // 第1轮，按最后1位排序
        /// abc, bda, cfd, rrr, uue, yui, qwe  // 第2轮，按倒数第2位排序
        /// abc, bda, cfd, qwe, rrr, uue, yui  // 第3轮，按倒数第3位排序
        /// 
        /// 下面实现一下LSD，为了简化，只考虑由小写字母构成的字符串数组
        /// </summary>
        /// <param name="arr"></param>
        public static void RadixSort(string[] arr)
        {
            int maxlen = arr[0].Length;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].Length > maxlen)
                    maxlen = arr[i].Length;
            }

            // 创建桶，由于这里是简化实现，str只有小写字母，所以只需要27个桶，其中"空位"放0号桶，'a'放1号桶，'b'放2号桶...，'z'放26号桶
            List<string>[] buckets = new List<string>[27];

            int p = maxlen;
            while (--p >= 0)
            {
                for (int i = 0; i < buckets.Length; i++) buckets[i] = new List<string>();  // 初始化每一个桶
                for (int i = 0; i < arr.Length; i++)                                       // 将每一个元素放到对应的桶中
                    buckets[GetCharIndex(arr[i], p)].Add(arr[i]);

                // 将桶中的每一个元素写回原数组中
                int index = 0;
                for (int i = 0; i < buckets.Length; i++)
                {
                    for (int j = 0; j < buckets[i].Count; j++)
                    {
                        arr[index++] = buckets[i][j];
                    }
                }
            }
        }

        /// <summary>
        /// 基数排序
        /// MSD就是先比较字符串的第1位，第1位相同的字符串比较字符串的第2位...，一次类推
        /// 
        /// 下面实现一下MSD，为了简化，只考虑由小写字母构成的字符串数组
        /// 这里用递归实现
        /// </summary>
        /// <param name="arr"></param>
        public static void RadixSort2(string[] arr)
        {

        }

        /// <summary>
        /// 获取字符串第k位字符所对应的桶的序号
        /// 
        /// 由于这里是简化实现，str只有小写字母，所以只需要27个桶，其中
        /// 空位放0号桶，'a'放1号桶，'b'放2号桶...，'z'放26号桶
        /// </summary>
        /// <param name="str"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static int GetCharIndex(string str, int k)
        {
            // 如果str位数不够，返回0，相当于在str后面补'0'
            if (k >= str.Length) return 0;

            return str[k] - 96;
        }

        /// <summary>
        /// 生成随机字符串用于测试
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GetRandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz";

            return new string(Enumerable.Repeat(chars, random.Next(1, length + 1))
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
