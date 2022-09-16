using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0053_1
{
    public class Solution0053_2 : Interface0053
    {
        /// <summary>
        /// 两次二分查找，分别找到目标值左右边界
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int leftborder;
            int low = 0, high = nums.Length - 1;
            while (low <= high)  // 寻找目标值的左边界
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] < target) low = mid + 1; else high = mid;
            }
            if (low > high) return 0; else leftborder = low;

            low = 0; high = nums.Length - 1;
            while (low <= high)  // 寻找目标值的右边界
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] <= target) low = mid; else high = mid - 1;
            }

            if (low > high) return 0; else return low - leftborder + 1;
        }
    }
}
