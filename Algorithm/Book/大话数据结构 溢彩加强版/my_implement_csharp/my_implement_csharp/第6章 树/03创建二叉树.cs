using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _03创建二叉树
    {
        /// <summary>
        /// 前序遍历的顺序创建二叉树，DFS
        /// 前序输入字符串就是将前序遍历时左右孩子为null的位置用特殊符号标记出来
        ///   A
        ///  / \
        /// B   C
        ///  \
        ///   D
        /// 前序遍历：ABDC
        /// 前序输入：AB#D##C##
        /// </summary>
        /// <returns></returns>
        public TreeNode PreOrderBuilder()
        {
            Console.WriteLine("Enter the node values in the order of the previous traversal:");
            char c = Console.ReadKey().KeyChar; Console.WriteLine();
            if (c == '#') return null;

            TreeNode root = new TreeNode(c);
            root.Left = PreOrderBuilder();
            root.Right = PreOrderBuilder();

            return root;
        }

        /// <summary>
        /// 中序遍历的顺序创建二叉树，DFS
        /// 中序就不像前序那么简单了，考虑下面两棵不同的二叉树，中序的序列一样的
        ///   A            D
        ///  / \          / \
        /// B   C        B   A
        ///  \                \
        ///   D                C
        /// BDAC         BDAC
        /// #B#D#A#C#    #B#D#A#C#
        /// </summary>
        /// <returns></returns>
        public TreeNode InOrderBuilder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 后序遍历的顺序创建二叉树，DFS
        /// 后序输入字符串就是将前序遍历时左右孩子为null的位置用特殊符号标记出来
        /// 后序输入字符串逆过来看就相当于变形的前序（父->右->左）
        ///   A
        ///  / \
        /// B   C
        ///  \
        ///   D
        /// 后序遍历：DBCA
        /// 后序输入：###DB##CA$  $表示已经输入结束
        /// </summary>
        /// <returns></returns>
        public TreeNode PostOrderBuilder()
        {
            Stack<char> buffer = new Stack<char>();
            Console.WriteLine("Enter the values of the nodes in the order of back-order traversal:");
            char c = Console.ReadKey().KeyChar; Console.WriteLine();
            while (c != '$')
            {
                buffer.Push(c);
                Console.WriteLine("Enter the values of the nodes in the order of back-order traversal:");
                c = Console.ReadKey().KeyChar; Console.WriteLine();
            }

            return PostOrderBuilder(buffer);
        }

        public TreeNode PostOrderBuilder(Stack<char> stack)
        {
            if (stack.Count == 0) return null;
            char c = stack.Pop();
            if (c == '#') return null;

            TreeNode node = new TreeNode(c);
            node.Right = PostOrderBuilder(stack);
            node.Left = PostOrderBuilder(stack);
            return node;
        }

        /// <summary>
        /// 层序遍历的顺序创建二叉树，BFS
        /// 层序输入字符串就是将前序遍历时左右孩子为null的位置用特殊符号标记出来
        ///   A
        ///  / \
        /// B   C
        ///  \
        ///   D
        /// 层序遍历：ABCD
        /// 层序输入：ABC#D##
        /// </summary>
        /// <returns></returns>
        public TreeNode LevelOrderBuilder()
        {
            Console.WriteLine("Enter the node values in the order of the sequential traversal:");
            char c = Console.ReadKey().KeyChar; Console.WriteLine();
            if (c == '#') return null;

            TreeNode root = new TreeNode(c);
            Queue<TreeNode> buffer = new Queue<TreeNode>(); buffer.Enqueue(root);
            while (buffer.Count > 0)
            {
                int cnt = buffer.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = buffer.Dequeue();
                    Console.WriteLine("Enter the node values in the order of the sequential traversal:");
                    c = Console.ReadKey().KeyChar; Console.WriteLine();
                    if (c != '#') { TreeNode left = new TreeNode(c); node.Left = left; buffer.Enqueue(left); }
                    Console.WriteLine("Enter the node values in the order of the sequential traversal:");
                    c = Console.ReadKey().KeyChar; Console.WriteLine();
                    if (c != '#') { TreeNode right = new TreeNode(c); node.Right = right; buffer.Enqueue(right); }
                }
            }

            return root;
        }
    }
}
