using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0541
{
    public class Solution0541_2
    {
        public string ReverseStr(string s, int k)
        {
            int times = s.Length % k == 0 ? s.Length / k : s.Length / k + 1;
            bool flag = true;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < times - 1; i++)
            {
                if (flag)
                    sb.Append(new string(s.Substring(k * i, k).Reverse().ToArray()));
                else
                    sb.Append(s.Substring(k * i, k));

                flag = !flag;
            }

            if (flag)
                sb.Append(new string(s.Substring(k * (times - 1)).Reverse().ToArray()));
            else
                sb.Append(s.Substring(k * (times - 1)));

            return sb.ToString();
        }
    }
}
