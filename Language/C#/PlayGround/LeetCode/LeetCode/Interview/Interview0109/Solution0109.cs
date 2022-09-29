using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0109
{
    public class Solution0109 : Interface0109
    {
        public bool IsFlipedString(string s1, string s2)
        {
            return s1.Length == s2.Length && $"{s1}{s1}".Contains(s2);
        }
    }
}
