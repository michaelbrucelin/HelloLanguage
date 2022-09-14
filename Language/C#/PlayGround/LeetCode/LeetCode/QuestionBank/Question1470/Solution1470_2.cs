using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1470
{
    public class Solution1470_2 : Interface1470
    {
        public int[] Shuffle(int[] nums, int n)
        {
            for (int i = 1; i < n * 2 - 1; i++)
            {
                int j = (i & 1) == 1 ? ((i - 1) >> 1) + n : (i >> 1);
                nums[i] |= (nums[j] & 1023) << 10;  // nums[i] |= nums[j] << 10;  // 这样是不对的，为什么？因为高位有符号位？
            }

            for (int i = 1; i < n * 2 - 1; i++)
                nums[i] = nums[i] >> 10;

            return nums;
        }
    }
}
