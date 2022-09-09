using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0144
{
    public class Solution0144_2 : Interface0144
    {
        /// <summary>
        /// 迭代
        /// 输出根节点 --> 将右节点入栈 --> 输出左节点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();

            IList<int> result = new List<int>();
            Stack<TreeNode> buffer = new Stack<TreeNode>();
            TreeNode node = root;
            while (node != null)
            {
                result.Add(node.val);
                if (node.right != null) buffer.Push(node.right);
                if (node.left != null) node = node.left;
                else if (buffer.Count > 0) node = buffer.Pop();
                else break;
            }

            return result;
        }
    }
}
