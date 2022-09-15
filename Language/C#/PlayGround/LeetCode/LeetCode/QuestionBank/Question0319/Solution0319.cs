using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0319
{
    public class Solution0319 : Interface0319
    {
        /// <summary>
        /// 暴力解，提交会超时
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int BulbSwitch(int n)
        {
            if (n <= 1) return n;

            bool[] buffer = new bool[n + 1];  // buffer[0]放弃不使用
            buffer[0] = false;
            for (int i = 1; i < buffer.Length; i++) buffer[i] = true;

            // 模拟每一轮开关灯
            for (int k = 2; k <= n; k++)  // k是轮次
            {
                for (int i = k; i < buffer.Length; i += k)
                    buffer[i] = !buffer[i];
            }

            return buffer.Count(b => b);
        }
    }
}
