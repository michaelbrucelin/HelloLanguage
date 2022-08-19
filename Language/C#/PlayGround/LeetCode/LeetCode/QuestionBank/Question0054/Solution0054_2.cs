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

            bool[,] visited = new bool[height, width];
            int index = 0, row = 0, column = 0;
            while (index < result.Length)
            {

            }

            return result;
        }
    }
}
