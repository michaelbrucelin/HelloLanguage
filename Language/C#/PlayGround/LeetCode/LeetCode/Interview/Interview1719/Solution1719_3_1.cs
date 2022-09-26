using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1719
{
    public class Solution1719_3_1 : Interface1719
    {
        /// <summary>
        /// 利用加法运算，并没有异或运算好，加法既没有异或运算的快，又有可能会溢出
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MissingTwo(int[] nums)
        {
            if (nums.Length == 0) return new int[] { 1, 2 };

            int N = nums.Length + 2;
            long sum = (1 + N) * N / 2;
            for (int i = 0; i < nums.Length; i++) sum -= nums[i];
            int border = (int)(sum / 2);

            long x = (1 + border) * border / 2;
            for (int i = 0; i < nums.Length; i++) if (nums[i] <= border) x -= nums[i];

            return new int[] { (int)x, (int)(sum - x) };
        }
    }
}
