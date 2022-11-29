using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _02遍历二叉树
    {
        /// <summary>
        /// 前序遍历二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderTraverse(TreeNode root)
        {
            if (root == null) return;

            Console.Write(root.Value);
            PreOrderTraverse(root.Left);
            PreOrderTraverse(root.Right);
        }

        /// <summary>
        /// 中序遍历二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        public void InOrderTraverse(TreeNode root)
        {
            if (root == null) return;

            InOrderTraverse(root.Left);
            Console.Write(root.Value);
            InOrderTraverse(root.Right);
        }

        /// <summary>
        /// 后序遍历二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        public void PostOrderTraverse(TreeNode root)
        {
            if (root == null) return;

            PostOrderTraverse(root.Left);
            PostOrderTraverse(root.Right);
            Console.Write(root.Value);
        }

        /// <summary>
        /// 层序遍历二叉树，BFS
        /// </summary>
        /// <param name="root"></param>
        public void LevelOrderTraverse(TreeNode root)
        {
            if (root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt;
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    Console.Write(node.Value);
                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
            }
        }
    }
}
