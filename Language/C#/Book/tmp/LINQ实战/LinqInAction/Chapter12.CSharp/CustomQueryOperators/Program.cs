using System;
using System.Collections.Generic;
using System.Linq;

using LinqInAction.LinqBooks.Common;
using LinqInAction.Extensibility;

namespace Chapter12.CustomQueryOperators
{
  class Program
  {
    static void Main(string[] args)
    {
      // Using the TotalPrice custom query operator
      var publishers =
        from publisher in SampleData.Publishers
        join book in SampleData.Books on publisher equals book.Publisher into pubBooks
        select new { Publisher = publisher.Name, TotalPrice = pubBooks.TotalPrice() };
      ObjectDumper.Write(publishers);
      Console.WriteLine("TotalPrice = " + SampleData.Books.TotalPrice());

      // Using the Min custom query operator
      Book minBook = SampleData.Books.Min();
      Console.WriteLine("Book with the lowest number of pages = {0} ({1} pages)",
        minBook.Title, minBook.PageCount);

      // Using the Books custom query operator
      var publishers2 =
        from publisher in SampleData.Publishers
        select new {
          Publisher = publisher.Name,
          TotalPrice = publisher.Books(SampleData.Books).TotalPrice()
        };
      ObjectDumper.Write(publishers2);

      // Using the IsExpensive custom query operator
      var books =
        from book in SampleData.Books
        group book.Title by book.IsExpensive() into bookGroup
        select new { Expensive = bookGroup.Key, Books = bookGroup };

      ObjectDumper.Write(books, 1);
    }
  }
}
