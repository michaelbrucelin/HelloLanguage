using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1668
{
    public class Solution1668_3 : Interface1668
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public int MaxRepeating(string sequence, string word)
        {
            if (word.Length > sequence.Length) return 0;

            int[] dp = new int[sequence.Length];
            int n = sequence.Length, m = word.Length;
            for (int i = m - 1; i < n; i++)
            {
                bool flag = true;
                for (int j = 0; j < m; j++)
                    if (sequence[i - m + 1 + j] != word[j]) { flag = false; break; }

                if (flag)
                    dp[i] = i == m - 1 ? 1 : dp[i - m] + 1;
            }

            return dp.Max();
        }
    }
}
