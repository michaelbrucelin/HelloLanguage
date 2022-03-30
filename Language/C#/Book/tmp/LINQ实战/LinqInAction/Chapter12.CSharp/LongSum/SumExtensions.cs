// Original author: Troy Magennis
// http://aspiring-technology.com/blogs/troym/archive/2006/10/06/24.aspx

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqInAction.Extensibility
{
  public static class SumExtensions
  {
    /// <summary>
    /// Returns the numerical Sum of all of the int's in the source sequence.
    /// </summary>
    /// <param name="source">Source sequence of int's</param>
    /// <returns>The Sum of all the elements in the source sequence.</returns>
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

    /// <summary>
    /// Returns the numerical Sum of all of the int?'s in the source sequence.
    /// </summary>
    /// <param name="source">Source sequence of int?'s</param>
    /// <returns>The Sum of all the elements in the source sequence.</returns>
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

    /// <summary>
    /// Returns the numerical Sum of all of the int?'s in the source sequence.
    /// </summary>
    /// <param name="source">Source sequence of int?'s</param>
    /// <param name="selector">Selector function.</param>
    /// <returns>The Sum of all the elements in the source sequence.</returns>
    public static long LongSum<T>(this IEnumerable<T> source, Func<T, int> selector)
    {
      return LongSum(Enumerable.Select(source, selector));
    }

    /// <summary>
    /// Returns the numerical Sum of all of the int?'s in the source sequence.
    /// </summary>
    /// <param name="source">Source sequence of int?'s</param>
    /// <param name="selector">Selector function.</param>
    /// <returns>The Sum of all the elements in the source sequence.</returns>
    public static long? LongSum<T>(this IEnumerable<T> source, Func<T, int?> selector)
    {
      return LongSum(Enumerable.Select(source, selector));
    }
  }
}