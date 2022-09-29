using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0016
{
    public class Solution0016_3 : Interface0016
    {
        /// <summary>
        /// 排序 + 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length == 3) return nums.Sum();

            Array.Sort(nums);
            int result = nums[0] + nums[1] + nums[2];
            if (result == target) return result;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;  // 此时找到的解，一定在上一轮中已经找到了
                int left = i + 1, right = nums.Length - 1;
                while (left < right)
                {
                    int threeSum = nums[i] + nums[left] + nums[right];
                    if (threeSum == target) return threeSum;
                    if (Math.Abs(threeSum - target) < Math.Abs(result - target)) result = threeSum;
                    if (threeSum < target)
                    {
                        left++;
                        while (left < right && nums[left] == nums[left - 1]) left++;     // 此时找到的解，一定在上一轮中已经找到了
                    }
                    else
                    {
                        right--;
                        while (right > left && nums[right] == nums[right + 1]) right--;  // 此时找到的解，一定在上一轮中已经找到了
                    }
                }
            }

            return result;
        }
    }
}
