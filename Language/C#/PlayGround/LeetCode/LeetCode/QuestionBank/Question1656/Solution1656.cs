using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1656
{
    public class Solution1656
    {

    }

    /**
    * Your OrderedStream object will be instantiated and called as such:
    * OrderedStream obj = new OrderedStream(n);
    * IList<string> param_1 = obj.Insert(idKey,value);
    */
    public class OrderedStream : Interface1656
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
