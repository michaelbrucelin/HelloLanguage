using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 字典树，前缀树，Trie
    /// </summary>
    public class Trie
    {
        public Trie()
        {
            _root = new TrieNode('\0');  // 根节点值可以是任意字符，这里使用 '\0' 表示
        }

        private readonly TrieNode _root;

        public void Insert(string word)
        {
            TrieNode ptr = _root;
            foreach (char c in word)
            {
                if (!ptr.Children.ContainsKey(c)) ptr.Children[c] = new TrieNode(c);
                ptr = ptr.Children[c];
            }
            ptr.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode node = FindNode(word);
            return node != null && node.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            return FindNode(prefix) != null;
        }

        private TrieNode FindNode(string word)
        {
            TrieNode ptr = _root;
            foreach (char c in word)
            {
                if (!ptr.Children.ContainsKey(c)) return null;
                ptr = ptr.Children[c];
            }
            return ptr;
        }
    }
}
