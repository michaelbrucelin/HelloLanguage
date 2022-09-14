using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0226
{
    public class Solution0226 : Interface0226
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;

            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);

            root.left = right;
            root.right = left;

            return root;
        }
    }
}
