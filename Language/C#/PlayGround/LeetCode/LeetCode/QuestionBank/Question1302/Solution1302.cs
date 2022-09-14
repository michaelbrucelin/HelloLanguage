using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1302
{
    public class Solution1302 : Interface1302
    {
        private Dictionary<int, int> buffer = new Dictionary<int, int>();
        public int DeepestLeavesSum(TreeNode root)
        {
            DeepestLeavesSum_DFS(root, 1);  // 题目保证了二叉树至少有一个节点

            return buffer[buffer.Max(kv => kv.Key)];
        }

        private void DeepestLeavesSum_DFS(TreeNode node, int level)
        {
            if (node == null) return;

            if (!buffer.ContainsKey(level))
                buffer.Add(level, node.val);
            else
                buffer[level] += node.val;

            DeepestLeavesSum_DFS(node.left, level + 1);
            DeepestLeavesSum_DFS(node.right, level + 1);
        }
    }
}
