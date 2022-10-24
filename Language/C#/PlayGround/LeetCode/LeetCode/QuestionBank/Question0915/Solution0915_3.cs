using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0915
{
    public class Solution0915_3 : Interface0915
    {
        public int PartitionDisjoint(int[] nums)
        {
            int max_left = nums[0], max_temp = nums[0], id = 0, result = 1;
            for (; id < nums.Length; id++)
            {
                if (nums[id] > max_temp) max_temp = nums[id];
                else if (nums[id] < max_left)
                {
                    result = id + 1;
                    max_left = max_temp;
                }
            }

            return result;
        }
    }
}
