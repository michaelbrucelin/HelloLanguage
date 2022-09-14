using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0654
{
    public class Solution0654 : Interface0654
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;
            if (nums.Length == 1) return new TreeNode(nums[0]);

            int maxid = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[maxid]) maxid = i;
            }

            TreeNode root = new TreeNode(nums[maxid]);
            root.left = ConstructMaximumBinaryTree(nums.Where((i, id) => id < maxid).ToArray());
            root.right = ConstructMaximumBinaryTree(nums.Where((i, id) => id > maxid).ToArray());

            return root;
        }
    }
}
