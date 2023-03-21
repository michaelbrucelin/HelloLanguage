using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class Traverse_ALGraph
    {
        public List<TVertex> Traverse_DFS<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<TVertex> result = new List<TVertex>();
            bool[] visited = new bool[graph.VertexCnt];
            for (int i = 0; i < graph.VertexCnt; i++)
                if (!visited[i]) dfs(i, graph, visited, result);

            return result;
        }

        private void dfs<TVertex, TEdge>(int vexid, ALGraph<TVertex, TEdge> graph, bool[] visited, List<TVertex> result)
            where TEdge : IComparable<TEdge>
        {
            result.Add(graph.AdjList[vexid].Data);
            visited[vexid] = true;
            Edge<TVertex, TEdge> edge = graph.AdjList[vexid].FirstEdge;
            while (edge != null)
            {
                if (!visited[edge.AdjId]) dfs(edge.AdjId, graph, visited, result);
                edge = edge.Next;
            }
        }
    }
}
