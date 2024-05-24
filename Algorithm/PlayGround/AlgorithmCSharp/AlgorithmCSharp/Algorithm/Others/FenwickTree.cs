using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现了一个通用的树状数组的 C# 实现，它可以用于处理任意类型的元素，支持在任意位置更新值和查询前缀和
    /// </summary>
    public class FenwickTree<T>
    {
        public FenwickTree(int size, Func<T, T, T> mergeFunc)
        {
            tree = new T[size + 1]; // 树状数组的索引从1开始，因此需要额外的空间
            merge = mergeFunc;
        }

        private T[] tree;
        private Func<T, T, T> merge;

        // 更新指定位置的值
        public void Update(int index, T value)
        {
            while (index < tree.Length)
            {
                tree[index] = merge(tree[index], value);
                index += index & -index; // 更新下一个节点的索引
            }
        }

        // 查询前缀和
        public T Query(int index)
        {
            T sum = default(T);
            while (index > 0)
            {
                sum = merge(sum, tree[index]);
                index -= index & -index; // 更新上一个节点的索引
            }
            return sum;
        }
    }
    /*
    public static void Main(string[] args)
    {
        // 使用示例：树状数组存储整数，并支持查询区间和
        FenwickTree<int> tree = new FenwickTree<int>(6, (x, y) => x + y);

        // 更新树状数组中的值
        tree.Update(1, 2);
        tree.Update(2, 3);
        tree.Update(3, 5);
        tree.Update(4, 7);
        tree.Update(5, 9);
        tree.Update(6, 11);

        // 查询前缀和
        Console.WriteLine("Prefix Sum from 1 to 3: " + tree.Query(3));
        Console.WriteLine("Prefix Sum from 2 to 4: " + (tree.Query(4) - tree.Query(1)));
    }
    */
}
