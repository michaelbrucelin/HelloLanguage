using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class Traverse_MGraph
    {
        #region DFS
        public List<TVertex> Traverse_DFS<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<TVertex> result = new List<TVertex>();
            bool[] visited = new bool[graph.VertexCnt];
            for (int i = 0; i < graph.VertexCnt; i++)
                if (!visited[i]) dfs(i, graph, visited, result);

            return result;
        }

        private void dfs<TVertex, TEdge>(int vexid, MGraph<TVertex, TEdge> graph, bool[] visited, List<TVertex> result)
            where TEdge : IComparable<TEdge>
        {
            result.Add(graph.Vexs[vexid]);
            visited[vexid] = true;
            for (int i = 0; i < graph.VertexCnt; i++)
                if (graph.Arc[vexid, i].CompareTo(graph.Infinity) != 0 && !visited[i])
                    dfs(i, graph, visited, result);
        }
        #endregion

        #region BFS
        public List<TVertex> Traverse_BFS<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<TVertex> result = new List<TVertex>();
            bool[] visited = new bool[graph.VertexCnt];
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                if (visited[i]) continue; queue.Enqueue(i);
                int cnt; while ((cnt = queue.Count) > 0)
                {
                    for (int j = 0, vexid; j < cnt; j++)
                    {
                        if (!visited[vexid = queue.Dequeue()])
                        {
                            result.Add(graph.Vexs[vexid]);
                            visited[vexid] = true;
                            for (int k = 0; k < graph.VertexCnt; k++)
                                if (graph.Arc[vexid, k].CompareTo(graph.Infinity) != 0 && !visited[k])
                                    queue.Enqueue(k);
                        }
                    }
                }
            }

            return result;
        }
        #endregion
    }
}
