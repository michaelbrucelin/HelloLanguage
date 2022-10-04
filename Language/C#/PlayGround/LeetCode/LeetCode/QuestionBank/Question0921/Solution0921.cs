using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0921
{
    public class Solution0921 : Interface0921
    {
        /// <summary>
        /// 移除"()"，然后看剩下多少个字符即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int MinAddToMakeValid(string s)
        {
            while (s.Contains("()")) s = s.Replace("()", "");
            return s.Length;
        }

        /// <summary>
        /// 使用朴素的方式处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinAddToMakeValid2(string s)
        {
            List<char> helper = s.ToList();
            bool flag = true;
            while (helper.Count > 0 && flag)
            {
                flag = false;
                for (int i = helper.Count - 1; i > 0; i--)
                {
                    if (helper[i] == ')' && helper[i - 1] == '(')
                    {
                        helper.RemoveRange(i - 1, 2);
                        flag = true;
                        i--;
                    }
                }
            }

            return helper.Count;
        }
    }
}
