using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1302
{
    public class Solution1302_2
    {
        private int result = 0;
        private int maxLevel = -1;

        public int DeepestLeavesSum(TreeNode root)
        {
            DeepestLeavesSum_DFS(root, 1);

            return result;
        }

        private void DeepestLeavesSum_DFS(TreeNode node, int level)
        {
            if (node == null) return;

            if (level > maxLevel)
            {
                maxLevel = level;
                result = node.val;
            }
            else if (level == maxLevel)
                result += node.val;

            DeepestLeavesSum_DFS(node.left, level + 1);
            DeepestLeavesSum_DFS(node.right, level + 1);
        }
    }
}
