using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0672
{
    public class Solution0672_2 : Interface0672
    {
        /// <summary>
        /// 就是对Solution0672的化简，Solution0672只是练习状态转换
        /// </summary>
        /// <param name="n"></param>
        /// <param name="presses"></param>
        /// <returns></returns>
        public int FlipLights(int n, int presses)
        {
            if (presses == 0) return 1;
            if (n == 1) return 2;
            if (n == 2) return presses == 1 ? 3 : 4;

            // n >= 3, presses >= 1
            if (presses == 1) return 4;
            if (presses == 2) return 7;
            return 8;
        }
    }
}
