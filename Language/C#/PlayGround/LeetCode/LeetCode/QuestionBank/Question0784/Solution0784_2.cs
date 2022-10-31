using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0784
{
    public class Solution0784_2 : Interface0784
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
            List<StringBuilder> list = new List<StringBuilder>();
            list.Add(new StringBuilder().Append(s[0]));
            if (char.IsLetter(s[0]))
                list.Add(new StringBuilder().Append((char)(s[0] ^ 32)));

            for (int i = 1; i < len; i++)
            {
                int cnt = list.Count;
                for (int j = 0; j < cnt; j++)
                {
                    if (char.IsLetter(s[i]))
                        list.Add(new StringBuilder(list[j].ToString()).Append((char)(s[i] ^ 32)));
                    list[j].Append(s[i]);
                }
            }

            return list.Select(sb => sb.ToString()).ToList();
        }

        /// <summary>
        /// 不用StringBuilder，用char[]
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> LetterCasePermutation2(string s)
        {
            int len = s.Length;
            List<char[]> list = new List<char[]>();
            list.Add(s.ToCharArray());
            if (char.IsLetter(s[0]))
            {
                char[] s2 = s.ToCharArray(); s2[0] = (char)(s2[0] ^ 32); list.Add(s2);
            }

            for (int i = 1; i < len; i++)
            {
                int cnt = list.Count;
                for (int j = 0; j < cnt; j++)
                {
                    // list[j][i] = s[i];  // 不需要操作
                    if (char.IsLetter(s[i]))
                    {
                        char[] s_temp = list[j].ToArray();
                        s_temp[i] = (char)(s_temp[i] ^ 32);
                        list.Add(s_temp);
                    }
                }
            }

            return list.Select(chars => new string(chars)).ToList();
        }

        /// <summary>
        /// 不用StringBuilder与char[]，直接拼接字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> LetterCasePermutation3(string s)
        {
            int len = s.Length;
            List<string> list = new List<string>();
            list.Add(s[0].ToString());
            if (char.IsLetter(s[0]))
                list.Add(((char)(s[0] ^ 32)).ToString());

            for (int i = 1; i < len; i++)
            {
                int cnt = list.Count;
                for (int j = 0; j < cnt; j++)
                {
                    if (char.IsLetter(s[i]))
                        list.Add($"{list[j]}{(char)(s[i] ^ 32)}");
                    list[j] = $"{list[j]}{s[i]}";
                }
            }

            return list.ToList();
        }
    }
}
