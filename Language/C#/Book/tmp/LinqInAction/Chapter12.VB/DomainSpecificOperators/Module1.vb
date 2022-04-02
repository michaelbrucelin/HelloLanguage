Imports LinqInAction.LinqBooks.Common
Imports LinqInAction.Chapter12.DomainSpecificOperators.QueryOperators

Module Module1

  Sub Main()
    ' Order By is performed by the standard implementation from System.Linq.Enumerable
    Dim books = _
      From book In SampleData.Books _
      Where book.Price < 30 _
      Order By book.Title _
      Select book.Title

    ObjectDumper.Write(books)
  End Sub

End Module