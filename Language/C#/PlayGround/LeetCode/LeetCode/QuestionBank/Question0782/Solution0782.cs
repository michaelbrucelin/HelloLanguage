using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0782
{
    public class Solution0782
    {
        /// <summary>
        /// 明确以下几点
        /// 1. 调整列，不会影响行的结果，调整行，不会影响列的结果
        /// 2. 在第一行已经调整好的（元素交叉）的情况下，如果有其他行元素没有交叉，那么其他行是无法调整正确的
        ///     简要证明，调整完的最终结果只有两种情况
        ///     2.1 两行一致，即  1 0 1 0 1 0 1 0 ...
        ///                       1 0 1 0 1 0 1 0 ...
        ///     2.2 两行交错，即  1 0 1 0 1 0 1 0 ...
        ///                       0 1 0 1 0 1 0 1 ...
        ///     假定第一行已经调整好了，而第二行没有调整好，
        ///     这时，如果有可能将第二行也调整好（第一行不能被破坏），那么考虑将调整好的步骤逆序操作到当前状态，
        ///     就是两行都调整好了，保证不破坏第一行的情况下，将第二行破坏即可，而仔细看上面的两种最终结果，可以看出，这是不可能的
        /// 3. 由第2点知，如果有解，无论调整那一行，调整的步数都是一致的
        /// 
        /// 基于上面几点，整体思路
        /// 1. 先调整列，使第一行的元素都是0 1交替的
        ///     1.1 然后检查各行是否都是正确的，有错误的，无解；都是正确的，继续；
        /// 2. 再调整列，使第一列的元素都是0 1交替的
        ///     2.1 第一列如果0比1多，第一行以0开头，否则第一行以1开头；
        ///     2.2 能调整成功，调整完毕；无法调整成功，无解；
        /// 3. 无论交换行，还是交换列，只要第一个元素值确认了，后面的元素就是固定的，所以只要交换的两行（列）的位置本来就是错的，交换的次数自然就是最少的
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int MovesToChessboard(int[][] board)
        {
            int result = 0;

            // 1. 将第一行调整为0 1交错的形式
            // 1.1 检查第一行有没有解
            int first_0_cnt = 0, first_1_cnt = 0;
            for (int i = 0; i < board[0].Length; i++)
                if (board[0][i] == 0) first_0_cnt++; else first_1_cnt++;

            if (first_1_cnt - first_0_cnt >= 2 || first_1_cnt - first_0_cnt <= -2)
                return -1;

            // 1.2 第一行有解，调整第一行第一个元素的值
            if (first_1_cnt == first_0_cnt)
            {
                int first_value_cnt = 0;
                for (int i = 0; i < board[0].Length; i += 2)
                    if (board[0][i] == board[0][0]) first_value_cnt++;
                if (first_value_cnt < (board[0].Length >> 1) - first_value_cnt)  // 更改第一个元素的值，交换的次数更少
                {
                    SwapFirstColumn(board);
                    result++;
                }
            }
            else if ((first_1_cnt - first_0_cnt == 1 && board[0][0] == 0) ||  // 第一个元素必须为1，而现在第一个元素为0
                     (first_0_cnt - first_1_cnt == 1 && board[0][0] == 1))    // 第一个元素必须为0，而现在第一个元素为1
            {
                SwapFirstColumn(board);
                result++;
            }

            // 1.3 将第一行调整为0 1交错的形式，一定有解且第一个元素前面已经调整好了
            int even = 0, odd = 1;
            for (; even < board[0].Length; even += 2)
            {
                if (board[0][even] != board[0][0])
                {
                    for (; odd < board[0].Length; odd += 2)
                    {
                        if (board[0][odd] == board[0][0])
                        {
                            SwapColumns(board, even, odd);
                            result++;
                            break;
                        }
                    }
                }
            }

            // 1.4 检查其他行是不是都调整为0 1交错的形式
            for (int i = 1; i < board.Length; i++)
                if (!IsCross(board[i])) return -1;

            // 2. 将第一列调整为0 1交错的形式
            // 2.1 检查第一列有没有解
            first_0_cnt = 0; first_1_cnt = 0;
            for (int i = 0; i < board.Length; i++)
                if (board[i][0] == 0) first_0_cnt++; else first_1_cnt++;

            if (first_1_cnt - first_0_cnt >= 2 || first_1_cnt - first_0_cnt <= -2)
                return -1;

            // 2.2 第一列有解，调整第一列第一个元素的值
            if (first_1_cnt == first_0_cnt)
            {
                int first_value_cnt = 0;
                for (int i = 0; i < board.Length; i += 2)
                    if (board[i][0] == board[0][0]) first_value_cnt++;
                if (first_value_cnt < (board.Length >> 1) - first_value_cnt)  // 更改第一个元素的值，交换的次数更少
                {
                    SwapFirstRow(board);
                    result++;
                }
            }
            else if ((first_1_cnt - first_0_cnt == 1 && board[0][0] == 0) ||  // 第一个元素必须为1，而现在第一个元素为0
                (first_0_cnt - first_1_cnt == 1 && board[0][0] == 1))         // 第一个元素必须为0，而现在第一个元素为1
            {
                SwapFirstRow(board);
                result++;
            }

            // 2.3 将第一列调整为0 1交错的形式，一定有解且第一个元素前面已经调整好了
            even = 0; odd = 1;
            for (; even < board.Length; even += 2)
            {
                if (board[even][0] != board[0][0])
                {
                    for (; odd < board.Length; odd += 2)
                    {
                        if (board[odd][0] == board[0][0])
                        {
                            SwapRows(board, even, odd);
                            result++;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 交换二位数组的两行
        /// </summary>
        /// <param name="board"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void SwapRows(int[][] board, int i, int j)
        {
            int[] temp = board[i];
            board[i] = board[j];
            board[j] = temp;
        }

        /// <summary>
        /// 交换二维数组的两列
        /// </summary>
        /// <param name="board"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void SwapColumns(int[][] board, int i, int j)
        {
            for (int k = 0; k < board.Length; k++)
            {
                int temp = board[k][i];
                board[k][i] = board[k][j];
                board[k][j] = temp;
            }
        }

        /// <summary>
        /// 调整第一行第一个元素的值，0 -> 1 1 -> 0
        /// </summary>
        /// <param name="board"></param>
        private void SwapFirstRow(int[][] board)
        {
            for (int i = 1; i < board.Length; i += 2)
            {
                if (board[i][0] != board[0][0])
                {
                    SwapRows(board, 0, i);
                    break;
                }
            }
        }

        /// <summary>
        /// 调整第一列第一个元素的值，0 -> 1 1 -> 0
        /// </summary>
        /// <param name="board"></param>
        private void SwapFirstColumn(int[][] board)
        {
            for (int i = 1; i < board[0].Length; i += 2)
            {
                if (board[0][i] != board[0][0])
                {
                    SwapColumns(board, 0, i);
                    break;
                }
            }
        }

        /// <summary>
        /// 判断数组是不是0 1交错的
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private bool IsCross(int[] arr)
        {
            for (int i = 2; i < arr.Length; i += 2)
                if (arr[i] != arr[0]) return false;

            for (int i = 1; i < arr.Length; i += 2)
                if (arr[i] == arr[0]) return false;

            return true;
        }

        /// <summary>
        /// 打印二维数组
        /// </summary>
        /// <param name="board"></param>
        private void PrintBoard(int[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                    Console.Write($"{board[i][j]} ");
                Console.WriteLine();
            }
        }

        public void Test0782()
        {
            //int[][] board = new int[][] {
            //    new int[] { 0, 1, 1, 0 },
            //    new int[] { 0, 1, 1, 0 },
            //    new int[] { 1, 0, 0, 1 },
            //    new int[] { 1, 0, 0, 1 } };

            //Console.WriteLine($"2: {MovesToChessboard(board)}");
            //PrintBoard(board);

            int[][] board = new int[][]{
                new int[] { 1, 1, 1, 0, 0, 1, 0, 0 },
                new int[] { 0, 0, 0, 1, 1, 0, 1, 1 },
                new int[] { 1, 1, 1, 0, 0, 1, 0, 0 },
                new int[] { 0, 0, 0, 1, 1, 0, 1, 1 },
                new int[] { 0, 0, 0, 1, 1, 0, 1, 1 },
                new int[] { 0, 0, 0, 1, 1, 0, 1, 1 },
                new int[] { 1, 1, 1, 0, 0, 1, 0, 0 },
                new int[] { 1, 1, 1, 0, 0, 1, 0, 0 }
            };

            Console.WriteLine($"3: {MovesToChessboard(board)}");
            PrintBoard(board);
        }
    }
}
