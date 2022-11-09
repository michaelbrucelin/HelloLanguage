using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0764
{
    public class Solution0764 : Interface0764
    {
        /// <summary>
        /// 最大的“加号”中心一定靠近矩阵的中心，所以从矩阵的中心向外一圈一圈遍历
        /// 能不能通过正向分析mines的分布，而不遍历就得到结果呢，总感觉这是一道数学题而不是编程题
        /// </summary>
        /// <param name="n"></param>
        /// <param name="mines"></param>
        /// <returns></returns>
        public int OrderOfLargestPlusSign(int n, int[][] mines)
        {
            int result = -1;
            HashSet<(int row, int col)> mines_hash = mines.Select(arr => (arr[0], arr[1])).ToHashSet();

            // 从矩阵的中心向外一圈一圈遍历
            for (int c = ((n - 1) >> 1); c + 1 > result; c--)  // c表示从外向内数第几圈，这一圈为中心最大的结果为c+1
            {
                int start = c, end = n - c - 1;
                for (int i = start; i <= end; i++)          // 上
                {
                    result = Math.Max(result, Extend(start, i, c + 1, mines_hash));
                    if (result == c + 1) goto End;
                }
                for (int i = start + 1; i <= end; i++)      // 右
                {
                    result = Math.Max(result, Extend(i, end, c + 1, mines_hash));
                    if (result == c + 1) goto End;
                }
                for (int i = end - 1; i >= start; i--)      // 下
                {
                    result = Math.Max(result, Extend(end, i, c + 1, mines_hash));
                    if (result == c + 1) goto End;
                }
                for (int i = end - 1; i >= start + 1; i--)  // 左
                {
                    result = Math.Max(result, Extend(i, start, c + 1, mines_hash));
                    if (result == c + 1) goto End;
                }
            }
            End:

            return result;
        }

        private int Extend(int row, int col, int radius, HashSet<(int row, int col)> mines)
        {
            if (mines.Contains((row, col))) return 0;
            int i;
            for (i = 1; i < radius && (!mines.Contains((row - i, col))); i++) ; radius = i;  // 向上找
            for (i = 1; i < radius && (!mines.Contains((row, col + i))); i++) ; radius = i;  // 向右找
            for (i = 1; i < radius && (!mines.Contains((row + i, col))); i++) ; radius = i;  // 向下找
            for (i = 1; i < radius && (!mines.Contains((row, col - i))); i++) ; radius = i;  // 向左找

            return radius;
        }
    }
}
