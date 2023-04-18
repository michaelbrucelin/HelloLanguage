using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class SP_ALGraph
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns>TEdge[] weights: 每个顶点的最短路径总权重, int[] paths: 每个顶点的最短路径的前一个顶点的id</returns>
        public (TEdge[] weights, int[] paths) SP_Dijkstra<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph, int start)
            where TEdge : INumber<TEdge>
        {
            TEdge[] weights = new TEdge[graph.VertexCnt]; Array.Fill(weights, graph.Infinity);
            int[] paths = new int[graph.VertexCnt]; Array.Fill(paths, -1);
            bool[] visited = new bool[graph.VertexCnt]; int visitcnt = 0;
            PriorityQueue<(TEdge weight, int vid), TEdge> minpq = new PriorityQueue<(TEdge weight, int vid), TEdge>();

            weights[start] = TEdge.Zero; paths[start] = start; minpq.Enqueue((TEdge.Zero, start), TEdge.Zero);
            while (visitcnt < graph.VertexCnt && minpq.Count > 0)
            {
                while (minpq.Count > 0 && visited[minpq.Peek().vid]) minpq.Dequeue();
                if (minpq.Count == 0) break;
                var next = minpq.Dequeue();
                visited[next.vid] = true; visitcnt++; if (visitcnt == graph.VertexCnt) break;
                Edge<TVertex, TEdge> edge = graph[next.vid].FirstEdge;
                while (edge != null)
                {
                    if (!visited[edge.AdjId])
                    {
                        TEdge _weight = weights[next.vid] + edge.Weight;
                        if (weights[edge.AdjId] == graph.Infinity || _weight < weights[edge.AdjId])
                        {
                            weights[edge.AdjId] = _weight; paths[edge.AdjId] = next.vid; minpq.Enqueue((_weight, edge.AdjId), _weight);
                        }
                    }
                    edge = edge.Next;
                }
            }

            return (weights, paths);
        }

        public (TEdge[] weights, int[] paths) SP_Floyd<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            return (null, null);  // for test
            throw new NotImplementedException();
        }
    }
}
