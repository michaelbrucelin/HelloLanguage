using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqInAction.Extensibility
{
    public static class CustomImplementation
    {
        /// <summary>
        /// Custom implementation of Where with the standard generic signature.
        /// </summary>
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, Boolean> predicate)
        {
            Console.WriteLine("in CustomImplementation.Where<TSource>");
            return Enumerable.Where(source, predicate);
        }

        /// <summary>
        /// Custom implementation of Select with the standard generic signature.
        /// </summary>
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            Console.WriteLine("in CustomImplementation.Select<TSource, TResult>");
            return Enumerable.Select(source, selector);
        }
    }
}