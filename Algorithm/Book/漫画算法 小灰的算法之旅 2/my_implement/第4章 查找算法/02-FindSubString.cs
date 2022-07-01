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
            //Random random = new Random();
            //string text = GetRandomString(random.Next(97, 127));
            //string pattern = GetRandomString(random.Next(3, 7));

            //Console.WriteLine($"text:    {text}");
            //Console.WriteLine($"pattern: {pattern}");
            //Console.WriteLine($"BF:  {FindStr_BF(text, pattern)}");
            //Console.WriteLine($"RK:  {FindStr_RK(text, pattern)}");
            //Console.WriteLine($"KMP: {FindStr_KMP(text, pattern)}");

            #region 验证KMP NEXT数组算法是否正确
            string pattern = "ABABABCA";
            int[] pmt = GetPMT(pattern);
            int[] next = GetNext(pattern);
            pattern.ToList().ForEach(c => Console.Write($"{c} ")); Console.WriteLine();
            pmt.ToList().ForEach(i => Console.Write($"{i} ")); Console.WriteLine();
            next.ToList().ForEach(i => Console.Write($"{i} ")); Console.WriteLine();

            Console.WriteLine(Environment.NewLine);
            pattern = "ABABCDABABAZ";
            pmt = GetPMT(pattern);
            next = GetNext(pattern);
            pattern.ToList().ForEach(c => Console.Write($"{c} ")); Console.WriteLine();
            pmt.ToList().ForEach(i => Console.Write($"{i} ")); Console.WriteLine();
            next.ToList().ForEach(i => Console.Write($"{i} ")); Console.WriteLine();

            Console.WriteLine(Environment.NewLine);
            pattern = "ABACABADABACABABA";
            pmt = GetPMT(pattern);
            next = GetNext(pattern);
            pattern.ToList().ForEach(c => Console.Write($"{c} ")); Console.WriteLine();
            pmt.ToList().ForEach(i => Console.Write($"{i} ")); Console.WriteLine();
            next.ToList().ForEach(i => Console.Write($"{i} ")); Console.WriteLine();
            #endregion
        }

        /// <summary>
        /// 子字符串查找，Brute Force算法
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int FindStr_BF(string text, string pattern)
        {
            int m = text.Length;
            int n = pattern.Length;
            if (m < n) return -1;

            for (int i = 0; i <= m - n; i++)
            {
                int j;
                for (j = 0; j < n && text[i + j] == pattern[j]; j++) ;

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
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int FindStr_RK(string text, string pattern)
        {
            int m = text.Length;
            int n = pattern.Length;
            if (m < n) return -1;

            int hash_str = FindStr_RK_Hash(text, 0, n - 1);
            int hash_tar = FindStr_RK_Hash(pattern, 0, n - 1);

            for (int i = 0; i <= m - n; i++)
            {
                if (hash_str == hash_tar)
                {
                    int j;
                    for (j = 0; j < n && text[i + j] == pattern[j]; j++) ;

                    if (j == n)
                        return i;
                }
                else if (i + n <= m - 1)  // 或i < m - n，判断是不是最后一轮
                    hash_str = hash_str - text[i] + text[i + n];
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
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static int FindStr_KMP(string text, string pattern)
        {
            return -1;
        }

        /// <summary>
        /// KMP算法，获取pmt数组
        /// 
        /// pmt更容易理解，next在KMP算法使用时更方便
        /// 
        /// index: | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 |
        /// char:  | A | B | A | B | A | B | C | A |
        /// pmt:   | 0 | 0 | 1 | 2 | 3 | 4 | 0 | 1 |  注意这里并不是char[4]!=char[6]就得出pmt[6]是0，而是经过计算得出pmt[6]是0
        /// next:  | 0 | 0 | 0 | 1 | 2 | 3 | 4 | 0 |  next就是pmt向后偏移一位的结果
        /// 
        /// index: | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | n | n | n | n | n | n | n | m | n |
        /// char:  | A | B | A | C | A | B | A | D | . | A | B | A | C | A | B | A | B | A |
        /// pmt:   | 0 | 0 | 1 | 0 | 1 | 2 | 3 | 0 | . | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 2 | 3 |  注意char[m]
        /// next:  | 0 | 0 | 0 | 1 | 0 | 1 | 2 | 3 | 0 | . | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 2 |
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static int[] GetPMT(string pattern)
        {
            int[] pmt = new int[pattern.Length];

            int j = 0;
            for (int i = 1; i < pattern.Length; i++)
            {
                if (pattern[i] == pattern[j])
                {
                    pmt[i] = j + 1;  // 等价于：nexts[i] = nexts[i - 1] + 1;
                    j++;
                }
                else
                {
                    if (j == 0)
                    {
                        pmt[i] = 0;
                    }
                    else
                    {
                        j = pmt[j - 1];
                        while (pattern[i] != pattern[j] && j > 0)
                            j = pmt[j - 1];

                        if (pattern[i] == pattern[j])
                        {
                            pmt[i] = j + 1;
                            j++;
                        }
                        else  // j == 0 && pattern[i] != pattern[0]
                        {
                            pmt[i] = 0;
                        }
                    }
                }
            }

            return pmt;
        }

        /// <summary>
        /// KMP算法，获取next数组
        /// 
        /// pmt更容易理解，next在KMP算法使用时更方便
        /// 
        /// index: | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 |
        /// char:  | A | B | A | B | A | B | C | A |
        /// pmt:   | 0 | 0 | 1 | 2 | 3 | 4 | 0 | 1 |  注意这里并不是char[4]!=char[6]就得出pmt[6]是0，而是经过计算得出pmt[6]是0
        /// next:  | 0 | 0 | 0 | 1 | 2 | 3 | 4 | 0 |  next就是pmt向后偏移一位的结果
        /// 
        /// index: | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | n | n | n | n | n | n | n | m | n |
        /// char:  | A | B | A | C | A | B | A | D | . | A | B | A | C | A | B | A | B | A |
        /// pmt:   | 0 | 0 | 1 | 0 | 1 | 2 | 3 | 0 | . | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 2 | 3 |  注意char[m]
        /// next:  | 0 | 0 | 0 | 1 | 0 | 1 | 2 | 3 | 0 | . | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 2 |
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static int[] GetNext(string pattern)
        {
            int[] next = new int[pattern.Length];

            int j = 0;
            for (int i = 2; i < pattern.Length; i++)
            {
                if (pattern[i - 1] == pattern[j])
                {
                    next[i] = j + 1;
                    j++;
                }
                else
                {
                    if (j == 0)
                    {
                        next[i] = 0;
                    }
                    else
                    {
                        j = next[j];
                        while (pattern[i - 1] != pattern[j] && j > 0)
                            j = next[j];

                        if (pattern[i - 1] == pattern[j])
                        {
                            next[i] = j + 1;
                            j++;
                        }
                        else  // j == 0 && pattern[i - 1] != pattern[0]
                        {
                            next[i] = 0;
                        }
                    }
                }
            }

            return next;
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
