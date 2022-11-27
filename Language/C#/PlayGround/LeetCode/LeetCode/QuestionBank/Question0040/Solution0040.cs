using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0040
{
    public class Solution0040 : Interface0040
    {
        /// <summary>
        /// 提交会超时，参考测试用例3
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Dictionary<string, List<int>> helper = new Dictionary<string, List<int>>();
            List<int> buffer = new List<int>();
            Array.Sort(candidates);
            dfs(candidates, target, 0, buffer, helper);

            return new List<IList<int>>(helper.Values);
        }

        private void dfs(int[] candidates, int target, int id, List<int> buffer, Dictionary<string, List<int>> helper)
        {
            int value = candidates[id];

            if (value < target && id + 1 < candidates.Length)  // 可以使用value，也可以不使用value
            {
                // 使用value
                List<int> list = new List<int>(buffer) { value };
                dfs(candidates, target - value, id + 1, list, helper);

                // 不使用value，既然不使用value，那么后面相同的value，也不能使用
                int move = 1;
                while (id + move < candidates.Length && candidates[id + move] == candidates[id]) move++;
                if (id + move < candidates.Length) dfs(candidates, target, id + move, buffer, helper);
            }
            else if (value == target)                          // 只有使用value这一种选择，因为数组升序
            {
                List<int> list = new List<int>(buffer) { value };
                string s = list.Select(i => i.ToString()).Aggregate((i1, i2) => $"{i1},{i2}");
                if (!helper.ContainsKey(s)) helper.Add(s, list);
            }
        }
    }
}
