using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0094
{
    public class Solution0094_2 : Interface0094
    {
        /// <summary>
        /// 迭代
        /// 根节点入栈 --> 左节点入栈 --> ... 到达最左侧的叶子结点
        /// 出栈一个节点，并输出该节点，然后将该节点的右节点作为新的根节点，重复步骤1
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();

            List<int> result = new List<int>();
            Stack<TreeNode> buffer = new Stack<TreeNode>();
            TreeNode node = root;
            while (node != null)
            {
                if (node.left != null) { buffer.Push(node); node = node.left; }
                else
                {
                    result.Add(node.val);
                    if (node.right != null) node = node.right;
                    else
                    {
                        node = null;
                        while (buffer.Count > 0)
                        {
                            TreeNode node1 = buffer.Pop();
                            result.Add(node1.val);
                            if (node1.right != null) { node = node1.right; break; }
                        }
                    }
                }
            }

            return result;
        }
    }
}
