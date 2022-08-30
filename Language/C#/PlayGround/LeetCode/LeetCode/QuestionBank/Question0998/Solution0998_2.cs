using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0998
{
    public class Solution0998_2
    {
        public TreeNode InsertIntoMaxTree(TreeNode root, int val)
        {
            if (root == null || val > root.val)
                return new TreeNode(val, root, null);

            TreeNode node = root;
            while (true)
            {
                if (node.right == null)
                {
                    node.right = new TreeNode(val);
                    return root;
                }
                else if (node.right.val < val)
                {
                    TreeNode node_new = new TreeNode(val);
                    node_new.left = node.right;
                    node.right = node_new;

                    return root;
                }
                else
                {
                    node = node.right;
                }
            }
        }
    }
}
