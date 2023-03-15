using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Graph
{
    public class Test
    {
        #region 手动生成测试用的二叉树
        public MGraph<int, int> GetMGraph()
        {
            MGraph<int, int> graph = new MGraph<int, int>(9, -1, false);
            for (int i = 0; i < 9; i++) graph.Vexs[i] = i;
            int[,] _arc = new int[9, 9] {{ -1, 10, -1, -1, -1, 11, -1, -1, -1 },
                                         { 10, -1, 18, -1, -1, -1, 16, -1, 12 },
                                         { -1, 18, -1, 22, -1, -1, -1, -1, -1 },
                                         { -1, -1, 22, -1, 20, -1, 24, 16, 21 },
                                         { -1, -1, -1, 20, -1, 26, -1,  7, -1 },
                                         { 11, -1, -1, -1, 26, -1, 17, -1, -1 },
                                         { -1, 16, -1, 24, -1, 17, -1, 19, -1 },
                                         { -1, -1, -1, 16,  7, -1, 19, -1, -1 },
                                         { -1, 12, -1, 21, -1, -1, -1, -1, -1 }};
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
            throw new NotImplementedException();
        }

        public ALGraph<int, int> GetALGraph2()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
