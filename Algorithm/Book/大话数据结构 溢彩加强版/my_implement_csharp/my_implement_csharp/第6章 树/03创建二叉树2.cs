using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _03创建二叉树2
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
        /// <param name="s"></param>
        /// <returns></returns>
        public TreeNode PreOrderBuilder(string s)
        {
            if (s.Length == 0 || s[0] == '#') return null;
            Queue<char> queue = new Queue<char>(s);
            return PreOrderBuilder(queue);
        }

        public TreeNode PreOrderBuilder(Queue<char> queue)
        {
            if (queue.Count == 0) return null;

            char c = queue.Dequeue(); if (c == '#') return null;
            TreeNode node = new TreeNode(c);
            node.Left = PreOrderBuilder(queue);
            node.Right = PreOrderBuilder(queue);

            return node;
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
        /// <param name="s"></param>
        /// <returns></returns>
        public TreeNode InOrderBuilder(string s)
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
        /// 后序输入：###DB##CA
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public TreeNode PostOrderBuilder(string s)
        {
            if (s.Length == 0 || s[0] == '#') return null;
            Stack<char> stack = new Stack<char>(s);
            return PostOrderBuilder(stack);
        }

        public TreeNode PostOrderBuilder(Stack<char> stack)
        {
            if (stack.Count == 0) return null;

            char c = stack.Pop(); if (c == '#') return null;
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
        /// <param name="s"></param>
        /// <returns></returns>
        public TreeNode LevelOrderBuilder(string s)
        {
            if (s.Length == 0 || s[0] == '#') return null;

            TreeNode root = new TreeNode(s[0]);
            Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
            int id = 0;
            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (++id < s.Length)
                    {
                        char c = s[id];
                        if (c != '#')
                        {
                            TreeNode left = new TreeNode(c);
                            node.Left = left;
                            queue.Enqueue(left);
                        }
                    }
                    if (++id < s.Length)
                    {
                        char c = s[id];
                        if (c != '#')
                        {
                            TreeNode right = new TreeNode(c);
                            node.Right = right;
                            queue.Enqueue(right);
                        }
                    }
                }
            }

            return root;
        }
    }
}
