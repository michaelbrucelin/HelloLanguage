using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0031
{
    public class Solution0031 : Interface0031
    {
        public void NextPermutation(int[] nums)
        {
            if (nums.Length == 1) return;
            if (nums.Length == 2) { Swap(nums, 0, 1); return; }

            int id = nums.Length - 2, len = nums.Length;
            while (id >= 0 && nums[id] >= nums[id + 1]) id--;             // id是开始调整的边界
            if (id == -1) { Reverse(nums, 0, len - 1); return; }          // 特例：已经是最大排列，直接反转整个数组
            if (id == len - 2) { Swap(nums, len - 2, len - 1); return; }  // 特例：反转数组的最后两个元素即可
            int id2 = BinarySearch(nums, id + 1, len - 1, nums[id]);      // id2是用来与边界交换的元素
            Swap(nums, id, id2);
            Reverse(nums, id + 1, len - 1);
        }

        private int BinarySearch(int[] nums, int left, int right, int target)
        {
            int result = left;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (nums[mid] > target)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }

        private void Reverse(int[] nums, int left, int right)
        {
            while (left < right)
            {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int t = nums[i];
            nums[i] = nums[j];
            nums[j] = t;
        }
    }
}
