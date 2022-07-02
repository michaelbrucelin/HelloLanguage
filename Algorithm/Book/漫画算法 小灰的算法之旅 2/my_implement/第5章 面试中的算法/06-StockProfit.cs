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
    }
}
