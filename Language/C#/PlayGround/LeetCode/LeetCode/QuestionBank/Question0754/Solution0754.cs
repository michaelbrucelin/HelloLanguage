using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0754
{
    public class Solution0754 : Interface0754
    {
        /// <summary>
        /// 暴力模拟
        /// 结果是对的，但是会超时
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ReachNumber(int target)
        {
            if (target == 1) return 1;

            HashSet<int> set = new HashSet<int>() { -1, 1 };
            int i = 2;
            for (; true; i++)
            {
                HashSet<int> buffer = new HashSet<int>();
                foreach (int item in set)
                {
                    buffer.Add(item - i);
                    buffer.Add(item + i);
                }
                if (buffer.Contains(target)) return i;
                set = buffer;
            }
        }
    }
}
