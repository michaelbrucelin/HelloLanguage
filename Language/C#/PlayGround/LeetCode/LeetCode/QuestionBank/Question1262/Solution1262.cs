using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1262
{
    public class Solution1262 : Interface1262
    {
        /// <summary>
        /// 贪心法
        /// 先将整个数组求和，如果和能被3整除，返回，如果不能，将数组排序，一点一点向下减
        /// 难点在于向下减的过程，即减去的应该是数组所有组合的和
        ///     假设数组（排序后）是{1， 1， 1， 1， 2， 9， 12}，依次减去的是{1, 2, 3, 4, 5, 6, 10, 11, 12, 13, 14, 15, ...}
        /// 这里使用一个SortedSet（有序Hash表）记录所有尝试过的组合，进而构建新的组合，过程如下
        /// 数组：{A, B, C, D}，SortedSet为{ }
        /// 遍历A，SortedSet为{A}
        /// 遍历B，SortedSet为{A} + {B, AB} = {A, B, AB}
        /// 遍历C，SortedSet为{A, B, AB} + {C, AC, BC, ABC} = {A, B, AB, C, AC, BC, ABC}
        /// 遍历D，SortedSet为{A, B, AB, C, AC, BC, ABC} + {D, AD, BD, ABD, CD, ACD, BCD, ABCD} = { ... ... }
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSumDivThree(int[] nums)
        {
            int sum = nums.Sum();
            if (sum % 3 == 0) return sum;

            int target = sum;
            Array.Sort(nums);
            SortedSet<int> buffer = new SortedSet<int>();    // 需要从小到大排序
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target) return sum - target;  // 已经不存在比target更小的解了
                if (!buffer.Contains(nums[i]) && (sum - nums[i]) % 3 == 0) return sum - nums[i];  // 单项的解一定是最小解（一定是nums[i] < target）

                HashSet<int> temp = new HashSet<int>() { nums[i] };
                foreach (int j in buffer)
                {
                    int item = j + nums[i];

                    if (!buffer.Contains(item))
                    {
                        if ((sum - item) % 3 == 0) target = item < target ? item : target;
                        temp.Add(item);
                    }
                }
                foreach (int item in temp) buffer.Add(item);
            }

            return 0;
        }
    }
}
