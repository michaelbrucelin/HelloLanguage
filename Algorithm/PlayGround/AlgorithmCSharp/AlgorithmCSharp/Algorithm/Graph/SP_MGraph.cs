using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class SP_MGraph
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns>TEdge[] weights: 每个顶点的最短路径总权重, int[] paths: 每个顶点的最短路径的前一个顶点的id</returns>
        public (TEdge[] weights, int[] paths) SP_Dijkstra<TVertex, TEdge>(MGraph<TVertex, TEdge> graph, int start)
            where TEdge : INumber<TEdge>
        {
            TEdge[] weights = new TEdge[graph.VertexCnt]; Array.Fill(weights, graph.Infinity); weights[start] = TEdge.Zero;
            int[] paths = new int[graph.VertexCnt]; Array.Fill(paths, -1); paths[start] = start;
            bool[] visited = new bool[graph.VertexCnt]; visited[start] = true; int visitcnt = 1;
            PriorityQueue<(TEdge weight, int vid), TEdge> minpq = new PriorityQueue<(TEdge weight, int vid), TEdge>();
            int ptr = start;  // 最新找到最短路径的顶点
            while (visitcnt < graph.VertexCnt)
            {
                for (int i = 0; i < graph.VertexCnt; i++)
                {
                    if (!visited[i] && graph[ptr, i] != graph.Infinity)
                    {
                        TEdge _weight = weights[ptr] + graph[ptr, i];
                        if (weights[i] == graph.Infinity || _weight < weights[i])
                        {
                            weights[i] = _weight; paths[i] = ptr; minpq.Enqueue((_weight, i), _weight);
                        }
                    }
                }
                while (minpq.Count > 0 && visited[minpq.Peek().vid]) minpq.Dequeue();
                if (minpq.Count == 0) break;
                var next = minpq.Dequeue();
                visited[next.vid] = true; visitcnt++;
                ptr = next.vid;
            }

            return (weights, paths);
        }

        public (TEdge[] weights, int[] paths) SP_Floyd<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            return (null, null);  // for test
            throw new NotImplementedException();
        }
    }
}
