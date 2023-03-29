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
        /// 
        /// </summary>
        /// <typeparam name="TVertex"></typeparam>
        /// <typeparam name="TEdge"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public List<(int v1, int v2)> MST_Kruskal<TVertex, TEdge>(MGraph<TVertex, TEdge> graph)
            where TEdge : IComparable<TEdge>
        {
            List<(int v1, int v2)> result = new List<(int v1, int v2)>();

            return result;
        }
    }
}
