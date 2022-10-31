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
        /// 排列组合，BFS
        /// 以"a1b2"为例
        /// 1. a A
        /// 2. a1 A1
        /// 3. a1b A1b a1B A1B
        /// 4. a1b2 A1b2 a1B2 A1B2
        /// 
        /// char^32即可切换大小写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> LetterCasePermutation(string s)
        {
            int len = s.Length;
            Queue<StringBuilder> queue = new Queue<StringBuilder>();
            queue.Enqueue(new StringBuilder().Append(s[0]));
            if (char.IsLetter(s[0]))
                queue.Enqueue(new StringBuilder().Append((char)(s[0] ^ 32)));

            for (int i = 1; i < len; i++)
            {
                int cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    StringBuilder sb = queue.Dequeue();
                    if (char.IsLetter(s[i]))
                        queue.Enqueue(new StringBuilder(sb.ToString()).Append((char)(s[i] ^ 32)));
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
            int len = s.Length;
            Queue<char[]> queue = new Queue<char[]>();
            queue.Enqueue(s.ToCharArray());
            if (char.IsLetter(s[0]))
            {
                char[] s2 = s.ToCharArray(); s2[0] = (char)(s2[0] ^ 32); queue.Enqueue(s2);
            }

            for (int i = 1; i < len; i++)
            {
                int cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    char[] s_temp = queue.Dequeue();
                    queue.Enqueue(s_temp);
                    if (char.IsLetter(s[i]))
                    {
                        char[] s_temp2 = s_temp.ToArray();
                        s_temp2[i] = (char)(s_temp2[i] ^ 32);
                        queue.Enqueue(s_temp2);
                    }
                }
            }

            return queue.Select(chars => new string(chars)).ToList();
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
            queue.Enqueue(s[0].ToString());
            if (char.IsLetter(s[0]))
                queue.Enqueue(((char)(s[0] ^ 32)).ToString());

            for (int i = 1; i < len; i++)
            {
                int cnt = queue.Count;
                for (int j = 0; j < cnt; j++)
                {
                    string str = queue.Dequeue();
                    queue.Enqueue($"{str}{s[i]}");
                    if (char.IsLetter(s[i]))
                        queue.Enqueue($"{str}{(char)(s[i] ^ 32)}");
                }
            }

            return queue.ToList();
        }
    }
}
