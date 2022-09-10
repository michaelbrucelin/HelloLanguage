using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0669
{
    public class Solution0669 : Interface0669
    {
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null) return null;

            TreeNode result = root;

            // 修剪low
            TreeNode parent = result, child = result;
            while (child != null)
            {
                if (child.val == low) { child.left = null; break; }
                else if (child.val > low) { parent = child; child = child.left; }
                else
                {
                    if (child == parent) { parent = child = child.right; result = parent; }
                    else { parent.left = child = child.right; }
                }
            }

            // 修剪high
            parent = child = result;
            while (child != null)
            {
                if (child.val == high) { child.right = null; break; }
                else if (child.val < high) { parent = child; child = child.right; }
                else
                {
                    if (child == parent) { parent = child = child.left; result = parent; }
                    else { parent.right = child = child.left; }
                }
            }

            return result;
        }
    }
}
