using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0652
{
    public class Solution0652
    {
        /// <summary>
        /// 暴力解，提交会内存溢出
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            IList<TreeNode> result = new List<TreeNode>();

            List<(TreeNode node, string key)> buffer = new List<(TreeNode, string)>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    buffer.Add((node, GetTreeKey(node)));
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            for (int i = buffer.Count - 1; i >= 0; i--)
            {
                var item = buffer[i];
                bool hasAdd = false;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (buffer[j].key == item.key)
                    {
                        buffer.RemoveAt(j);
                        if (!hasAdd) { result.Add(item.node); hasAdd = true; }
                        i--;
                    }
                }
            }

            return result;
        }

        private string GetTreeKey(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool hasNode = true;
            while (hasNode)
            {
                hasNode = false;
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node == null) { sb.Append("-"); queue.Enqueue(null); queue.Enqueue(null); }
                    else
                    {
                        sb.Append($"-{node.val}");
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                        if (node.left != null || node.right != null) hasNode = true;
                    }
                }
            }

            return sb.ToString();
        }
    }
}
