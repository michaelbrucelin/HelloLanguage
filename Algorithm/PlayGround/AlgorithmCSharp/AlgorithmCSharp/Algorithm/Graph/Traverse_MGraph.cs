using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class Traverse_MGraph
    {
        public List<TVertex> Traverse_DFS<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<TVertex> result = new List<TVertex>();
            HashSet<int> visited = new HashSet<int>();
            for (int i = 0; i < graph.VertexCnt; i++) dfs(i, graph, visited, result);

            return result;
        }

        private void dfs<TVertex, TEdge>(int vexid, MGraph<TVertex, TEdge> graph, HashSet<int> visited, List<TVertex> result)
            where TEdge : IComparable<TEdge>
        {
            if (!visited.Contains(vexid))
            {
                result.Add(graph.Vexs[vexid]);
                visited.Add(vexid);
                for (int i = 0; i < graph.VertexCnt; i++)
                    if (graph.Arc[vexid, i].CompareTo(graph.Infinity) != 0 && !visited.Contains(i))
                        dfs(i, graph, visited, result);
            }
        }
    }
}
