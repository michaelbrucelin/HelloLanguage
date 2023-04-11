using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class Traverse_ALGraph
    {
        #region DFS
        public List<TVertex> Traverse_DFS<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            List<TVertex> result = new List<TVertex>();
            bool[] visited = new bool[graph.VertexCnt];
            for (int i = 0; i < graph.VertexCnt; i++)
                if (!visited[i]) dfs(i, graph, visited, result);

            return result;
        }

        private void dfs<TVertex, TEdge>(int vexid, ALGraph<TVertex, TEdge> graph, bool[] visited, List<TVertex> result)
            where TEdge : INumber<TEdge>
        {
            result.Add(graph[vexid].Data);
            visited[vexid] = true;
            Edge<TVertex, TEdge> edge = graph[vexid].FirstEdge;
            while (edge != null)
            {
                if (!visited[edge.AdjId]) dfs(edge.AdjId, graph, visited, result);
                edge = edge.Next;
            }
        }
        #endregion

        #region BFS
        /// <summary>
        /// 树的遍历中经常这样BFS，这样BFS可以明确当前是第几层
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<TVertex> Traverse_BFS<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            List<TVertex> result = new List<TVertex>();
            bool[] visited = new bool[graph.VertexCnt];
            Queue<int> queue = new Queue<int>(); Edge<TVertex, TEdge> ptr;
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                if (visited[i]) continue;
                result.Add(graph[i].Data); visited[i] = true; queue.Enqueue(i);
                int cnt; while ((cnt = queue.Count) > 0)
                {
                    for (int j = 0, vexid; j < cnt; j++)
                    {
                        ptr = graph[queue.Dequeue()].FirstEdge;
                        while (ptr != null)
                        {
                            if (!visited[vexid = ptr.AdjId])
                            {
                                result.Add(graph[vexid].Data); visited[vexid] = true; queue.Enqueue(vexid);
                            }
                            ptr = ptr.Next;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 图中顶点没有明确的第几层的概念，所以也可以这样BFS，理论上这样BFS还能稍快一点
        /// 但是如果明确需要知道第几层（最短几步），这样BFS就不可以了
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<TVertex> Traverse_BFS2<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            List<TVertex> result = new List<TVertex>();
            bool[] visited = new bool[graph.VertexCnt];
            Queue<int> queue = new Queue<int>(); Edge<TVertex, TEdge> ptr;
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                if (visited[i]) continue;
                result.Add(graph[i].Data); visited[i] = true; queue.Enqueue(i);
                int vexid; while (queue.Count > 0)
                {
                    ptr = graph[queue.Dequeue()].FirstEdge;
                    while (ptr != null)
                    {
                        if (!visited[vexid = ptr.AdjId])
                        {
                            result.Add(graph[vexid].Data); visited[vexid] = true; queue.Enqueue(vexid);
                        }
                        ptr = ptr.Next;
                    }
                }
            }

            return result;
        }
        #endregion
    }
}
