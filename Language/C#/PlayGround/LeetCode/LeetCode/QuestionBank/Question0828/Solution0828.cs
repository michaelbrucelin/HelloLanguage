using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0828
{
    public class Solution0828
    {
        public int UniqueLetterString(string s)
        {
            int result = 0;

            result = s.Length;  // 长度为1的子串无需验证

            return result;
        }

        /// <summary>
        /// 计算整数对应二进制中1的数量
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int BitCount(int i)
        {
            int result = 0;

            while (i > 0)
            {
                result++;
                i &= (i - 1);
            }

            return result;
        }
    }
}
