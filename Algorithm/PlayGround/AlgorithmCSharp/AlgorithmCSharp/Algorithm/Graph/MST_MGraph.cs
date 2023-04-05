using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class MST_MGraph
    {
        /// <summary>
        /// 这里借助了最小堆来实现，但是最小堆中会有冗余的数据，
        ///     例如，有一条顶点1到顶点9的边，还有一条顶点9到顶点1的边，其实二者留其一（小的）即可
        ///     还有，如果堆顶就是到顶点9的边，这是堆顶出队列，原则上另一条到顶点9的边就没用了，但是没有一起出队列
        /// 以上两点导致最小堆中有冗余的数据，这样会增加最小堆入队与出队的时间复杂度
        /// 如果可以有一种数据结构，有3个维度：<key, value, priority>就好了
        ///     key是字典的key，这里记录目标顶点
        ///     value是字典的值，这里记录起始顶点，或者边都可以
        ///     priority是排序依据，这样字典就相当于堆了
        /// 没有找到这样的数据结构
        /// 
        /// 这里使用visitcnt记录已经访问到的顶点，当全部顶点都已经访问到，可以提前终止BFS
        ///     注意，只有BFS才可以这样判断，其他算法（例如Kruskal），即使访问到了全部的顶点，也不代表已经形成了树
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <returns>(int v1, int v2)记录的是起点与终点的id</returns>
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
                        if (!visited[j] && graph[i, j].CompareTo(graph.Infinity) != 0)
                            minpq.Enqueue((i, j), graph[i, j]);

                    while (visitcnt < graph.VertexCnt && minpq.Count > 0)
                    {
                        var edge = minpq.Dequeue();
                        if (!visited[edge.v2])
                        {
                            result.Add(edge); visited[edge.v2] = true; visitcnt++;
                            for (int k = 0; k < graph.VertexCnt; k++)
                                if (!visited[k] && graph[edge.v2, k].CompareTo(graph.Infinity) != 0)
                                    minpq.Enqueue((edge.v2, k), graph[edge.v2, k]);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 这里使用并查集来检查是否形成环
        /// 这里使用edgecnt来记录已经访问到的边，当edgecnt = VexCount - 1时，可以提前终止边的遍历，因为此时已经形成了生成树
        ///     注意，如果图不是连通图，永远edgecnt < VexCount - 1，但是如果edgecnt = VexCount - 1，则一定形成了生成树（前提是无环）
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<(int v1, int v2)> MST_Kruskal<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<(int v1, int v2)> result = new List<(int v1, int v2)>();
            int[] disjoint = new int[graph.VertexCnt]; for (int i = 0; i < disjoint.Length; i++) disjoint[i] = i;
            int edgecnt = 0;
            IComparer<(TEdge, int, int)> comparer = Comparer<(TEdge, int, int)>.Create((t1, t2) =>
            {
                int priority;
                priority = t1.Item1.CompareTo(t2.Item1); if (priority != 0) return priority;
                priority = t1.Item2 - t2.Item2; if (priority != 0) return priority;
                return t1.Item3 - t2.Item3;
            });
            PriorityQueue<(int v1, int v2), (TEdge, int v1, int v2)> minpq = new PriorityQueue<(int v1, int v2), (TEdge, int v1, int v2)>(comparer);
            for (int i = 0; i < graph.VertexCnt; i++) for (int j = 0; j < graph.VertexCnt; j++)
                {
                    if (graph[i, j].CompareTo(graph.Infinity) != 0) minpq.Enqueue((i, j), (graph[i, j], i, j));
                }

            while (edgecnt < graph.VertexCnt - 1 && minpq.Count > 0)
            {
                var edge = minpq.Dequeue();
                if (!IsCycle(disjoint, edge.v1, edge.v2))
                {
                    result.Add(edge); edgecnt++;
                }
            }

            return result;
        }

        /// <summary>
        /// 检查两个顶点连接后是否会形成环，并查集操作
        /// </summary>
        /// <param name="disjoint"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private bool IsCycle(int[] disjoint, int v1, int v2)
        {
            int _v1 = v1, _v2 = v2;
            while (disjoint[_v1] != _v1) _v1 = disjoint[_v1];
            while (disjoint[_v2] != _v2) _v2 = disjoint[_v2];

            bool result = _v1 == _v2;
            if (!result)
            {
                int v = Math.Min(_v1, _v2);
                disjoint[_v1] = disjoint[_v2] = disjoint[v1] = disjoint[v2] = v;
            }

            return result;
        }
    }
}
