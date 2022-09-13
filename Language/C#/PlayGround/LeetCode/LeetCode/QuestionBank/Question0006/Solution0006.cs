using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0006
{
    public class Solution0006 : Interface0006
    {
        /// <summary>
        /// 找规律
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || numRows >= s.Length) return s;

            StringBuilder sb = new StringBuilder();
            int interval = numRows * 2 - 2;
            // 第一行
            for (int i = 0; i < s.Length; i += interval) sb.Append(s[i]);
            // 中间那些行
            for (int row = 1; row < numRows - 1; row++)
            {
                int interval_row = row * 2;
                for (int i = row; i < s.Length; i += interval_row)
                {
                    sb.Append(s[i]);
                    interval_row = interval - interval_row;
                }
            }
            // 最后一行
            for (int i = numRows - 1; i < s.Length; i += interval) sb.Append(s[i]);

            return sb.ToString();
        }
    }
}
