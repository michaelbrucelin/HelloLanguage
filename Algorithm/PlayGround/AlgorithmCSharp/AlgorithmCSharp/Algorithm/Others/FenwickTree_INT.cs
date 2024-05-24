using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现一个简单的树状数组
    /// </summary>
    public class FenwickTree_INT
    {
        public FenwickTree_INT(int size)
        {
            tree = new int[size + 1]; // 树状数组的索引从1开始，因此需要额外的空间
        }

        private int[] tree;

        // 更新指定位置的值
        public void Update(int index, int delta)
        {
            while (index < tree.Length)
            {
                tree[index] += delta;
                index += index & -index; // 更新下一个节点的索引
            }
        }

        // 查询前缀和
        public int Query(int index)
        {
            int sum = 0;
            while (index > 0)
            {
                sum += tree[index];
                index -= index & -index; // 更新上一个节点的索引
            }
            return sum;
        }
    }
    /*
    public static void Main(string[] args)
    {
        int[] nums = { 1, 3, 5, 7, 9, 11 };
        FenwickTree_INT tree = new FenwickTree_INT(nums.Length);
        
        // 构建树状数组
        for (int i = 0; i < nums.Length; i++)
        {
            tree.Update(i + 1, nums[i]); // 索引从1开始
        }

        // 查询前缀和
        Console.WriteLine("Prefix Sum from 1 to 3: " + tree.Query(3));
        Console.WriteLine("Prefix Sum from 2 to 4: " + (tree.Query(4) - tree.Query(1)));
    }
    */
}
