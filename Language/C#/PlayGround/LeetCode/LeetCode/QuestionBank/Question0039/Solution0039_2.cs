using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0039
{
    public class Solution0039_2 : Interface0039
    {
        /// <summary>
        /// 同Solution0039
        /// 先将数组排序，这样数组后面的元素一定大于前面的元素，可以做一些剪枝进行搜索加速
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
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

            if (value < target)        // 可以使用value，也可以不使用value
            {
                List<int> list = new List<int>(buffer) { value };
                dfs(candidates, target - value, id, list, result);

                if (id + 1 < candidates.Length) dfs(candidates, target, id + 1, buffer, result);
            }
            else if (value == target)  // 只有使用value这一种选择，因为数组升序
            {
                List<int> list = new List<int>(buffer) { value };
                result.Add(list);
            }
        }
    }
}
