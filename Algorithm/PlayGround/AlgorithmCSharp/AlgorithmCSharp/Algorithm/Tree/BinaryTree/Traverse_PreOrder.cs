using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Tree.BinaryTree
{
    /// <summary>
    /// 先序遍历二叉树
    /// </summary>
    public class Traverse_PreOrder
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Recursive(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            result.Add(root.Value);
            if (root.Left != null) result.AddRange(Traverse_Recursive(root.Left));
            if (root.Right != null) result.AddRange(Traverse_Recursive(root.Right));

            return result;
        }

        /// <summary>
        /// 递归2
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Recursive2(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            dfs(root, result);

            return result;
        }

        private void dfs(TreeNode node, List<char> buffer)
        {
            if (node == null) return;

            buffer.Add(node.Value);
            dfs(node.Left, buffer);
            dfs(node.Right, buffer);
        }

        /// <summary>
        /// 迭代
        /// 1. 将指针指向根节点
        /// 2. 输出指针
        /// 3. 判断指针的孩子情况
        ///     3.1. 有左有右，右孩子入栈，指针指向左孩子
        ///     3.2. 有左无右，指针指向左孩子
        ///     3.2. 无左有右，指针指向右孩子
        ///     3.4. 无左无右，指针指向栈顶（弹栈）
        /// 4. 回到步骤2
        /// 5. 直至指针无左无右且栈空，遍历结束
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Iteration(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null)
            {
                result.Add(ptr.Value);
                if (ptr.Left != null)
                {
                    if (ptr.Right != null) stack.Push(ptr.Right);
                    ptr = ptr.Left;
                }
                else
                {
                    if (ptr.Right != null) ptr = ptr.Right;
                    else if (stack.Count > 0) ptr = stack.Pop();
                    else break;
                }
            }

            return result;
        }

        /// <summary>
        /// 迭代2
        /// 用迭代的方式实现Traverse_Recursive2()的递归函数，两种方式是等价的，
        /// 区别在于递归的时候隐式地维护了一个栈，而这里在迭代的时候需要显式地将这个栈模拟出来，其余的实现与细节都相同。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Iteration2(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            return result;
        }

        /// <summary>
        /// 迭代，Morris
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Morris(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            return result;
        }
    }
}
