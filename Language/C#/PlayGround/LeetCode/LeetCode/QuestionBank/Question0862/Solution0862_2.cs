using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0862
{
    public class Solution0862_2 : Interface0862
    {
        /// <summary>
        /// 用List代替双向队列
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int ShortestSubarray(int[] nums, int k)
        {
            int n = nums.Length;
            long[] preSumArr = new long[n + 1];
            for (int i = 0; i < n; i++)
                preSumArr[i + 1] = preSumArr[i] + nums[i];

            int result = n + 1;
            List<int> queue = new List<int>();
            for (int i = 0; i <= n; i++)
            {
                long curSum = preSumArr[i];
                while (queue.Count != 0 && curSum - preSumArr[queue[0]] >= k)
                {
                    result = Math.Min(result, i - queue[0]); queue.RemoveAt(0);
                }
                while (queue.Count != 0 && preSumArr[queue.Last()] >= curSum)
                {
                    queue.RemoveAt(queue.Count - 1);
                }
                queue.Add(i);
            }

            return result < n + 1 ? result : -1;
        }

        /// <summary>
        /// 用LinkedList代替双向队列，很慢，比List慢了无数倍，
        /// 没理解LinkedList在只有两端操作的情况下仍然比List慢那么多，那LinkedList的使用场景是？
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int ShortestSubarray2(int[] nums, int k)
        {
            int n = nums.Length;
            long[] preSumArr = new long[n + 1];
            for (int i = 0; i < n; i++)
                preSumArr[i + 1] = preSumArr[i] + nums[i];

            int result = n + 1;
            LinkedList<int> queue = new LinkedList<int>();
            for (int i = 0; i <= n; i++)
            {
                long curSum = preSumArr[i];
                while (queue.Count != 0 && curSum - preSumArr[queue.First()] >= k)
                {
                    result = Math.Min(result, i - queue.First()); queue.RemoveFirst();
                }
                while (queue.Count != 0 && preSumArr[queue.Last()] >= curSum)
                {
                    queue.RemoveLast();
                }
                queue.AddLast(i);
            }

            return result < n + 1 ? result : -1;
        }
    }
}
