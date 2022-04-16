using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempTestCSharp
{
    public static class SumExtensions
    {
        public static long LongSum(this IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            long sum = 0;
            checked
            {
                foreach (int v in source)
                    sum += v;
            }

            return sum;
        }

        public static long? LongSum(this IEnumerable<int?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            long? sum = 0;
            checked
            {
                foreach (int? v in source)
                    if (v != null)
                        sum += v;
            }

            return sum;
        }

        public static long LongSum<T>(this IEnumerable<T> source, Func<T, int> selector)
        {
            return SumExtensions.LongSum(Enumerable.Select(source, selector));
        }

        public static long? LongSum<T>(this IEnumerable<T> source, Func<T, int?> selector)
        {
            return SumExtensions.LongSum(Enumerable.Select(source, selector));
        }
    }
}
