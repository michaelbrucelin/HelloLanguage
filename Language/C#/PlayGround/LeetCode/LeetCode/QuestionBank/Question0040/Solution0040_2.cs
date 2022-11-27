using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0040
{
    public class Solution0040_2 : Interface0040
    {
        /// <summary>
        /// 与Solution0040一样
        /// 只是去掉了生成数组的hash值放入字典去重复这一步，但是确实没产生重复值，自己也没想太清楚
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> buffer = new List<int>();
            Array.Sort(candidates);
            dfs(candidates, target, 0, buffer, result);

            return result;
        }

        private void dfs(int[] candidates, int target, int id, List<int> buffer, List<IList<int>> result)
        {
            int value = candidates[id];

            if (value < target && id + 1 < candidates.Length)  // 可以使用value，也可以不使用value
            {
                // 使用value
                List<int> list = new List<int>(buffer) { value };
                dfs(candidates, target - value, id + 1, list, result);

                // 不使用value，既然不使用value，那么后面相同的value，也不能使用
                int move = 1;
                while (id + move < candidates.Length && candidates[id + move] == candidates[id]) move++;
                if (id + move < candidates.Length) dfs(candidates, target, id + move, buffer, result);
            }
            else if (value == target)                          // 只有使用value这一种选择，因为数组升序
            {
                List<int> list = new List<int>(buffer) { value };
                result.Add(list);
            }
        }
    }
}
