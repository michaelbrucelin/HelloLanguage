using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Tree.BinaryTree
{
    /// <summary>
    /// 中序遍历二叉树
    /// </summary>
    public class Traverse_InOrder
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
            result.Add(root.Value);
            result.AddRange(Traverse_Recursive(root.Right));

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
            buffer.Add(node.Value);
            dfs(node.Right, buffer);
        }

        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Iteration(TreeNode root)
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
