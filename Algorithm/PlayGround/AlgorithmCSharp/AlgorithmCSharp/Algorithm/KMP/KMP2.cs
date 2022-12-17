using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.KMP
{
    public class KMP2
    {
        public int CharIndex_KMP(string s, string t)
        {
            if (s.Length < t.Length) return -1;
            if (s.Length == t.Length) return s == t ? 0 : -1;

            int[] next = GetNext(t);
            int i = 0, j = 0, len_s = s.Length, len_t = t.Length;  // i是s的索引，j是t的索引
            while (len_s - i >= len_t - j)
            {
                while (i < len_s && j < len_t && s[i] == t[j]) { i++; j++; };

                if (j == len_t) return i - len_t;
                j = next[j];
                if (j == -1) { i++; j++; }
            }

            return -1;
        }

        /// <summary>
        /// 优化next数组，具体的比较KMP2.GetNext()与KMP.GetNext()
        /// 索引：  012345678    012345678    01234567    012345678
        /// 字符串：ababaaaba    ababaaxba    abababca    aaaaaaaab
        /// next：  -0-12--12    -0-12-10-    -0-1234-    -0-0-0-07    // 初始为-1，只是为了编程上的方便，没有特别的意义
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] GetNext(string s)
        {
            if (s.Length == 0) return new int[0];
            if (s.Length == 1) return new int[1] { -1 };
            if (s.Length == 2) return new int[2] { -1, 0 };

            int[] next = new int[s.Length]; next[0] = -1; next[1] = 0;
            int i = 2, j = 0;
            while (i < s.Length)
            {
                while (j >= 0 && s[i - 1] != s[j]) j = next[j];
                if (j == -1)
                {
                    if (s[i] != s[0]) next[i] = 0; else next[i] = -1;
                }
                else
                {
                    if (s[i] != s[j]) next[i] = j + 1; else next[i] = next[j];
                }
                i++; j++;
            }

            return next;
        }
    }
}
