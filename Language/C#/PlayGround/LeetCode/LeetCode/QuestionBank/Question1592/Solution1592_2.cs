using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1592
{
    public class Solution1592_2 : Interface1592
    {
        /// <summary>
        /// 使用C# API
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ReorderSpaces(string text)
        {
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int wordCnt = words.Length;
            int blankCnt = text.Count(c => c == ' ');

            string mid = "", tail = new string(' ', blankCnt);
            if (wordCnt > 1)
            {
                mid = new string(' ', blankCnt / (wordCnt - 1));
                tail = new string(' ', blankCnt % (wordCnt - 1));
            }

            return $"{string.Join(mid, words)}{tail}";
        }
    }
}
