using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现了通用的并查集，支持任意类型的元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnionFind<T>
    {
        // 初始化并查集
        public UnionFind(IEnumerable<T> elements)
        {
            parent = new Dictionary<T, T>();
            rank = new Dictionary<T, int>();
            foreach (var element in elements)
            {
                parent[element] = element;
                rank[element] = 0;
            }
        }

        private Dictionary<T, T> parent;
        private Dictionary<T, int> rank;

        // 查找操作，带路径压缩
        public T Find(T p)
        {
            if (!parent.ContainsKey(p))
            {
                throw new ArgumentException("Element not found in UnionFind");
            }

            if (!EqualityComparer<T>.Default.Equals(parent[p], p))
            {
                parent[p] = Find(parent[p]); // 路径压缩
            }
            return parent[p];
        }

        // 合并操作，按秩合并
        public void Union(T p, T q)
        {
            T rootP = Find(p);
            T rootQ = Find(q);
            if (!EqualityComparer<T>.Default.Equals(rootP, rootQ))
            {
                if (rank[rootP] > rank[rootQ])
                {
                    parent[rootQ] = rootP;
                }
                else if (rank[rootP] < rank[rootQ])
                {
                    parent[rootP] = rootQ;
                }
                else
                {
                    parent[rootQ] = rootP;
                    rank[rootP]++;
                }
            }
        }

        // 检查两个元素是否属于同一集合
        public bool Connected(T p, T q)
        {
            return EqualityComparer<T>.Default.Equals(Find(p), Find(q));
        }
    }
    /*
    public static void Main(string[] args)
    {
        // Example usage with integers
        var elements = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        UnionFind<int> uf = new UnionFind<int>(elements);

        // 合并一些节点
        uf.Union(0, 1);
        uf.Union(1, 2);
        uf.Union(3, 4);
        uf.Union(4, 5);

        // 检查连接情况
        Console.WriteLine(uf.Connected(0, 2)); // True
        Console.WriteLine(uf.Connected(0, 3)); // False

        // 合并更多节点
        uf.Union(2, 3);

        // 再次检查连接情况
        Console.WriteLine(uf.Connected(0, 5)); // True

        // Example usage with strings
        var stringElements = new List<string> { "a", "b", "c", "d", "e" };
        UnionFind<string> ufStrings = new UnionFind<string>(stringElements);

        // 合并一些节点
        ufStrings.Union("a", "b");
        ufStrings.Union("b", "c");

        // 检查连接情况
        Console.WriteLine(ufStrings.Connected("a", "c")); // True
        Console.WriteLine(ufStrings.Connected("a", "d")); // False
    }
    */
}
