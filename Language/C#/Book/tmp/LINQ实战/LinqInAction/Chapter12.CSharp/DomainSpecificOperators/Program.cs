// Uncomment "using System.Linq" to be able to use orderby

//using System.Linq;
using LinqInAction.Extensibility;
using LinqInAction.LinqBooks.Common;

static class TestDomainSpecificOperators
{
  static void Main()
  {
    var books =
      from book in SampleData.Books
      where book.Price < 30
      //orderby book.Title
      select book.Title;

    ObjectDumper.Write(books);
  }
}