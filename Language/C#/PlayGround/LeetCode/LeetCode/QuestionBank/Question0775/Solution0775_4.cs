using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0775
{
    public class Solution0775_4 : Interface0775
    {
        public bool IsIdealPermutation(int[] nums)
        {
            if (nums.Length <= 2) return true;

            int max = nums[0];
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] < max) return false;
                max = Math.Max(max, nums[i - 1]);
            }

            return true;
        }
    }
}
