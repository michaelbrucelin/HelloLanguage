using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1235
{
    public class Solution1235 : Interface1235
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="profit"></param>
        /// <returns></returns>
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            (int start, int end, int profit)[] jobs = new (int start, int end, int profit)[profit.Length + 1];
            jobs[0] = (0, 0, 0);  // 哨兵
            for (int i = 0; i < profit.Length; i++) jobs[i + 1] = (startTime[i], endTime[i], profit[i]);
            Array.Sort(jobs, (i, j) => i.end - j.end);

            int[] dp = new int[jobs.Length];
            dp[0] = 0;
            for (int i = 1; i < jobs.Length; i++)
            {
                int j = BinarySearch(jobs, i - 1, jobs[i].start);
                dp[i] = Math.Max(dp[i - 1], dp[j] + jobs[i].profit);
            }

            return dp[dp.Length - 1];
        }

        private int BinarySearch((int start, int end, int profit)[] jobs, int right, int target)
        {
            int left = 0, result = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (jobs[mid].end <= target)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                    right = mid - 1;
            }

            return result;
        }
    }
}
