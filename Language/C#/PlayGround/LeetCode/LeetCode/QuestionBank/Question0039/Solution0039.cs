using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0039
{
    public class Solution0039 : Interface0039
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> buffer = new List<int>();
            dfs(candidates, target, 0, buffer, result);

            return result;
        }

        private void dfs(int[] candidates, int target, int id, List<int> buffer, List<IList<int>> result)
        {
            int value = candidates[id];

            // 使用candidates[id]
            if (value < target)
            {
                List<int> list = new List<int>(buffer) { value };
                dfs(candidates, target - value, id, list, result);
            }
            else if (value == target)
            {
                List<int> list = new List<int>(buffer) { value };
                result.Add(list);
            }

            // 不使用candidates[id]
            if (id + 1 < candidates.Length) dfs(candidates, target, id + 1, buffer, result);
        }
    }
}
