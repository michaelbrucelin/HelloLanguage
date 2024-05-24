using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    public class TrieNode
    {
        public TrieNode(char value)
        {
            Value = value;
            Children = new Dictionary<char, TrieNode>();
            IsEndOfWord = false;
        }

        public char Value { get; }
        public Dictionary<char, TrieNode> Children { get; }
        public bool IsEndOfWord { get; set; }
    }
}
