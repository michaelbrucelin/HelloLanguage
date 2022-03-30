// Import System.Linq instead of LinqInAction.Extensibility if you want to use the default implementation

//using System.Linq;
using LinqInAction.Extensibility;
using LinqInAction.LinqBooks.Common;

class TestCustomImplementation
{
  static void Main()
  {
    var books =
      from book in SampleData.Books
      where book.Price < 30
      select book.Title;

    ObjectDumper.Write(books);
  }
}

