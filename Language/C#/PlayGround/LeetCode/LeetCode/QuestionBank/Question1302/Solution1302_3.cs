using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1302
{
    public class Solution1302_3
    {
        public int DeepestLeavesSum(TreeNode root)
        {
            int result = 0;

            Queue<TreeNode> buffer = new Queue<TreeNode>();
            buffer.Enqueue(root);
            while (buffer.Count > 0)
            {
                result = 0;
                int levelcnt = buffer.Count;
                while (levelcnt-- > 0)
                {
                    TreeNode node = buffer.Dequeue();
                    result += node.val;
                    if (node.left != null) buffer.Enqueue(node.left);
                    if (node.right != null) buffer.Enqueue(node.right);
                }
            }

            return result;
        }
    }
}
