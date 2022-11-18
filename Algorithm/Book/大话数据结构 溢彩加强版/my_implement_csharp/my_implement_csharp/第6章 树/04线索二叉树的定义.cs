using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第6章_树
{
    public class _04线索二叉树的定义
    {
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
