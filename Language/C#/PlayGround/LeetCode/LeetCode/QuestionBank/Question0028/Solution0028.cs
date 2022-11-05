using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0028
{
    public class Solution0028 : Interface0028
    {
        /// <summary>
        /// 暴力解法
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length) return -1;

            int m = haystack.Length, n = needle.Length;
            for (int i = 0; i <= m - n; i++)
            {
                bool flag = true;
                for (int j = 0; j < n; j++) if (haystack[i + j] != needle[j]) { flag = false; break; }
                if (flag) return i;
            }

            return -1;
        }

        /// <summary>
        /// 直接使用API
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr2(string haystack, string needle)
        {
            return haystack.IndexOf(needle);
        }
    }
}
