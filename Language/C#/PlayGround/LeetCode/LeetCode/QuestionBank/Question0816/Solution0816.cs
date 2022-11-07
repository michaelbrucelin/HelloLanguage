using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0816
{
    public class Solution0816 : Interface0816
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> AmbiguousCoordinates(string s)
        {
            HashSet<string> buffer = new HashSet<string>();
            int len = s.Length - 2;
            for (int l = 1; l < len; l++)  // i是拆分后前面那部分字符串的长度
            {
                string s1 = s.Substring(1, l);
                string s2 = s.Substring(l + 1, len - l);
                string x, y;
                for (int i = 1; i <= s1.Length; i++)
                {
                    var info1 = IsCorrect(s1, i);
                    if (!info1.correct) continue; else x = info1.s;

                    for (int j = 1; j <= s2.Length; j++)
                    {
                        var info2 = IsCorrect(s2, j);
                        if (!info2.correct) continue; else y = info2.s;

                        buffer.Add($"({x}, {y})");
                    }
                }
            }

            return buffer.ToList();
        }

        /// <summary>
        /// 整数：
        /// 1. 开头不可以为0（0除外）
        /// 小数：
        /// 1. 结尾不可以为0
        /// 2. 整数部分按照整数规则来
        /// </summary>
        /// <param name="s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private (bool correct, string s) IsCorrect(string s, int i)
        {
            if (i < s.Length)  // 判断小数的合法性
            {
                string s_int = s.Substring(0, i), s_float = s.Substring(i);
                if ((s_int.Length > 1 && s_int[0] == '0') || (s_float[s_float.Length - 1] == '0'))
                    return (false, "");
                else
                    return (true, $"{s_int}.{s_float}");
            }
            else               // 判断整数的合法性
            {
                if (s.Length > 1 && s[0] == '0')
                    return (false, "");
                else
                    return (true, s);
            }
        }
    }
}
