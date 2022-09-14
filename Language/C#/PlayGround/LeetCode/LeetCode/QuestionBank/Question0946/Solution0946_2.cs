using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0946
{
    public class Solution0946_2 : Interface0946
    {
        /// <summary>
        /// 原地操作（利用pushed数组模拟栈），性能不一定好，就是练习
        /// </summary>
        /// <param name="pushed"></param>
        /// <param name="popped"></param>
        /// <returns></returns>
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            int index = 0;                                  // index是栈顶索引
            for (int i = 0, j = 0; i < pushed.Length; i++)  // j是popped的索引
            {
                pushed[index++] = pushed[i];
                while (index > 0 && pushed[index - 1] == popped[j] && ++j >= 0) index--;
            }

            return index == 0;
        }
    }
}
