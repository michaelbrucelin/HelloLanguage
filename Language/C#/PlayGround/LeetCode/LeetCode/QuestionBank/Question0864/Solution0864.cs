using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0864
{
    public class Solution0864 : Interface0864
    {
        private readonly static (int row, int col)[] directions = new (int row, int col)[] { (-1, 0), (0, 1), (1, 0), (0, -1) };  // 上右下左

        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestPathAllKeys(string[] grid)
        {
            int start_row = -1, start_col = -1, rowcnt = grid.Length, colcnt = grid[0].Length;
            int keycnt = 0; Dictionary<char, int> keymap = new Dictionary<char, int>();         // 当有两把钥匙时，题目没有保证是a与b，也有可能是a与c
            for (int row = 0; row < rowcnt; row++) for (int col = 0; col < colcnt; col++)       // 寻找起点并记录钥匙
                {
                    if (char.IsLower(grid[row][col])) keymap.Add(grid[row][col], ++keycnt - 1);
                    else if (grid[row][col] == '@') { start_row = row; start_col = col; }
                }
            int done = (1 << keycnt) - 1;

            Queue<(int row, int col, int state)> queue = new Queue<(int row, int col, int state)>();
            queue.Enqueue((start_row, start_col, 0));
            int[,,] states = new int[rowcnt, colcnt, (1 << keycnt)]; states[start_row, start_col, 0] = 1;
            int steps = 0;
            while (queue.Count > 0)
            {
                steps++; int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    var info = queue.Dequeue();
                    for (int j = 0; j < 4; j++)
                    {
                        int row = info.row + directions[j].row, col = info.col + directions[j].col;
                        if (row >= 0 && row < rowcnt && col >= 0 && col < colcnt)
                        {
                            char c = grid[row][col]; int state = info.state;
                            if (c == '.' || c == '@')
                            {
                                if (states[row, col, state] == 0) { states[row, col, state] = 1; queue.Enqueue((row, col, state)); }
                            }
                            else if (char.IsLower(c))
                            {
                                state = state |= (1 << keymap[c]);
                                if (state == done) return steps;
                                if (states[row, col, state] == 0) { states[row, col, state] = 1; queue.Enqueue((row, col, state)); }
                            }
                            else if (char.IsUpper(c))
                            {
                                int key_mask = (1 << keymap[(char)(c ^ 32)]);
                                if ((state & key_mask) == key_mask && states[row, col, state] == 0) { states[row, col, state] = 1; queue.Enqueue((row, col, state)); }
                            }
                        }
                    }
                }
            }

            return -1;
        }
    }
}
