using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0934
{
    public class Solution0934 : Interface0934
    {
        /// <summary>
        /// 当两座岛都只有一个点时，桥长为两座岛的 横坐标差 + 纵坐标差 - 1
        /// 所以，结果就是先找出两座岛各自的点集，然后找出两个点集中 【横坐标差 + 纵坐标差 - 1】 的最小值
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestBridge(int[][] grid)
        {
            List<(int row, int col)> island1 = new List<(int, int)>();
            List<(int row, int col)> island2 = new List<(int, int)>();

            return -1;
        }

        public void FindIsland_DFS(int[][] grid, bool[][] mask, List<(int row, int col)> island, int row, int col)
        {
            if (grid[row][col] == 1 && (!mask[row][col]))
            {
                island.Add((row, col)); mask[row][col] = true;
                if (row > 0) FindIsland_DFS(grid, mask, island, row - 1, col);                   // 上
                if (row < grid.Length - 1) FindIsland_DFS(grid, mask, island, row + 1, col);     // 下
                if (col > 0) FindIsland_DFS(grid, mask, island, row, col - 1);                   // 左
                if (col < grid[0].Length - 1) FindIsland_DFS(grid, mask, island, row, col + 1);  // 右
            }
        }
    }
}
