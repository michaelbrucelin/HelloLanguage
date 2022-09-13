using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0107
{
    public class Solution0107 : Interface0107
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            Stack<List<int>> result = new Stack<List<int>>();
            Queue<TreeNode> buffer = new Queue<TreeNode>();
            buffer.Enqueue(root);
            while (buffer.Count > 0)
            {
                int cnt = buffer.Count;
                List<int> list = new List<int>();
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = buffer.Dequeue();
                    list.Add(node.val);
                    if (node.left != null) buffer.Enqueue(node.left);
                    if (node.right != null) buffer.Enqueue(node.right);
                }
                result.Push(list);
            }

            return new List<IList<int>>(result);
        }
    }
}
