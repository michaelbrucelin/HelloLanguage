using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using LinqInAction.LinqBooks.Common;

static class TestConversionOperators
{
  static void Main()
  {
    IEnumerable<String> titles = SampleData.Books.Select(book => book.Title);

    Console.WriteLine("ToArray:");
    String[] array = titles.ToArray();
    ObjectDumper.Write(array);

    Console.WriteLine();

    Console.WriteLine("ToList:");
    List<String> list = titles.ToList();
    ObjectDumper.Write(list);

    Console.WriteLine();

    Console.WriteLine("ToDictionary:");
    Dictionary<String, Book> isbnRef = SampleData.Books.ToDictionary(book => book.Isbn);
    Book linqRules = isbnRef["0-111-77777-2"];
    Console.WriteLine("Book found: " + linqRules);
  }
}