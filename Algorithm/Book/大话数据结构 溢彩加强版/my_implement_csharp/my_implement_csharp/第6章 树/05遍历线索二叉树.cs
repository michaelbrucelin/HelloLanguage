using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _05遍历线索二叉树
    {
        /// <summary>
        /// 遍历前序线索二叉树，DFS
        /// 1. 有左孩子输出左孩子，因为左孩子一定是后继
        /// 2. 没有左孩子，输出“右XX”，因为要么是后孩子，要么就是后继，无论是什么，此时都是后继
        /// 3. 没有左孩子，“右XX”里面是null，遍历结束
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderTraverse(ThreadTreeNode root)
        {
        }

        /// <summary>
        /// 遍历中序线索二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        public void InOrderTraverse(ThreadTreeNode root)
        {
        }

        /// <summary>
        /// 遍历后序线索二叉树，DFS
        /// </summary>
        /// <param name="root"></param>
        public void PostOrderTraverse(ThreadTreeNode root)
        {
        }

        /// <summary>
        /// 遍历层序线索二叉树，BFS
        /// </summary>
        /// <param name="root"></param>
        public void LevelOrderTraverse(ThreadTreeNode root)
        {
        }
    }
}
