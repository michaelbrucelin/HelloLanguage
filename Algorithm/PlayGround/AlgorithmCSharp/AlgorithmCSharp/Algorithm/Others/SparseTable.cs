using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现的通用稀疏表，可以存储任意类型的数据，并支持任意的查询函数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SparseTable<T>
    {
        public SparseTable(T[] array, Func<T, T, T> queryFunction)
        {
            int n = array.Length;
            int k = (int)Math.Log2(n) + 1;
            table = new T[n, k];
            log = new int[n + 1];
            queryFunc = queryFunction;

            BuildLog(n);
            BuildTable(array, n, k);
        }

        private T[,] table;
        private Func<T, T, T> queryFunc;
        private int[] log;

        private void BuildLog(int n)
        {
            log[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                log[i] = log[i / 2] + 1;
            }
        }

        private void BuildTable(T[] array, int n, int k)
        {
            for (int i = 0; i < n; i++)
            {
                table[i, 0] = array[i];
            }

            for (int j = 1; j < k; j++)
            {
                for (int i = 0; i + (1 << j) <= n; i++)
                {
                    table[i, j] = queryFunc(table[i, j - 1], table[i + (1 << (j - 1)), j - 1]);
                }
            }
        }

        public T Query(int left, int right)
        {
            int j = log[right - left + 1];
            return queryFunc(table[left, j], table[right - (1 << j) + 1, j]);
        }
    }
    /*
    public static void Main(string[] args)
    {
        int[] array = { 1, 3, 2, 7, 9, 11, 3, 5, 6, 2, 0, 8 };
        Func<int, int, int> minFunction = (x, y) => Math.Min(x, y);
        SparseTable<int> st = new SparseTable<int>(array, minFunction);

        // Example queries
        Console.WriteLine(st.Query(0, 2)); // Output: 1
        Console.WriteLine(st.Query(3, 5)); // Output: 7
        Console.WriteLine(st.Query(6, 10)); // Output: 0
        Console.WriteLine(st.Query(0, 11)); // Output: 0

        // Example usage with strings
        string[] stringArray = { "apple", "banana", "orange", "grape", "kiwi" };
        Func<string, string, string> maxLengthFunction = (x, y) => x.Length > y.Length ? x : y;
        SparseTable<string> stStrings = new SparseTable<string>(stringArray, maxLengthFunction);

        // Example queries with strings
        Console.WriteLine(stStrings.Query(0, 2)); // Output: "banana"
        Console.WriteLine(stStrings.Query(1, 4)); // Output: "orange"
    }
    */
}
