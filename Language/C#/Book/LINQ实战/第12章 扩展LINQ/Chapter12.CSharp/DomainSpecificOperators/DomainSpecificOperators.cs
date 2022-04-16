using System;
using System.Collections.Generic;
using System.Linq;

using LinqInAction.LinqBooks.Common;

namespace LinqInAction.Extensibility
{
    static class DomainSpecificOperators
    {
        /// <summary>
        /// Domain-specific implementation of Where.
        /// Here we work on a sequence of <see cref="Book"/> objects.
        /// </summary>
        public static IEnumerable<Book> Where(this IEnumerable<Book> source, Func<Book, Boolean> predicate)
        {
            foreach (Book book in source)
            {
                Console.WriteLine("processing book \"{0}\" in DomainSpecificOperators.Where", book.Title);
                if (predicate(book))
                    yield return book;
            }
        }

        /// <summary>
        /// Domain-specific implementation of Select.
        /// Here we work on a sequence of <see cref="Book"/> objects.
        /// </summary>
        public static IEnumerable<TResult> Select<TResult>(this IEnumerable<Book> source, Func<Book, TResult> selector)
        {
            foreach (Book book in source)
            {
                Console.WriteLine("processing book \"{0}\" in DomainSpecificOperators.Select<TResult>", book.Title);
                yield return selector(book);
            }
        }
    }
}