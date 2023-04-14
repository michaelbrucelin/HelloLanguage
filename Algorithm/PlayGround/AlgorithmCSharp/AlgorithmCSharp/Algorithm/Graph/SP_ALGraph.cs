using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
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
            return (null, null);  // for test
            throw new NotImplementedException();
        }

        public (TEdge[] weights, int[] paths) SP_Floyd<TVertex, TEdge>(ALGraph<TVertex, TEdge> graph)
            where TEdge : INumber<TEdge>
        {
            return (null, null);  // for test
            throw new NotImplementedException();
        }
    }
}
