using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.KMP
{
    public class KMP
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
        /// 由于C#中字符串与书中C定义的字符串结构不同，这里实现的是C#中字符串的next数组
        /// 索引：  012345678    012345678    01234567    012345678
        /// 字符串：ababaaaba    ababaaxba    abababca    aaaaaaaab
        /// next：  -00123112    -00123100    -0012340    -01234567    // 初始为-1，只是为了编程上的方便，没有特别的意义
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
                next[i] = j + 1;  // next[i] = j == -1 ? 0 : j + 1;
                i++; j++;
            }

            return next;
        }
    }
}
