using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1582
{
    public class Solution1582_3 : Interface1582
    {
        public int NumSpecial(int[][] mat)
        {
            int result = 0;

            int[] rowcnt = new int[mat.Length], colcnt = new int[mat[0].Length];
            for (int i = 0; i < mat.Length; i++)
                for (int j = 0; j < mat[0].Length; j++)
                { rowcnt[i] += mat[i][j]; colcnt[j] += mat[i][j]; }

            for (int i = 0; i < mat.Length; i++)
                for (int j = 0; j < mat[0].Length; j++)
                    if (mat[i][j] == 1 && rowcnt[i] == 1 && colcnt[j] == 1) result++;

            return result;
        }

        /// <summary>
        /// 在上面的算法的基础上做一些优化，使外层循环的次数更少
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int NumSpecial2(int[][] mat)
        {
            int result = 0;

            int[] rowcnt = new int[mat.Length], colcnt = new int[mat[0].Length];
            for (int i = 0; i < mat.Length; i++)
                for (int j = 0; j < mat[0].Length; j++)
                { rowcnt[i] += mat[i][j]; colcnt[j] += mat[i][j]; }

            for (int i = 0; i < mat.Length; i++)
            {
                if (rowcnt[i] != 1) continue;
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (mat[i][j] == 1 && rowcnt[i] == 1 && colcnt[j] == 1)
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
