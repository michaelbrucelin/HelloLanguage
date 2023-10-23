using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    public class UnionFindNode<T> where T : IComparable<T>
    {
        public UnionFindNode(T data)
        {
            Data = data;
            Parent = this;
            Rank = 0;
        }

        public T Data { get; set; }
        public UnionFindNode<T> Parent { get; set; }
        public int Rank { get; set; }
    }
}
