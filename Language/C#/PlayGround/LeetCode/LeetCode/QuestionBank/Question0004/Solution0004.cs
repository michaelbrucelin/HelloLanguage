using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0004
{
    /// <summary>
    /// 未完成
    /// </summary>
    public class Solution0004 : Interface0004
    {
        /// <summary>
        /// 二分法
        /// 只要找到了两个数组中最小的(m+n)/2个元素即可，所以可以使用二分法
        /// 用二分法拆解较小的数组，用小数组驱动大数组，时间复杂度为O(log(min(m,n)))
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length) (nums1, nums2) = (nums2, nums1);  // 让nums1是长度更短的那个数组

            int target = (nums2.Length - nums1.Length) / 2 + nums1.Length;     // (nums1.Length + nums2.Length) / 2;
            int low = 0, high = nums1.Length - 1, mid1 = 0, mid2 = 0;
            while (low <= high)
            {
                mid1 = (high - low) / 2 + low;  // nums1中取前mid1+1个元素
                mid2 = target - mid1 - 2;       // nums2中取前mid2+1个元素
                if (mid1 < nums1.Length - 1 && nums2[mid2] > nums1[mid1 + 1]) { low = mid1 + 1; continue; }
                if (mid2 < nums2.Length - 1 && nums1[mid1] > nums2[mid2 + 1]) { high = mid1 - 1; continue; }
                break;
            }

            if (((nums1.Length + nums2.Length) & 1) == 1)
            {
                if (mid1 == nums1.Length - 1) return nums2[mid2 + 1];
                if (mid2 == nums2.Length - 1) return nums1[mid1 + 1];
                return Math.Min(nums1[mid1 + 1], nums2[mid2 + 1]);
            }
            else
            {
                int left = Math.Min(nums1[mid1], nums2[mid2]);
                if (mid1 == nums1.Length - 1)
                {
                    
                    return nums2[mid2 + 1];
                }
                if (mid2 == nums2.Length - 1) return nums1[mid1 + 1];
                return Math.Min(nums1[mid1 + 1], nums2[mid2 + 1]);
            }
        }
    }
}
