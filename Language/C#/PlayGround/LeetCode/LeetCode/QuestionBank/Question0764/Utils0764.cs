using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0764
{
    public class Utils0764
    {
        /// <summary>
        /// 从中心向四周一圈一圈扩散遍历，适用于n*n的方形矩阵（行列式）
        /// </summary>
        /// <param name="mines"></param>
        public void ExtendTraverse(int n)
        {
            int[][] grid = Enumerable.Range(0, n).Select(i => Enumerable.Range(n * i, n).ToArray()).ToArray();
            Utils.PrintArray(grid, true);

            for (int c = ((n - 1) >> 1); c >= 0; c--)  // 从外向内数第几圈
            {
                int start = c, end = n - c - 1;
                for (int i = start; i <= end; i++) Console.Write($"{grid[start][i]} ");          // 上
                for (int i = start + 1; i <= end; i++) Console.Write($"{grid[i][end]} ");        // 右
                for (int i = end - 1; i >= start; i--) Console.Write($"{grid[end][i]} ");        // 下
                for (int i = end - 1; i >= start + 1; i--) Console.Write($"{grid[i][start]} ");  // 左
            }
        }
    }
}
