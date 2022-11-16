using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0775
{
    public class Solution0775_2 : Interface0775
    {
        public bool IsIdealPermutation(int[] nums)
        {
            if (nums.Length <= 2) return true;

            int min = nums[nums.Length - 1];
            for (int i = nums.Length - 3; i >= 0; i--)
            {
                if (nums[i] > min) return false;
                min = Math.Min(min, nums[i + 1]);
            }

            return true;
        }
    }
}
