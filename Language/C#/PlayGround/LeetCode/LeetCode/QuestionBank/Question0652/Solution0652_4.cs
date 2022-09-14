using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0652
{
    public class Solution0652_4 : Interface0652
    {
        private Dictionary<(int, int, int), (TreeNode node, int key)> dic;
        private HashSet<TreeNode> set;
        private int index;

        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            dic = new Dictionary<(int, int, int), (TreeNode node, int key)>();
            set = new HashSet<TreeNode>();
            index = 0;

            GetTreeKey(root);

            return new List<TreeNode>(set);
        }

        private int GetTreeKey(TreeNode root)
        {
            if (root == null) return 0;

            (int, int, int) key = (root.val, GetTreeKey(root.left), GetTreeKey(root.right));

            if (dic.ContainsKey(key))
            {
                set.Add(dic[key].node);
                return dic[key].key;
            }
            else
            {
                dic.Add(key, (root, ++index));
                return index;
            }
        }
    }
}
