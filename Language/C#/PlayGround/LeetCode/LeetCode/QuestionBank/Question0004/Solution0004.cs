using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0004
{
    public class Solution0004 : Interface0004
    {
        /// <summary>
        /// 二分法
        /// 只要使用二分法找到了两个数组中最小的(m+n)/2+1个元素即可
        ///     如果m+n是奇数，那么最小的(m+n)/2+1个元素中最大的那个元素就是中位数
        ///     如果m+n是偶数，那么最小的(m+n)/2+1个元素中最大的那两个元素的均值就是中位数
        /// 只要确定其中一个数组的位置，那么另一个数组的位置也一定确定了，因为要找的元素的数量是固定的(m+n)/2+1个
        /// 用二分法拆解较小的数组，用小数组驱动大数组，时间复杂度为O(log(min(m,n)))
        /// 明确驱动小数组除了时间复杂度更低之外，还有一个好处就是只要小数组可能达到数组的边界，编码更简单一些
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length) (nums1, nums2) = (nums2, nums1);   // 让nums1是长度更短的那个数组

            int m = nums1.Length, n = nums2.Length;
            int target = (n - m) / 2 + m + 1;   // (m + n) / 2 + 1;
            int low = 0, high = m - 1;
            int mid1 = (int)Math.Floor((high - low) / 2d) + low;  // nums1中取前mid1+1个元素
            int mid2 = target - mid1 - 2;       // nums2中取前mid2+1个元素
            while (low <= high)
            {
                if (mid1 < m - 1 && nums2[mid2] > nums1[mid1 + 1])
                {
                    low = mid1 + 1; mid1 = (int)Math.Floor((high - low) / 2d) + low; mid2 = target - mid1 - 2; continue;
                }
                if (mid2 < n - 1 && nums1[mid1] > nums2[mid2 + 1])
                {
                    high = mid1 - 1; mid1 = (int)Math.Floor((high - low) / 2d) + low; mid2 = target - mid1 - 2; continue;
                }
                break;
            }

            if (((m + n) & 1) == 1)
            {
                if (mid1 >= m) return nums2[target - m - 1];
                if (mid1 < 0) return nums2[target - 1];
                return Math.Max(nums1[mid1], nums2[mid2]);
            }
            else
            {
                List<int> buffer = new List<int>();
                if (mid1 >= m)
                {
                    if (m >= 2) { buffer.Add(nums1[m - 1]); buffer.Add(nums1[m - 2]); }
                    else if (m == 1) buffer.Add(nums1[0]);
                }
                else
                {
                    if (mid1 >= 0) buffer.Add(nums1[mid1]);
                    if (mid1 - 1 >= 0) buffer.Add(nums1[mid1 - 1]);
                }

                if (mid2 >= 0) buffer.Add(nums2[mid2]);
                if (mid2 - 1 >= 0) buffer.Add(nums2[mid2 - 1]);

                buffer = buffer.OrderByDescending(i => i).ToList();

                return (buffer[0] + buffer[1]) / 2d;
            }
        }
    }
}
