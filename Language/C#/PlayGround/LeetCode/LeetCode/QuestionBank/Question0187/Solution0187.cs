using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0187
{
    public class Solution0187
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            HashSet<string> result = new HashSet<string>();

            HashSet<string> temp = new HashSet<string>();
            for (int i = 0; i <= s.Length - 10; i++)
            {
                if (temp.Contains(s.Substring(i, 10)))
                    result.Add(s.Substring(i, 10));
                else
                    temp.Add(s.Substring(i, 10));
            }

            return result.ToList();
        }

        public IList<string> FindRepeatedDnaSequences2(string s)
        {
            if (s.Length <= 10)
                return new List<string>();

            Dictionary<string, int> temp0 = new Dictionary<string, int>();
            for (int i = 0; i <= s.Length - 10; i++)
            {
                string s_item = s.Substring(i, 10);
                if (temp0.Keys.Contains(s_item))
                    temp0[s_item]++;
                else
                    temp0.Add(s_item, 1);
            }

            return temp0.Where(w => w.Value > 1).Select(i => i.Key).ToList();
        }
    }
}
