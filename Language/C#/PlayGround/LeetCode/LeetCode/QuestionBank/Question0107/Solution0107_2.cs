using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0107
{
    public class Solution0107_2 : Interface0107
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            List<IList<int>> result = new List<IList<int>>();

            DFS(root, 0, result);
            result.Reverse();

            return result;
        }

        private void DFS(TreeNode node, int level, List<IList<int>> list)
        {
            if (level >= list.Count) list.Add(new List<int>());  // 一层一层向下，所以不用考虑index，直接加一项就可以

            list[level].Add(node.val);
            if (node.left != null) DFS(node.left, level + 1, list);
            if (node.right != null) DFS(node.right, level + 1, list);
        }
    }
}
