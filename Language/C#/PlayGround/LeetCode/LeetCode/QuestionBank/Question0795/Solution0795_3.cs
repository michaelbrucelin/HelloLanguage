using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0795
{
    public class Solution0795_3 : Interface0795
    {
        public int NumSubarrayBoundedMax(int[] nums, int left, int right)
        {
            return CountLower(nums, right) - CountLower(nums, left - 1);
        }

        private int CountLower(int[] nums, int lower)
        {
            int result = 0, temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= lower) temp++; else temp = 0;
                result += temp;
            }

            return result;
        }
    }
}
