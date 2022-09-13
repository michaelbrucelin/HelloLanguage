using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0006
{
    public class Solution0006_2 : Interface0006
    {
        /// <summary>
        /// 模拟过程
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || numRows >= s.Length) return s;

            List<char>[] buffer = new List<char>[numRows];
            for (int i = 0; i < buffer.Length; i++) buffer[i] = new List<char>();

            int index = 0, increment = 1;
            for (int i = 0; i < s.Length; i++)
            {
                buffer[index].Add(s[i]);
                if (index == 0) increment = 1;
                else if (index == numRows - 1) increment = -1;
                index += increment;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
                for (int j = 0; j < buffer[i].Count; j++) sb.Append(buffer[i][j]);

            return sb.ToString();
        }
    }
}
