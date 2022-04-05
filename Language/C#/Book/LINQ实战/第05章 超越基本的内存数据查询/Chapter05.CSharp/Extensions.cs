using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqInAction.Chapter05
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> func)
        {
            foreach (var item in source)
                func(item);
        }

        public static TElement MaxElement<TElement, TData>(this IEnumerable<TElement> source, Func<TElement, TData> selector) where TData : IComparable<TData>
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (selector == null)
                throw new ArgumentNullException("selector");

            Boolean firstElement = true;
            TElement result = default(TElement);
            TData maxValue = default(TData);
            foreach (TElement element in source)
            {
                var candidate = selector(element);
                if (firstElement || (candidate.CompareTo(maxValue) > 0))
                {
                    firstElement = false;
                    maxValue = candidate;
                    result = element;
                }
            }
            return result;
        }
    }
}