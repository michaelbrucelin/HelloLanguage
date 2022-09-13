using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0005
{
    public class Solution0005_2 : Interface0005
    {
        /// <summary>
        /// DP
        /// 令s[i,j]表示字符串s中第i-1个字符到第j-1个字符之间的子串
        /// 那么s[i,j]是回文子串的前提是：
        ///     1. 当j-i <= 2时，s[i] == s[j] 
        ///     2. 当j-i > 2 时，s[i] ==s [j] 且 s[i+1,j-1]是回文子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            int len = s.Length;
            if (len < 2) return s;

            bool[,] dp = new bool[len, len];  // C#中bool值的默认值是false
            for (int i = 0; i < len; i++) dp[i, i] = true;

            // DP
            int start = 0, length = 1;
            for (int j = 0; j < len; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    if (j - i <= 2) dp[i, j] = s[i] == s[j];
                    else dp[i, j] = s[i] == s[j] && dp[i + 1, j - 1];

                    if (dp[i, j] && j - i + 1 > length) { start = i; length = j - i + 1; }
                }
            }

            return s.Substring(start, length);
        }
    }
}
