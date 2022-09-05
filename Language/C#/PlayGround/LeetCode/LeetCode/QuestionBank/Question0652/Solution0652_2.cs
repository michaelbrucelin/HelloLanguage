using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0652
{
    public class Solution0652_2
    {
        private List<(TreeNode node, string key)> buffer;

        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            IList<TreeNode> result = new List<TreeNode>();

            buffer = new List<(TreeNode node, string key)>();
            GetTreeKey(root);

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
            if (root == null) return "null";

            string leftChild = GetTreeKey(root.left);
            string rightChild = GetTreeKey(root.right);
            string key = $"{root.val}-{leftChild}-{rightChild}";

            buffer.Add((root, key));
            return key;
        }
    }
}
