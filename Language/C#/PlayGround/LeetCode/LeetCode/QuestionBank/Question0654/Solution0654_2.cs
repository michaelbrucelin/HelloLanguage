using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0654
{
    public class Solution0654_2
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if (nums.Length == 1) return new TreeNode(nums[0]);

            int maxid = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[maxid]) maxid = i;
            }

            TreeNode root = new TreeNode(nums[maxid]);
            root.left = _ConstructMaximumBinaryTree(nums, 0, maxid - 1);
            root.right = _ConstructMaximumBinaryTree(nums, maxid + 1, nums.Length - 1);

            return root;
        }

        public TreeNode _ConstructMaximumBinaryTree(in int[] nums, int left, int right)
        {
            if (left > right) return null;
            if (left == right) return new TreeNode(nums[left]);

            int maxid = left;
            for (int i = left + 1; i <= right; i++)
            {
                if (nums[i] > nums[maxid]) maxid = i;
            }

            TreeNode node = new TreeNode(nums[maxid]);
            node.left = _ConstructMaximumBinaryTree(nums, left, maxid - 1);
            node.right = _ConstructMaximumBinaryTree(nums, maxid + 1, right);

            return node;
        }
    }
}
