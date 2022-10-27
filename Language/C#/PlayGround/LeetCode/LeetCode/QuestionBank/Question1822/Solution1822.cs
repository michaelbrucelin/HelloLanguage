using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1822
{
    public class Solution1822 : Interface1822
    {
        public int ArraySign(int[] nums)
        {
            int result = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) return 0;
                if (nums[i] < 0) result *= -1;
            }

            return result;
        }
    }
}
