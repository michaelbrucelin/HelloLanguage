using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    /// <summary>
    /// 实现了一个简单的后缀数组
    /// </summary>
    public class SuffixArray
    {
        public SuffixArray(string inputText)
        {
            text = inputText;
            BuildSuffixArray();
        }

        private string text;
        private int[] suffixArray;

        // 构建后缀数组
        private void BuildSuffixArray()
        {
            int n = text.Length;
            suffixArray = Enumerable.Range(0, n).ToArray();
            Array.Sort(suffixArray, (x, y) => string.Compare(text.Substring(x), text.Substring(y), StringComparison.Ordinal));
        }

        // 获取后缀数组
        public int[] GetSuffixArray()
        {
            return suffixArray;
        }

        // 输出后缀数组
        public void PrintSuffixArray()
        {
            Console.WriteLine("Suffix Array:");
            foreach (var index in suffixArray)
            {
                Console.WriteLine(index + ": " + text.Substring(index));
            }
        }
    }
    /*
    public static void Main(string[] args)
    {
        string text = "banana";
        SuffixArray suffixArray = new SuffixArray(text);
        suffixArray.PrintSuffixArray();
    }
    */
}
