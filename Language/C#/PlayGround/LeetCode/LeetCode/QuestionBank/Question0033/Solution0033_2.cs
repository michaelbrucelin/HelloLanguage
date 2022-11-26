using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0033
{
    public class Solution0033_2 : Interface0033
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            if (nums.Length == 2) return nums[0] == target ? 0 : nums[1] == target ? 1 : -1;

            int len = nums.Length, left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (nums[mid] == target) return mid;
                if (nums[0] <= nums[mid])  // 左侧有序
                {
                    if (nums[0] <= target && target < nums[mid]) right = mid - 1; else left = mid + 1;
                }
                else                       // 右侧有序
                {
                    if (nums[mid] < target && target <= nums[len - 1]) left = mid + 1; else right = mid - 1;
                }
            }

            return -1;
        }
    }
}
