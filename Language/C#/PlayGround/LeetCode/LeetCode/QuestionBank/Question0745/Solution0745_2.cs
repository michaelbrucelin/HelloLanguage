using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0745
{
    public class WordFilter_2
    {
        public WordFilter_2(string[] words)
        {
            dic = new Dictionary<string, int>();
            for (int index = words.Length - 1; index >= 0; index--)
            {
                string word = words[index];
                for (int i = 1; i <= word.Length; i++)
                    for (int j = 1; j <= word.Length; j++)
                        dic.TryAdd($"{word.Substring(0, i)}-{word.Substring(word.Length - j)}", index);
            }
        }

        private Dictionary<string, int> dic;

        public int F(string pref, string suff)
        {
            if (dic.ContainsKey($"{pref}-{suff}"))
                return dic[$"{pref}-{suff}"];

            return -1;
        }
    }
}
