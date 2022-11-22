using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0799
{
    public class Solution0799_2 : Interface0799
    {
        /// <summary>
        /// 与Solution0799一样，做了下面两点优化
        /// 1. 由于左右是对称的，所以只需要模拟左面一半就可以了
        /// 2. 从中间向两边遍历，因为如果某个位置不能向下流水，那么继续边缘的位置也不能向下流水
        /// 3. 如果某个位置为0，且这个位置比要求解的位置更靠近中心，结果也一定为0
        /// 可以参照Solution0799.xlsx理解下面的代码中的边界处理
        /// </summary>
        /// <param name="poured"></param>
        /// <param name="query_row"></param>
        /// <param name="query_glass"></param>
        /// <returns></returns>
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            if (poured == 0) return 0;
            if (query_row == 0) return 1;
            if (query_row == 1) return poured == 1 ? 0 : poured == 2 ? 0.5 : 1;  // 前两行需要单独处理

            query_glass = Math.Min(query_glass, query_row - query_glass);
            int rowid = 0, len = (query_row >> 1) + 1;
            double[] row_curr = new double[len]; row_curr[0] = poured;
            while (++rowid <= query_row)
            {
                if (rowid == 1)  // 第2行单独处理
                {
                    row_curr[0] = row_curr[0] > 1 ? (row_curr[0] - 1) / 2 : 0;
                    if (row_curr[0] == 0) break;
                }
                else             // 第3行以及以后的行
                {
                    double[] row_next = new double[len];
                    int mid = rowid >> 1;
                    if ((rowid & 1) != 1)
                        row_next[mid] = row_curr[mid - 1] > 1 ? row_curr[mid - 1] - 1 : 0;
                    else
                        row_next[mid] = (row_curr[mid - 1] > 1 ? (row_curr[mid - 1] - 1) / 2 : 0)  // 这里3元运算符如果不加括号会有优先级错误
                                      + (row_curr[mid] > 1 ? (row_curr[mid] - 1) / 2 : 0);
                    for (int i = mid - 1; i > 0; i--)
                    {
                        double left = row_curr[i - 1] > 1 ? (row_curr[i - 1] - 1) / 2 : 0;
                        double right = row_curr[i] > 1 ? (row_curr[i] - 1) / 2 : 0;
                        if (left + right == 0) break;
                        row_next[i] = left + right;
                        if (row_next[i] == 0)                // 这里的等于0的判断，循环前面处理mid位置与循环后面处理0位置也应该判断，感觉很不优雅，而且对整体时间复杂度影响不大，就不写了
                        {
                            if (i >= query_glass) return 0;  // 等于0的位置比结果位置更靠近中心，结果也一定为0
                            break;                           // 前面的位置一定为0，直接下一轮
                        }
                    }
                    row_next[0] = row_curr[0] > 1 ? (row_curr[0] - 1) / 2 : 0;
                    row_curr = row_next;
                }
            }

            return row_curr[query_glass] > 1 ? 1 : row_curr[query_glass];
        }
    }
}
