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
            HashSet<(int row, int col)> island1 = new HashSet<(int, int)>();
            HashSet<(int row, int col)> island2 = new HashSet<(int, int)>();

            return -1;
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
