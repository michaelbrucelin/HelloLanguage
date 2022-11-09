using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0764
{
    public class Solution0764_2 : Interface0764
    {
        /// <summary>
        /// 与Solution0764一样，只是将哈希表由HashSet<(int row, int col)>改为HashSet<int>
        /// </summary>
        /// <param name="n"></param>
        /// <param name="mines"></param>
        /// <returns></returns>
        public int OrderOfLargestPlusSign(int n, int[][] mines)
        {
            int result = -1;
            HashSet<int> mines_hash = mines.Select(arr => arr[0] * n + arr[1]).ToHashSet();  // n进制数字

            // 从矩阵的中心向外一圈一圈遍历
            for (int c = ((n - 1) >> 1); c + 1 > result; c--)  // c表示从外向内数第几圈，这一圈为中心最大的结果为c+1
            {
                int start = c, end = n - c - 1;
                for (int i = start; i <= end; i++)          // 上
                {
                    result = Math.Max(result, Extend(start, i, c + 1, n, mines_hash));
                    if (result == c + 1) goto End;
                }
                for (int i = start + 1; i <= end; i++)      // 右
                {
                    result = Math.Max(result, Extend(i, end, c + 1, n, mines_hash));
                    if (result == c + 1) goto End;
                }
                for (int i = end - 1; i >= start; i--)      // 下
                {
                    result = Math.Max(result, Extend(end, i, c + 1, n, mines_hash));
                    if (result == c + 1) goto End;
                }
                for (int i = end - 1; i >= start + 1; i--)  // 左
                {
                    result = Math.Max(result, Extend(i, start, c + 1, n, mines_hash));
                    if (result == c + 1) goto End;
                }
            }
            End:

            return result;
        }

        private int Extend(int row, int col, int radius, int n, HashSet<int> mines)
        {
            if (mines.Contains(row * n + col)) return 0;
            int i;
            for (i = 1; i < radius && (!mines.Contains((row - i) * n + col)); i++) ; radius = i;  // 向上找
            for (i = 1; i < radius && (!mines.Contains(row * n + col + i)); i++) ; radius = i;    // 向右找
            for (i = 1; i < radius && (!mines.Contains((row + i) * n + col)); i++) ; radius = i;  // 向下找
            for (i = 1; i < radius && (!mines.Contains(row * n + col - i)); i++) ; radius = i;    // 向左找

            return radius;
        }
    }
}
