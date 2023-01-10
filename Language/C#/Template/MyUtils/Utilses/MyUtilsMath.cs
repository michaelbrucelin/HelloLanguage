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
        /// <summary>
        /// 组合
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static long nCr(int n, int r)
        {
            // naive: return Factorial(n) / (Factorial(r) * Factorial(n - r));
            return nPr(n, r) / Factorial(r);
        }

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
    }
}
