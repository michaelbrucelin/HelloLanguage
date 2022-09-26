using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1719
{
    public class Solution1719 : Interface1719
    {
        /// <summary>
        /// 将 1-N 以及 nums 中的所有值异或一次，最后的结果（不妨设为xy）将是缺失的两个数字的异或结果，且结果不为0，即至少有一位是 1（不妨设为第 n 位）
        /// 将 1-N 以及 nums 都以第 n 位是 0 或者 1 分为两组，那么：
        ///     1-N 与 nums 的第1组的合集中，包含1次缺失的数字（其中一个），其余数字均为2次
        ///     1-N 与 nums 的第2组的合集中，包含1次缺失的数字（另一个），  其余数字均为2次
        /// 这时分别对两组合集中的数字，全部异或运算，两个结果即是两个缺失值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MissingTwo(int[] nums)
        {
            if (nums.Length == 0) return new int[] { 1, 2 };

            int x = 0, y = 0;

            int N = nums.Length + 2;
            int xy = 0;
            for (int i = 1; i <= N; i++) xy ^= i;
            for (int i = 0; i < nums.Length; i++) xy ^= nums[i];  // xy为两个缺失值的异或值
            int k = 0; while ((xy & (1 << k)) == 0) k++;          // xy的第k位（右数）为1

            k = (1 << k);
            for (int i = 1; i <= N; i++) if ((i & k) == 0) x ^= i; else y ^= i;
            for (int i = 0; i < nums.Length; i++) if ((nums[i] & k) == 0) x ^= nums[i]; else y ^= nums[i];

            return new int[] { x, y };
        }

        /// <summary>
        /// 将上面的方法优化，只要找出了其中的一个值，就找到了另一个值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MissingTwo2(int[] nums)
        {
            if (nums.Length == 0) return new int[] { 1, 2 };

            int x = 0, y = 0;

            int N = nums.Length + 2;
            int xy = 0;
            for (int i = 1; i <= N; i++) xy ^= i;
            for (int i = 0; i < nums.Length; i++) xy ^= nums[i];  // xy为两个缺失值的异或值
            int k = 0; while ((xy & (1 << k)) == 0) k++;          // xy的第k位（右数）为1

            k = (1 << k);
            for (int i = 1; i <= N; i++) if ((i & k) == 0) x ^= i;
            for (int i = 0; i < nums.Length; i++) if ((nums[i] & k) == 0) x ^= nums[i];
            y = xy ^ x;

            return new int[] { x, y };
        }
    }
}
