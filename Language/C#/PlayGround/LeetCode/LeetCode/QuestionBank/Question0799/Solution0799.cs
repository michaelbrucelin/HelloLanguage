using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0799
{
    public class Solution0799 : Interface0799
    {
        /// <summary>
        /// 感觉有数学规律，直接数学通项就可以解出结果，但是没找到合适的规律，见Solution0799.xlsx
        /// 那就模拟一下
        /// 1. 第1层留下1杯水，两边个流下(poured-1)/2杯水到第二层
        /// 2. 第2层每个杯子留下一杯水，然后两边各留下(poured-3)/4杯水到第三层
        /// 3. ... ...
        /// 需要注意
        /// 1. 中间的杯子接两边的入水
        /// 2. 留下一杯水的同时，如果没有剩余，不会流下“负”水
        /// </summary>
        /// <param name="poured"></param>
        /// <param name="query_row"></param>
        /// <param name="query_glass"></param>
        /// <returns></returns>
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            if (poured == 0) return 0;
            if (poured == 1) { if (query_row == 0) return 1; else return 0; }

            int rowid = 0;
            double[] row_curr = new double[query_row + 1]; row_curr[0] = poured;
            while (++rowid <= query_row)
            {
                double[] row_next = new double[query_row + 1];
                row_next[0] = row_curr[0] > 1 ? (row_curr[0] - 1) / 2 : 0;
                for (int i = 1; i < rowid; i++)
                {
                    double left = row_curr[i - 1] > 1 ? (row_curr[i - 1] - 1) / 2 : 0;
                    double right = row_curr[i] > 1 ? (row_curr[i] - 1) / 2 : 0;
                    row_next[i] = left + right;
                }
                row_next[rowid] = row_curr[rowid - 1] > 1 ? (row_curr[rowid - 1] - 1) / 2 : 0;
                row_curr = row_next;
            }

            return row_curr[query_glass] > 1 ? 1 : row_curr[query_glass];
        }

        /// <summary>
        /// 简单优化，如果整行都是0，就不再判断下一行了
        /// </summary>
        /// <param name="poured"></param>
        /// <param name="query_row"></param>
        /// <param name="query_glass"></param>
        /// <returns></returns>
        public double ChampagneTower2(int poured, int query_row, int query_glass)
        {
            if (poured == 0) return 0;
            if (poured == 1) { if (query_row == 0) return 1; else return 0; }

            int rowid = 0;
            double[] row_curr = new double[query_row + 1]; row_curr[0] = poured;
            while (++rowid <= query_row)
            {
                bool flag = true;
                double[] row_next = new double[query_row + 1];
                row_next[0] = row_curr[0] > 1 ? (row_curr[0] - 1) / 2 : 0;
                if (row_next[0] > 0) flag = false;
                for (int i = 1; i < rowid; i++)
                {
                    double left = row_curr[i - 1] > 1 ? (row_curr[i - 1] - 1) / 2 : 0;
                    double right = row_curr[i] > 1 ? (row_curr[i] - 1) / 2 : 0;
                    row_next[i] = left + right;
                    if (row_next[i] > 0) flag = false;
                }
                row_next[rowid] = row_curr[rowid - 1] > 1 ? (row_curr[rowid - 1] - 1) / 2 : 0;
                // if (row_next[rowid] > 0) flag = false;  与row_next[0]处的值一致
                row_curr = row_next;

                if (flag) break;
            }

            return row_curr[query_glass] > 1 ? 1 : row_curr[query_glass];
        }
    }
}
