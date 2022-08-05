using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0623
{
    /// <summary>
    /// 深度优先解法1
    /// </summary>
    public class Question0623
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
                return new TreeNode(val, root, null);
            else if (depth == 2)
            {
                root.left = new TreeNode(val, root.left, null);
                root.right = new TreeNode(val, null, root.right);
            }
            else
            {
                if (root.left != null)
                    AddOneRow(root.left, val, depth - 1);
                if (root.right != null)
                    AddOneRow(root.right, val, depth - 1);
            }

            return root;
        }
    }
}
