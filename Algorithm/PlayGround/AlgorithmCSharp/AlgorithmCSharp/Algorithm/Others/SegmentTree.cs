using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    public class SegmentTree<T>
    {
        public SegmentTree(T[] nums, Func<T, T, T> mergeFunction)
        {
            this.nums = nums;
            this.mergeFunc = mergeFunction;
            int len = nums.Length;
            int height = (int)Math.Ceiling(Math.Log(len, 2));
            int maxSize = (1 << (height + 1)) - 1;             // 2 * (int)Math.Pow(2, height) - 1;
            tree = new T[maxSize];
            BuildTree(0, 0, len - 1);
        }

        private T[] nums;
        private T[] tree;
        private Func<T, T, T> mergeFunc;

        private void BuildTree(int index, int start, int end)
        {
            if (start == end)
            {
                tree[index] = nums[start];
            }
            else
            {
                int mid = start + ((end - start) >> 1);
                BuildTree(2 * index + 1, start, mid);
                BuildTree(2 * index + 2, mid + 1, end);
                tree[index] = mergeFunc(tree[2 * index + 1], tree[2 * index + 2]);
            }
        }

        public T Query(int start, int end)
        {
            return QueryHelper(0, 0, nums.Length - 1, start, end);
        }

        private T QueryHelper(int index, int start, int end, int qStart, int qEnd)
        {
            if (qStart > end || qEnd < start) return default(T);     // Out of range
            if (qStart <= start && qEnd >= end) return tree[index];  // Current segment is within query range

            int mid = start + ((end - start) >> 1);
            T leftResult = QueryHelper(2 * index + 1, start, mid, qStart, qEnd);
            T rightResult = QueryHelper(2 * index + 2, mid + 1, end, qStart, qEnd);
            if (EqualityComparer<T>.Default.Equals(leftResult, default(T))) return rightResult;
            if (EqualityComparer<T>.Default.Equals(rightResult, default(T))) return leftResult;

            return mergeFunc(leftResult, rightResult);
        }
    }

    /*
    public static void Main(string[] args)
    {
        // Example usage with integer array
        int[] nums = { 1, 3, 2, 7, 9, 11 };
        Func<int, int, int> maxFunction = (x, y) => Math.Max(x, y);
        SegmentTree<int> segTree = new SegmentTree<int>(nums, maxFunction);

        // Example queries
        int startIndex = 1;
        int endIndex = 4;

        int maxInRange = segTree.Query(startIndex, endIndex);

        Console.WriteLine($"The maximum value in range [{startIndex}, {endIndex}] is: {maxInRange}");

        // Example usage with double array
        double[] doubleNums = { 1.5, 3.2, 2.7, 7.4, 9.1, 11.8 };
        Func<double, double, double> sumFunction = (x, y) => x + y;
        SegmentTree<double> segTreeDouble = new SegmentTree<double>(doubleNums, sumFunction);

        // Example queries
        startIndex = 2;
        endIndex = 5;

        double sumInRange = segTreeDouble.Query(startIndex, endIndex);

        Console.WriteLine($"The sum of values in range [{startIndex}, {endIndex}] is: {sumInRange}");
    }
     */
}
