Imports LinqInAction.LinqBooks.Common

Module Module1

  Sub Main()
    ' VB does not seem to like our non-sequence query operator in a query expression
    'Dim books = _
    '  From publisher In SampleData.Publishers(0) _
    '  Group Join book In SampleData.Books On publisher Equals book.Publisher Into bookGroup = Group _
    '  Select New With {.Publisher = publisher.Name, .Books = bookGroup}
    Dim books = _
      SampleData.Publishers(0) _
        .GroupJoin(SampleData.Books, _
           Function(publisher) publisher, _
           Function(book) book.Publisher, _
           Function(publisher, bookGroup) New With {.Publisher = publisher.Name, .Books = bookGroup})

    ObjectDumper.Write(books, 1)
  End Sub

End Module