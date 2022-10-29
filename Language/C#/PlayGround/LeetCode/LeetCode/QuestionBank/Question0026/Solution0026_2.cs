using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0026
{
    public class Solution0026_2 : Interface0026
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;

            int slow = 1, fast = 1;
            while (fast < nums.Length)
            {
                if (nums[fast] != nums[fast - 1]) nums[slow++] = nums[fast];
                fast++;
            }

            return slow;
        }
    }
}
