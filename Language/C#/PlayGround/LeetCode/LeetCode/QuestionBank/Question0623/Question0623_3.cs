using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0623
{
    /// <summary>
    /// 广度优先解法
    /// </summary>
    public class Question0623_3
    {
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
                return new TreeNode(val, root, null);

            List<TreeNode> nodes = new List<TreeNode>() { root };
            for (int i = 1; i < depth - 1; i++)
            {
                List<TreeNode> temp = new List<TreeNode>();
                foreach (TreeNode node in nodes)
                {
                    if (node.left != null) temp.Add(node.left);
                    if (node.right != null) temp.Add(node.right);
                }
                nodes = temp;
            }

            foreach (TreeNode node in nodes)
            {
                node.left = new TreeNode(val, node.left, null);
                node.right = new TreeNode(val, null, node.right);
            }

            return root;
        }
    }
}
