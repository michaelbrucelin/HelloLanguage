using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0946
{
    public class Solution0946
    {
        /// <summary>
        /// 使用是个栈模拟一下操作的过程即可
        /// </summary>
        /// <param name="pushed"></param>
        /// <param name="popped"></param>
        /// <returns></returns>
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> stack = new Stack<int>();
            int i = 0;                               // i是popped的索引
            for (int j = 0; j < popped.Length; j++)  // j是popped的索引
            {
                if (stack.Count > 0 && stack.Peek() == popped[j])  // 能弹栈就弹栈
                    stack.Pop();
                else                                               // 否则就压栈
                {
                    while (i < pushed.Length && pushed[i] != popped[j]) stack.Push(pushed[i++]);
                    if (i == pushed.Length)
                        return false;
                    else
                        i++;
                }
            }

            return true;
        }
    }
}
