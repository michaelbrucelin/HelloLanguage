using System;
using System.Collections.Generic;
using System.Linq;

using LinqInAction.Extensibility;
using LinqInAction.LinqBooks.Common;

namespace Chapter12.NonSequenceOperator
{
  class Program
  {
    static void Main(string[] args)
    {
      var books =
        from publisher in SampleData.Publishers[0]
        join book in SampleData.Books on publisher equals book.Publisher into bookGroup
        select new { Publisher = publisher.Name, Books = bookGroup };

      ObjectDumper.Write(books, 1);
    }
  }
}