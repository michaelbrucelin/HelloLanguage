using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0438
{
    public class Solution0438_3 : Interface0438
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            if (s.Length < p.Length) return result;

            int len_s = s.Length, len_p = p.Length;
            int diff = 0; int[] helper = new int[26];
            for (int i = 0; i < len_p; i++) { helper[p[i] - 'a']++; helper[s[i] - 'a']--; }
            diff = helper.Count(i => i != 0);
            if (diff == 0) result.Add(0);
            for (int i = 1; i <= len_s - len_p; i++)
            {
                int id = s[i - 1] - 'a'; helper[id]++;
                if (helper[id] == 0) diff--; else if (helper[id] == 1) diff++;

                id = s[i + len_p - 1] - 'a'; helper[id]--;
                if (helper[id] == 0) diff--; else if (helper[id] == -1) diff++;

                if (diff == 0) result.Add(i);
            }

            return result;
        }
    }
}
