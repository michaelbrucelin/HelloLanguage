using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0640
{
    public class Solution0640 : Interface0640
    {
        /// <summary>
        /// 逐个字符分析即可，将X的系数和常数分别聚合成一个值，再分析结果
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        public string SolveEquation(string equation)
        {
            int signal = 1, coefficient = 0, constant = 0;

            int isleft = 1;  // 在等号左侧为正，右侧为负
            bool isbuffer = false;
            int buffer = 0;
            for (int i = 0; i < equation.Length; i++)
            {
                switch (equation[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        isbuffer = true;
                        buffer = buffer * 10 + (equation[i] - '0');
                        break;
                    case '+':
                    case '-':
                        constant += -1 * isleft * signal * buffer;
                        isbuffer = false;
                        buffer = 0;
                        signal = equation[i] == '+' ? 1 : -1;
                        break;
                    case 'x':
                        if (!isbuffer) buffer = 1;
                        coefficient += isleft * signal * buffer;
                        isbuffer = false;
                        buffer = 0;
                        break;
                    case '=':
                        constant += -1 * signal * buffer;  // 一定在左侧，处理缓存的常数
                        isbuffer = false;
                        buffer = 0;
                        signal = 1;
                        isleft = -1;
                        break;
                    default:
                        break;
                }
            }
            constant += signal * buffer;  // 一定在右侧，处理缓存的常数

            if (coefficient == 0)
                return constant == 0 ? "Infinite solutions" : "No solution";
            else
                return $"x={constant / coefficient}";
        }
    }
}
