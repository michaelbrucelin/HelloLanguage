using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1678
{
    public class Solution1678 : Interface1678
    {
        /// <summary>
        /// 使用朴素的C方式
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string Interpret(string command)
        {
            if (command.Length <= 1) return command;

            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < command.Length)
            {
                switch (command[i])
                {
                    case 'G':
                        sb.Append(command[i++]);
                        break;
                    case '(':
                        if (command[i + 1] == ')') { sb.Append('o'); i += 2; }
                        else { sb.Append("al"); i += 4; }
                        break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 使用API
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string Interpret2(string command)
        {
            return command.Replace("(al)", "al").Replace("()", "o");
        }
    }
}
