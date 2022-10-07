using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1800
{
    public class Solution1800 : Interface1800
    {
        public int MaxAscendingSum(int[] nums)
        {
            int result = 0;
            int temp, id = 0;
            while (id < nums.Length)
            {
                temp = nums[id];
                while (++id < nums.Length && nums[id] > nums[id - 1]) temp += nums[id];
                if (temp > result) result = temp;
            }

            return result;
        }
    }
}
