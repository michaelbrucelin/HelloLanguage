using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public static class MyUtilsMath
    {
        #region 组合
        /// <summary>
        /// 组合
        /// 根据初始值的不同选择合适的计算方式
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static long nCr(int n, int r)
        {
            if (n < 29 || (n == 29 && r < 15))
                return nCr_Fast(n, r);
            else
                return nCr_Slow(n, r);
        }

        /// <summary>
        /// 组合
        /// n=29, r=15开始溢出
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static long nCr_Fast(int n, int r)
        {
            // naive: return Factorial(n) / (Factorial(r) * Factorial(n - r));
            return nPr(n, r) / Factorial(r);
        }

        /// <summary>
        /// 组合
        /// 更安全的计算方式，但是也更慢，n=67, r=30开始溢出
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static long nCr_Slow(int n, int r)
        {
            int[] multip = new int[r];
            for (int i = 0; i < r; i++) multip[i] = n - i;
            Queue<int> divide = new Queue<int>();
            for (int i = 1; i <= r; i++) divide.Enqueue(i);

            while (divide.Count > 0)
            {
                int div = divide.Dequeue();
                for (int i = 0; i < multip.Length; i++)
                {
                    if (multip[i] > 1)
                    {
                        int gcd = GetGCD(multip[i], div);
                        multip[i] /= gcd; div /= gcd;
                        if (div == 1) break;
                    }
                }

                if (div != 1) divide.Enqueue(div);
            }

            long result = 1;
            for (int i = 0; i < r; i++) result *= multip[i];

            return result;
        }
        #endregion

        #region 排列
        /// <summary>
        /// 排列
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static long nPr(int n, int r)
        {
            // naive: return Factorial(n) / Factorial(n - r);
            return FactorialDivision(n, n - r);
        }
        #endregion

        #region 阶乘
        /// <summary>
        /// 阶乘除
        /// </summary>
        /// <param name="topFactorial"></param>
        /// <param name="divisorFactorial"></param>
        /// <returns></returns>
        public static long FactorialDivision(int topFactorial, int divisorFactorial)
        {
            long result = 1;
            for (int i = topFactorial; i > divisorFactorial; i--) result *= i;

            return result;
        }

        /// <summary>
        /// 阶乘运算
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++) result *= i;

            return result;
        }
        #endregion

        #region 最大公约数
        /// <summary>
        /// 最大公约数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y)
            {
                if ((x & 1) == 0 && (y & 1) == 0)
                {
                    x >>= 1; y >>= 1; move++;
                }
                else if ((x & 1) == 0 && (y & 1) == 1) x >>= 1;
                else if ((x & 1) == 1 && (y & 1) == 0) y >>= 1;
                else
                {
                    if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                }
            }

            return x << move;
        }
        #endregion
    }
}
