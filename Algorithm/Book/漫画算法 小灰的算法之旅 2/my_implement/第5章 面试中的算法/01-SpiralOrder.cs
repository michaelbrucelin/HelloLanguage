using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[,] matrix = new int[4, 5] {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 }
            };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]}\t");

                Console.WriteLine();
            }

            int[] arr = SpiralOrder2(matrix);
            arr.ToList().ForEach(i => Console.Write($"{i}, "));
        }

        /// <summary>
        /// 顺时针螺旋遍历二维数组
        /// 
        /// 如果输入如下二维数组：
        ///  1   2   3   4   5
        ///  6   7   8   9  10
        /// 11  12  13  14  15
        /// 16  17  18  19  20
        /// 
        /// 则返回如下一维数组：
        /// 1  2  3  4  5  10  15  20  19  18  17  16  11  6  7  8  9  14  13  12
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[] SpiralOrder(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int[] result = new int[m * n];
            int index = 0;

            int top = 0, right = n - 1, bottom = m - 1, left = 0;
            while (true)
            {
                // 1. 上边，从左向右
                if (top > bottom || left > right) break;
                for (int i = left; i <= right; i++)
                    result[index++] = matrix[top, i];
                top++;

                // 2. 右边，从上到下
                if (top > bottom || left > right) break;
                for (int i = top; i <= bottom; i++)
                    result[index++] = matrix[i, right];
                right--;

                // 3. 下边，从右向左
                if (top > bottom || left > right) break;
                for (int i = right; i >= left; i--)
                    result[index++] = matrix[bottom, i];
                bottom--;

                // 4. 左边，从下到上
                if (top > bottom || left > right) break;
                for (int i = bottom; i >= top; i--)
                    result[index++] = matrix[i, left];
                left++;
            }

            return result;
        }

        /// <summary>
        /// 顺时针螺旋遍历二维数组
        /// 
        /// 如果输入如下二维数组：
        ///  1   2   3   4   5
        ///  6   7   8   9  10
        /// 11  12  13  14  15
        /// 16  17  18  19  20
        /// 
        /// 则返回如下一维数组：
        /// 1  2  3  4  5  10  15  20  19  18  17  16  11  6  7  8  9  14  13  12
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[] SpiralOrder2(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int[] result = new int[m * n];
            int index = 0;

            int top = 0, right = n - 1, bottom = m - 1, left = 0;
            while (true)
            {
                // 1. 上边，从左向右
                if (index >= result.Length) break;
                for (int i = left; i <= right; i++)
                    result[index++] = matrix[top, i];
                top++;

                // 2. 右边，从上到下
                if (index >= result.Length) break;
                for (int i = top; i <= bottom; i++)
                    result[index++] = matrix[i, right];
                right--;

                // 3. 下边，从右向左
                if (index >= result.Length) break;
                for (int i = right; i >= left; i--)
                    result[index++] = matrix[bottom, i];
                bottom--;

                // 4. 左边，从下到上
                if (index >= result.Length) break;
                for (int i = bottom; i >= top; i--)
                    result[index++] = matrix[i, left];
                left++;
            }

            return result;
        }
    }
}
