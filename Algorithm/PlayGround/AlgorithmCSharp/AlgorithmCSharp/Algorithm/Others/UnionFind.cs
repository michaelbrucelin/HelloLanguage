using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Others
{
    public class UnionFind<T> : IEnumerable<T> where T : IComparable<T>
    {
        public UnionFind()
        {
            nodes = new Dictionary<T, UnionFindNode<T>>();
        }

        private Dictionary<T, UnionFindNode<T>> nodes;

        public int Count { get { return nodes.Count; } }

        public IEnumerator<T> GetEnumerator()
        {
            return nodes.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return nodes.Keys.GetEnumerator();
        }

        public bool Contains(T data)
        {
            return nodes.ContainsKey(data);
        }

        public bool Make(T data)
        {
            if (Contains(data)) return false;

            nodes.Add(data, new UnionFindNode<T>(data));

            return true;
        }

        public bool Union(T dataA, T dataB)
        {
            var nodeA = nodes[dataA];
            var nodeB = nodes[dataB];

            var parentA = nodeA.Parent;
            var parentB = nodeB.Parent;

            if (parentA == parentB) return false;

            if (parentA.Rank >= parentB.Rank)
            {
                if (parentA.Rank == parentB.Rank) ++parentA.Rank;

                parentB.Parent = parentA;
            }
            else
            {
                parentA.Parent = parentB;
            }

            return true;
        }

        public T Find(T data)
        {
            return Find(nodes[data]).Data;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Clear()
        {
            nodes.Clear();
        }

        private UnionFindNode<T> Find(UnionFindNode<T> node)
        {
            var parent = node.Parent;
            if (parent == node) return node;

            node.Parent = Find(node.Parent);

            return node.Parent;
        }
    }
}
