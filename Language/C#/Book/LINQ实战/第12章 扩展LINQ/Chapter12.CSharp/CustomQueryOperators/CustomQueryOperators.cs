using System;
using System.Collections.Generic;
using System.Linq;

using LinqInAction.LinqBooks.Common;

namespace LinqInAction.Extensibility
{
    public static class CustomQueryOperators
    {
        public static Decimal TotalPrice(this IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException("books");

            Decimal result = 0;
            foreach (Book book in books)
                if (book != null)
                    result += book.Price;
            return result;
        }

        /// <summary>
        /// Domain-specific implementation of Min.
        /// Here we work on a sequence of <see cref="Book"/> objects and return a <see cref="Book"/>.
        /// </summary>
        /// <remarks>We consider the result is the book that has the lowest number of pages.</remarks>
        public static Book Min(this IEnumerable<Book> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            Book result = null;
            foreach (Book book in source)
            {
                if ((result == null) || (book.PageCount < result.PageCount))
                    result = book;
            }
            return result;
        }

        /// <summary>
        /// Returns a publisher's books from a sequence of books.
        /// </summary>
        static public IEnumerable<Book> Books(this Publisher publisher,
          IEnumerable<Book> books)
        {
            return books.Where(book => book.Publisher == publisher);
        }

        public static Boolean IsExpensive(this Book book)
        {
            if (book == null)
                throw new ArgumentNullException("book");

            // Consider a book as expensive if its price is high or
            // the number of pages is low considering the price
            return (book.Price > 50) || ((book.Price / book.PageCount) > 0.10M);
        }
    }
}