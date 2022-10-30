using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0784
{
    public class Solution0784 : Interface0784
    {
        /// <summary>
        /// 排列组合
        /// 以"a1b2"为例
        /// 1. a A
        /// 2. a1 A1
        /// 3. a1b A1b a1B A1B
        /// 4. a1b2 A1b2 a1B2 A1B2
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> LetterCasePermutation(string s)
        {
            int len = s.Length;
            Queue<StringBuilder> queue = new Queue<StringBuilder>();
            if (char.IsLetter(s[0]))
            {
                queue.Enqueue(new StringBuilder().Append(s[0].ToString().ToLower()));
                queue.Enqueue(new StringBuilder().Append(s[0].ToString().ToUpper()));
            }
            else
                queue.Enqueue(new StringBuilder().Append(s[0].ToString()));

            for (int i = 1; i < len; i++)
            {
                int cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    StringBuilder sb = queue.Dequeue();
                    if (char.IsLetter(s[i]))
                    {
                        queue.Enqueue(new StringBuilder(sb.ToString()).Append(s[i].ToString().ToLower()));
                        // queue.Enqueue(new StringBuilder(sb.ToString()).Append(s[i].ToString().ToUpper()));
                        queue.Enqueue(sb.Append(s[i].ToString().ToUpper()));
                    }
                    else
                        queue.Enqueue(sb.Append(s[i]));
                }
            }

            return queue.Select(sb => sb.ToString()).ToList();
        }

        /// <summary>
        /// 不用StringBuilder，用char[]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> LetterCasePermutation2(string s)
        {
            return null;
        }

        /// <summary>
        /// 不用StringBuilder与char[]，直接拼接字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> LetterCasePermutation3(string s)
        {
            int len = s.Length;
            Queue<string> queue = new Queue<string>();
            if (char.IsLetter(s[0]))
            {
                queue.Enqueue(s[0].ToString().ToLower());
                queue.Enqueue(s[0].ToString().ToUpper());
            }
            else
                queue.Enqueue(s[0].ToString());

            for (int i = 1; i < len; i++)
            {
                int cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    string str = queue.Dequeue();
                    if (char.IsLetter(s[i]))
                    {
                        queue.Enqueue($"{str}{s[i].ToString().ToLower()}");
                        queue.Enqueue($"{str}{s[i].ToString().ToUpper()}");
                    }
                    else
                        queue.Enqueue($"{str}{s[i]}");
                }
            }

            return queue.ToList();
        }
    }
}
