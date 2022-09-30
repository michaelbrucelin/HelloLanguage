using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0108
{
    public class Solution0108 : Interface0108
    {
        public void SetZeroes(int[][] matrix)
        {
            bool[] rowmask = new bool[matrix.Length];
            bool[] colmask = new bool[matrix[0].Length];

            for (int row = 0; row < matrix.Length; row++) for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 0) { rowmask[row] = true; colmask[col] = true; }
                }

            for (int row = 0; row < rowmask.Length; row++)
            {
                if (rowmask[row])
                    for (int col = 0; col < matrix[0].Length; col++) matrix[row][col] = 0;
            }

            for (int col = 0; col < colmask.Length; col++)
            {
                if (colmask[col])
                    for (int row = 0; row < matrix.Length; row++) matrix[row][col] = 0;
            }
        }

        public void SetZeroes2(int[][] matrix)
        {
            bool[] rowmask = new bool[matrix.Length];
            bool[] colmask = new bool[matrix[0].Length];

            for (int row = 0; row < matrix.Length; row++) for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 0) { rowmask[row] = true; colmask[col] = true; }
                }

            for (int row = 0; row < matrix.Length; row++) for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (rowmask[row] || colmask[col]) matrix[row][col] = 0;
                }
        }
    }
}
