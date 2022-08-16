using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1656
{
    public class Solution1656
    {
        public void Test()
        {
            OrderedStream os = new OrderedStream(5);
            Console.WriteLine(ListToString(os.Insert(3, "ccccc")));  // 插入 (3, "ccccc")，返回 []
            Console.WriteLine(ListToString(os.Insert(1, "aaaaa")));  // 插入 (1, "aaaaa")，返回 ["aaaaa"]
            Console.WriteLine(ListToString(os.Insert(2, "bbbbb")));  // 插入 (2, "bbbbb")，返回 ["bbbbb", "ccccc"]
            Console.WriteLine(ListToString(os.Insert(5, "eeeee")));  // 插入 (5, "eeeee")，返回 []
            Console.WriteLine(ListToString(os.Insert(4, "ddddd")));  // 插入 (4, "ddddd")，返回 ["ddddd", "eeeee"]
        }

        private string ListToString(IList<string> list)
        {
            if (list.Count == 0)
                return "[]";

            return $"[{list.Select(s => $"\"{s}\"").Aggregate((s1, s2) => $"{s1}, {s2}")}]";
        }
    }

    /**
    * Your OrderedStream object will be instantiated and called as such:
    * OrderedStream obj = new OrderedStream(n);
    * IList<string> param_1 = obj.Insert(idKey,value);
    */
    public class OrderedStream
    {

        public OrderedStream(int n)
        {
            arr = new string[n];
        }

        private string[] arr;
        private int pointer = 0;

        public IList<string> Insert(int idKey, string value)
        {
            arr[idKey - 1] = value;

            List<string> result = new List<string>();
            for (int i = pointer; i < arr.Length && arr[i] != null; i++, pointer++)
                result.Add(arr[i]);

            return result;
        }
    }
}
