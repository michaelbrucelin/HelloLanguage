using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0053_2
{
    public class Solution0053 : Interface0053
    {
        public int MissingNumber(int[] nums)
        {
            int left = 0, right = nums.Length;
            int mid = left + (right - left) / 2;
            while (left < right)
            {
                if (nums[mid] == mid)
                    left = mid + 1;
                else
                    right = mid;
                mid = left + (right - left) / 2;
            }

            return mid;
        }

        public int MissingNumber2(int[] nums)
        {
            int low = 0, high = nums.Length;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == mid)
                    low = mid + 1;
                else
                    high = mid;
            }

            return low;
        }
    }
}