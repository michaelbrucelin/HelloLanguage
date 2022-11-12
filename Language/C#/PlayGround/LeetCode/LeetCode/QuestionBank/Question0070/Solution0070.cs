using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0070
{
    public class Solution0070 : Interface0070
    {
        /// <summary>
        /// 斐波那契
        /// 要到达n，那么必须到达n-1或n-2，到达n-1再迈一步就到达n，到达n-2再迈2次一步或迈一次两步就到达n，但是迈两次1步与先到达n-1重复了
        /// 所以f(n) = f(n-1) + f(n-2)
        /// 
        /// 迭代解，使用数组
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            int[] dp = new int[n]; dp[0] = 1; dp[1] = 2;
            for (int i = 2; i < n; i++) dp[i] = dp[i - 1] + dp[i - 2];

            return dp[n - 1];
        }

        /// <summary>
        /// 迭代解，滚动向前
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs2(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            int n1 = 1, n2 = 2, n3 = 3;
            for (int i = 2; i < n; i++)
            {
                n3 = n2 + n1;
                n1 = n2;
                n2 = n3;
            }

            return n3;
        }

        /// <summary>
        /// 迭代解，滚动向前，使用值元组交换变量
        /// 这样交换变量是错误的，达不到sql的效果
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs3(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;

            int n1 = 1, n2 = 2, n3 = 3;
            for (int i = 2; i < n; i++)
            {
                (n1, n2, n3) = (n2, n3, n1 + n2);  // 这样交换变量是错误的，达不到sql的效果
            }

            return n3;
        }

        /// <summary>
        /// 递归解，提交会超时
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs4(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            return ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }
    }
}
