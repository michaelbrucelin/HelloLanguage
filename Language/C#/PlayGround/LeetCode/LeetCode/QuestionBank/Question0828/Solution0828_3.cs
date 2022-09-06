using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0828
{
    public class Solution0828_3 : Interface0828
    {
        public int UniqueLetterString(string s)
        {
            Dictionary<char, List<int>> buffer = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!buffer.ContainsKey(s[i])) buffer.Add(s[i], new List<int>() { -1 });
                buffer[s[i]].Add(i);
            }

            int result = 0;
            foreach (var kv in buffer)
            {
                List<int> list = kv.Value;
                list.Add(s.Length);
                for (int i = 1; i < list.Count - 1; i++)
                    result += (list[i] - list[i - 1]) * (list[i + 1] - list[i]);
            }

            return result;
        }
    }
}
