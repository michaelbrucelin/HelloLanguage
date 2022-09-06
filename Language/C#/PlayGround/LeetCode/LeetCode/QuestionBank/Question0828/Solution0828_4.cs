using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0828
{
    public class Solution0828_4 : Interface0828
    {
        public int UniqueLetterString(string s)
        {
            int[] last = new int[26];
            int[] curr = new int[26];

            Array.Fill(last, -1);
            Array.Fill(curr, -1);

            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int id = s[i] - 'A';
                if (curr[id] != -1) result += (curr[id] - last[id]) * (i - curr[id]);

                last[id] = curr[id];
                curr[id] = i;
            }

            for (int i = 0; i < 26; i++)
                result += (curr[i] - last[i]) * (s.Length - curr[i]);

            return result;
        }
    }
}
