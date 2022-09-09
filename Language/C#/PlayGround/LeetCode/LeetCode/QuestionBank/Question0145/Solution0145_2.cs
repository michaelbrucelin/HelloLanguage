using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0145
{
    public class Solution0145_2 : Interface0145
    {
        /// <summary>
        /// 迭代
        /// 根节点入栈1 --> 右节点入栈1 --> 左节点入栈2
        /// 以右节点作为新的根节点继续上面的步骤，当不存在右节点了，从栈2中弹出一个节点作为根节点
        /// 最后输出栈1即可
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();

            Stack<int> result = new Stack<int>();
            Stack<TreeNode> buffer = new Stack<TreeNode>();
            TreeNode node = root;
            while (node != null)
            {
                result.Push(node.val);
                if (node.left != null) buffer.Push(node.left);
                if (node.right != null) node = node.right;
                else if (buffer.Count > 0) node = buffer.Pop();
                else break;
            }

            return new List<int>(result);
        }
    }
}
