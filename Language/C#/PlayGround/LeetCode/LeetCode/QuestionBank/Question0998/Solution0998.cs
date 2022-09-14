using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0998
{
    public class Solution0998 : Interface0998
    {
        /// <summary>
        /// 题目实在难懂
        /// 就是向最大树root中添加一值为val的节点，如果val大于root的值，那么就把root当做值为val节点左孩子，否则，就把val插入到右孩子的相应位置。
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertIntoMaxTree(TreeNode root, int val)
        {
            if (root == null || val > root.val)
                return new TreeNode(val, root, null);
            else
            {
                root.right = InsertIntoMaxTree(root.right, val);
                return root;
            }
        }
    }
}
