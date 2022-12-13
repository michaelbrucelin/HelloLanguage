using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Tree.BinaryTree
{
    /// <summary>
    /// 后序遍历二叉树
    /// </summary>
    public class Traverse_PostOrder
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

            result.AddRange(Traverse_Recursive(root.Left));
            result.AddRange(Traverse_Recursive(root.Right));
            result.Add(root.Value);

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

            dfs(node.Left, buffer);
            dfs(node.Right, buffer);
            buffer.Add(node.Value);
        }

        /// <summary>
        /// 迭代
        /// 本质上就是采用“根->右->左”的伪前序遍历方式进行前序遍历，只不过操作节点改为入栈，最后整体弹栈（反序）
        /// 1. 将指针指向根节点
        /// 2. 指针入栈1
        /// 3. 判断指针的孩子情况
        ///     3.1. 有右有左，左孩子入栈2，指针指向右孩子
        ///     3.2. 有右无左，指针指向右孩子
        ///     3.2. 无右有左，指针指向左孩子
        ///     3.4. 无右无左，指针指向栈2的栈顶（弹栈）
        /// 4. 回到步骤2
        /// 5. 直至指针无左无右且栈2为空栈，将栈1中的元素一次弹栈并输出
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Iteration(TreeNode root)
        {
            Stack<char> result = new Stack<char>();
            if (root == null) return new List<char>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null)
            {
                result.Push(ptr.Value);
                if (ptr.Right != null)
                {
                    if (ptr.Left != null) stack.Push(ptr.Left);
                    ptr = ptr.Right;
                }
                else
                {
                    if (ptr.Left != null) ptr = ptr.Left;
                    else if (stack.Count > 0) ptr = stack.Pop();
                    else break;
                }
            }

            return result.ToList();
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
