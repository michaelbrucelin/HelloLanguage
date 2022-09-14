using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0623
{
    /// <summary>
    /// 深度优先解法2
    /// </summary>
    public class Solution0623_2 : Interface0623
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
                return new TreeNode(val, root, null);
            else
                FindAndAddOneRow(root, val, depth, 1);

            return root;
        }

        private void FindAndAddOneRow(TreeNode node, int val, int depth, int depth_cur)
        {
            if (depth_cur == depth - 1)
            {
                node.left = new TreeNode(val, node.left, null);
                node.right = new TreeNode(val, null, node.right);
            }
            else
            {
                if (node.left != null)
                    FindAndAddOneRow(node.left, val, depth, depth_cur + 1);
                if (node.right != null)
                    FindAndAddOneRow(node.right, val, depth, depth_cur + 1);
            }
        }
    }
}
