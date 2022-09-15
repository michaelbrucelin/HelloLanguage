using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0319
{
    public class Solution0319_2 : Interface0319
    {
        /// <summary>
        /// 找规律
        /// 对于每一盏灯，假设为第n盏灯，那么n的每一个约数都会触发一次切换开关，所以
        ///     如果n不是完全平方数，则触发了偶数次开关，关闭状态
        ///     如果n  是完全平方数，则触发了奇数次开关，打开状态
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int BulbSwitch(int n)
        {
            if (n <= 1) return n;

            int result = 1;
            while (result * result <= n) result++;

            return result - 1;
        }

        public int BulbSwitch2(int n)
        {
            return (int)Math.Sqrt(n);  // return (int) Math.Sqrt(n + 0.5);  这样才稳妥
        }
    }
}
