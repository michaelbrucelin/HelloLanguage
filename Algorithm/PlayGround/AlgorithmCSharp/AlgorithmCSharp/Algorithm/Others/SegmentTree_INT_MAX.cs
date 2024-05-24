using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现了构建线段树和查询区间最大值的功能
    /// </summary>
    public class SegmentTree_INT_MAX
    {
        public SegmentTree_INT_MAX(int[] nums)
        {
            this.nums = nums;
            int len = nums.Length;
            int height = (int)Math.Ceiling(Math.Log(len, 2));
            int maxSize = (1 << (height + 1)) - 1;             // 2 * (int)Math.Pow(2, height) - 1;
            tree = new int[maxSize];
            BuildTree(0, 0, len - 1);
        }

        private int[] nums;
        private int[] tree;

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
                tree[index] = Math.Max(tree[2 * index + 1], tree[2 * index + 2]);
            }
        }

        public int Query(int start, int end)
        {
            return QueryHelper(0, 0, nums.Length - 1, start, end);
        }

        private int QueryHelper(int index, int start, int end, int qStart, int qEnd)
        {
            if (qStart > end || qEnd < start) return int.MinValue;   // Out of range
            if (qStart <= start && qEnd >= end) return tree[index];  // Current segment is within query range
            int mid = start + ((end - start) >> 1);
            int leftMax = QueryHelper(2 * index + 1, start, mid, qStart, qEnd);
            int rightMax = QueryHelper(2 * index + 2, mid + 1, end, qStart, qEnd);

            return Math.Max(leftMax, rightMax);
        }
    }

    /*
    public static void Main(string[] args)
    {
        int[] nums = { 1, 3, 2, 7, 9, 11 };
        SegmentTree_INT_MAX segTree = new SegmentTree_INT_MAX(nums);

        // Example queries
        int startIndex = 1;
        int endIndex = 4;

        int maxInRange = segTree.Query(startIndex, endIndex);

        Console.WriteLine($"The maximum value in range [{startIndex}, {endIndex}] is: {maxInRange}");
    }
    */
}
