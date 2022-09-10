using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0003
{
    public class Solution0003 : Interface0003
    {
        /// <summary>
        /// 用一个字典记录当前子串中的元素以及每个元素的位置即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            int result = 0;

            Dictionary<char, int> buffer = new Dictionary<char, int>();
            int start = 0;  // 不重复子串的起点
            for (int i = 0; i < s.Length; i++)
            {
                if (!buffer.ContainsKey(s[i])) buffer.Add(s[i], i);
                else
                {
                    result = Math.Max(result, i - start);
                    for (int j = start; j < buffer[s[i]]; j++) buffer.Remove(s[j]);
                    start = buffer[s[i]] + 1;
                    buffer[s[i]] = i;
                }
            }

            return Math.Max(result, buffer.Count);
        }
    }
}
