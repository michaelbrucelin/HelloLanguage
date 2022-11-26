using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0034
{
    public class Solution0034 : Interface0034
    {
        /// <summary>
        /// 二分法找左右两侧的边界
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int len = nums.Length;
            int left = BinarySearchLeftBorder(nums, 0, len - 1, target);
            if (left == len) return new int[] { -1, -1 };
            int right = BinarySearchRightBorder(nums, left, len - 1, target);
            return new int[] { left, right };
        }

        private int BinarySearchLeftBorder(int[] nums, int left, int right, int target)
        {
            int result = right + 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (nums[mid] == target) result = mid;
                if (nums[mid] >= target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return result;
        }

        private int BinarySearchRightBorder(int[] nums, int left, int right, int target)
        {
            int result = left - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (nums[mid] == target) result = mid;
                if (nums[mid] <= target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return result;
        }
    }
}
