﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    public class MGraph<TVertex, TEdge> where TEdge : INumber<TEdge>
    {
        public MGraph(int vertexCnt, TEdge infinity, bool directed)
        {
            Infinity = infinity;
            Directed = directed;
            Vexs = new TVertex[vertexCnt];
            Arc = new TEdge[vertexCnt, vertexCnt];
        }

        public MGraph(TVertex[] vexs, TEdge infinity, bool directed)
        {
            Infinity = infinity;
            Directed = directed;
            Vexs = vexs;
            Arc = new TEdge[vexs.Length, vexs.Length];
        }

        public MGraph(TVertex[] vexs, TEdge[,] arc, TEdge infinity, bool directed)
        {
            if (vexs.Length != arc.GetLength(0) || arc.GetLength(0) != arc.GetLength(1))
                throw new Exception("Vexs or Arc data error.");

            Infinity = infinity;
            Directed = directed;
            Vexs = vexs;
            Arc = arc;
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
        /// 顶点表的索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TVertex this[int index] { get { return Vexs[index]; } }

        /// <summary>
        /// 边表
        /// </summary>
        public TEdge[,] Arc { get; }

        /// <summary>
        /// 边表的索引器
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public TEdge this[int row, int col] { get { return Arc[row, col]; } }
    }
    #endregion

    #region 邻接表
    /// <summary>
    /// 邻接表
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    public class ALGraph<TVertex, TEdge> where TEdge : INumber<TEdge>
    {
        public ALGraph(TEdge infinity, bool directed)
        {
            AdjList = new List<Vertex<TVertex, TEdge>>();
            Infinity = infinity;
            Directed = directed;
        }

        public ALGraph(int vertexCnt, TEdge infinity, bool directed)
        {
            AdjList = new List<Vertex<TVertex, TEdge>>(vertexCnt);
            Infinity = infinity;
            Directed = directed;
        }

        public ALGraph(List<Vertex<TVertex, TEdge>> adjList, TEdge infinity, bool directed)
        {
            AdjList = adjList;
            Infinity = infinity;
            Directed = directed;
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
        /// 顶点列表
        /// </summary>
        public List<Vertex<TVertex, TEdge>> AdjList;

        /// <summary>
        /// 顶点列表的索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vertex<TVertex, TEdge> this[int index] { get { return AdjList[index]; } }

        /// <summary>
        /// 图中当前顶点数
        /// </summary>
        public int VertexCnt { get { return AdjList.Count; } }

        /// <summary>
        /// 图中当前边数
        /// </summary>
        public int EdgeCnt
        {
            get
            {
                int cnt = 0; Edge<TVertex, TEdge> ptr;
                for (int i = 0, _cnt = 0; i < AdjList.Count; i++, _cnt = 0)
                {
                    ptr = AdjList[i].FirstEdge;
                    while (ptr != null) { _cnt++; ptr = ptr.Next; }
                    cnt += _cnt;
                }
                if (!Directed) cnt >>= 1;
                return cnt;
            }
        }
    }

    /// <summary>
    /// 邻接表，顶点表结点
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    public class Vertex<TVertex, TEdge> where TEdge : INumber<TEdge>
    {
        public Vertex() { }

        public Vertex(TVertex data)
        {
            Data = data;
        }

        /// <summary>
        /// 顶点域，存储顶点信息
        /// </summary>
        public TVertex Data;

        /// <summary>
        /// 边表头指针
        /// </summary>
        public Edge<TVertex, TEdge> FirstEdge;
    }

    /// <summary>
    /// 邻接表，边表结点
    /// </summary>
    /// <typeparam name="TEdge"></typeparam>
    public class Edge<TVertex, TEdge> where TEdge : INumber<TEdge>
    {
        public Edge() { }

        public Edge(int adjid, TEdge weight)
        {
            AdjId = adjid;
            Weight = weight;
        }

        /// <summary>
        /// 邻接点域，存储该边连接顶点在顶点表中的id
        /// </summary>
        public int AdjId;

        /// <summary>
        /// 用于存储权值，对于非网图可以不需要
        /// </summary>
        public TEdge Weight;

        /// <summary>
        /// 链域，指向下一个边
        /// </summary>
        public Edge<TVertex, TEdge> Next;
    }
    #endregion
}
