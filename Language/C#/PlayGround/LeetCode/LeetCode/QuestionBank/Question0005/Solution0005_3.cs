using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0005
{
    public class Solution0005_3 : Interface0005
    {
        /// <summary>
        /// 中心扩散法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            int start = 0, length = 1;
            for (int i = 0; i < s.Length - 1; i++)
            {
                var r_odd = ExpandAroundCenter(s, i, i);
                var r_even = ExpandAroundCenter(s, i, i + 1);
                if (r_even.length > r_odd.length) (r_odd, r_even) = (r_even, r_odd);

                if (r_odd.length > length) { start = r_odd.start; length = r_odd.length; }
            }

            return s.Substring(start, length);
        }

        /// <summary>
        /// 调用时保证了i==j或i+1==j，这里不做判断
        /// </summary>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private (int start, int length) ExpandAroundCenter(string s, int i, int j)
        {
            int left, right;
            if (i == j) left = right = i;
            else if (s[i] == s[j]) { left = i; right = j; }
            else return (i, 1);

            while (left > 0 && right < s.Length - 1 && s[left - 1] == s[right + 1]) { left--; right++; }

            return (left, right - left + 1);
        }
    }
}
