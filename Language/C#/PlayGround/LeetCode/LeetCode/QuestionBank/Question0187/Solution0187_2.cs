using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0187
{
    public class Solution0187_2
    {
        private const int L = 10;
        private Dictionary<char, int> bin = new Dictionary<char, int> { { 'A', 0 }, { 'C', 1 }, { 'G', 2 }, { 'T', 3 } };

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            if (s.Length < L) return new List<string>();

            HashSet<string> result = new HashSet<string>();
            HashSet<int> temp = new HashSet<int>();
            int x = 0;
            for (int i = 0; i < L; i++)
            {
                x = (x << 2) | bin[s[i]];
            }
            temp.Add(x);

            for (int i = 1; i <= s.Length - L; i++)
            {
                x = ((x << 2) | bin[s[i + L - 1]]) & ((1 << 20) - 1);

                if (temp.Contains(x))
                    result.Add(s.Substring(i, L));
                else
                    temp.Add(x);
            }

            return result.ToList();
        }
    }
}
