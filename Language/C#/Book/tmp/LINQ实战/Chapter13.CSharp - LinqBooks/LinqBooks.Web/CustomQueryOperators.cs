#region Imports

using System;
using System.Collections.Generic;
using System.Linq;

using LinqBooks.Entities;

#endregion Imports

namespace LinqBooks.Web
{
  public static class CustomQueryOperators
  {
    public static TElement MaxElement<TElement, TData>(
      this IEnumerable<TElement> source,
      Func<TElement, TData> selector)
      where TData : IComparable<TData>
    {
      if (source == null)
        throw new ArgumentNullException("source");
      if (selector == null)
        throw new ArgumentNullException("selector");

      TElement result = default(TElement);
      TData maxValue = default(TData);
      foreach (TElement element in source)
      {
        var candidate = selector(element);
        if ((maxValue == null) || ((IComparable)candidate).CompareTo(maxValue) > 0)
        {
          maxValue = candidate;
          result = element;
        }
      }
      return result;
    }

    public static Decimal TotalPrice(this IEnumerable<Book> books)
    {
      if (books == null)
        throw new ArgumentNullException("books");

      Decimal result = 0;
      foreach (Book book in books)
        if ((book != null) && (book.Price.HasValue))
          result += book.Price.Value;
      return result;
    }
  }
}