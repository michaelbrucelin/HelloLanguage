using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0784
{
    public class Solution0784_5 : Interface0784
    {
        public IList<string> LetterCasePermutation(string s)
        {
            int len = s.Length;
            int m = 0;
            for (int i = 0; i < len; i++) if (char.IsLetter(s[i])) m++;  // m = s.Count(c => char.IsLetter(c));            

            List<string> result = new List<string>();
            int cnt = (1 << m);
            for (int mask = 0; mask < cnt; mask++)                       // 逐个结果进行计算
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0, j = 0; i < len; i++)                     // 对当前结果逐位计算
                {
                    if (char.IsLetter(s[i]))
                    {
                        if ((mask & (1 << j++)) != 0)
                            sb.Append(s[i].ToString().ToUpper());
                        else
                            sb.Append(s[i].ToString().ToLower());
                    }
                    else
                        sb.Append(s[i]);
                }

                result.Add(sb.ToString());
            }

            return result;
        }
    }
}
