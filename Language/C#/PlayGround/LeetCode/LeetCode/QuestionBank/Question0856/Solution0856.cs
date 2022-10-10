using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0856
{
    public class Solution0856 : Interface0856
    {
        /// <summary>
        /// ( 就入栈，) 就计算一次，如果栈顶是两个数字，就相加
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int ScoreOfParentheses(string s)
        {
            Stack<int> helper = new Stack<int>();  // 用0表示(
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') helper.Push(0);
                else                               // s[i]==')', helper.Count必然>0，否则s就不是平衡括号字符串
                {
                    if (helper.Peek() == 0)
                    {
                        helper.Pop();
                        if (helper.Count > 0 && helper.Peek() > 0)  // 前面一项仍然是数字
                        {
                            int item = helper.Pop();
                            helper.Push(item + 1);
                        }
                        else
                            helper.Push(1);
                    }
                    else
                    {
                        int item = helper.Pop();
                        helper.Pop();
                        if (helper.Count > 0 && helper.Peek() > 0)  // 前面一项仍然是数字
                        {
                            int item2 = helper.Pop();
                            helper.Push(item * 2 + item2);
                        }
                        else
                            helper.Push(item * 2);
                    }
                }
            }

            return helper.Pop();
        }
    }
}
