using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Tree.BinaryTree
{
    /// <summary>
    /// 层序遍历二叉树
    /// </summary>
    public class Traverse_LevelOrder
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    result.Add(node.Value);
                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
            }

            return result;
        }
    }
}
