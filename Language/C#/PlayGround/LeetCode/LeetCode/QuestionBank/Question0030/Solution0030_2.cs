using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0030
{
    public class Solution0030_2 : Interface0030
    {
        /// <summary>
        /// 同Solution0030一样，添加了判断“出窗口”与“入窗口”的字符串是否一样
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> result = new List<int>();
            if (s.Length < words[0].Length * words.Length) return result;

            Dictionary<string, int> helper = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
                if (helper.ContainsKey(words[i])) helper[words[i]]++; else helper.Add(words[i], 1);

            int len_s = s.Length, len_word = words[0].Length, len_words = words.Length * words[0].Length;
            int wordcnt = words.Length, wordspan = len_word * (wordcnt - 1);
            for (int round = 0; round < len_word; round++)
            {
                if (len_s - round < len_words) break;
                Dictionary<string, int> temp = new Dictionary<string, int>(helper);
                for (int i = round; i < len_words; i += len_word)
                {
                    string word = s.Substring(i, len_word);
                    if (temp.ContainsKey(word)) temp[word]--;
                }
                int diff = temp.Count(kv => kv.Value != 0);
                bool last_status = false;
                if (diff == 0) { result.Add(round); last_status = true; }

                for (int i = round + len_word; i <= len_s - len_words; i += len_word)
                {
                    string word_out = s.Substring(i - len_word, len_word), word_in = s.Substring(i + wordspan, len_word);
                    if (word_in == word_out)
                    {
                        if (last_status) result.Add(i);
                        continue;
                    }

                    if (temp.ContainsKey(word_out))
                    {
                        temp[word_out]++;
                        if (temp[word_out] == 0) diff--; else if (temp[word_out] == 1) diff++;
                    }

                    if (temp.ContainsKey(word_in))
                    {
                        temp[word_in]--;
                        if (temp[word_in] == 0) diff--; else if (temp[word_in] == -1) diff++;
                    }

                    if (diff == 0) { result.Add(i); last_status = true; } else last_status = false;
                }
            }

            return result;
        }
    }
}
