using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0038
{
    public class Solution0038_2 : Interface0038
    {
        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            if (n == 1) return "1";

            StringBuilder result = new StringBuilder("1");
            for (int i = 1; i < n; i++)
            {
                StringBuilder sb = new StringBuilder();
                int id = 0, len = result.Length;
                while (id < len)
                {
                    int cnt = 1;
                    while (id + 1 < len && result[id + 1] == result[id]) { cnt++; id++; }
                    sb.Append($"{cnt}{result[id]}");
                    id++;
                }
                result = sb;
            }

            return result.ToString();
        }
    }
}
