using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _99Test
    {
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

        public void TestPrint()
        {
            TreeNode tree;
            tree = GetTree(); PrintTree(tree);
            tree = GetTree2(); PrintTree(tree);
        }

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
    }
}
