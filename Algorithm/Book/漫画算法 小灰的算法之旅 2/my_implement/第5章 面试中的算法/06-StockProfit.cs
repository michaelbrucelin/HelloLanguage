using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] prices = { 9, 2, 7, 4, 3, 1, 8, 4 };
            prices.ToList().ForEach(i => Console.Write($"{i}, "));
            Console.WriteLine();

            Console.WriteLine($"MaxProfitFor1Time:   {MaxProfitFor1Time(prices)}");
            Console.WriteLine($"MaxProfitForAnyTime: {MaxProfitForAnyTime(prices)}");

            prices = new int[] { 1, 2, 4, 8, 3, 9, 6, 7 };
            prices.ToList().ForEach(i => Console.Write($"{i}, "));
            Console.WriteLine();

            int[,] buffer;
            Console.WriteLine($"MaxProfitFor2Time:   {MaxProfitFor2Time(prices, out buffer)}");
            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                for (int j = 0; j < buffer.GetLength(1); j++)
                    Console.Write($"{buffer[i, j]}\t");
                Console.WriteLine();
            }

            Console.WriteLine($"MaxProfitFor2Time:   {MaxProfitForKTime(prices, 2, out buffer)}");
            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                for (int j = 0; j < buffer.GetLength(1); j++)
                    Console.Write($"{buffer[i, j]}\t");
                Console.WriteLine();
            }

            Console.WriteLine($"MaxProfitFor3Time:   {MaxProfitForKTime(prices, 3, out buffer)}");
            for (int i = 0; i < buffer.GetLength(0); i++)
            {
                for (int j = 0; j < buffer.GetLength(1); j++)
                    Console.Write($"{buffer[i, j]}\t");
                Console.WriteLine();
            }

            int[] buffer2;
            Console.WriteLine($"MaxProfitFor3Time:   {MaxProfitForKTime(prices, 3, out buffer2)}");
            buffer2.ToList().ForEach(i => Console.Write($"{i}\t"));
        }

        /// <summary>
        /// 给定一个price数组，它存储着每天的股票价格，第n个元素代表第n天的价格。
        /// 如果最多只允许进行1次买入和卖出，那么股票的最大收益是多少？
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfitFor1Time(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;

            int minPrice = prices[0];
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] <= minPrice)
                    minPrice = prices[i];
                else if (prices[i] - minPrice > maxProfit)
                    maxProfit = prices[i] - minPrice;
            }

            return maxProfit;
        }

        /// <summary>
        /// 把题目做一个变形：如果买卖次数不限，那么股票的最大收益是多少？
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfitForAnyTime(int[] prices)
        {
            int maxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxProfit += prices[i] - prices[i - 1];
            }

            return maxProfit;
        }

        /// <summary>
        /// 如果最多允许2次买卖，那么股票的最大收益是多少？同样不允许连续买入。
        /// 
        /// 使用动态规划实现，分析见06-StockProfit.md
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfitFor2Time(int[] prices, out int[,] buffer)
        {
            buffer = new int[prices.Length, 5];  // 最多2次买卖共有5个买卖状态

            // 初始条件
            buffer[0, 0] = 0;
            buffer[0, 1] = -prices[0];
            buffer[0, 2] = 0;
            buffer[0, 3] = -prices[0];
            buffer[0, 4] = 0;

            // DP
            for (int n = 1; n < prices.Length; n++)
            {
                for (int m = 0; m < 5; m++)
                {
                    if (m == 0)
                        buffer[n, m] = 0;
                    else if ((m & 1) == 1)  // m为奇数
                        buffer[n, m] = Math.Max(buffer[n - 1, m - 1] - prices[n], buffer[n - 1, m]);
                    else                    // m为偶数
                        buffer[n, m] = Math.Max(buffer[n - 1, m - 1] + prices[n], buffer[n - 1, m]);
                }
            }

            return buffer[buffer.GetLength(0) - 1, buffer.GetLength(1) - 1];
        }

        /// <summary>
        /// 把股票买卖问题再做一层变化：如果最大交易次数不再是2次，而是k次（k是输入参数），那么如何求得全局最大收益？
        /// 
        /// 使用动态规划实现，分析见06-StockProfit.md
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int MaxProfitForKTime(int[] prices, int k, out int[,] buffer)
        {
            buffer = new int[prices.Length, k * 2 + 1];  // 最多k次买卖共有2k+1个买卖状态

            // 初始条件
            for (int i = 0; i < buffer.GetLength(1); i++)
            {
                if ((i & 1) != 1)
                    buffer[0, i] = 0;
                else
                    buffer[0, i] = -prices[0];
            }

            // DP
            for (int n = 1; n < prices.Length; n++)
            {
                for (int m = 0; m < buffer.GetLength(1); m++)
                {
                    if (m == 0)             // 这个判断可以省略，数组初始值就是0，这里为了演示，就写了这个判断
                        buffer[n, m] = 0;
                    else if ((m & 1) == 1)  // m为奇数
                        buffer[n, m] = Math.Max(buffer[n - 1, m - 1] - prices[n], buffer[n - 1, m]);
                    else                    // m为偶数
                        buffer[n, m] = Math.Max(buffer[n - 1, m - 1] + prices[n], buffer[n - 1, m]);
                }
            }

            return buffer[buffer.GetLength(0) - 1, buffer.GetLength(1) - 1];
        }

        /// <summary>
        /// 把股票买卖问题再做一层变化：如果最大交易次数不再是2次，而是k次（k是输入参数），那么如何求得全局最大收益？
        /// 
        /// 使用动态规划实现，将过程中使用的二维数组降为一维数组，分析见06-StockProfit.md
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="k"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static int MaxProfitForKTime(int[] prices, int k, out int[] buffer)
        {
            buffer = new int[k * 2 + 1];  // 最多k次买卖共有2k+1个买卖状态

            // 初始条件
            for (int i = 0; i < buffer.Length; i++)
            {
                if ((i & 1) != 1)
                    buffer[i] = 0;
                else
                    buffer[i] = -prices[0];
            }

            // DP
            for (int n = 1; n < prices.Length; n++)
            {
                for (int m = buffer.Length - 1; m > 0; m--)
                {
                    if ((m & 1) == 1)
                        buffer[m] = Math.Max(buffer[m - 1] - prices[n], buffer[m]);
                    else
                        buffer[m] = Math.Max(buffer[m - 1] + prices[n], buffer[m]);
                }
            }

            return buffer[buffer.Length - 1];
        }
    }
}
