using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0934
{
    public class Solution0934 : Interface0934
    {
        /// <summary>
        /// 先DFS找出其中一座岛，再找出另一座岛，然后将其中一座岛的边缘向外扩张，直至扩张到另一座岛
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestBridge(int[][] grid)
        {
            HashSet<(int row, int col)> island = new HashSet<(int, int)>();

            // 找出第一座岛
            int row = 0, col = 0;
            for (row = 0; row < grid.Length; row++) for (col = 0; col < grid[row].Length; col++) if (grid[row][col] == 1) goto End1; End1:
            FindIsland_DFS(grid, island, row, col);

            // 找第一座岛的边缘
            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
            foreach (var point in island)
            {
                row = point.row; col = point.col;
                if (IsShore(grid, row, col)) queue.Enqueue(point);
            }

            // 扩张第一座岛
            int result = 0;
            while (true)
            {
                int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    var point = queue.Dequeue();
                    row = point.row; col = point.col;
                    if (row > 0)
                    {
                        if (grid[row - 1][col] == 1) goto Find;
                        if (grid[row - 1][col] == 0) { grid[row - 1][col] = 2; queue.Enqueue((row - 1, col)); }
                    }
                    if (row < grid.Length - 1)
                    {
                        if (grid[row + 1][col] == 1) goto Find;
                        if (grid[row + 1][col] == 0) { grid[row + 1][col] = 2; queue.Enqueue((row + 1, col)); }
                    }
                    if (col > 0)
                    {
                        if (grid[row][col - 1] == 1) goto Find;
                        if (grid[row][col - 1] == 0) { grid[row][col - 1] = 2; queue.Enqueue((row, col - 1)); }
                    }
                    if (col < grid[0].Length - 1)
                    {
                        if (grid[row][col + 1] == 1) goto Find;
                        if (grid[row][col + 1] == 0) { grid[row][col + 1] = 2; queue.Enqueue((row, col + 1)); }
                    }
                }
                result++;
            }
            Find:

            return result;
        }

        private bool IsShore(int[][] grid, int row, int col)
        {
            if (row > 0 && grid[row - 1][col] == 0) return true;                        // 上边缘
            else if (row < grid.Length - 1 && grid[row + 1][col] == 0) return true;     // 下边缘
            else if (col > 0 && grid[row][col - 1] == 0) return true;                   // 左边缘
            else if (col < grid[0].Length - 1 && grid[row][col + 1] == 0) return true;  // 右边缘

            return false;
        }

        /// <summary>
        /// DFS查找一座岛，并将岛的数字由1改为2
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="mask"></param>
        /// <param name="island"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void FindIsland_DFS(int[][] grid, HashSet<(int row, int col)> island, int row, int col)
        {
            if (grid[row][col] == 1)
            {
                island.Add((row, col)); grid[row][col] = 2;
                if (row > 0) FindIsland_DFS(grid, island, row - 1, col);                   // 上
                if (row < grid.Length - 1) FindIsland_DFS(grid, island, row + 1, col);     // 下
                if (col > 0) FindIsland_DFS(grid, island, row, col - 1);                   // 左
                if (col < grid[0].Length - 1) FindIsland_DFS(grid, island, row, col + 1);  // 右
            }
        }

        /// <summary>
        /// DFS查找一座岛
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="mask"></param>
        /// <param name="island"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void FindIsland_DFS(int[][] grid, bool[][] mask, HashSet<(int row, int col)> island, int row, int col)
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
