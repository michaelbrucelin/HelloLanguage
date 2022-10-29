using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0026
{
    public class Solution0026 : Interface0026
    {
        public int RemoveDuplicates(int[] nums)
        {
            int result = nums.Length;
            for (int i = 1; i < result; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    for (int j = i; j < result - 1; j++) nums[j] = nums[j + 1];
                    i--; result--;
                }
            }

            return result;
        }
    }
}
