using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1694
{
    public class Solution1694 : Interface1694
    {
        public string ReformatNumber(string number)
        {
            List<char> result = new List<char>();
            int p = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == '-' || number[i] == ' ') continue;
                if (p++ % 3 == 0) result.Add('-');
                result.Add(number[i]);
            }
            if (result[result.Count - 2] == '-')
            {
                int cnt = result.Count;
                char t = result[cnt - 2];
                result[cnt - 2] = result[cnt - 3];
                result[cnt - 3] = t;
            }

            return new string(result.ToArray(), 1, result.Count - 1);
        }
    }
}
