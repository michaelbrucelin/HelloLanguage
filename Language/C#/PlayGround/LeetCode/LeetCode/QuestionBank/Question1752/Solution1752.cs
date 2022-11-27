using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1752
{
    public class Solution1752 : Interface1752
    {
        /// <summary>
        /// 如果数组可以轮旋，需要满足下面两个条件的其中一个
        /// 1. 已经是排序后的
        /// 2. 数组可以分为前后两段，每一段都是排序的，且nums[0] >= nums[len-1]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool Check(int[] nums)
        {
            int pieces = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1]) pieces++; else continue;
                if (pieces > 2) return false;
            }
            if (pieces == 2) return nums[0] >= nums[nums.Length - 1];

            return true;
        }
    }
}
