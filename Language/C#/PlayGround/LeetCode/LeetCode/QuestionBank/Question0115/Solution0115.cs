using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0115
{
    public class Solution0115 : Interface0115
    {
        /// <summary>
        /// DP，见Solution0115_my.xlsx
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int NumDistinct(string s, string t)
        {
            int row = s.Length, col = t.Length;
            int[,] dp = new int[row, col];

            dp[0, 0] = s[0] == t[0] ? 1 : 0;
            for (int c = 1; c < col; c++) dp[0, c] = 0;
            for (int r = 1; r < row; r++) if (s[r] == t[0]) dp[r, 0] = dp[r - 1, 0] + 1; else dp[r, 0] = dp[r - 1, 0];

            for (int c = 1; c < col; c++) for (int r = 1; r < row; r++)
                {
                    if (s[r] == t[c])
                        dp[r, c] = dp[r - 1, c - 1] + dp[r - 1, c];
                    else
                        dp[r, c] = dp[r - 1, c];
                }

            return dp[row - 1, col - 1];
        }

        /// <summary>
        /// 优化空间复杂度
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int NumDistinct2(string s, string t)
        {
            int[] dp = new int[s.Length];

            dp[0] = s[0] == t[0] ? 1 : 0;
            for (int i = 1; i < s.Length; i++)
                if (s[i] == t[0]) dp[i] = dp[i - 1] + 1; else dp[i] = dp[i - 1];

            for (int i = 1; i < t.Length; i++)
            {
                char c = t[i];
                int[] dptemp = new int[dp.Length];
                for (int j = 1; j < s.Length; j++)
                {
                    if (s[j] == c)
                        dptemp[j] = dptemp[j - 1] + dp[j - 1];
                    else
                        dptemp[j] = dptemp[j - 1];
                }
                dp = dptemp;
            }

            return dp[s.Length - 1];
        }
    }
}
