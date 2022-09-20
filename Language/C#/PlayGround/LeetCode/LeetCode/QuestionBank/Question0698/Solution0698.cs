using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0698
{
    /// <summary>
    /// 未完成
    /// </summary>
    public class Solution0698 : Interface0698
    {
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            if (k == 1) return true;

            int sum = nums.Sum();
            if (sum % k != 0) return false;

            int target = sum / k;
            List<int> list = nums.OrderBy(i => i).ToList();
            if (list[list.Count - 1] > target) return false;

            while (list.Count > 0 && list[list.Count - 1] == target) { list.RemoveAt(list.Count - 1); k--; }

            return Recursive(list, 0, k, target, 0);
        }

        /// <summary>
        /// list已经升序排序，每次取最后一项（最大项），然后构建target
        ///     构建target，只有两种可能，使用最后（最小）的项 + 不使用最后（最小）的项
        ///     根据这仅有的两种可能递归即可
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start">从第几项开始找</param>
        /// <param name="k">需要分几组</param>
        /// <param name="target">每一组的目标值</param>
        /// <param name="already">当前组已经累计的值</param>
        /// <returns></returns>
        private bool Recursive(List<int> list, int start, int k, int target, int already)
        {
            if (list.Count == 0 && k == 0) return true;
            if ((list.Count > 0 && k <= 0) || (list.Count == 0 && k > 0)) return false;

            if (already == 0)
            {
                already = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                return Recursive(list, 0, k, target, already);
            }
            else
            {
                if (start >= list.Count) return false;

                int target_now = target - already;
                if (list[start] == target_now)                           // 最后（最小）的项恰巧等于“缺口”，就必须使用，因为已经是最小的项了
                {
                    list.RemoveAt(start);
                    return Recursive(list, 0, k - 1, target, 0);
                }
                else if (list[start] < target_now)
                {
                    if (Recursive(list, start + 1, k, target, already))  // 不使用最小的一项
                        return true;
                    else                                                 // 使用最小的一项
                    {
                        list.RemoveAt(start);
                        return Recursive(list, start, k, target, already + list[0]);
                    }
                }
                else  // list[start] > target_now
                    return false;
            }
        }
    }
}
