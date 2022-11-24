using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0795
{
    public class Solution0795_2 : Interface0795
    {
        public int NumSubarrayBoundedMax(int[] nums, int left, int right)
        {
            int result = 0, last1 = -1, last2 = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > right) { last2 = i; last1 = -1; } else if (nums[i] >= left) last1 = i;
                if (last1 != -1) result += last1 - last2;
            }

            return result;
        }
    }
}
