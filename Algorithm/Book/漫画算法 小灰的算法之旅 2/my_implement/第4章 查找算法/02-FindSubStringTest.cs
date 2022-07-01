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
            string text = GetRandomString(random.Next(32768, 65536));
            string pattern = GetRandomString(random.Next(8, 16));
            Test(text, pattern);

            Console.WriteLine();
            text = "ATGTGAGCTGGTGTGTGCFAA";
            pattern = "GTGTGCF";
            Test(text, pattern);

            Console.WriteLine();
            text = new string('A', 10000) + "B";
            pattern = new string('A', 10) + "B";
            Test(text, pattern);
        }

        public static void Test(string text, string pattern)
        {
            // Console.WriteLine($"text:    {text}");
            Console.WriteLine($"text_len: {text.Length}, pattern_len: {pattern.Length}, pattern: {pattern}");

            var r_bf = FindStr_BF(text, pattern);
            var r_rk = FindStr_RK(text, pattern);
            var r_kmp = FindStr_KMP(text, pattern);

            Console.WriteLine($"BF:  {r_bf.pos}, {r_bf.cnt}");
            Console.WriteLine($"RK:  {r_rk.pos}, {r_rk.cnt}");
            Console.WriteLine($"KMP: {r_kmp.pos}, {r_kmp.cnt}");
        }

        /// <summary>
        /// 子字符串查找，Brute Force算法
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static (int pos, int cnt) FindStr_BF(string text, string pattern)
        {
            int cnt = 0;

            int m = text.Length;
            int n = pattern.Length;
            if (m < n) return (-1, cnt);

            for (int i = 0; i <= m - n; i++)
            {
                int j;
                for (j = 0; j < n && text[i + j] == pattern[j]; j++)
                {
                    cnt++;
                }

                if (j == n)
                    return (i, cnt);
            }

            return (-1, cnt);
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
        public static (int pos, int cnt) FindStr_RK(string text, string pattern)
        {
            int cnt = 0;

            int m = text.Length;
            int n = pattern.Length;
            if (m < n) return (-1, cnt);

            int hash_str = FindStr_RK_Hash(text, 0, n - 1); cnt += n;
            int hash_tar = FindStr_RK_Hash(pattern, 0, n - 1); cnt += n;

            for (int i = 0; i <= m - n; i++)
            {
                if (hash_str == hash_tar)
                {
                    int j;
                    for (j = 0; j < n && text[i + j] == pattern[j]; j++)
                        cnt++;

                    if (j == n)
                        return (i, cnt);
                }
                else if (i + n <= m - 1)  // 或i < m - n，判断是不是最后一轮
                {
                    cnt++;
                    hash_str = hash_str - text[i] + text[i + n];
                }
            }

            return (-1, cnt);
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
        public static (int pos, int cnt) FindStr_KMP(string text, string pattern)
        {
            int cnt = 0;

            int m = text.Length;
            int n = pattern.Length;
            if (m < n) return (-1, cnt);

            var nexts = GetNext(pattern);
            int[] next = nexts.next;
            cnt += nexts.cnt;

            int i = 0, j = 0;
            while (i < m && j < n)
            {
                if (text[i] == pattern[j])
                {
                    cnt++;

                    if (j == n - 1)
                        return (i - j, cnt);

                    i++;
                    j++;
                }
                else
                {
                    if (j == 0)
                        i++;
                    else
                        j = next[j];
                }
            }

            return (-1, cnt);
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
        private static (int[] next, int cnt) GetNext(string pattern)
        {
            int cnt = 0;
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

            return (next, cnt);
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

/*
text_len: 46949, pattern_len: 15, pattern: DBDDACDDABDDBBA
BF:  -1, 15564
RK:  -1, 15672
KMP: -1, 14703

text_len: 21, pattern_len: 7, pattern: GTGTGCF
BF:  12, 18
RK:  12, 33
KMP: 12, 14

text_len: 10001, pattern_len: 11, pattern: AAAAAAAAAAB
BF:  9990, 99911
RK:  9990, 10023
KMP: 9990, 10001
*/
