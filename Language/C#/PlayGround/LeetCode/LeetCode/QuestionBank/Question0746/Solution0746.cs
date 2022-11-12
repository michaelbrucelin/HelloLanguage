using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0746
{
    public class Solution0746 : Interface0746
    {
        /// <summary>
        /// DP
        /// 要到达楼顶（数组越界），必须先到达数组的最后一项或者倒数第二项
        /// 所以f(n) = Min(f(n-1)+cost[n-1], f(n-2)+cost[n-2])
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            int[] dp = new int[cost.Length + 1]; dp[0] = 0; dp[1] = 0;
            for (int i = 2; i < dp.Length; i++)
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);

            return dp[dp.Length - 1];
        }

        /// <summary>
        /// DP，滚动数组
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs2(int[] cost)
        {
            int dp1 = 0, dp2 = 0, dp3 = -1;
            for (int i = 2; i <= cost.Length; i++)
            {
                dp3 = Math.Min(dp2 + cost[i - 1], dp1 + cost[i - 2]);
                dp1 = dp2; dp2 = dp3;
            }

            return dp3;
        }
    }
}
