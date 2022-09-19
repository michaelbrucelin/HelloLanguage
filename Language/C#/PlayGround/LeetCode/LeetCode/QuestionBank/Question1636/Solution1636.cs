using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1636
{
    public class Solution1636 : Interface1636
    {
        /// <summary>
        /// 不使用LINQ
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FrequencySort(int[] nums)
        {
            Dictionary<int, int> helper = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (helper.ContainsKey(nums[i])) helper[nums[i]]++;
                else helper.Add(nums[i], 1);
            }

            Array.Sort(nums, (i, j) =>
            {
                if (helper[i] != helper[j]) return helper[i] - helper[j];
                else return j - i;
            });

            return nums;
        }

        /// <summary>
        /// 使用LINQ
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FrequencySort2(int[] nums)
        {
            return nums.OrderBy(i => nums.Count(j => j == i)).ThenByDescending(i => i).ToArray();
        }
    }
}
