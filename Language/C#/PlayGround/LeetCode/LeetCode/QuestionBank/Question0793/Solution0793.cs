using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0793
{
    public class Solution0793 : Interface0793
    {
        /// <summary>
        /// 结果只能是5和0两种
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int PreimageSizeFZF(int k)
        {
            int i = 0;
            while (true)
            {
                int cnt = GetFactorialTailZeros(i);
                if (cnt == k) return 5;
                if (cnt > k) break;
                i += 5;
            }

            return 0;
        }

        /// <summary>
        /// 计算x的阶乘结尾0的数量，这是一个数学问题，仔细分析一下其实就是含有因数5的数量
        /// 这样求解太慢
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int GetFactorialTailZeros(int x)
        {
            int result = 0;

            int i = 0;
            while ((i += 5) <= x)
            {
                int j = i;
                while (j / 5 * 5 == j)
                {
                    result++;
                    j /= 5;
                }
            }

            return result;
        }

        /// <summary>
        /// 计算x的阶乘结尾0的数量，这是一个数学问题，仔细分析一下其实就是含有因数5的数量
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int GetFactorialTailZeros2(int x)
        {
            if (x < 0) return -1;

            int result = 0;

            for (int i = 5; x >= i; i *= 5)
                result += x / i;

            return result;
        }
        
        /// <summary>
        /// 计算x的阶乘结尾0的数量，这是一个数学问题，仔细分析一下其实就是含有因数5的数量
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int GetFactorialTailZeros3(int x)
        {
            if (x < 5)
                return 0;
            else
                return (x / 5 + GetFactorialTailZeros(x / 5));
        }
    }
}