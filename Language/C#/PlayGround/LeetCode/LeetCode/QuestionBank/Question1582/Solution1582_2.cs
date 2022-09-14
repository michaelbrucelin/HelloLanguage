using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1582
{
    public class Solution1582_2 : Interface1582
    {
        /// <summary>
        /// 在暴力解的基础上进行优化，在判断一个单元格结果的基础上，可以排除一些单元格，减少外层的循环次数
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int NumSpecial(int[][] mat)
        {
            int result = 0;

            bool[] colmask = new bool[mat[0].Length];
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (colmask[j]) continue;
                    if (mat[i][j] == 1)  // 无论这个值验证是否通过，都直接下一行，因为这一行后面的值如果是1，也会因为一行两个1而验证失败
                    {
                        colmask[j] = true;  // 这一列已经有一个1了，这一列的其他值无需再验证
                        if (!VerifyRow(mat, i, j)) { break; }
                        if (!VerifyColumn(mat, i, j)) { break; }

                        result++;
                        break;
                    }
                }
            }

            return result;
        }

        private bool VerifyRow(int[][] mat, int row, int column)
        {
            for (int i = 0; i < mat[0].Length; i++)
                if (i != column && mat[row][i] == 1) return false;

            return true;
        }

        private bool VerifyColumn(int[][] mat, int row, int column)
        {
            for (int i = 0; i < mat.Length; i++)
                if (i != row && mat[i][column] == 1) return false;

            return true;
        }
    }
}
