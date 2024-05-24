using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现了稀疏表的构建和区间最小值查询
    /// </summary>
    public class SparseTable_INT_MIN
    {
        public SparseTable_INT_MIN(int[] array)
        {
            int n = array.Length;
            int k = (int)Math.Log2(n) + 1;
            table = new int[n, k];
            log = new int[n + 1];

            BuildLog(n);
            BuildTable(array, n, k);
        }

        private int[,] table;
        private int[] log;

        private void BuildLog(int n)
        {
            log[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                log[i] = log[i / 2] + 1;
            }
        }

        private void BuildTable(int[] array, int n, int k)
        {
            for (int i = 0; i < n; i++)
            {
                table[i, 0] = array[i];
            }

            for (int j = 1; j < k; j++)
            {
                for (int i = 0; i + (1 << j) <= n; i++)
                {
                    table[i, j] = Math.Min(table[i, j - 1], table[i + (1 << (j - 1)), j - 1]);
                }
            }
        }

        public int Query(int left, int right)
        {
            int j = log[right - left + 1];
            return Math.Min(table[left, j], table[right - (1 << j) + 1, j]);
        }
    }
    /*
    public static void Main(string[] args)
    {
        int[] array = { 1, 3, 2, 7, 9, 11, 3, 5, 6, 2, 0, 8 };
        SparseTable st = new SparseTable(array);

        // Example queries
        Console.WriteLine(st.Query(0, 2)); // Output: 1
        Console.WriteLine(st.Query(3, 5)); // Output: 7
        Console.WriteLine(st.Query(6, 10)); // Output: 0
        Console.WriteLine(st.Query(0, 11)); // Output: 0
    }
    */
}
