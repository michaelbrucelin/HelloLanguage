using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0015
{
    public class Solution0015 : Interface0015
    {
        /// <summary>
        /// 排序，3层循环暴力解，提交会超时
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            HashSet<(int, int, int)> buffer = new HashSet<(int, int, int)>();

            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++) for (int j = i + 1; j < nums.Length; j++) for (int k = j + 1; k < nums.Length; k++)
                    {
                        int v = nums[i] + nums[j] + nums[k];
                        if (v < 0) continue;
                        if (v == 0) { buffer.Add((nums[i], nums[j], nums[k])); continue; }
                        break;  // v > 0
                    }

            List<IList<int>> result = new List<IList<int>>();
            foreach (var item in buffer) result.Add(new List<int>() { item.Item1, item.Item2, item.Item3 });

            return result;
        }
    }
}
