using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0934
{
    public class Test0934
    {
        public void Test()
        {
            Interface0934 solution = new Solution0934();
            int[][] grid;
            int result, answer;
            int id = 0;

            // 1.
            grid = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } };
            answer = 1; result = solution.ShortestBridge(grid);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            grid = new int[][] { new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 1 } };
            answer = 2; result = solution.ShortestBridge(grid);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            grid = new int[][] { new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 0, 0, 0, 1 }, new int[] { 1, 0, 1, 0, 1 }, new int[] { 1, 0, 0, 0, 1 }, new int[] { 1, 1, 1, 1, 1 } };
            answer = 1; result = solution.ShortestBridge(grid);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }

        public void TestGetIslang()
        {
            Action<int[][], bool[][], HashSet<(int row, int col)>, int, int> action;
            // Solution0934 solution = new Solution0934(); action = solution.FindIsland_DFS;
            Solution0934_2 solution = new Solution0934_2(); action = solution.FindIsland_BFS;
            int[][] grid;
            bool[][] mask;
            HashSet<(int row, int col)> island;
            int r = 0, c = 0;

            // 1.
            grid = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } };
            mask = new bool[][] { new bool[2], new bool[2] };
            island = new HashSet<(int row, int col)>();
            for (r = 0; r < grid.Length; r++) for (c = 0; c < grid[r].Length; c++) if (grid[r][c] == 1) goto End1;
            End1:
            action(grid, mask, island, r, c);
            Utils.PrintArray(grid, true);
            Utils.PrintArray(mask, true);
            Utils.PrintArray(new List<(int, int)>(island));

            // 2.
            grid = new int[][] { new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 1 } };
            mask = new bool[][] { new bool[3], new bool[3], new bool[3] };
            island = new HashSet<(int row, int col)>();
            for (r = 0; r < grid.Length; r++) for (c = 0; c < grid[r].Length; c++) if (grid[r][c] == 1) goto End2;
            End2:
            action(grid, mask, island, r, c);
            Utils.PrintArray(grid, true);
            Utils.PrintArray(mask, true);
            Utils.PrintArray(new List<(int, int)>(island));

            // 3.
            grid = new int[][] { new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 0, 0, 0, 1 }, new int[] { 1, 0, 1, 0, 1 }, new int[] { 1, 0, 0, 0, 1 }, new int[] { 1, 1, 1, 1, 1 } };
            mask = new bool[][] { new bool[5], new bool[5], new bool[5], new bool[5], new bool[5] };
            island = new HashSet<(int row, int col)>();
            for (r = 0; r < grid.Length; r++) for (c = 0; c < grid[r].Length; c++) if (grid[r][c] == 1) goto End3;
            End3:
            action(grid, mask, island, r, c);
            Utils.PrintArray(grid, true);
            Utils.PrintArray(mask, true);
            Utils.PrintArray(new List<(int, int)>(island));
        }
    }
}
