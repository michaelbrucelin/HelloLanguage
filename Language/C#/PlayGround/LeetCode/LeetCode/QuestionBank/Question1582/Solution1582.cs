using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1582
{
    public class Solution1582
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int NumSpecial(int[][] mat)
        {
            int result = 0;

            for (int i = 0; i < mat.Length; i++)
                for (int j = 0; j < mat[0].Length; j++)
                    if (mat[i][j] == 1 && Verify(mat, i, j)) result++;

            return result;
        }

        private bool Verify(int[][] mat, int row, int column)
        {
            for (int i = 0; i < mat[0].Length; i++)
                if (i != column && mat[row][i] == 1) return false;

            for (int i = 0; i < mat.Length; i++)
                if (i != row && mat[i][column] == 1) return false;

            return true;
        }
    }
}
