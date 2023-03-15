using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class Graph
    {
    }

    #region 邻接矩阵
    /// <summary>
    /// 邻接矩阵
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    public class MGraph<TVertex, TEdge> where TEdge : IComparable<TEdge>
    {
        public MGraph(int VertexCnt, TEdge Infinity, bool Directed)
        {
            this.Infinity = Infinity;
            this.Directed = Directed;
            this.Vexs = new TVertex[VertexCnt];
            this.Arc = new TEdge[VertexCnt, VertexCnt];
        }

        public MGraph(TVertex[] Vexs, TEdge Infinity, bool Directed)
        {
            this.Infinity = Infinity;
            this.Directed = Directed;
            this.Vexs = Vexs;
            this.Arc = new TEdge[Vexs.Length, Vexs.Length];
        }

        public MGraph(TVertex[] Vexs, TEdge[,] Arc, TEdge Infinity, bool Directed)
        {
            if (Vexs.Length != Arc.GetLength(0) || Arc.GetLength(0) != Arc.GetLength(1))
                throw new Exception("Vexs or Arc data error.");

            this.Infinity = Infinity;
            this.Directed = Directed;
            this.Vexs = Vexs;
            this.Arc = Arc;
        }

        /// <summary>
        /// bool: 有向图; false: 无向图
        /// </summary>
        public bool Directed { get; }

        /// <summary>
        /// 不存在的边的权值，可以设置为-1, int.Max等不可能的权值
        /// </summary>
        public TEdge Infinity { get; }

        /// <summary>
        /// 图中当前的顶点数
        /// </summary>
        public int VertexCnt { get { return Vexs.Length; } }

        /// <summary>
        /// 图中当前的边数
        /// </summary>
        public int EdgeCnt
        {
            get
            {
                int cnt = 0;
                if (Directed)
                {
                    foreach (TEdge edge in Arc) if (edge.CompareTo(Infinity) != 0) cnt++;
                }
                else
                {
                    for (int r = 0; r < VertexCnt; r++) for (int c = 0; c <= r; c++) if (Arc[r, c].CompareTo(Infinity) != 0) cnt++;
                }
                return cnt;
            }
        }

        /// <summary>
        /// 顶点表
        /// </summary>
        public TVertex[] Vexs { get; }

        /// <summary>
        /// 边表
        /// </summary>
        public TEdge[,] Arc { get; }
    }
    #endregion

    #region 邻接表
    /// <summary>
    /// 邻接表
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    public class ALGraph<TVertex, TEdge> where TEdge : IComparable<TEdge>
    {
        public List<Vertex<TVertex, TEdge>> AdjList;
        public int VertexCnt;                         // 图中当前顶点数
        public int EdgesCnt;                          // 图中当前边数
    }

    /// <summary>
    /// 邻接表，顶点表结点
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    public class Vertex<TVertex, TEdge> where TEdge : IComparable<TEdge>
    {
        public int @in;                               // 顶点入度，某些场景（例如拓扑排序）中会用到，一般不需要
        public TVertex data;                          // 顶点域，存储顶点信息
        public Edge<TEdge> firstedge;                 // 边表头指针
    }

    /// <summary>
    /// 邻接表，边表结点
    /// </summary>
    /// <typeparam name="TEdge"></typeparam>
    public class Edge<TEdge> where TEdge : IComparable<TEdge>
    {
        public int adjvex;                            // 邻接点域，存储该顶点对应的下标
        public TEdge weight;                          // 用于存储权值，对于非网图可以不需要
        public Edge<TEdge> next;                      // 链域，指向下一个邻接点
    }
    #endregion
}
