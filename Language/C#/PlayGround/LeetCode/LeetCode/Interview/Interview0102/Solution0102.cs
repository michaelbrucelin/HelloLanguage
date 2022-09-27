using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0102
{
    public class Solution0102 : Interface0102
    {
        public bool CheckPermutation(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            Dictionary<char, int> helper = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++)
            {
                if (helper.ContainsKey(s1[i])) helper[s1[i]]++;
                else helper.Add(s1[i], 1);
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (!helper.ContainsKey(s2[i])) return false;
                if (helper[s2[i]] > 1) helper[s2[i]]--; else helper.Remove(s2[i]);
            }

            return true;
        }
    }
}
