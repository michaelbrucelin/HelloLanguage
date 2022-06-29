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
            string str = GetRandomString(random.Next(97, 127));
            string target = GetRandomString(random.Next(3, 7));

            Console.WriteLine($"str:\t{str}");
            Console.WriteLine($"target:\t{target}");
            Console.WriteLine($"BF:  {FindStr_BF(str, target)}");
            Console.WriteLine($"RK:  {FindStr_RK(str, target)}");
            Console.WriteLine($"KMP: {FindStr_KMP(str, target)}");
        }

        /// <summary>
        /// 子字符串查找，Brute Force算法
        /// </summary>
        /// <param name="str"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int FindStr_BF(string str, string target)
        {
            int m = str.Length;
            int n = target.Length;
            if (m < n) return -1;

            for (int i = 0; i <= m - n; i++)
            {
                int j;
                for (j = 0; j < n && str[i + j] == target[j]; j++) ;

                if (j == n)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// 子字符串查找，Rabin-Karp算法
        /// 与BF算法逐位比较两个字符串不同的是，RK算法先比较两个字符串的hash值，如果相同再逐位比较两个字符串（因为存在hash冲突）
        /// 所以RK算法中hash算法的选择就比较重要了，要尽可能满足下面几点
        ///     1. 算法要简单，如果算法复杂度大于两个字符串逐位比较就没有意义了
        ///     2. 可以利用前一个子串更快的计算出下一个子串，即hash计算并不是独立的
        ///        例如已知"abcdefg"的hash值，可以利用它更快的算出"bcdefgh"的hash值
        ///        本质上与第1点的目的是一致的
        ///     3. 要尽可能少的hash冲突，否则会退化为Brute Force算法（其实更糟，因为还多计算了hash值）
        /// 这里为了方便演示，hash算法直接采用逐位相加字符串每一个字符的ASCII码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int FindStr_RK(string str, string target)
        {
            int m = str.Length;
            int n = target.Length;
            if (m < n) return -1;

            int hash_str = FindStr_RK_Hash(str, 0, n - 1);
            int hash_tar = FindStr_RK_Hash(target, 0, n - 1);

            for (int i = 0; i <= m - n; i++)
            {
                if (hash_str == hash_tar)
                {
                    int j;
                    for (j = 0; j < n && str[i + j] == target[j]; j++) ;

                    if (j == n)
                        return i;
                }
                else if (i + n <= m - 1)  // 或i < m - n，判断是不是最后一轮
                    hash_str = hash_str - str[i] + str[i + n];
            }

            return -1;
        }

        /// <summary>
        /// RK算法的hash算法
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static int FindStr_RK_Hash(string str, int start, int end)
        {
            int hash = 0;
            for (int i = start; i <= end; i++)
                hash += (str[i] - 'a');

            return hash;
        }

        /// <summary>
        /// 子字符串查找，KMP算法
        /// D.E.Knuth，J.H.Morris和V.R.Pratt
        /// </summary>
        /// <param name="str"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int FindStr_KMP(string str, string target)
        {
            return -1;
        }

        /// <summary>
        /// 生成随机字符串用于测试
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GetRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCD";

            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
