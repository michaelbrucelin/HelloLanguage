using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0687
{
    public class Solution0687 : Interface0687
    {
        private static int result;

        public int LongestUnivaluePath(TreeNode root)
        {
            result = 0;
            DFS(root);

            return result;
        }

        private int DFS(TreeNode node)
        {
            if (node == null) return 0;

            int left = DFS(node.left), right = DFS(node.right);
            int left1 = 0, right1 = 0;
            if (node.left != null && node.val == node.left.val) left1 = left + 1;
            if (node.right != null && node.val == node.right.val) right1 = right + 1;

            result = Math.Max(result, left1 + right1);
            return Math.Max(left1, right1);
        }
    }
}
