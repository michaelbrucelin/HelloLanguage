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
            throw new NotImplementedException();
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
        /// 后续遍历的顺序创建二叉树，DFS
        /// 后续输入字符串就是将前序遍历时左右孩子为null的位置用特殊符号标记出来
        /// 后续输入字符串逆过来看就相当于变形的前序（父->右->左）
        ///   A
        ///  / \
        /// B   C
        ///  \
        ///   D
        /// 后续遍历：DBCA
        /// 后续输入：###DB##CA
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public TreeNode PostOrderBuilder(string s)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
