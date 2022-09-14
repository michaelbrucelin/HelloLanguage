using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0318
{
    public class Solution0318 : Interface0318
    {
        public int MaxProduct(string[] words)
        {
            int result = 0;

            for (int i = 0; i < words.Length; i++)
            {
                int key1 = GetKeyCode(words[i]);
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (words[i].Length * words[j].Length <= result) continue;

                    int key2 = GetKeyCode(words[j]);
                    if ((key1 & key2) == 0) result = words[i].Length * words[j].Length;
                }
            }

            return result;
        }

        /// <summary>
        /// 用一个26位的bitmap记录word中含有那些字母
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private int GetKeyCode(string word)
        {
            int result = 0;

            for (int i = 0; i < word.Length; i++)
                result |= (1 << (word[i] - 'a'));

            return result;
        }
    }
}
