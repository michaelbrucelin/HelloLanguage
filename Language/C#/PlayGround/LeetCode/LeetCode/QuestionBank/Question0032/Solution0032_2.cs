using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0032
{
    public class Solution0032_2 : Interface0032
    {
        /// <summary>
        /// 与Solution0032一样的逻辑，但是代码更简短，理解一下
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses(string s)
        {
            int result = 0;
            Stack<int> stack = new Stack<int>(); stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') stack.Push(i);
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                        stack.Push(i);
                    else
                        result = Math.Max(result, i - stack.Peek());
                }
            }

            return result;
        }
    }
}
