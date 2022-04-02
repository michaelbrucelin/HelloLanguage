Imports LinqInAction.LinqBooks.Common

Module Module1

  Sub Main()
    Dim books = _
      SampleData.Books _
        .Select(Function(book, index) New With {index, book.Title}) _
        .OrderBy(Function(book) book.Title)
    ObjectDumper.Write(books)
  End Sub

End Module