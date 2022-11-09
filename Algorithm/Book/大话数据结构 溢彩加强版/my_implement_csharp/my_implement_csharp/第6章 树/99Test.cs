using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _99Test
    {
        public void TestTraverse()
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

        public void TestPrint()
        {
            TreeNode tree = GetTree();
            PrintTree(tree);
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
        /// 前序：ABDGHCEIF
        /// 中序：GDHBAEICF
        /// 后续：GHDBIEFCA
        /// 层序：ABCDEFGHI
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
        /// 前序：ABDHKECFIGJ
        /// 中序：HKDBEAIFCGJ
        /// 后续：KHDEBIFJGCA
        /// 层序：ABCDEFGHIJK
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
                    if (node.Right != null) { Console.Write($"{node.Value}/{node.Right.Value}  "); queue.Enqueue(node.Right); }
                }
                Console.WriteLine();
            }
        }
    }
}
