using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0054
{
    public class Solution0054_2
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int width = matrix[0].Length, height = matrix.Length;
            int[] result = new int[width * height];

            bool[,] visited = new bool[height + 2, width + 2];  // 外围一圈为true，这样下面就不需要考虑边界问题了matrix[i,j]对应于visited[i+1,j+1]
            for (int i = 0; i < width + 2; i++)
            {
                visited[0, i] = true;
                visited[height + 1, i] = true;
            }
            for (int i = 1; i < height + 2; i++)
            {
                visited[i, 0] = true;
                visited[i, width + 1] = true;
            }

            int index = 0;
            (int x, int y) position = (0, 0);
            int direction = 0;  // 0 左→右  1 上→下  2 右→左  3 下→上
            int[,] directions = new int[4, 2] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
            while (index < result.Length)
            {
                result[index++] = matrix[position.y][position.x];
                visited[position.y + 1, position.x + 1] = true;

                if (visited[position.y + directions[direction, 1] + 1, position.x + directions[direction, 0] + 1])
                    direction = (direction + 1) % 4;

                position = (position.x + directions[direction, 0], position.y + directions[direction, 1]);
            }

            return result;
        }
    }
}
