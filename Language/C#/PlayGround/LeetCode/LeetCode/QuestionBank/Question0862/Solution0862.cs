using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0862
{
    public class Solution0862 : Interface0862
    {
        /// <summary>
        /// 双指针
        /// 用两个指针分别指向子数组的首尾，起始时两个指针都在数组的起始位置
        /// 首先尾指针向后移动，直至子数组和大于等于目标值，更新结果
        /// 然后首指针向后移动，直至子数组和小于目标值，如果期间有子数组和大于等于目标值，需要更新结果
        /// 重复上面的步骤即可，如果得到结果1，跳出
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int ShortestSubarray(int[] nums, int k)
        {
            int result = nums.Length + 1;
            int left = 0, right = 0, sum = 0;
            for (; right < nums.Length; right++)
            {
                sum += nums[right];
                if (sum >= k)
                {
                    result = Math.Min(result, right - left + 1);
                    if (result == 1) return 1;
                    for (; left <= right; left++)
                    {
                        sum -= nums[left];
                        if (sum >= k)
                        {
                            result = Math.Min(result, right - left + 1);
                            if (result == 1) return 1;
                        }
                        else break;
                    }
                }
            }

            return result == nums.Length + 1 ? -1 : result;
        }
    }
}
