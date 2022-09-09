using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1262
{
    public class Solution1262_2 : Interface1262
    {
        /// <summary>
        /// 在Solution1262上进行优化
        /// 如果sum能被3整除，返回，如果不能，则sum%3只有1与2两种可能，
        ///     如果sum%3==1，则需要一个除3余1的项或两个除3余2的项
        ///     如果sum%3==2，则需要一个除3余2的项或两个除3余1的项
        /// 所以与能被3整除的数组项无关
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
                if (nums[i] % 3 == 0) continue;
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
                foreach (int item in temp) if (item % 3 != 0) buffer.Add(item);
            }

            return sum - target;
        }
    }
}
