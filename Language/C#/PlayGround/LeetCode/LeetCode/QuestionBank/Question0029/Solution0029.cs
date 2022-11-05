using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0029
{
    public class Solution0029 : Interface0029
    {
        /// <summary>
        /// 除数左移一位，可以变为2倍
        /// 所以让被除数与除数比较大小，即可求出商
        /// 由于受int32限制，所以将被除数与除数都转为负数再进行运算
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 1) return dividend;
            if (dividend == 0) return 0;
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;

            int symbol = 1;
            if (dividend > 0) dividend = -dividend; else symbol = -1;
            if (divisor > 0) divisor = -divisor; else symbol *= -1;

            int result = 0;
            while (dividend <= divisor)
            {
                int power = -1, divisor_temp = divisor;
                while (dividend <= divisor_temp)
                {
                    power++;
                    if (dividend - divisor_temp <= divisor_temp) { divisor_temp <<= 1; continue; }  // dividend大于等于2倍的divisor_temp
                    dividend -= divisor_temp;
                    break;
                }
                result += (1 << power);
            }

            return symbol * result;
        }
    }
}
