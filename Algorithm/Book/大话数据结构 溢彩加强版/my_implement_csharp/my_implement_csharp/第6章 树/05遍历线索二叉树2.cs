﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _05遍历线索二叉树2
    {
        /// <summary>
        /// 遍历前序线索二叉树，DFS
        /// 1. 有左孩子输出左孩子，因为左孩子一定是后继
        /// 2. 没有左孩子，输出“右XX”，因为要么是后孩子，要么就是后继，无论是什么，此时都是后继
        /// 3. 没有左孩子，“右XX”里面是null，遍历结束
        /// </summary>
        /// <param name="root"></param>
        public string PreOrderTraverse(ThreadTreeNode root)
        {
            if (root == null) return "";

            StringBuilder sb = new StringBuilder();
            PreOrderTraverse(root, sb);

            return sb.ToString();
        }

        private void PreOrderTraverse(ThreadTreeNode node, StringBuilder sb)
        {
            if (node == null) return;

            sb.Append(node.Value);
            if (node.LTag == 0)
                PreOrderTraverse(node.Left, sb);
            else if (node.Right != null)
                PreOrderTraverse(node.Right, sb);
        }

        /// <summary>
        /// 遍历中序线索二叉树，DFS
        /// 1. 从根开始一直向后找左孩子，直至没有左孩子（有前驱且前驱为null）的节点，此节点为遍历的起点
        /// 2. 依次遍历当前节点的后继节点，直至遍历的节点没有后继节点
        /// 3. 如果当前节点没有后继节点，从此节点的右孩子向下一直找左孩子直至没有左孩子（有前驱）的节点，回到步骤2
        /// 4. 到达没有右孩子且后继为null的节点，遍历结束
        /// </summary>
        /// <param name="root"></param>
        public string InOrderTraverse(ThreadTreeNode root)
        {
            if (root == null) return "";

            StringBuilder sb = new StringBuilder();
            InOrderTraverse(root, sb);

            return sb.ToString();
        }

        public void InOrderTraverse(ThreadTreeNode node, StringBuilder sb)
        {
            if (node == null) return;

            ThreadTreeNode ptr = node;
            while (ptr.LTag == 0) ptr = ptr.Left;  // 遍历的起点，不需要ptr.Left != null，左XX为null的节点，LTag为1
            sb.Append(ptr.Value);
            while (ptr.RTag == 1 && ptr.Right != null) { ptr = ptr.Right; sb.Append(ptr.Value); }
            if (ptr.Right != null) InOrderTraverse(ptr.Right, sb);
        }

        /// <summary>
        /// 遍历后序线索二叉树，DFS
        /// 没有找到直接遍历的方法，不过可以按照“前”->“右”->“左”的方式遍历并将遍历到的节点入栈，遍历后再一次弹栈即可
        /// 1. 有右孩子将右孩子入栈，因为右孩子一定是“后继”
        /// 2. 没有右孩子，将“左XX”入栈，因为要么是“后孩子”，要么就是“后继”，无论是什么，此时都是“后继”
        /// 3. 没有右孩子，“左XX”里面是null，遍历结束
        /// 4. 依次弹栈获得真正遍历的序列
        /// </summary>
        /// <param name="root"></param>
        public string PostOrderTraverse(ThreadTreeNode root)
        {
            if (root == null) return "";

            Stack<ThreadTreeNode> stack = new Stack<ThreadTreeNode>();
            PostOrderTraverse(root, stack);

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0) sb.Append(stack.Pop().Value);

            return sb.ToString();
        }

        private void PostOrderTraverse(ThreadTreeNode node, Stack<ThreadTreeNode> stack)
        {
            if (node == null) return;
            stack.Push(node);
            if (node.RTag == 0)
                PostOrderTraverse(node.Right, stack);
            else if (node.Left != null)
                PostOrderTraverse(node.Left, stack);
        }

        /// <summary>
        /// 遍历层序线索二叉树，BFS
        /// 没有找到遍历的方法。
        /// </summary>
        /// <param name="root"></param>
        public void LevelOrderTraverse(ThreadTreeNode root)
        {
        }
    }
}
