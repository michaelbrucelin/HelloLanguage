using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MGraph<TVertex, TEdge>
    {
        public MGraph(int VertexCnt, TEdge Infinity)
        {
            this.Infinity = Infinity;
            this.VertexCnt = VertexCnt;
            this.EdgeCnt = 0;
            this.Vexs = new TVertex[VertexCnt];
            this.Arc = new TEdge[VertexCnt, VertexCnt];
        }

        public MGraph(TVertex[] Vexs, TEdge Infinity)
        {
            this.Infinity = Infinity;
            this.VertexCnt = Vexs.Length;
            this.EdgeCnt = 0;
            this.Vexs = Vexs;
            this.Arc = new TEdge[Vexs.Length, Vexs.Length];
        }

        public MGraph(TVertex[] Vexs, TEdge[,] Arc, TEdge Infinity)
        {
            if (Vexs.Length != Arc.GetLength(0) || Arc.GetLength(0) != Arc.GetLength(1))
                throw new Exception("Vexs or Arc data error.");

            this.Infinity = Infinity;
            this.VertexCnt = Vexs.Length;
            // this.EdgeCnt = 0;  // 需要计算
            this.Vexs = Vexs;
            this.Arc = Arc;
        }

        public TEdge Infinity { get; }  // 不存在的边的权值，可以设置为-1, int.Max等不可能的权值

        public int VertexCnt { get; }   // 图中当前的顶点数

        public int EdgeCnt { get; }     // 图中当前的边数

        public TVertex[] Vexs { get; }  // 顶点表

        public TEdge[,] Arc { get; }    // 边表
    }
    #endregion

    #region 邻接表
    /// <summary>
    /// 邻接表
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    public class ALGraph<TVertex, TEdge>
    {

    }

    public class Vertex<TVertex>
    {

    }

    public class Edge<TEdge>
    {
        int adjvex;                    // 邻接点域，存储该顶点对应的下标
        TEdge weight;                  // 用于存储权值，对于非网图可以不需要
        Edge<TEdge> next;              // 链域，指向下一个邻接点
    }
    #endregion
}
