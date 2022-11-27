using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0038
{
    public class Solution0038 : Interface0038
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            if (n == 1) return "1";

            string last = CountAndSay(n - 1);
            StringBuilder sb = new StringBuilder();
            int id = 0, len = last.Length;
            while (id < len)
            {
                int cnt = 1;
                while (id + 1 < len && last[id + 1] == last[id]) { cnt++; id++; }
                sb.Append($"{cnt}{last[id]}");
                id++;
            }

            return sb.ToString();
        }
    }
}
