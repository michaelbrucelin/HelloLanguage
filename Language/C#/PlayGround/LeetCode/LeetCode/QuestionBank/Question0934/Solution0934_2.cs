using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0934
{
    public class Solution0934_2 : Interface0934
    {
        /// <summary>
        /// 与Solution0934一致，只不过查找岛的过程由DFS改为BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestBridge(int[][] grid)
        {
            HashSet<(int row, int col)> island = new HashSet<(int, int)>();

            // 找出第一座岛
            int row = 0, col = 0;
            for (row = 0; row < grid.Length; row++) for (col = 0; col < grid[row].Length; col++) if (grid[row][col] == 1) goto End1; End1:
            FindIsland_BFS(grid, island, row, col);

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
        /// BFS查找一座岛，并将岛的数字由1改为2
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="mask"></param>
        /// <param name="island"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void FindIsland_BFS(int[][] grid, HashSet<(int row, int col)> island, int row, int col)
        {
            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
            queue.Enqueue((row, col));
            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    var point = queue.Dequeue();
                    int r = point.row, c = point.col;
                    if (grid[r][c] == 1)
                    {
                        island.Add(point); grid[r][c] = 2;
                        if (r > 0) queue.Enqueue((r - 1, c));                   // 上
                        if (r < grid.Length - 1) queue.Enqueue((r + 1, c));     // 下
                        if (c > 0) queue.Enqueue((r, c - 1));                   // 左
                        if (c < grid[0].Length - 1) queue.Enqueue((r, c + 1));  // 右
                    }
                }
            }
        }

        /// <summary>
        /// BFS查找一座岛
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="mask"></param>
        /// <param name="island"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void FindIsland_BFS(int[][] grid, bool[][] mask, HashSet<(int row, int col)> island, int row, int col)
        {
            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
            queue.Enqueue((row, col));
            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    var point = queue.Dequeue();
                    int r = point.row, c = point.col;
                    if (grid[r][c] == 1 && (!mask[r][c]))
                    {
                        island.Add(point); mask[r][c] = true;
                        if (r > 0) queue.Enqueue((r - 1, c));                   // 上
                        if (r < grid.Length - 1) queue.Enqueue((r + 1, c));     // 下
                        if (c > 0) queue.Enqueue((r, c - 1));                   // 左
                        if (c < grid[0].Length - 1) queue.Enqueue((r, c + 1));  // 右
                    }
                }
            }
        }
    }
}
