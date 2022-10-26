using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0862
{
    public class Solution0862 : Interface0862
    {
        /// <summary>
        /// 未完成
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int ShortestSubarray(int[] nums, int k)
        {
            int result = nums.Length + 1;

            return result == nums.Length + 1 ? -1 : result;
        }
    }
}
