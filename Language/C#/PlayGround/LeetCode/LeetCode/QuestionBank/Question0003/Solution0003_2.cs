using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0003
{
    public class Solution0003_2 : Interface0003
    {
        /// <summary>
        /// 与Solution0003一样，稍加优化，用Hash表即可，无需字典
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            int result = 0;

            HashSet<char> buffer = new HashSet<char>();
            int start = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!buffer.Contains(s[i])) buffer.Add(s[i]);
                else
                {
                    result = Math.Max(result, i - start);
                    while (s[start] != s[i]) { buffer.Remove(s[start]); start++; }
                    start++;
                }
            }

            return Math.Max(result, buffer.Count);
        }
    }
}
