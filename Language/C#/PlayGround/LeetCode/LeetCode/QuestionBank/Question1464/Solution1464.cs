using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1464
{
    public class Solution1464
    {
        public int MaxProduct(int[] nums)
        {
            int max1 = nums[0] > nums[1] ? nums[0] : nums[1];  // 最大
            int max2 = nums[0] > nums[1] ? nums[1] : nums[0];  // 次大

            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i] <= max2) continue;

                if (nums[i] > max1)
                {
                    max2 = max1;
                    max1 = nums[i];
                }
                else if (nums[i] > max2)
                    max2 = nums[i];
            }

            return (max1 - 1) * (max2 - 1);
        }
    }
}
