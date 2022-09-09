using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1598
{
    public class Solution1598 : Interface1598
    {
        /// <summary>
        /// 就是栈操作
        /// ../  弹栈，需要检查当前栈是否为空
        /// ./   无操作
        /// x/   入栈
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        public int MinOperations(string[] logs)
        {
            Stack<bool> stack = new Stack<bool>();

            for (int i = 0; i < logs.Length; i++)
            {
                switch (logs[i])
                {
                    case "../":
                        if (stack.Count > 0) stack.Pop();
                        break;
                    case "./":
                        break;
                    default:
                        stack.Push(true);
                        break;
                }
            }

            return stack.Count;
        }

        /// <summary>
        /// 不用栈，直接记录
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        public int MinOperations2(string[] logs)
        {
            int result = 0;

            for (int i = 0; i < logs.Length; i++)
            {
                switch (logs[i])
                {
                    case "../":
                        if (result > 0) result--;
                        break;
                    case "./":
                        break;
                    default:
                        result++;
                        break;
                }
            }

            return result;
        }
    }
}
