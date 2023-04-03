using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
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
            where TEdge : IComparable<TEdge>
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
        /// 
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<(int v1, int v2)> MST_Kruskal<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<(int v1, int v2)> result = new List<(int v1, int v2)>();

            return result;
        }
    }
}
