using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0104
{
    public class Solution0104 : Interface0104
    {
        /// <summary>
        /// 原理与一笔画一致，出现奇数次的字符要么没有，要么只有一个（放在中间）。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CanPermutePalindrome(string s)
        {
            Dictionary<char, int> buffer = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
                if (buffer.ContainsKey(s[i])) buffer[s[i]]++; else buffer.Add(s[i], 1);

            int oddcnt = 0;
            foreach (char key in buffer.Keys)
            {
                if ((buffer[key] & 1) == 1)
                {
                    oddcnt++;
                    if (oddcnt > 1) return false;
                }
            }

            return true;
        }
    }
}
