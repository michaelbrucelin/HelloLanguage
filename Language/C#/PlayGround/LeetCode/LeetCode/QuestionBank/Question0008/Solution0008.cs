using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0008
{
    public class Solution0008 : Interface0008
    {
        /// <summary>
        /// 可以考虑用long类型承载结果，并检查是否int溢出
        /// 这里使用try catch来检查int是否溢出
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MyAtoi(string s)
        {
            int result = 0;

            int sign = 1, i = 0;
            while (i < s.Length && s[i] == ' ') i++;                         // 忽略前导空格
            if (i >= s.Length) return 0;
            if (s[i] == '-') { sign = -1; i++; } else if (s[i] == '+') i++;  // 获取符号
            try
            {
                for (; i < s.Length; i++)
                {
                    if (!char.IsDigit(s[i])) break;
                    else result = checked(result * 10 + sign * (s[i] - '0'));
                }
                return result;
            }
            catch (OverflowException ex)
            {
                if (sign == 1) return int.MaxValue;
                else return int.MinValue;
            }
        }
    }
}
