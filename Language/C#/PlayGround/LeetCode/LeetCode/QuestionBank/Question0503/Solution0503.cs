using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0503
{
    public class Solution0503 : Interface0503
    {
        /// <summary>
        /// 与Question0496基本一样，循环2圈即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NextGreaterElements(int[] nums)
        {
            int[] result = new int[nums.Length];

            Dictionary<(int id, int value), (bool done, int value)> dic = new Dictionary<(int, int), (bool, int)>();
            Stack<(int id, int value)> stack = new Stack<(int id, int value)>();
            int N = nums.Length * 2;
            for (int i = 0; i < N - 1; i++)
            {
                int id = i >= nums.Length ? i - nums.Length : i;
                dic.TryAdd((id, nums[id]), (false, -1));

                while (stack.Count > 0 && nums[id] > stack.Peek().value)
                {
                    var key = stack.Pop();
                    if (!dic[key].done)
                        dic[key] = (true, nums[id]);
                }

                if (stack.Count == 0)
                    stack.Push((id, nums[id]));
                else
                    stack.Push((id, nums[id]));  // 相等的也要入栈
            }

            for (int i = 0; i < nums.Length; i++)
                result[i] = dic[(i, nums[i])].value;

            return result;
        }
    }
}
