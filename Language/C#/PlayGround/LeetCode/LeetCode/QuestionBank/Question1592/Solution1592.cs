using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1592
{
    public class Solution1592 : Interface1592
    {
        /// <summary>
        /// 使用类C的朴素方式处理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ReorderSpaces(string text)
        {
            char[] buffer = new char[text.Length];
            int blankCnt = 0;
            int wordCnt = 0;
            int bufferLen = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    if (bufferLen > 0 && buffer[bufferLen - 1] != ' ') buffer[bufferLen++] = ' ';
                    blankCnt++;
                }
                else
                {
                    if (bufferLen == 0 || buffer[bufferLen - 1] == ' ') wordCnt++;
                    buffer[bufferLen++] = text[i];
                }
            }
            if (buffer[bufferLen - 1] == ' ') bufferLen--;  // 确保buffer是一个以一个空格分隔的wrod序列

            int midCnt = 0, tailCnt = blankCnt;
            if (wordCnt > 1)
            {
                midCnt = blankCnt / (wordCnt - 1);
                tailCnt = blankCnt % (wordCnt - 1);
            }

            char[] result = new char[text.Length];
            int j = 0;
            for (int i = 0; i < bufferLen; i++)
            {
                if (buffer[i] != ' ') result[j++] = buffer[i];
                else for (int k = 0; k < midCnt; k++) result[j++] = ' ';
            }
            if (tailCnt > 0) for (int k = 0; k < tailCnt; k++) result[j++] = ' ';

            return new string(result);
        }
    }
}
