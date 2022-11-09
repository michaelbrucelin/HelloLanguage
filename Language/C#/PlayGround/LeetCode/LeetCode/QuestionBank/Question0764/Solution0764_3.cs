using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0764
{
    public class Solution0764_3 : Interface0764
    {
        public int OrderOfLargestPlusSign2(int n, int[][] mines)
        {
            int result = 0;
            HashSet<int> hash = mines.Select(arr => arr[0] * n + arr[1]).ToHashSet();
            int[,,] dp = new int[4, n, n];
            for (int k = 0; k < 4; k++) for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) dp[k, i, j] = n;

            for (int col = 0; col < n; col++) for (int row = 0; row < n; row++)       // 向上方向，从上向下遍历
                    if (row == 0) dp[0, row, col] = hash.Contains(row * n + col) ? 0 : 1;
                    else dp[0, row, col] = hash.Contains(row * n + col) ? 0 : Math.Min(dp[0, row - 1, col] + 1, dp[0, row, col]);

            for (int row = 0; row < n; row++) for (int col = n - 1; col >= 0; col--)  // 向右方向，从右向左遍历
                    if (col == n - 1) dp[1, row, col] = hash.Contains(row * n + col) ? 0 : 1;
                    else dp[1, row, col] = hash.Contains(row * n + col) ? 0 : Math.Min(dp[1, row, col + 1] + 1, dp[1, row, col]);

            for (int col = 0; col < n; col++) for (int row = n - 1; row >= 0; row--)  // 向下方向，从下向上遍历
                    if (row == n - 1) dp[2, row, col] = hash.Contains(row * n + col) ? 0 : 1;
                    else dp[2, row, col] = hash.Contains(row * n + col) ? 0 : Math.Min(dp[2, row + 1, col] + 1, dp[2, row, col]);

            for (int row = 0; row < n; row++) for (int col = 0; col < n; col++)       // 向左方向，从左向右遍历
                {
                    if (col == 0) dp[3, row, col] = hash.Contains(row * n + col) ? 0 : 1;
                    else dp[3, row, col] = hash.Contains(row * n + col) ? 0 : Math.Min(dp[3, row, col - 1] + 1, dp[3, row, col]);
                    result = Math.Max((new int[] { dp[0, row, col], dp[1, row, col], dp[2, row, col], dp[3, row, col], }).Min(), result);
                }

            return result;
        }

        /// <summary>
        /// 与上面的一样，优化了空间复杂度
        /// </summary>
        /// <param name="n"></param>
        /// <param name="mines"></param>
        /// <returns></returns>
        public int OrderOfLargestPlusSign(int n, int[][] mines)
        {
            int result = 0;
            HashSet<int> hash = mines.Select(arr => arr[0] * n + arr[1]).ToHashSet();
            int[,] dp = new int[n, n];
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) dp[i, j] = n;

            for (int col = 0; col < n; col++)  // 向上方向，从上向下遍历
            {
                int cnt = 0; for (int row = 0; row < n; row++)
                {
                    if (hash.Contains(row * n + col)) cnt = 0; else cnt++;
                    dp[row, col] = Math.Min(dp[row, col], cnt);
                }
            }

            for (int row = 0; row < n; row++)  // 向右方向，从右向左遍历
            {
                int cnt = 0; for (int col = n - 1; col >= 0; col--)
                {
                    if (hash.Contains(row * n + col)) cnt = 0; else cnt++;
                    dp[row, col] = Math.Min(dp[row, col], cnt);
                }
            }

            for (int col = 0; col < n; col++)  // 向下方向，从下向上遍历
            {
                int cnt = 0; for (int row = n - 1; row >= 0; row--)
                {
                    if (hash.Contains(row * n + col)) cnt = 0; else cnt++;
                    dp[row, col] = Math.Min(dp[row, col], cnt);
                }
            }

            for (int row = 0; row < n; row++)  // 向左方向，从左向右遍历
            {
                int cnt = 0; for (int col = 0; col < n; col++)
                {
                    if (hash.Contains(row * n + col)) cnt = 0; else cnt++;
                    dp[row, col] = Math.Min(dp[row, col], cnt);
                    result = Math.Max(dp[row, col], result);
                }
            }

            return result;
        }
    }
}
