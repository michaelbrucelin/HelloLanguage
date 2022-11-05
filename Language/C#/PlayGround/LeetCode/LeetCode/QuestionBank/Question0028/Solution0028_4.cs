using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0028
{
    public class Solution0028_4 : Interface0028
    {
        /// <summary>
        /// KMP2，优化了next数组
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length) return -1;
            if (needle.Length == haystack.Length) return needle == haystack ? 0 : -1;

            int[] next = GetNext(needle);
            int i = 0, j = 0, len_s = haystack.Length, len_t = needle.Length;
            while (len_s - i >= len_t - j)
            {
                while (i < len_s && j < len_t && haystack[i] == needle[j]) { i++; j++; };

                if (j == len_t) return i - len_t;
                j = next[j];
                if (j == -1) { i++; j++; }
            }

            return -1;
        }

        private int[] GetNext(string s)
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
                { if (s[i] != s[0]) next[i] = 0; else next[i] = -1; }
                else
                { if (s[i] != s[j]) next[i] = j + 1; else next[i] = next[j]; }
                i++; j++;
            }

            return next;
        }
    }
}
