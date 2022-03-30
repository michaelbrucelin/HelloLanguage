using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using LinqInAction.LinqBooks.Common;

static class TestDistinct
{
  static void WithoutDistinct()
  {
    var authors = 
      SampleData.Books
        .SelectMany(book => book.Authors)
        .Select(author => author.FirstName+" "+author.LastName);
    ObjectDumper.Write(authors);
  }

  static void WithDistinct()
  {
    var authors =
    SampleData.Books
      .SelectMany(book => book.Authors)
      .Distinct()
      .Select(author => author.FirstName + " " + author.LastName);
    ObjectDumper.Write(authors);
  }

  static void Main()
  {
    Console.WriteLine("Without Distinct:");
    WithoutDistinct();

    Console.WriteLine();
    
    Console.WriteLine("With Distinct:");
    WithDistinct();
  }
}