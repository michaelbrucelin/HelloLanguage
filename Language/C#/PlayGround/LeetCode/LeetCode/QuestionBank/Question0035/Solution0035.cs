using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0035
{
    public class Solution0035
    {
        public int SearchInsert(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    low = mid + 1;
                else
                    high = mid;
            }

            // low == high
            if (nums[low] < target)
                return low + 1;
            else
                return low;
        }
    }
}
