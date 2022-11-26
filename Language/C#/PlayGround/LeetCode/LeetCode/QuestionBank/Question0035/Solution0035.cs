using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0035
{
    public class Solution0035 : Interface0035
    {
        public int SearchInsert(int[] nums, int target)
        {
            int result = nums.Length;
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (nums[mid] >= target)
                {
                    result = mid;
                    right = mid - 1;
                }
                else
                    left = mid + 1;
            }

            return result;
        }

        public int SearchInsert2(int[] nums, int target)
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
