using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0026
{
    public class Solution0026_3 : Interface0026
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;

            int slow = 1, fast = 1;
            while (fast < nums.Length)
            {
                if (nums[fast] != nums[fast - 1])
                {
                    if (fast - slow > 0) nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }

            return slow;
        }
    }
}
