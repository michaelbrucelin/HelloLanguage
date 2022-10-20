using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0779
{
    public class Solution0779 : Interface0779
    {
        /// <summary>
        /// 找规律
        /// 1  1   0
        /// 2  2   01
        /// 3  3   0110
        /// 4  8   01101001
        /// 5  16  0110100110010110
        /// 6  32  01101001100101101001011001101001
        /// 可以得出以下结论：
        /// 1. 新的一行是上面那行长度的2倍
        /// 2. 新的一行前面一半与上一行一样，后面一半是前一行的相反状态（数学归纳法即可证明）
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthGrammar(int n, int k)
        {
            Stack<int> stack = new Stack<int>();
            int i = 1;
            while (i < k) { stack.Push(i); i = (i << 1); }

            int cnt = 0;
            while (k > 1)
            {
                int minus = stack.Pop();
                if (k > minus) { k -= minus; cnt++; }
            }

            return (cnt & 1) == 1 ? 1 : 0;
        }
    }
}
