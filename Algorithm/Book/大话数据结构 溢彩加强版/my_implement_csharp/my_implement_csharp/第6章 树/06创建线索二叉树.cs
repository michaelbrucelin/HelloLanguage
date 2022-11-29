using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _06创建线索二叉树
    {
        /// <summary>
        /// 前序遍历的顺序创建线索二叉树，DFS
        /// 前序遍历一次二叉树，并且在遍历的过程中给二叉树添加好线索
        /// 遍历到某一结点时，除了已经当前节点，还知道前驱节点（pre，通过ref参数传递），但是不知道后继节点
        /// 所以在遍历到节点node时，可以填补node的前驱与前驱的后继
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderBuilder(ThreadTreeNode root)
        {
            if (root == null) return;

            ThreadTreeNode pre = null;
            PreOrderBuilder(root, ref pre);
        }

        private void PreOrderBuilder(ThreadTreeNode node, ref ThreadTreeNode pre)
        {
            if (node.Left == null) { node.LTag = 1; node.Left = pre; }
            if (pre != null && pre.Right == null) { pre.RTag = 1; pre.Right = node; }
            pre = node;
            if (node.LTag == 0) PreOrderBuilder(node.Left, ref pre);  // if (node.LTag == 0 && node.Left != null)
            if (node.RTag == 0 && node.Right != null) PreOrderBuilder(node.Right, ref pre);
        }

        /// <summary>
        /// 前序遍历的顺序创建线索二叉树，DFS
        /// 前序遍历一次二叉树，并且在遍历的过程中给二叉树添加好线索
        /// 遍历到某一结点时，除了已经当前节点，还知道前驱节点（pre，通过ref参数传递），但是不知道后继节点
        /// 所以在遍历到节点node时，可以填补node的前驱与前驱的后继
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderBuilder2(ThreadTreeNode root)
        {
            if (root == null) return;

            if (root.Left == null) root.LTag = 1;   // 根节点没有前驱，所以单独处理，如果放递归中处理，每一个节点都需要判断前驱是否为null
            if (root.Right == null) root.RTag = 1;
            ThreadTreeNode pre = root;
            if (root.Left != null) PreOrderBuilder2(root.Left, ref pre);
            if (root.Right != null) PreOrderBuilder2(root.Right, ref pre);
        }

        private void PreOrderBuilder2(ThreadTreeNode node, ref ThreadTreeNode pre)
        {
            if (node.Left == null) { node.LTag = 1; node.Left = pre; }
            if (node.Right == null) node.RTag = 1;
            if (pre.Right == null) { pre.RTag = 1; pre.Right = node; }

            pre = node;
            if (node.LTag == 0) PreOrderBuilder2(node.Left, ref pre);
            if (node.RTag == 0) PreOrderBuilder2(node.Right, ref pre);
        }

        /// <summary>
        /// 中序遍历的顺序创建线索二叉树，DFS
        /// 中序遍历一次二叉树，并且在遍历的过程中给二叉树添加好线索
        /// 遍历到某一结点时，除了已经当前节点，还知道前驱节点（pre，通过ref参数传递），但是不知道后继节点
        /// 所以在遍历到节点node时，可以填补node的前驱与前驱的后继
        /// </summary>
        /// <param name="root"></param>
        public void InOrderBuilder(ThreadTreeNode root)
        {
            if (root == null) return;

            ThreadTreeNode pre = null;
            InOrderBuilder(root, ref pre);
        }

        private void InOrderBuilder(ThreadTreeNode node, ref ThreadTreeNode pre)
        {
            if (node.LTag == 0 && node.Left != null) InOrderBuilder(node.Left, ref pre);
            if (node.Left == null) { node.LTag = 1; node.Left = pre; }
            if (pre != null && pre.Right == null) { pre.RTag = 1; pre.Right = node; }
            pre = node;
            if (node.RTag == 0 && node.Right != null) InOrderBuilder(node.Right, ref pre);
        }

        /// <summary>
        /// 后序遍历的顺序创建线索二叉树，DFS
        /// 后序遍历一次二叉树，并且在遍历的过程中给二叉树添加好线索
        /// 遍历到某一结点时，除了已经当前节点，还知道前驱节点（pre，通过ref参数传递），但是不知道后继节点
        /// 所以在遍历到节点node时，可以填补node的前驱与前驱的后继
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public void PostOrderBuilder(ThreadTreeNode root)
        {
            if (root == null) return;

            ThreadTreeNode pre = null;
            PostOrderBuilder(root, ref pre);
        }

        private void PostOrderBuilder(ThreadTreeNode node, ref ThreadTreeNode pre)
        {
            if (node.LTag == 0 && node.Left != null) PostOrderBuilder(node.Left, ref pre);
            if (node.RTag == 0 && node.Right != null) PostOrderBuilder(node.Right, ref pre);
            if (node.Left == null) { node.LTag = 1; node.Left = pre; }
            if (pre != null && pre.Right == null) { pre.RTag = 1; pre.Right = node; }
            pre = node;
        }

        /// <summary>
        /// 层序遍历的顺序创建线索二叉树，BFS
        /// 层序遍历一次二叉树，并且在遍历的过程中给二叉树添加好线索
        /// 层序遍历每一层第一个元素是上一层最后一个元素的后继，最后一个元素是下一层第一个元素的前驱，中间的元素就不用说了（线性表）
        /// </summary>
        /// <param name="root"></param>
        public void LevelOrderBuilder(ThreadTreeNode root)
        {
            if (root == null) return;

            Queue<ThreadTreeNode> queue = new Queue<ThreadTreeNode>();
            queue.Enqueue(root);
            int cnt; ThreadTreeNode pre = null;
            while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    ThreadTreeNode node = queue.Dequeue();
                    if (node.Left == null) { node.LTag = 1; node.Left = pre; }
                    if (pre != null && pre.Right == null) { pre.RTag = 1; pre.Right = node; }
                    pre = node;
                }
            }
        }
    }
}
