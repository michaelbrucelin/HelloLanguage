using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0784
{
    public class Solution0784_3 : Interface0784
    {
        /// <summary>
        /// 排列组合，DFS
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> LetterCasePermutation(string s)
        {
            if (s.Length == 0) return new List<string>() { string.Empty };

            IList<string> buffer = LetterCasePermutation(s.Substring(1));
            List<string> result = new List<string>();
            if (char.IsLetter(s[0]))
                for (int i = 0; i < buffer.Count; i++)
                {
                    result.Add($"{s[0]}{buffer[i]}");
                    result.Add($"{(char)(s[0] ^ 32)}{buffer[i]}");
                }
            else
                for (int i = 0; i < buffer.Count; i++)
                    result.Add($"{s[0]}{buffer[i]}");

            return result;
        }
    }
}
