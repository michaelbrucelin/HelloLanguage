using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    /// <summary>
    /// 最小生成树（Minimum Weight Spanning Tree, Minimum Cost Spanning Tree, Minimum Spanning Tree）
    /// </summary>
    public class MST_ALGraph
    {
        /// <summary>
        /// 这里借助了最小堆来实现，但是最小堆中会有冗余的数据，详情见MST_MGraph.MST_Prim()的描述
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <returns>(int v1, int v2)记录的是起点与终点的id</returns>
        public List<(int v1, int v2)> MST_Prim<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            List<(int v1, int v2)> result = new List<(int v1, int v2)>();
            bool[] visited = new bool[graph.VertexCnt]; int visitcnt = 0;
            PriorityQueue<(int v1, int v2), TEdge> minpq = new PriorityQueue<(int v1, int v2), TEdge>();

            Edge<TVertex, TEdge> ptr;
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true; visitcnt++; minpq.Clear();
                    ptr = graph[i].FirstEdge;
                    while (ptr != null)
                    {
                        if (!visited[ptr.AdjId]) minpq.Enqueue((i, ptr.AdjId), ptr.Weight);
                        ptr = ptr.Next;
                    }

                    while (visitcnt < graph.VertexCnt && minpq.Count > 0)
                    {
                        var edge = minpq.Dequeue();
                        if (!visited[edge.v2])
                        {
                            result.Add(edge); visited[edge.v2] = true; visitcnt++;
                            ptr = graph[edge.v2].FirstEdge;
                            while (ptr != null)
                            {
                                if (!visited[ptr.AdjId]) minpq.Enqueue((edge.v2, ptr.AdjId), ptr.Weight);
                                ptr = ptr.Next;
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 这里使用并查集来检查是否形成环
        /// 这里使用edgecnt来记录已经访问到的边，当edgecnt = VexCount - 1时，可以提前终止边的遍历，因为此时已经形成了生成树
        ///     注意，如果图不是连通图，永远edgecnt < VexCount - 1，但是如果edgecnt = VexCount - 1，则一定形成了生成树（前提是无环）
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<(int v1, int v2)> MST_Kruskal<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            List<(int v1, int v2)> result = new List<(int v1, int v2)>();
            int[] disjoint = new int[graph.VertexCnt]; for (int i = 0; i < disjoint.Length; i++) disjoint[i] = i;
            int edgecnt = 0;
            IComparer<(TEdge, int, int)> comparer = Comparer<(TEdge, int, int)>.Create((t1, t2) =>
            {
                if (t1.Item1 - t2.Item1 > TEdge.Zero) return 1; else if (t1.Item1 - t2.Item1 < TEdge.Zero) return -1;
                if (t1.Item2 - t2.Item2 != 0) return t1.Item2 - t2.Item2;
                return t1.Item3 - t2.Item3;
            });
            PriorityQueue<(int v1, int v2), (TEdge, int v1, int v2)> minpq = new PriorityQueue<(int v1, int v2), (TEdge, int v1, int v2)>(comparer);
            Edge<TVertex, TEdge> ptr; for (int i = 0; i < graph.VertexCnt; i++)
            {
                ptr = graph[i].FirstEdge; while (ptr != null)
                {
                    minpq.Enqueue((i, ptr.AdjId), (ptr.Weight, i, ptr.AdjId));
                    ptr = ptr.Next;
                }
            }

            while (edgecnt < graph.VertexCnt - 1 && minpq.Count > 0)
            {
                var edge = minpq.Dequeue();
                if (!IsCycle(disjoint, edge.v1, edge.v2))
                {
                    result.Add(edge); edgecnt++;
                }
            }

            return result;
        }

        /// <summary>
        /// 检查两个顶点连接后是否会形成环，并查集操作
        /// </summary>
        /// <param name="disjoint"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private bool IsCycle(int[] disjoint, int v1, int v2)
        {
            int _v1 = v1, _v2 = v2;
            while (disjoint[_v1] != _v1) _v1 = disjoint[_v1];
            while (disjoint[_v2] != _v2) _v2 = disjoint[_v2];

            bool result = _v1 == _v2;
            if (!result)
            {
                int v = Math.Min(_v1, _v2);
                disjoint[_v1] = disjoint[_v2] = disjoint[v1] = disjoint[v2] = v;
            }

            return result;
        }
    }
}
