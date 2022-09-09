using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0144
{
    /// <summary>
    /// 递归
    /// </summary>
    public class Solution0144 : Interface0144
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();

            List<int> result = new List<int>();
            result.Add(root.val);
            result.AddRange(PreorderTraversal(root.left));
            result.AddRange(PreorderTraversal(root.right));

            return result;
        }
    }
}
