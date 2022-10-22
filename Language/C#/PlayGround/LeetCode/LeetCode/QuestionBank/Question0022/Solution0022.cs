using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0022
{
    public class Solution0022 : Interface0022
    {
        /// <summary>
        /// 只要保证任意长度的前缀中，左括号的数量大于等于右括号的数量即可
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            Queue<(string str, int left, int right)> queue = new Queue<(string, int, int)>();
            queue.Enqueue(("(", 1, 0));
            for (int i = 2; i < n * 2; i++)
            {
                int cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    var item = queue.Dequeue();
                    if (item.left < n) queue.Enqueue(($"{item.str}(", item.left + 1, item.right));
                    if (item.right < item.left) queue.Enqueue(($"{item.str})", item.left, item.right + 1));
                }
            }

            return new List<string>(queue.Select(item => $"{item.str})"));
        }
    }
}
