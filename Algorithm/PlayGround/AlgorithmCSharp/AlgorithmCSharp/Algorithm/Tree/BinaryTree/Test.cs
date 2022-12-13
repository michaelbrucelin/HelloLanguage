using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Tree.BinaryTree
{
    public class Test
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
        public void TestTraverse_PreOrder()
        {
            Traverse_PreOrder traverse = new Traverse_PreOrder();
            TreeNode tree;
            List<char> list; string result, answer;
            int id = 0;

            Console.WriteLine("递归");
            tree = GetTree(); answer = "ABDGHCEIF";
            list = traverse.Traverse_Recursive(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "ABDHKECFIGJ";
            list = traverse.Traverse_Recursive(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            Console.WriteLine("递归2");
            tree = GetTree(); answer = "ABDGHCEIF";
            list = traverse.Traverse_Recursive2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "ABDHKECFIGJ";
            list = traverse.Traverse_Recursive2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            Console.WriteLine("迭代");
            tree = GetTree(); answer = "ABDGHCEIF";
            list = traverse.Traverse_Iteration(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "ABDHKECFIGJ";
            list = traverse.Traverse_Iteration(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            Console.WriteLine("迭代2");
            tree = GetTree(); answer = "ABDGHCEIF";
            list = traverse.Traverse_Iteration2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "ABDHKECFIGJ";
            list = traverse.Traverse_Iteration2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }

        public void TestTraverse_InOrder()
        {
            Traverse_InOrder traverse = new Traverse_InOrder();
            TreeNode tree;
            List<char> list; string result, answer;
            int id = 0;

            Console.WriteLine("递归");
            tree = GetTree(); answer = "GDHBAEICF";
            list = traverse.Traverse_Recursive(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "HKDBEAIFCGJ";
            list = traverse.Traverse_Recursive(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            Console.WriteLine("递归2");
            tree = GetTree(); answer = "GDHBAEICF";
            list = traverse.Traverse_Recursive2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "HKDBEAIFCGJ";
            list = traverse.Traverse_Recursive2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            Console.WriteLine("迭代");
            tree = GetTree(); answer = "GDHBAEICF";
            list = traverse.Traverse_Iteration(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "HKDBEAIFCGJ";
            list = traverse.Traverse_Iteration(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            Console.WriteLine("迭代2");
            tree = GetTree(); answer = "GDHBAEICF";
            list = traverse.Traverse_Iteration2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "HKDBEAIFCGJ";
            list = traverse.Traverse_Iteration2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }

        public void TestTraverse_PostOrder()
        {
            Traverse_PostOrder traverse = new Traverse_PostOrder();
            TreeNode tree;
            List<char> list; string result, answer;
            int id = 0;

            Console.WriteLine("递归");
            tree = GetTree(); answer = "GHDBIEFCA";
            list = traverse.Traverse_Recursive(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "KHDEBIFJGCA";
            list = traverse.Traverse_Recursive(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            Console.WriteLine("递归2");
            tree = GetTree(); answer = "GHDBIEFCA";
            list = traverse.Traverse_Recursive2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "KHDEBIFJGCA";
            list = traverse.Traverse_Recursive2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            Console.WriteLine("迭代");
            tree = GetTree(); answer = "GHDBIEFCA";
            list = traverse.Traverse_Iteration(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "KHDEBIFJGCA";
            list = traverse.Traverse_Iteration(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            Console.WriteLine("迭代2");
            tree = GetTree(); answer = "GHDBIEFCA";
            list = traverse.Traverse_Iteration2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "KHDEBIFJGCA";
            list = traverse.Traverse_Iteration2(tree); result = list.Select(c => c.ToString()).Aggregate("", (c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }

        public void TestTraverse_LevelOrder()
        {
            Traverse_LevelOrder traverse = new Traverse_LevelOrder();
            TreeNode tree;
            List<char> list; string result, answer;
            int id = 0;

            Console.WriteLine("BFS");
            tree = GetTree(); answer = "ABCDEFGHI";
            list = traverse.Traverse(tree); result = list.Select(c => c.ToString()).Aggregate((c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            tree = GetTree2(); answer = "ABCDEFGHIJK";
            list = traverse.Traverse(tree); result = list.Select(c => c.ToString()).Aggregate((c1, c2) => $"{c1}{c2}");
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
        #endregion

        #region 测试二叉树的创建
        //public void TestPreOrderBuilder()
        //{
        //    _03创建二叉树 builder = new _03创建二叉树();
        //    TreeNode tree = builder.PreOrderBuilder();

        //    Console.WriteLine("Print Tree:");
        //    PrintTree(tree);
        //}

        //public void TestPreOrderBuilder(string s)
        //{
        //    _03创建二叉树2 builder = new _03创建二叉树2();
        //    TreeNode tree = builder.PreOrderBuilder(s);

        //    Console.WriteLine("Print Tree:");
        //    PrintTree(tree);
        //}

        //public void TestPostOrderBuilder()
        //{
        //    _03创建二叉树 builder = new _03创建二叉树();
        //    TreeNode tree = builder.PostOrderBuilder();

        //    Console.WriteLine("Print Tree:");
        //    PrintTree(tree);
        //}

        //public void TestPostOrderBuilder(string s)
        //{
        //    _03创建二叉树2 builder = new _03创建二叉树2();
        //    TreeNode tree = builder.PostOrderBuilder(s);

        //    Console.WriteLine("Print Tree:");
        //    PrintTree(tree);
        //}

        //public void TestLevelOrderBuilder()
        //{
        //    _03创建二叉树 builder = new _03创建二叉树();
        //    TreeNode tree = builder.LevelOrderBuilder();

        //    Console.WriteLine("Print Tree:");
        //    PrintTree(tree);
        //}

        //public void TestLevelOrderBuilder(string s)
        //{
        //    _03创建二叉树2 builder = new _03创建二叉树2();
        //    TreeNode tree = builder.LevelOrderBuilder(s);

        //    Console.WriteLine("Print Tree:");
        //    PrintTree(tree);
        //}
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
        /// 后序：GHDBIEFCA  ##G##HD#B###IE##FCA
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
        /// 后序：KHDEBIFJGCA  ###KH#D##EB##I#F###JGCA
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
        #endregion
    }
}
