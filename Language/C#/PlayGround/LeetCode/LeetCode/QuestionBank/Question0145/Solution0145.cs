using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0145
{
    public class Solution0145 : Interface0145
    {
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();

            List<int> result = new List<int>();
            result.AddRange(PostorderTraversal(root.left));
            result.AddRange(PostorderTraversal(root.right));
            result.Add(root.val);

            return result;
        }
    }
}
