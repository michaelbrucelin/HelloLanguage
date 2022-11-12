using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0790
{
    public class Solution0790 : Interface0790
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// DP
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTilings(int n)
        {
            int[,] dp = new int[n + 1, 4]; dp[0, 3] = 1;
            for (int i = 1; i <= n; i++)
            {
                dp[i, 0] = dp[i - 1, 3];
                dp[i, 1] = (dp[i - 1, 0] + dp[i - 1, 2]) % MOD;
                dp[i, 2] = (dp[i - 1, 0] + dp[i - 1, 1]) % MOD;
                dp[i, 3] = (((dp[i - 1, 0] + dp[i - 1, 1]) % MOD + dp[i - 1, 2]) % MOD + dp[i - 1, 3]) % MOD;
            }
            return dp[n, 3];
        }

        /// <summary>
        /// 滚动数组
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumTilings2(int n)
        {
            (int, int, int, int) prev = (0, 0, 0, 1);
            (int, int, int, int) curr = (-1, -1, -1, -1);
            for (int i = 1; i <= n; i++)
            {
                curr.Item1 = prev.Item4;
                curr.Item2 = (prev.Item1 + prev.Item3) % MOD;
                curr.Item3 = (prev.Item1 + prev.Item2) % MOD;
                curr.Item4 = (((prev.Item1 + prev.Item2) % MOD + prev.Item3) % MOD + prev.Item4) % MOD;
                prev = curr;
            }
            return curr.Item4;
        }
    }
}
