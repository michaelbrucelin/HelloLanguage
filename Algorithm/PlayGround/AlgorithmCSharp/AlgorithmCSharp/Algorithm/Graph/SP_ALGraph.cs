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

        public (TEdge[,] weights, int[,] paths) SP_Floyd<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            int vcnt = graph.VertexCnt;
            TEdge[,] weights = new TEdge[vcnt, vcnt]; int[,] paths = new int[vcnt, vcnt];
            for (int r = 0; r < vcnt; r++) for (int c = 0; c < vcnt; c++)
                {
                    weights[r, c] = r == c ? TEdge.Zero : graph.Infinity;
                    paths[r, c] = r == c ? r : -1;
                }
            for (int i = 0; i < vcnt; i++)
            {
                Edge<TVertex, TEdge> edge = graph[i].FirstEdge;
                while (edge != null)
                {
                    weights[i, edge.AdjId] = edge.Weight; paths[i, edge.AdjId] = i;
                    edge = edge.Next;
                }
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
