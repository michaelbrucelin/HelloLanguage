using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0805
{
    public class Solution0805 : Interface0805
    {
        /// <summary>
        /// 假定整个数组的平均值为avg，那么只要找出数组中的一部分（不可以是全部）的平均值是avg，那么剩余的那部分的平均值也一定是avg。
        /// BFS
        /// 使用BFS构建全排列结果，暴力解，提交会超时
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool SplitArraySameAverage(int[] nums)
        {
            if (nums.Length == 1) return false;
            if (nums.Length == 2) return nums[0] == nums[1];

            int len = nums.Length;
            decimal target = nums.Average(i => (decimal)i);
            if (nums[0] == target) return true;
            HashSet<(decimal sum, int cnt)> buffer = new HashSet<(decimal sum, int cnt)>() { (nums[0], 1) };  // 这里使用HashSet而不使用Queue，可以剪掉重复的运算
            for (int i = 1; i < nums.Length; i++)
            {
                HashSet<(decimal sum, int cnt)> buffer_temp = new HashSet<(decimal sum, int cnt)>();
                foreach (var item in buffer)
                {
                    decimal sum = item.sum + nums[i]; int cnt = item.cnt + 1;
                    if (cnt == len) continue;

                    if (sum / cnt == target) return true;
                    buffer_temp.Add(item);
                    buffer_temp.Add((sum, cnt));
                }
                buffer = buffer_temp;
            }

            return false;
        }
    }
}
