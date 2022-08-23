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
        /// 整体思路
        /// 1. 先调整列，使每一行的元素都是0 1交替的
        /// 2. 再调整行，使每一列的元素都是0 1交替的
        /// 
        /// 明确一下几点
        /// 1. 调整列，不会影响行的结果，调整行，不会影响列的结果
        /// 2. 在第一行已经调整好的（元素交叉）的情况下，如果有其他行元素没有交叉，那么其他行是无法调整正确的
        ///     简要证明，只有两种情况
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int MovesToChessboard(int[][] board)
        {
            SwapColumns(board, 0, 1);
            SwapRows(board, 1, 2);

            return -1;
        }

        private void SwapRows(int[][] board, int i, int j)
        {
            int[] temp = board[i];
            board[i] = board[j];
            board[j] = temp;
        }

        private void SwapColumns(int[][] board, int i, int j)
        {
            for (int k = 0; k < board.Length; k++)
            {
                int temp = board[k][i];
                board[k][i] = board[k][j];
                board[k][j] = temp;
            }
        }

        public void PrintBoard(int[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                    Console.Write($"{board[i][j]} ");
                Console.WriteLine();
            }
        }
    }
}
