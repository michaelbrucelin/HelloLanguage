﻿using AlgorithmCSharp.Algorithm.Tree.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class Test
    {
        #region 一些基本测试
        public void ShowInfo()
        {
            MGraph<int, int> mgraph;
            mgraph = GetMGraph();
            Console.WriteLine($"mgraph01的顶点数：{mgraph.VertexCnt}，边数：{mgraph.EdgeCnt}");
            mgraph = GetMGraph2();
            Console.WriteLine($"mgraph02的顶点数：{mgraph.VertexCnt}，边数：{mgraph.EdgeCnt}");

            ALGraph<int, int> algraph;
            algraph = GetALGraph();
            Console.WriteLine($"algraph01的顶点数：{algraph.VertexCnt}，边数：{algraph.EdgeCnt}");
            algraph = GetALGraph2();
            Console.WriteLine($"algraph02的顶点数：{algraph.VertexCnt}，边数：{algraph.EdgeCnt}");
        }
        #endregion

        #region 测试图的遍历
        public void TestTraverse_MGraph()
        {
            Traverse_MGraph traverse = new Traverse_MGraph();
            MGraph<int, int> graph;
            List<int> list; string result, answer;
            int id = 0;

            #region DFS
            Console.WriteLine("DFS");
            graph = GetMGraph(); answer = "012345678";
            list = traverse.Traverse_DFS(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            graph = GetMGraph2(); answer = "012436758";
            list = traverse.Traverse_DFS(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            #endregion

            #region BFS
            Console.WriteLine("BFS");
            graph = GetMGraph(); answer = "015268437";
            list = traverse.Traverse_BFS(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            graph = GetMGraph2(); answer = "012345678";
            list = traverse.Traverse_BFS(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            #endregion

            #region BFS2
            Console.WriteLine("BFS2");
            graph = GetMGraph(); answer = "015268437";
            list = traverse.Traverse_BFS2(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            graph = GetMGraph2(); answer = "012345678";
            list = traverse.Traverse_BFS2(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            #endregion
        }

        public void TestTraverse_ALGraph()
        {
            Traverse_ALGraph traverse = new Traverse_ALGraph();
            ALGraph<int, int> graph;
            List<int> list; string result, answer;
            int id = 0;

            #region DFS
            Console.WriteLine("DFS");
            graph = GetALGraph(); answer = "012345678";
            list = traverse.Traverse_DFS(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            graph = GetALGraph2(); answer = "012436758";
            list = traverse.Traverse_DFS(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            #endregion

            #region BFS
            Console.WriteLine("BFS");
            graph = GetALGraph(); answer = "015268437";
            list = traverse.Traverse_BFS(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            graph = GetALGraph2(); answer = "012345678";
            list = traverse.Traverse_BFS(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            #endregion

            #region BFS2
            Console.WriteLine("BFS2");
            graph = GetALGraph(); answer = "015268437";
            list = traverse.Traverse_BFS2(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            graph = GetALGraph2(); answer = "012345678";
            list = traverse.Traverse_BFS2(graph); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            #endregion
        }
        #endregion

        #region 手动生成测试用的二叉树
        public MGraph<int, int> GetMGraph()
        {
            MGraph<int, int> graph = new MGraph<int, int>(9, -1, false);
            for (int i = 0; i < 9; i++) graph.Vexs[i] = i;
            int[,] _arc = new int[9, 9] {{ -1, 10, -1, -1, -1, 11, -1, -1, -1 },
                                         { 10, -1, 18, -1, -1, -1, 16, -1, 12 },
                                         { -1, 18, -1, 22, -1, -1, -1, -1,  8 },
                                         { -1, -1, 22, -1, 20, -1, 24, 16, 21 },
                                         { -1, -1, -1, 20, -1, 26, -1,  7, -1 },
                                         { 11, -1, -1, -1, 26, -1, 17, -1, -1 },
                                         { -1, 16, -1, 24, -1, 17, -1, 19, -1 },
                                         { -1, -1, -1, 16,  7, -1, 19, -1, -1 },
                                         { -1, 12,  8, 21, -1, -1, -1, -1, -1 }};
            for (int r = 0; r < 9; r++) for (int c = 0; c < 9; c++) graph.Arc[r, c] = _arc[r, c];

            return graph;
        }

        public MGraph<int, int> GetMGraph2()
        {
            MGraph<int, int> graph = new MGraph<int, int>(9, -1, false);
            for (int i = 0; i < 9; i++) graph.Vexs[i] = i;
            int[,] _arc = new int[9, 9] {{ -1,  1,  5, -1, -1, -1, -1, -1, -1 },
                                         {  1, -1,  3,  7,  5, -1, -1, -1, -1 },
                                         {  5,  3, -1, -1,  1,  7, -1, -1, -1 },
                                         { -1,  7, -1, -1,  2, -1,  3, -1, -1 },
                                         { -1,  5,  1,  2, -1,  3,  6,  9, -1 },
                                         { -1, -1,  7, -1,  3, -1, -1,  5, -1 },
                                         { -1, -1, -1,  3,  6, -1, -1,  2,  7 },
                                         { -1, -1, -1, -1,  9,  5,  2, -1,  4 },
                                         { -1, -1, -1, -1, -1, -1,  7,  4, -1 }};
            for (int r = 0; r < 9; r++) for (int c = 0; c < 9; c++) graph.Arc[r, c] = _arc[r, c];

            return graph;
        }

        public ALGraph<int, int> GetALGraph()
        {
            ALGraph<int, int> graph = new ALGraph<int, int>(9, false);
            for (int i = 0; i < 9; i++) graph.AdjList.Add(new Vertex<int, int>(i));
            graph.AdjList[0].FirstEdge = new Edge<int, int>(1, 10) { Next = new Edge<int, int>(5, 11) };
            graph.AdjList[1].FirstEdge = new Edge<int, int>(0, 10) { Next = new Edge<int, int>(2, 18) { Next = new Edge<int, int>(6, 16) { Next = new Edge<int, int>(8, 12) } } };
            graph.AdjList[2].FirstEdge = new Edge<int, int>(1, 18) { Next = new Edge<int, int>(3, 22) { Next = new Edge<int, int>(8, 8) } };
            graph.AdjList[3].FirstEdge = new Edge<int, int>(2, 22) { Next = new Edge<int, int>(4, 20) { Next = new Edge<int, int>(6, 24) { Next = new Edge<int, int>(7, 16) { Next = new Edge<int, int>(8, 21) } } } };
            graph.AdjList[4].FirstEdge = new Edge<int, int>(3, 20) { Next = new Edge<int, int>(5, 26) { Next = new Edge<int, int>(7, 7) } };
            graph.AdjList[5].FirstEdge = new Edge<int, int>(0, 11) { Next = new Edge<int, int>(4, 26) { Next = new Edge<int, int>(6, 17) } };
            graph.AdjList[6].FirstEdge = new Edge<int, int>(1, 16) { Next = new Edge<int, int>(3, 24) { Next = new Edge<int, int>(5, 17) { Next = new Edge<int, int>(7, 19) } } };
            graph.AdjList[7].FirstEdge = new Edge<int, int>(3, 16) { Next = new Edge<int, int>(4, 7) { Next = new Edge<int, int>(6, 19) } };
            graph.AdjList[8].FirstEdge = new Edge<int, int>(1, 12) { Next = new Edge<int, int>(2, 8) { Next = new Edge<int, int>(3, 21) } };

            return graph;
        }

        public ALGraph<int, int> GetALGraph2()
        {
            ALGraph<int, int> graph = new ALGraph<int, int>(9, false);
            for (int i = 0; i < 9; i++) graph.AdjList.Add(new Vertex<int, int>(i));
            graph.AdjList[0].FirstEdge = new Edge<int, int>(1, 1) { Next = new Edge<int, int>(2, 5) };
            graph.AdjList[1].FirstEdge = new Edge<int, int>(0, 1) { Next = new Edge<int, int>(2, 3) { Next = new Edge<int, int>(3, 7) { Next = new Edge<int, int>(4, 5) } } };
            graph.AdjList[2].FirstEdge = new Edge<int, int>(0, 5) { Next = new Edge<int, int>(1, 3) { Next = new Edge<int, int>(4, 1) { Next = new Edge<int, int>(5, 7) } } };
            graph.AdjList[3].FirstEdge = new Edge<int, int>(1, 7) { Next = new Edge<int, int>(4, 2) { Next = new Edge<int, int>(6, 3) } };
            graph.AdjList[4].FirstEdge = new Edge<int, int>(1, 5) { Next = new Edge<int, int>(2, 1) { Next = new Edge<int, int>(3, 2) { Next = new Edge<int, int>(5, 3) { Next = new Edge<int, int>(6, 6) { Next = new Edge<int, int>(7, 9) } } } } };
            graph.AdjList[5].FirstEdge = new Edge<int, int>(2, 7) { Next = new Edge<int, int>(4, 3) { Next = new Edge<int, int>(7, 5) } };
            graph.AdjList[6].FirstEdge = new Edge<int, int>(3, 3) { Next = new Edge<int, int>(4, 6) { Next = new Edge<int, int>(7, 2) { Next = new Edge<int, int>(8, 7) } } };
            graph.AdjList[7].FirstEdge = new Edge<int, int>(4, 9) { Next = new Edge<int, int>(5, 5) { Next = new Edge<int, int>(6, 2) { Next = new Edge<int, int>(8, 4) } } };
            graph.AdjList[8].FirstEdge = new Edge<int, int>(6, 7) { Next = new Edge<int, int>(7, 4) };

            return graph;
        }
        #endregion
    }
}