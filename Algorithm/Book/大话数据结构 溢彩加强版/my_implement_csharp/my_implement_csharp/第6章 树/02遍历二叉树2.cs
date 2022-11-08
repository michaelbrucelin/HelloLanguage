using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _02遍历二叉树2
    {
        #region 前序遍历
        /// <summary>
        /// 前序遍历二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        public string PreOrderTraverse(TreeNode root)
        {
            if (root == null) return string.Empty;

            StringBuilder sb = new StringBuilder();
            PreOrderTraverse(root, sb);

            return sb.ToString();
        }

        public void PreOrderTraverse(TreeNode root, StringBuilder sb)
        {
            if (root == null) return;

            sb.Append(root.Value);
            PreOrderTraverse(root.Left, sb);
            PreOrderTraverse(root.Right, sb);
        }
        #endregion

        #region 中序遍历
        /// <summary>
        /// 中序遍历二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        public string InOrderTraverse(TreeNode root)
        {
            if (root == null) return string.Empty;

            StringBuilder sb = new StringBuilder();
            InOrderTraverse(root, sb);

            return sb.ToString();
        }

        public void InOrderTraverse(TreeNode root, StringBuilder sb)
        {
            if (root == null) return;

            InOrderTraverse(root.Left, sb);
            sb.Append(root.Value);
            InOrderTraverse(root.Right, sb);
        }
        #endregion

        #region 后序遍历
        /// <summary>
        /// 后序遍历二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        public string PostOrderTraverse(TreeNode root)
        {
            if (root == null) return string.Empty;

            StringBuilder sb = new StringBuilder();
            PostOrderTraverse(root, sb);

            return sb.ToString();
        }

        public void PostOrderTraverse(TreeNode root, StringBuilder sb)
        {
            if (root == null) return;

            PostOrderTraverse(root.Left, sb);
            PostOrderTraverse(root.Right, sb);
            sb.Append(root.Value);
        }
        #endregion

        #region 层序遍历
        /// <summary>
        /// 层序遍历二叉树，BFS
        /// </summary>
        /// <param name="root"></param>
        public string LevelOrderTraverse(TreeNode root)
        {
            if (root == null) return string.Empty;

            StringBuilder sb = new StringBuilder();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int cnt = queue.Count;
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    sb.Append(node.Value);
                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
            }

            return sb.ToString();
        }
        #endregion
    }
}
