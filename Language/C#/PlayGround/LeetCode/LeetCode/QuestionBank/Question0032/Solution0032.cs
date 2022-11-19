using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0032
{
    public class Solution0032 : Interface0032
    {
        /// <summary>
        /// 一个字符串是正确有效括号的充要条件是满足下面两点
        /// 1. 左括号数量等于右括号数量
        /// 2. 任意前缀左括号的数量大于等于右括号的数量
        /// 
        /// 用栈模拟一遍，将所有无法匹配的括号的位置全部置1
        /// "()(()":    [0, 0, 1, 0, 0]
        /// ")()((())": [1, 0, 0, 1, 0, 0, 0, 0]
        /// 经过这样的处理后, 此题就变成了寻找最长的连续的0的长度
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses(string s)
        {
            if (s.Length <= 1) return 0;

            Stack<int> stack = new Stack<int>();
            bool[] mask = new bool[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') stack.Push(i);
                else
                {
                    if (stack.Count == 0) mask[i] = true;      // 将多余的右括号标记
                    else stack.Pop();                          // 将匹配到右括号的左括号出栈
                }
            }
            while (stack.Count > 0) mask[stack.Pop()] = true;  // 将没有匹配到右括号的左括号标记

            int result = 0, temp = 0;
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i])
                {
                    result = Math.Max(result, temp);
                    temp = 0;
                }
                else
                {
                    temp++;
                }
            }
            result = Math.Max(result, temp);

            return result;
        }
    }
}
