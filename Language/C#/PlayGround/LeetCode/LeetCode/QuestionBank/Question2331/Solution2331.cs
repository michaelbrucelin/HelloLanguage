using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2331
{
    public class Solution2331 : Interface2331
    {
        public bool EvaluateTree(TreeNode root)
        {
            if (root.val < 2) return root.val == 1;

            if (root.val == 2)
                return EvaluateTree(root.left) || EvaluateTree(root.right);
            else
                return EvaluateTree(root.left) && EvaluateTree(root.right);
        }
    }
}
