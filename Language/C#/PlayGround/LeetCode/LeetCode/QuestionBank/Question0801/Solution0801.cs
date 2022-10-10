using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0801
{
    public class Solution0801 : Interface0801
    {
        /// <summary>
        /// DP
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int MinSwap(int[] nums1, int[] nums2)
        {
            int len = nums1.Length;
            int[,] dp = new int[2, len];
            dp[0, 0] = 0;
            dp[1, 0] = 1;

            for (int i = 1; i < len; i++)
            {
                if (nums1[i] > nums1[i - 1] && nums2[i] > nums2[i - 1] && nums1[i] > nums2[i - 1] && nums2[i] > nums1[i - 1])
                {
                    dp[0, i] = Math.Min(dp[0, i - 1], dp[1, i - 1]);      // 前一位换没换与这一位换不换没关系
                    dp[1, i] = Math.Min(dp[1, i - 1], dp[0, i - 1]) + 1;  // 前一位换没换与这一位换不换没关系
                }
                else if (nums1[i] > nums1[i - 1] && nums2[i] > nums2[i - 1])
                {
                    dp[0, i] = dp[0, i - 1];      // 前一位没换，这一位也不换
                    dp[1, i] = dp[1, i - 1] + 1;  // 前一位换了，这一位也得换
                }
                else if (nums1[i] > nums2[i - 1] && nums2[i] > nums1[i - 1])
                {
                    dp[0, i] = dp[1, i - 1];      // 前一位换了，这一位就不换
                    dp[1, i] = dp[0, i - 1] + 1;  // 前一位没换，这一位就得换
                }
            }

            return Math.Min(dp[0, len - 1], dp[1, len - 1]);
        }

        /// <summary>
        /// 使用滚动数组优化上面方法的空间复杂度
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MinSwap2(int[] nums1, int[] nums2)
        {
            int len = nums1.Length;
            int dp0 = 0, dp1 = 1;

            for (int i = 1; i < len; i++)
            {
                int dp00 = dp0, dp11 = dp1;
                if (nums1[i] > nums1[i - 1] && nums2[i] > nums2[i - 1] && nums1[i] > nums2[i - 1] && nums2[i] > nums1[i - 1])
                {
                    dp0 = Math.Min(dp00, dp11);      // 前一位换没换与这一位换不换没关系
                    dp1 = Math.Min(dp11, dp00) + 1;  // 前一位换没换与这一位换不换没关系
                }
                else if (nums1[i] > nums1[i - 1] && nums2[i] > nums2[i - 1])
                {
                    dp0 = dp00;      // 前一位没换，这一位也不换
                    dp1 = dp11 + 1;  // 前一位换了，这一位也得换
                }
                else if (nums1[i] > nums2[i - 1] && nums2[i] > nums1[i - 1])
                {
                    dp0 = dp11;      // 前一位换了，这一位就不换
                    dp1 = dp00 + 1;  // 前一位没换，这一位就得换
                }
            }

            return Math.Min(dp0, dp1);
        }
    }
}
