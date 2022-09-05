using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0652
{
    public class Solution0652_3
    {
        private Dictionary<string, TreeNode> dic;
        private HashSet<TreeNode> set;

        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            dic = new Dictionary<string, TreeNode>();
            set = new HashSet<TreeNode>();

            GetTreeKey(root);

            return new List<TreeNode>(set);
        }

        private string GetTreeKey(TreeNode root)
        {
            if (root == null) return "null";

            string leftChild = GetTreeKey(root.left);
            string rightChild = GetTreeKey(root.right);
            string key = $"{root.val}-{leftChild}-{rightChild}";

            if (dic.ContainsKey(key))
                set.Add(dic[key]);
            else
                dic.Add(key, root);

            return key;
        }
    }
}
