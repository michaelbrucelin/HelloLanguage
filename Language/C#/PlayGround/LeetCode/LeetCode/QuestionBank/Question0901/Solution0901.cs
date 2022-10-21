using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0901
{
    public class StockSpanner : Interface0901
    {
        public StockSpanner()
        {
            stocks = new List<int>();
            result = new List<int>();
        }

        private List<int> stocks;  // 记录每一天的股票价钱
        private List<int> result;  // 记录每一天的结果

        /// <summary>
        /// 用一个数组记录每一天的结果，然后回溯即可
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public int Next(int price)
        {
            stocks.Add(price);
            if (stocks.Count == 1) { result.Add(1); return 1; }

            int temp = 1;
            int id = stocks.Count - 1 - 1;
            while (id >= 0 && price >= stocks[id]) { temp += result[id]; id -= result[id]; }
            result.Add(temp);

            return temp;
        }
    }
}
