using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0033
{
    public class Solution0033 : Interface0033
    {
        /// <summary>
        /// 先用二分法找到“数组最大值”，然后再二分法找目标值
        /// 下面是二分法找“数组最大值”：
        /// 取数组的中点，
        ///     如果中点的值大于中点的下一个值，则中点是是数组的最大值
        ///     如果中点的值小于起点的值，“数组最大值”在中点的左侧
        ///     否则（中点的值大于终点的值），“数组最大值”在中点的右侧
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            if (nums.Length == 2) return nums[0] == target ? 0 : nums[1] == target ? 1 : -1;

            int len = nums.Length;
            if (nums[0] < nums[nums.Length - 1]) return BinarySearch(nums, 0, nums.Length - 1, target);  // 数组没旋转

            int k = len - 1, left = 0, right = len - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (mid == len - 1) break;
                if (nums[mid] > nums[mid + 1])
                {
                    k = mid; break;
                }
                else if (nums[mid] < nums[0])
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            if (nums[0] == target)
                return 0;
            else if (nums[0] < target)
                return BinarySearch(nums, 1, k, target);
            else
                return BinarySearch(nums, k + 1, len - 1, target);
        }

        private int BinarySearch(int[] nums, int left, int right, int target)
        {
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }
    }
}
