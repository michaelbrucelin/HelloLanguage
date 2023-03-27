using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class MST_MGraph
    {
        public List<(int v1, int v2)> MST_Prim<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<(int v1, int v2)> result = new List<(int v1, int v2)>();
            bool[] visited = new bool[graph.VertexCnt]; int visitcnt = 0;
            PriorityQueue<(int v1, int v2), TEdge> minpq = new PriorityQueue<(int v1, int v2), TEdge>();

            for (int i = 0; i < graph.VertexCnt; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true; visitcnt++; minpq.Clear();
                    for (int j = 0; j < graph.VertexCnt; j++)
                        if (!visited[j] && graph.Arc[i, j].CompareTo(graph.Infinity) != 0)
                            minpq.Enqueue((i, j), graph.Arc[i, j]);

                    while (visitcnt < graph.VertexCnt && minpq.Count > 0)
                    {
                        var edge = minpq.Dequeue();
                        if (!visited[edge.v2])
                        {
                            result.Add(edge); visited[edge.v2] = true; visitcnt++;
                            for (int k = 0; k < graph.VertexCnt; k++)
                                if (!visited[k] && graph.Arc[edge.v2, k].CompareTo(graph.Infinity) != 0)
                                    minpq.Enqueue((edge.v2, k), graph.Arc[edge.v2, k]);
                        }
                    }
                }
            }

            return result;
        }
    }
}
