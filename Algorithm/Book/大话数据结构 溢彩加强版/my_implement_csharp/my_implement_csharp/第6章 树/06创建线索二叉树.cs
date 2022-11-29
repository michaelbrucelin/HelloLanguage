using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _06创建线索二叉树
    {
        /// <summary>
        /// 前序遍历的顺序创建线索二叉树，DFS
        /// 中序遍历一次二叉树，并且在遍历的过程中给二叉树添加好线索
        /// 遍历到某一结点时，除了已经当前节点，还知道前驱节点（pre，通过ref参数传递），但是不知道后继节点
        /// 所以在遍历到节点node时，可以填补node的前驱与前驱的后继
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderBuilder(ThreadTreeNode root)
        {
            if (root == null) return;

            if (root.Left == null) root.LTag = 1;  // 根节点没有前驱，所以单独处理，如果放递归中处理，每一个节点都需要判断前驱是否为null
            ThreadTreeNode pre = root;
            if (root.Left != null) PreOrderBuilder(root.Left, ref pre);
            PreOrderBuilder(root.Right, ref pre);  // right一定要递归，因为在后继中处理前驱的后继
        }

        private void PreOrderBuilder(ThreadTreeNode node, ref ThreadTreeNode pre)
        {
            if (node == null) return;

            if (node.Left == null) { node.LTag = 1; node.Left = pre; }
            if (pre.Right == null) { pre.RTag = 1; pre.Right = node; }
            pre = node;
            if (node.LTag == 0) PreOrderBuilder(node.Left, ref pre);
            PreOrderBuilder(node.Right, ref pre);
        }

        /// <summary>
        /// 中序遍历的顺序创建线索二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        public void InOrderBuilder(ThreadTreeNode root)
        {

        }

        /// <summary>
        /// 后序遍历的顺序创建线索二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public void PostOrderBuilder(ThreadTreeNode root)
        {

        }

        /// <summary>
        /// 层序遍历的顺序创建线索二叉树，BFS
        /// </summary>
        /// <param name="root"></param>
        public void LevelOrderBuilder(ThreadTreeNode root)
        {

        }
    }
}
