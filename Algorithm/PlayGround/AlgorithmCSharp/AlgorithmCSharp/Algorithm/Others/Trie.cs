using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现了字典树，前缀树，Trie
    /// </summary>
    public class Trie
    {
        public Trie()
        {
            Root = new TrieNode('\0');  // 根节点值可以是任意字符，这里使用 '\0' 表示
        }

        public readonly TrieNode Root;

        public void Insert(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                Root.IsEndOfWord = true;
                return;
            }

            TrieNode ptr = Root;
            foreach (char c in word)
            {
                if (!ptr.Children.ContainsKey(c)) ptr.Children[c] = new TrieNode(c);
                ptr = ptr.Children[c];
            }
            ptr.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            if (string.IsNullOrEmpty(word)) return Root.IsEndOfWord;

            TrieNode node = FindNode(word);

            return node != null && node.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            if (string.IsNullOrEmpty(prefix)) return true;  // 所有字符串都以空字符串作为前缀

            return FindNode(prefix) != null;
        }

        private TrieNode FindNode(string word)
        {
            TrieNode ptr = Root;
            foreach (char c in word)
            {
                if (!ptr.Children.ContainsKey(c)) return null;
                ptr = ptr.Children[c];
            }

            return ptr;
        }
    }
    /*
    public static void Main(string[] args)
    {
        Trie trie = new Trie();
        
        // 插入单词
        trie.Insert("apple");
        trie.Insert("banana");
        trie.Insert("orange");

        // 搜索单词
        Console.WriteLine(trie.Search("apple"));   // 输出: True
        Console.WriteLine(trie.Search("orange"));  // 输出: True
        Console.WriteLine(trie.Search("pear"));    // 输出: False

        // 搜索前缀
        Console.WriteLine(trie.StartsWith("app"));    // 输出: True
        Console.WriteLine(trie.StartsWith("ban"));    // 输出: True
        Console.WriteLine(trie.StartsWith("peach"));  // 输出: False
    }
    */
}
