using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0053_1
{
    public class Solution0053 : Interface0053
    {
        /// <summary>
        /// 随便找到一个目标值，然后中心扩散
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            int result = 0, target_id = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] < target)
                    low = mid + 1;
                else if (nums[mid] > target)
                    high = mid - 1;
                else
                {
                    target_id = mid;
                    break;
                }
            }

            if (target_id != -1)
            {
                result++;
                for (int i = target_id - 1; i >= 0; i--) if (nums[i] == target) result++; else break;
                for (int i = target_id + 1; i < nums.Length; i++) if (nums[i] == target) result++; else break;
            }

            return result;
        }
    }
}
