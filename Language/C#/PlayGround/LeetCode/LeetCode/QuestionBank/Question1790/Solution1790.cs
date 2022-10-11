using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1790
{
    public class Solution1790 : Interface1790
    {
        public bool AreAlmostEqual(string s1, string s2)
        {
            int id1 = -1, id2 = -1;
            int ptr = 0;
            while (ptr < s1.Length && s1[ptr] == s2[ptr]) ptr++;  // 找出第1个不匹配的位
            if (ptr == s1.Length) return true;
            id1 = ptr++;

            while (ptr < s1.Length && s1[ptr] == s2[ptr]) ptr++;  // 找出第2个不匹配的位
            if (ptr == s1.Length) return false;
            id2 = ptr++;

            while (ptr < s1.Length && s1[ptr] == s2[ptr]) ptr++;  // 找出第3个不匹配的位
            if (ptr < s1.Length) return false;

            if (s1[id1] == s2[id2] && s1[id2] == s2[id1])
                return true;
            else
                return false;
        }
    }
}
