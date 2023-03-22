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
        /// <summary>
        /// 树的遍历中经常这样BFS，这样BFS可以明确当前是第几层
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<TVertex> Traverse_BFS<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<TVertex> result = new List<TVertex>();
            bool[] visited = new bool[graph.VertexCnt];
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                if (visited[i]) continue;
                result.Add(graph.Vexs[i]); visited[i] = true; queue.Enqueue(i);
                int cnt; while ((cnt = queue.Count) > 0)
                {
                    for (int j = 0, vexid; j < cnt; j++)
                    {
                        vexid = queue.Dequeue();
                        for (int k = 0; k < graph.VertexCnt; k++)
                            if (graph.Arc[vexid, k].CompareTo(graph.Infinity) != 0 && !visited[k])
                            {
                                result.Add(graph.Vexs[k]); visited[k] = true; queue.Enqueue(k);
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
        public List<TVertex> Traverse_BFS2<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<TVertex> result = new List<TVertex>();
            bool[] visited = new bool[graph.VertexCnt];
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < graph.VertexCnt; i++)
            {
                if (visited[i]) continue;
                result.Add(graph.Vexs[i]); visited[i] = true; queue.Enqueue(i);
                int vexid; while (queue.Count > 0)
                {
                    vexid = queue.Dequeue();
                    for (int k = 0; k < graph.VertexCnt; k++)
                        if (graph.Arc[vexid, k].CompareTo(graph.Infinity) != 0 && !visited[k])
                        {
                            result.Add(graph.Vexs[k]); visited[k] = true; queue.Enqueue(k);
                        }
                }
            }

            return result;
        }
        #endregion
    }
}
