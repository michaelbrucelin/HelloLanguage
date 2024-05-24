using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现的并查集
    /// </summary>
    public class UnionFind_INT
    {
        // 初始化并查集
        public UnionFind_INT(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        private int[] parent;
        private int[] rank;

        // 查找操作，带路径压缩
        public int Find(int p)
        {
            if (parent[p] != p)
            {
                parent[p] = Find(parent[p]); // 路径压缩
            }
            return parent[p];
        }

        // 合并操作，按秩合并
        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP != rootQ)
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
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }
    }
    /*
    public static void Main(string[] args)
    {
        int size = 10;
        UnionFind_INT uf = new UnionFind_INT(size);

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
    }
    */
}
