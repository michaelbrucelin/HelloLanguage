using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _04线索二叉树的定义
    {
        /*
            线索二叉树 的定义如下:
            “一个二叉树通过如下的方法“穿起来”：所有原本为空的右子节点指针改为指向该节点在中序序列中的后继，所有原本为空的左子节点指针改为指向该节点的中序序列的前驱。”
            https://zh.wikipedia.org/wiki/%E7%BA%BF%E7%B4%A2%E4%BA%8C%E5%8F%89%E6%A0%91

            所以怀疑尽管理论上可以有前序、中序、后序以及层序的线索二叉树，但是实际应用中只有中序的线索二叉树。
        */
    }

    public class ThreadTreeNode
    {
        public ThreadTreeNode(char value, ThreadTreeNode left = null, ThreadTreeNode right = null, int ltag = 0, int rtag = 0)
        {
            Value = value;
            Left = left;
            Right = right;
            LTag = ltag;
            RTag = rtag;
        }

        public char Value { get; set; }
        public ThreadTreeNode Left { get; set; }
        public ThreadTreeNode Right { get; set; }
        /// <summary>
        /// 0: 左孩子; 1: 前驱
        /// </summary>
        public int LTag;
        /// <summary>
        /// 0: 右孩子; 1: 后继
        /// </summary>
        public int RTag;
    }
}
