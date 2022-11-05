using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0028
{
    public class Solution0028_2 : Interface0028
    {
        /// <summary>
        /// 滑动窗口 + hash
        /// 这里hash直接使用最简单的SUM(ASCII)的形式模拟
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length) return -1;

            int m = haystack.Length, n = needle.Length;
            int hash = needle.Select(c => (int)c).Sum();
            int hash_window = haystack.Take(n).Select(c => (int)c).Sum();
            for (int i = 0; i <= m - n; i++)
            {
                if (hash_window == hash)
                {
                    bool flag = true;
                    for (int j = 0; j < n; j++) if (haystack[i + j] != needle[j]) { flag = false; break; }
                    if (flag) return i;
                }
                if (i < m - n)
                    hash_window = hash_window - (int)haystack[i] + (int)haystack[i + n];
            }

            return -1;
        }
    }
}
