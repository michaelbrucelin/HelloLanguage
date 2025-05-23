﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    /// <summary>
    /// 最短路径（Shortest Paths）
    /// </summary>
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
            TEdge[] weights = new TEdge[graph.VertexCnt]; Array.Fill(weights, graph.Infinity);
            int[] paths = new int[graph.VertexCnt]; Array.Fill(paths, -1);
            bool[] visited = new bool[graph.VertexCnt]; int visitcnt;
            PriorityQueue<(TEdge weight, int vid), TEdge> minpq = new PriorityQueue<(TEdge weight, int vid), TEdge>();

            weights[start] = TEdge.Zero; paths[start] = start; visited[start] = true; visitcnt = 1;
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

        public (TEdge[,] weights, int[,] paths) SP_Floyd<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            int vcnt = graph.VertexCnt;
            TEdge[,] weights = new TEdge[vcnt, vcnt]; int[,] paths = new int[vcnt, vcnt];
            for (int r = 0; r < vcnt; r++) for (int c = 0; c < vcnt; c++)
                {
                    weights[r, c] = r == c ? TEdge.Zero : graph[r, c];
                    paths[r, c] = graph[r, c] != graph.Infinity || r == c ? r : -1;
                }

            for (int k = 0; k < vcnt; k++) for (int r = 0; r < vcnt; r++)
                {
                    if (weights[r, k] == graph.Infinity) continue;
                    for (int c = 0; c < vcnt; c++)
                    {
                        if (weights[k, c] == graph.Infinity) continue;
                        if (weights[r, c] == graph.Infinity || weights[r, k] + weights[k, c] < weights[r, c])
                        {
                            weights[r, c] = weights[r, k] + weights[k, c]; paths[r, c] = paths[k, c];
                        }
                    }
                }

            return (weights, paths);
        }
    }
}
