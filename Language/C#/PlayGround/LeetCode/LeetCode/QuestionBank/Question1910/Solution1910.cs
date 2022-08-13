using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1910
{
    public class Solution1910
    {
        public string RemoveOccurrences(string s, string part)
        {
            int p;
            while ((p = s.IndexOf(part)) >= 0)
                s = s.Remove(p, part.Length);

            return s;
        }
    }
}
