using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0745
{
    /// <summary>
    /// 暴力求解，超时了
    /// </summary>
    public class WordFilter : Interface0745
    {
        public WordFilter(string[] words)
        {
            this.words = words;
        }

        private string[] words;

        public int F(string pref, string suff)
        {
            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (pref.Length > words[i].Length || suff.Length > words[i].Length)
                    continue;
                if (words[i].StartsWith(pref) && words[i].EndsWith(suff))
                    return i;
            }

            return -1;
        }
    }

    /**
     * Your WordFilter object will be instantiated and called as such:
     * WordFilter obj = new WordFilter(words);
     * int param_1 = obj.F(pref,suff);
     */
}
