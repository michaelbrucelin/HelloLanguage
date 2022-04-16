using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp0
{
    /// <summary>
    /// 自己实现一个Linq类
    /// </summary>
    public static class MyUtilsLinqImplementation
    {
        //实现Linq的Where方法
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        //实现Linq的Select方法
        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            int index = 0;
            foreach (TSource item in source)
            {
                yield return selector(item, index++);
            }
        }

        //实现Linq的Any方法
        public static bool MyAny<T>(this IEnumerable<T> sequence)
        {
            return sequence.GetEnumerator().MoveNext();
        }

        public static bool MyAny<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            return sequence.MyWhere(predicate).GetEnumerator().MoveNext();
        }

        //实现Linq的All方法
        public static bool MyAll<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            return !sequence.MyAny(i => !predicate(i));
        }

        //实现Linq的Count方法
        public static int MyCount<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach (T item in sequence)
            {
                count++;
            }

            return count;
        }

        public static int MyCount<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
        {
            return sequence.MyWhere(predicate).MyCount();
        }

        //实现Linq的Sum方法
        public static decimal? MySum(this IEnumerable<decimal?> sequence)
        {
            decimal sum = 0;
            foreach (decimal? item in sequence)
            {
                if (item != null)
                {
                    sum += (decimal)item;
                }
            }

            return sum;
        }

        public static decimal MySum(this IEnumerable<decimal> sequence)
        {
            decimal sum = 0;
            foreach (decimal item in sequence)
            {
                sum += item;
            }

            return sum;
        }

        public static double? MySum(this IEnumerable<double?> sequence)
        {
            double sum = 0;
            foreach (double? item in sequence)
            {
                if (item != null)
                {
                    sum += (double)item;
                }
            }

            return sum;
        }

        public static double MySum(this IEnumerable<double> sequence)
        {
            double sum = 0;
            foreach (double item in sequence)
            {
                sum += item;
            }

            return sum;
        }

        public static float? MySum(this IEnumerable<float?> sequence)
        {
            float sum = 0;
            foreach (float? item in sequence)
            {
                if (item != null)
                {
                    sum += (float)item;
                }
            }

            return sum;
        }

        public static float MySum(this IEnumerable<float> sequence)
        {
            float sum = 0;
            foreach (float item in sequence)
            {
                sum += item;
            }

            return sum;
        }

        public static int? MySum(this IEnumerable<int?> sequence)
        {
            int sum = 0;
            foreach (int? item in sequence)
            {
                if (item != null)
                {
                    sum += (int)item;
                }
            }

            return sum;
        }

        public static int MySum(this IEnumerable<int> sequence)
        {
            int sum = 0;
            foreach (int item in sequence)
            {
                sum += item;
            }

            return sum;
        }

        public static long? MySum(this IEnumerable<long?> sequence)
        {
            long sum = 0;
            foreach (long? item in sequence)
            {
                if (item != null)
                {
                    sum += (long)item;
                }
            }

            return sum;
        }

        public static long MySum(this IEnumerable<long> sequence)
        {
            long sum = 0;
            foreach (long item in sequence)
            {
                sum += item;
            }

            return sum;
        }

        //实现Linq更通用的聚合方法
        public static int MyAggregate(this IEnumerable<int> sequence, int seed, Func<int, int, int> func)
        {
            //int agg = default(int);
            int agg = seed;
            foreach (int item in sequence)
            {
                agg = func(agg, item);
            }

            return agg;
        }

        public static T MyAggregate<T>(this IEnumerable<T> sequence, T seed, Func<T, T, T> func)
        {
            //T agg = default(T);
            T agg = seed;
            foreach (T item in sequence)
            {
                agg = func(agg, item);
            }

            return agg;
        }

        public static TAccumulate MyAggregate<TSource, TAccumulate>(this IEnumerable<TSource> sequence, Func<TAccumulate, TSource, TAccumulate> func)
        {
            TAccumulate agg = default(TAccumulate);
            foreach (var item in sequence)
            {
                agg = func(agg, item);
            }

            return agg;
        }

        public static TAccumulate MyAggregate<TSource, TAccumulate>(this IEnumerable<TSource> sequence, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            TAccumulate agg = seed;
            foreach (var item in sequence)
            {
                agg = func(agg, item);
            }

            return agg;
        }

        public static int MyAggregate2(this IEnumerable<int> sequence, Func<int, int, int> func)
        {
            IEnumerator<int> enumerator = sequence.GetEnumerator();
            enumerator.MoveNext();
            int agg = enumerator.Current;
            while (enumerator.MoveNext())
            {
                agg = func(agg, enumerator.Current);
            }

            return agg;
        }

        public static T MyAggregate2<T>(this IEnumerable<T> sequence, Func<T, T, T> func)
        {
            IEnumerator<T> enumerator = sequence.GetEnumerator();
            enumerator.MoveNext();
            T agg = enumerator.Current;
            while (enumerator.MoveNext())
            {
                agg = func(agg, enumerator.Current);
            }

            return agg;
        }

        //实现Linq的OrderBy方法
        //public static MyOrderedEnumerable<T, TKey> MyOrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> comparer)
        //    where TKey : IComparable<TKey>
        //{
        //    return new MyOrderedEnumerable<T, TKey>(source, comparer);
        //}

        public static IOrderingImpl<T> MyOrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> comparer) where TKey : IComparable<TKey>
        {
            return new MyOrderedEnumerable<T, TKey>(source, comparer);
        }

        public static IOrderingImpl<T> MyThenBy<T, TKey>(this IOrderingImpl<T> source, Func<T, TKey> comparer) where TKey : IComparable<TKey>
        {
            return new MyOrderedEnumerable<T, TKey>(source, comparer);
        }

        //实现Linq的SelectMany方法
        public static IEnumerable<TOutput> MySelectMany<T1, T2, TOutput>(this IEnumerable<T1> src, Func<T1, IEnumerable<T2>> inputSelector, Func<T1, T2, TOutput> resultSelector)
        {
            foreach (T1 first in src)
            {
                foreach (T2 second in inputSelector(first))
                {
                    yield return resultSelector(first, second);
                }
            }
        }
    }

    public interface IOrderingImpl<T> : IEnumerable<T>
    {
        int CompareTo(T left, T right);
        IEnumerable<T> OriginalSource { get; }
    }

    public class MyOrderedEnumerable<T, TKey> : IOrderingImpl<T>, IEnumerable<T> where TKey : IComparable<TKey>
    {
        private Comparison<T> comparison;
        private IEnumerable<T> source;

        public MyOrderedEnumerable(IOrderingImpl<T> source, Func<T, TKey> comparer)
        {
            this.source = source;
            comparison = (a, b) =>
            {
                var originalComparison = source.CompareTo(a, b);
                if (originalComparison != 0)
                    return originalComparison;
                else
                    return comparer(a).CompareTo(comparer(b));
            };
        }

        public MyOrderedEnumerable(IEnumerable<T> source, Func<T, TKey> comparer)
        {
            this.source = source;
            comparison = (a, b) => comparer(a).CompareTo(comparer(b));
        }

        public IEnumerable<T> OriginalSource
        {
            get
            {
                return source;
            }
        }

        public int CompareTo(T left, T right)
        {
            return comparison(left, right);
        }

        public IEnumerator<T> GetEnumerator()
        {
            // very poor implementation, but works:
            List<T> sorted = source.ToList();
            sorted.Sort(comparison);
            return sorted.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}