using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0940
{
    public class Solution0940_3 : Interface0940
    {
        public int DistinctSubseqII(string s)
        {
            const int MOD = 1000000007;

            int[] helper = new int[26];
            int[] dp = new int[s.Length];
            helper[s[0] - 'a'] = 1; dp[0] = 2;
            for (int i = 1; i < s.Length; i++)
            {
                dp[i] = ((dp[i - 1] * 2) % MOD - helper[s[i] - 'a'] + MOD) % MOD;
                helper[s[i] - 'a'] = dp[i - 1];
            }

            return dp[dp.Length - 1] - 1;
        }

        /// <summary>
        /// 对空间复杂度进行优化
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int DistinctSubseqII2(string s)
        {
            const int MOD = 1000000007;

            int[] helper = new int[26];
            helper[s[0] - 'a'] = 1;
            int dp = 2;
            for (int i = 1; i < s.Length; i++)
            {
                int temp = dp;
                dp = ((temp * 2) % MOD - helper[s[i] - 'a'] + MOD) % MOD;
                helper[s[i] - 'a'] = temp;
            }

            return dp - 1;
        }
    }
}
