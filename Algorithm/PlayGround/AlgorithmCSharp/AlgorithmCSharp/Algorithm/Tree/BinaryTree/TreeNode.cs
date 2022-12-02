using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Tree.BinaryTree
{
    public class TreeNode
    {
        public TreeNode(char value, TreeNode left = null, TreeNode right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public char Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}
