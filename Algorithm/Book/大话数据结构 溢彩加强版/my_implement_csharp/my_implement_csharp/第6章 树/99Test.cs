using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _99Test
    {
        #region 测试二叉树的输出
        public void TestPrint()
        {
            TreeNode tree;
            tree = GetTree(); PrintTree(tree);
            tree = GetTree2(); PrintTree(tree);
        }
        #endregion

        #region 测试二叉树的遍历
        public void TestTraverse_1_1()
        {
            _02遍历二叉树 traverser = new _02遍历二叉树();
            TreeNode tree = GetTree();
            int id = 0;

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 前序遍历：ABDGHCEIF");
            traverser.PreOrderTraverse(tree);

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 中序遍历：GDHBAEICF");
            traverser.InOrderTraverse(tree);

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 后序遍历：GHDBIEFCA");
            traverser.PostOrderTraverse(tree);

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 层序遍历：ABCDEFGHI");
            traverser.LevelOrderTraverse(tree);
        }

        public void TestTraverse_1_2()
        {
            _02遍历二叉树 traverser = new _02遍历二叉树();
            TreeNode tree = GetTree2();
            int id = 0;

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 前序遍历：ABDHKECFIGJ");
            traverser.PreOrderTraverse(tree);

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 中序遍历：HKDBEAIFCGJ");
            traverser.InOrderTraverse(tree);

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 后序遍历：KHDEBIFJGCA");
            traverser.PostOrderTraverse(tree);

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 层序遍历：ABCDEFGHIJK");
            traverser.LevelOrderTraverse(tree);
        }

        public void TestTraverse_2_1()
        {
            _02遍历二叉树2 traverser = new _02遍历二叉树2();
            TreeNode tree = GetTree();
            string result, answer;
            int id = 0;

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 前序遍历："); answer = "ABDGHCEIF";
            result = traverser.PreOrderTraverse(tree);
            Console.WriteLine($"{result == answer}, result: {result}, answer: {answer}");

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 中序遍历："); answer = "GDHBAEICF";
            result = traverser.InOrderTraverse(tree);
            Console.WriteLine($"{result == answer}, result: {result}, answer: {answer}");

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 后序遍历："); answer = "GHDBIEFCA";
            result = traverser.PostOrderTraverse(tree);
            Console.WriteLine($"{result == answer}, result: {result}, answer: {answer}");

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 层序遍历："); answer = "ABCDEFGHI";
            result = traverser.LevelOrderTraverse(tree);
            Console.WriteLine($"{result == answer}, result: {result}, answer: {answer}");
        }

        public void TestTraverse_2_2()
        {
            _02遍历二叉树2 traverser = new _02遍历二叉树2();
            TreeNode tree = GetTree2();
            string result, answer;
            int id = 0;

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 前序遍历："); answer = "ABDHKECFIGJ";
            result = traverser.PreOrderTraverse(tree);
            Console.WriteLine($"{result == answer}, result: {result}, answer: {answer}");

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 中序遍历："); answer = "HKDBEAIFCGJ";
            result = traverser.InOrderTraverse(tree);
            Console.WriteLine($"{result == answer}, result: {result}, answer: {answer}");

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 后序遍历："); answer = "KHDEBIFJGCA";
            result = traverser.PostOrderTraverse(tree);
            Console.WriteLine($"{result == answer}, result: {result}, answer: {answer}");

            Console.WriteLine($"{Environment.NewLine}{++id,2}. 层序遍历："); answer = "ABCDEFGHIJK";
            result = traverser.LevelOrderTraverse(tree);
            Console.WriteLine($"{result == answer}, result: {result}, answer: {answer}");
        }
        #endregion

        #region 测试二叉树的创建
        public void TestPreOrderBuilder()
        {
            _03创建二叉树 builder = new _03创建二叉树();
            TreeNode tree = builder.PreOrderBuilder();

            Console.WriteLine("Print Tree:");
            PrintTree(tree);
        }

        public void TestPreOrderBuilder(string s)
        {
            _03创建二叉树2 builder = new _03创建二叉树2();
            TreeNode tree = builder.PreOrderBuilder(s);

            Console.WriteLine("Print Tree:");
            PrintTree(tree);
        }

        public void TestPostOrderBuilder()
        {
            _03创建二叉树 builder = new _03创建二叉树();
            TreeNode tree = builder.PostOrderBuilder();

            Console.WriteLine("Print Tree:");
            PrintTree(tree);
        }

        public void TestPostOrderBuilder(string s)
        {
            _03创建二叉树2 builder = new _03创建二叉树2();
            TreeNode tree = builder.PostOrderBuilder(s);

            Console.WriteLine("Print Tree:");
            PrintTree(tree);
        }

        public void TestLevelOrderBuilder()
        {
            _03创建二叉树 builder = new _03创建二叉树();
            TreeNode tree = builder.LevelOrderBuilder();

            Console.WriteLine("Print Tree:");
            PrintTree(tree);
        }

        public void TestLevelOrderBuilder(string s)
        {
            _03创建二叉树2 builder = new _03创建二叉树2();
            TreeNode tree = builder.LevelOrderBuilder(s);

            Console.WriteLine("Print Tree:");
            PrintTree(tree);
        }
        #endregion

        #region 手动生成测试用的二叉树
        /// <summary>
        /// 手动创建一个如下所示的二叉树，用于测试遍历结果
        ///       A
        ///      / \
        ///     B   C
        ///    /   / \
        ///   D   E   F
        ///  / \   \
        /// G   H   I
        /// 前序：ABDGHCEIF  ABDG##H###CE#I##F##
        /// 中序：GDHBAEICF  #G#D#H#B#A#E#I#C#F#
        /// 后续：GHDBIEFCA  ##G##HD#B###IE##FCA
        /// 层序：ABCDEFGHI  ABCD#EFGH#I########
        /// </summary>
        /// <returns></returns>
        public TreeNode GetTree()
        {
            return new TreeNode('A')
            {
                Left = new TreeNode('B')
                {
                    Left = new TreeNode('D')
                    {
                        Left = new TreeNode('G'),
                        Right = new TreeNode('H')
                    }
                },
                Right = new TreeNode('C')
                {
                    Left = new TreeNode('E')
                    {
                        Right = new TreeNode('I')
                    },
                    Right = new TreeNode('F')
                }
            };
        }

        /// <summary>
        /// 手动创建一个如下所示的二叉树，用于测试遍历结果
        ///         A
        ///       /   \
        ///     B       C
        ///    / \     / \
        ///   D   E   F   G
        ///  /       /     \
        /// H       I       J
        ///  \
        ///   K
        /// 前序：ABDHKECFIGJ  ABDH#K###E##CFI###G#J##
        /// 中序：HKDBEAIFCGJ  #H#K#D#B#E#A#I#F#C#G#J#
        /// 后续：KHDEBIFJGCA  ###KH#D##EB##I#F###JGCA
        /// 层序：ABCDEFGHIJK  ABCDEFGH###I##J#K######
        /// </summary>
        /// <returns></returns>
        public TreeNode GetTree2()
        {
            return new TreeNode('A')
            {
                Left = new TreeNode('B')
                {
                    Left = new TreeNode('D')
                    {
                        Left = new TreeNode('H')
                        {
                            Right = new TreeNode('K')
                        }
                    },
                    Right = new TreeNode('E')
                },
                Right = new TreeNode('C')
                {
                    Left = new TreeNode('F')
                    {
                        Left = new TreeNode('I')
                    },
                    Right = new TreeNode('G')
                    {
                        Right = new TreeNode('J')
                    }
                }
            };
        }
        #endregion

        #region 手动生成测试用的线索二叉树（未初始化线索）
        /// <summary>
        /// 手动创建一个如下所示的线索二叉树，用于测试初始化线索
        ///       A
        ///      / \
        ///     B   C
        ///    /   / \
        ///   D   E   F
        ///  / \   \
        /// G   H   I
        /// 前序：ABDGHCEIF  ABDG##H###CE#I##F##
        /// 中序：GDHBAEICF  #G#D#H#B#A#E#I#C#F#
        /// 后续：GHDBIEFCA  ##G##HD#B###IE##FCA
        /// 层序：ABCDEFGHI  ABCD#EFGH#I########
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetThreadTree_NoInit()
        {
            return new ThreadTreeNode('A')
            {
                Left = new ThreadTreeNode('B')
                {
                    Left = new ThreadTreeNode('D')
                    {
                        Left = new ThreadTreeNode('G'),
                        Right = new ThreadTreeNode('H')
                    }
                },
                Right = new ThreadTreeNode('C')
                {
                    Left = new ThreadTreeNode('E')
                    {
                        Right = new ThreadTreeNode('I')
                    },
                    Right = new ThreadTreeNode('F')
                }
            };
        }

        /// <summary>
        /// 手动创建一个如下所示的线索二叉树，用于测试初始化线索
        ///         A
        ///       /   \
        ///     B       C
        ///    / \     / \
        ///   D   E   F   G
        ///  /       /     \
        /// H       I       J
        ///  \
        ///   K
        /// 前序：ABDHKECFIGJ  ABDH#K###E##CFI###G#J##
        /// 中序：HKDBEAIFCGJ  #H#K#D#B#E#A#I#F#C#G#J#
        /// 后续：KHDEBIFJGCA  ###KH#D##EB##I#F###JGCA
        /// 层序：ABCDEFGHIJK  ABCDEFGH###I##J#K######
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetThreadTree2_NoInit()
        {
            return new ThreadTreeNode('A')
            {
                Left = new ThreadTreeNode('B')
                {
                    Left = new ThreadTreeNode('D')
                    {
                        Left = new ThreadTreeNode('H')
                        {
                            Right = new ThreadTreeNode('K')
                        }
                    },
                    Right = new ThreadTreeNode('E')
                },
                Right = new ThreadTreeNode('C')
                {
                    Left = new ThreadTreeNode('F')
                    {
                        Left = new ThreadTreeNode('I')
                    },
                    Right = new ThreadTreeNode('G')
                    {
                        Right = new ThreadTreeNode('J')
                    }
                }
            };
        }
        #endregion

        #region 手动生成测试用的前序线索二叉树（已初始化线索）
        /// <summary>
        /// 手动创建一个如下所示的前序线索二叉树，用于测试遍历结果
        ///       A
        ///      / \
        ///     B   C
        ///    /   / \
        ///   D   E   F
        ///  / \   \
        /// G   H   I
        /// 前序：ABDGHCEIF  ABDG##H###CE#I##F##
        /// 中序：GDHBAEICF  #G#D#H#B#A#E#I#C#F#
        /// 后续：GHDBIEFCA  ##G##HD#B###IE##FCA
        /// 层序：ABCDEFGHI  ABCD#EFGH#I########
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetPreOrderThreadTree()
        {
            ThreadTreeNode node_A = new ThreadTreeNode('A');
            ThreadTreeNode node_B = new ThreadTreeNode('B');
            ThreadTreeNode node_C = new ThreadTreeNode('C');
            ThreadTreeNode node_D = new ThreadTreeNode('D');
            ThreadTreeNode node_E = new ThreadTreeNode('E');
            ThreadTreeNode node_F = new ThreadTreeNode('F');
            ThreadTreeNode node_G = new ThreadTreeNode('G');
            ThreadTreeNode node_H = new ThreadTreeNode('H');
            ThreadTreeNode node_I = new ThreadTreeNode('I');

            node_A.LTag = 0; node_A.Left = node_B; node_A.RTag = 0; node_A.Right = node_C;
            node_B.LTag = 0; node_B.Left = node_D; node_B.RTag = 1; node_B.Right = node_D;
            node_C.LTag = 0; node_C.Left = node_E; node_C.RTag = 0; node_C.Right = node_F;
            node_D.LTag = 0; node_D.Left = node_G; node_D.RTag = 0; node_D.Right = node_H;
            node_E.LTag = 1; node_E.Left = node_C; node_E.RTag = 0; node_E.Right = node_I;
            node_F.LTag = 1; node_F.Left = node_I; node_F.RTag = 1; node_F.Right = null;
            node_G.LTag = 1; node_G.Left = node_D; node_G.RTag = 1; node_G.Right = node_H;
            node_H.LTag = 1; node_H.Left = node_G; node_H.RTag = 1; node_H.Right = node_C;
            node_I.LTag = 1; node_I.Left = node_E; node_I.RTag = 1; node_I.Right = node_F;

            return node_A;
        }

        /// <summary>
        /// 手动创建一个如下所示的前序线索二叉树，用于测试遍历结果
        ///         A
        ///       /   \
        ///     B       C
        ///    / \     / \
        ///   D   E   F   G
        ///  /       /     \
        /// H       I       J
        ///  \
        ///   K
        /// 前序：ABDHKECFIGJ  ABDH#K###E##CFI###G#J##
        /// 中序：HKDBEAIFCGJ  #H#K#D#B#E#A#I#F#C#G#J#
        /// 后续：KHDEBIFJGCA  ###KH#D##EB##I#F###JGCA
        /// 层序：ABCDEFGHIJK  ABCDEFGH###I##J#K######
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetPreOrderThreadTree2()
        {
            ThreadTreeNode node_A = new ThreadTreeNode('A');
            ThreadTreeNode node_B = new ThreadTreeNode('B');
            ThreadTreeNode node_C = new ThreadTreeNode('C');
            ThreadTreeNode node_D = new ThreadTreeNode('D');
            ThreadTreeNode node_E = new ThreadTreeNode('E');
            ThreadTreeNode node_F = new ThreadTreeNode('F');
            ThreadTreeNode node_G = new ThreadTreeNode('G');
            ThreadTreeNode node_H = new ThreadTreeNode('H');
            ThreadTreeNode node_I = new ThreadTreeNode('I');
            ThreadTreeNode node_J = new ThreadTreeNode('J');
            ThreadTreeNode node_K = new ThreadTreeNode('K');

            return node_A;
        }
        #endregion

        #region 手动生成测试用的中序线索二叉树（已初始化线索）
        /// <summary>
        /// 手动创建一个如下所示的中序线索二叉树，用于测试遍历结果
        ///       A
        ///      / \
        ///     B   C
        ///    /   / \
        ///   D   E   F
        ///  / \   \
        /// G   H   I
        /// 前序：ABDGHCEIF  ABDG##H###CE#I##F##
        /// 中序：GDHBAEICF  #G#D#H#B#A#E#I#C#F#
        /// 后续：GHDBIEFCA  ##G##HD#B###IE##FCA
        /// 层序：ABCDEFGHI  ABCD#EFGH#I########
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetInOrderThreadTree()
        {
            ThreadTreeNode node_A = new ThreadTreeNode('A');
            ThreadTreeNode node_B = new ThreadTreeNode('B');
            ThreadTreeNode node_C = new ThreadTreeNode('C');
            ThreadTreeNode node_D = new ThreadTreeNode('D');
            ThreadTreeNode node_E = new ThreadTreeNode('E');
            ThreadTreeNode node_F = new ThreadTreeNode('F');
            ThreadTreeNode node_G = new ThreadTreeNode('G');
            ThreadTreeNode node_H = new ThreadTreeNode('H');
            ThreadTreeNode node_I = new ThreadTreeNode('I');

            return node_A;
        }

        /// <summary>
        /// 手动创建一个如下所示的中序线索二叉树，用于测试遍历结果
        ///         A
        ///       /   \
        ///     B       C
        ///    / \     / \
        ///   D   E   F   G
        ///  /       /     \
        /// H       I       J
        ///  \
        ///   K
        /// 前序：ABDHKECFIGJ  ABDH#K###E##CFI###G#J##
        /// 中序：HKDBEAIFCGJ  #H#K#D#B#E#A#I#F#C#G#J#
        /// 后续：KHDEBIFJGCA  ###KH#D##EB##I#F###JGCA
        /// 层序：ABCDEFGHIJK  ABCDEFGH###I##J#K######
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetInOrderThreadTree2()
        {
            ThreadTreeNode node_A = new ThreadTreeNode('A');
            ThreadTreeNode node_B = new ThreadTreeNode('B');
            ThreadTreeNode node_C = new ThreadTreeNode('C');
            ThreadTreeNode node_D = new ThreadTreeNode('D');
            ThreadTreeNode node_E = new ThreadTreeNode('E');
            ThreadTreeNode node_F = new ThreadTreeNode('F');
            ThreadTreeNode node_G = new ThreadTreeNode('G');
            ThreadTreeNode node_H = new ThreadTreeNode('H');
            ThreadTreeNode node_I = new ThreadTreeNode('I');
            ThreadTreeNode node_J = new ThreadTreeNode('J');
            ThreadTreeNode node_K = new ThreadTreeNode('K');

            return node_A;
        }
        #endregion

        #region 手动生成测试用的后序线索二叉树（已初始化线索）
        /// <summary>
        /// 手动创建一个如下所示的后序线索二叉树，用于测试遍历结果
        ///       A
        ///      / \
        ///     B   C
        ///    /   / \
        ///   D   E   F
        ///  / \   \
        /// G   H   I
        /// 前序：ABDGHCEIF  ABDG##H###CE#I##F##
        /// 中序：GDHBAEICF  #G#D#H#B#A#E#I#C#F#
        /// 后续：GHDBIEFCA  ##G##HD#B###IE##FCA
        /// 层序：ABCDEFGHI  ABCD#EFGH#I########
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetPostOrderThreadTree()
        {
            ThreadTreeNode node_A = new ThreadTreeNode('A');
            ThreadTreeNode node_B = new ThreadTreeNode('B');
            ThreadTreeNode node_C = new ThreadTreeNode('C');
            ThreadTreeNode node_D = new ThreadTreeNode('D');
            ThreadTreeNode node_E = new ThreadTreeNode('E');
            ThreadTreeNode node_F = new ThreadTreeNode('F');
            ThreadTreeNode node_G = new ThreadTreeNode('G');
            ThreadTreeNode node_H = new ThreadTreeNode('H');
            ThreadTreeNode node_I = new ThreadTreeNode('I');

            return node_A;
        }

        /// <summary>
        /// 手动创建一个如下所示的后序线索二叉树，用于测试遍历结果
        ///         A
        ///       /   \
        ///     B       C
        ///    / \     / \
        ///   D   E   F   G
        ///  /       /     \
        /// H       I       J
        ///  \
        ///   K
        /// 前序：ABDHKECFIGJ  ABDH#K###E##CFI###G#J##
        /// 中序：HKDBEAIFCGJ  #H#K#D#B#E#A#I#F#C#G#J#
        /// 后续：KHDEBIFJGCA  ###KH#D##EB##I#F###JGCA
        /// 层序：ABCDEFGHIJK  ABCDEFGH###I##J#K######
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetPostOrderThreadTree2()
        {
            ThreadTreeNode node_A = new ThreadTreeNode('A');
            ThreadTreeNode node_B = new ThreadTreeNode('B');
            ThreadTreeNode node_C = new ThreadTreeNode('C');
            ThreadTreeNode node_D = new ThreadTreeNode('D');
            ThreadTreeNode node_E = new ThreadTreeNode('E');
            ThreadTreeNode node_F = new ThreadTreeNode('F');
            ThreadTreeNode node_G = new ThreadTreeNode('G');
            ThreadTreeNode node_H = new ThreadTreeNode('H');
            ThreadTreeNode node_I = new ThreadTreeNode('I');
            ThreadTreeNode node_J = new ThreadTreeNode('J');
            ThreadTreeNode node_K = new ThreadTreeNode('K');

            return node_A;
        }
        #endregion

        #region 手动生成测试用的层序线索二叉树（已初始化线索）
        /// <summary>
        /// 手动创建一个如下所示的层序线索二叉树，用于测试遍历结果
        ///       A
        ///      / \
        ///     B   C
        ///    /   / \
        ///   D   E   F
        ///  / \   \
        /// G   H   I
        /// 前序：ABDGHCEIF  ABDG##H###CE#I##F##
        /// 中序：GDHBAEICF  #G#D#H#B#A#E#I#C#F#
        /// 后续：GHDBIEFCA  ##G##HD#B###IE##FCA
        /// 层序：ABCDEFGHI  ABCD#EFGH#I########
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetLevelOrderThreadTree()
        {
            ThreadTreeNode node_A = new ThreadTreeNode('A');
            ThreadTreeNode node_B = new ThreadTreeNode('B');
            ThreadTreeNode node_C = new ThreadTreeNode('C');
            ThreadTreeNode node_D = new ThreadTreeNode('D');
            ThreadTreeNode node_E = new ThreadTreeNode('E');
            ThreadTreeNode node_F = new ThreadTreeNode('F');
            ThreadTreeNode node_G = new ThreadTreeNode('G');
            ThreadTreeNode node_H = new ThreadTreeNode('H');
            ThreadTreeNode node_I = new ThreadTreeNode('I');

            return node_A;
        }

        /// <summary>
        /// 手动创建一个如下所示的层序线索二叉树，用于测试遍历结果
        ///         A
        ///       /   \
        ///     B       C
        ///    / \     / \
        ///   D   E   F   G
        ///  /       /     \
        /// H       I       J
        ///  \
        ///   K
        /// 前序：ABDHKECFIGJ  ABDH#K###E##CFI###G#J##
        /// 中序：HKDBEAIFCGJ  #H#K#D#B#E#A#I#F#C#G#J#
        /// 后续：KHDEBIFJGCA  ###KH#D##EB##I#F###JGCA
        /// 层序：ABCDEFGHIJK  ABCDEFGH###I##J#K######
        /// </summary>
        /// <returns></returns>
        public ThreadTreeNode GetLevelOrderThreadTree2()
        {
            ThreadTreeNode node_A = new ThreadTreeNode('A');
            ThreadTreeNode node_B = new ThreadTreeNode('B');
            ThreadTreeNode node_C = new ThreadTreeNode('C');
            ThreadTreeNode node_D = new ThreadTreeNode('D');
            ThreadTreeNode node_E = new ThreadTreeNode('E');
            ThreadTreeNode node_F = new ThreadTreeNode('F');
            ThreadTreeNode node_G = new ThreadTreeNode('G');
            ThreadTreeNode node_H = new ThreadTreeNode('H');
            ThreadTreeNode node_I = new ThreadTreeNode('I');
            ThreadTreeNode node_J = new ThreadTreeNode('J');
            ThreadTreeNode node_K = new ThreadTreeNode('K');

            return node_A;
        }
        #endregion

        #region 输出二叉树到控制台
        /// <summary>
        /// 简单的输出一棵二叉树
        /// 层序，BFS
        ///       A
        ///      / \
        ///     B   C
        ///    /   / \
        ///   D   E   F
        ///  / \   \
        /// G   H   I
        /// A
        /// A/B  A/C
        /// B/D  C/E  C/F
        /// D/G  D/H  E/I
        /// </summary>
        /// <param name="root"></param>
        public void PrintTree(TreeNode root)
        {
            if (root == null) { Console.WriteLine("Empty Binary Tree."); return; }

            Console.WriteLine($"{root.Value}");
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.Left != null) { Console.Write($"{node.Value}/{node.Left.Value}  "); queue.Enqueue(node.Left); }
                    if (node.Right != null) { Console.Write($"{node.Value}\\{node.Right.Value}  "); queue.Enqueue(node.Right); }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 简单的输出一棵线索二叉树
        /// </summary>
        /// <param name="root"></param>
        public void PrintTree(ThreadTreeNode root)
        {
        }
        #endregion
    }
}
