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
    }
}
