using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0054
{
    public class Solution0054 : Interface0054
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int top = 0, right = matrix[0].Length - 1, bottom = matrix.Length - 1, left = 0;
            int[] result = new int[(right + 1) * (bottom + 1)];

            int index = 0;
            while (index < result.Length)
            {
                // 上边
                for (int i = left; i <= right; i++) result[index++] = matrix[top][i];

                if (index == result.Length) break;
                top++;

                // 右边
                for (int i = top; i <= bottom; i++) result[index++] = matrix[i][right];

                if (index == result.Length) break;
                right--;

                // 底边
                for (int i = right; i >= left; i--) result[index++] = matrix[bottom][i];

                if (index == result.Length) break;
                bottom--;

                // 左边
                for (int i = bottom; i >= top; i--) result[index++] = matrix[i][left];

                if (index == result.Length) break;
                left++;
            }

            return result;
        }
    }
}
