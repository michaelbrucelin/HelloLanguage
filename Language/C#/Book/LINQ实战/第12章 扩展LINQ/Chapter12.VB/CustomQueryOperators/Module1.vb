Imports LinqInAction.LinqBooks.Common
Imports LinqInAction.Chapter12.CustomQueryOperators.QueryOperators

Module Module1

  Sub Main()
    ' Using the TotalPrice custom query operator
    Dim publishers = _
      From publisher In SampleData.Publishers _
      Group Join book In SampleData.Books On publisher Equals book.Publisher Into pubBooks = Group _
      Select New With {.Publisher = publisher.Name, .TotalPrice = pubBooks.TotalPrice()}
    ObjectDumper.Write(publishers)
    Console.WriteLine("TotalPrice = " & SampleData.Books.TotalPrice())

    ' Using the Min custom query operator
    Dim minBook As Book = SampleData.Books.Min()
    Console.WriteLine("Book with the lowest number of pages = {0} ({1} pages)", _
      minBook.Title, minBook.PageCount)

    ' Using the Books custom query operator
    Dim publishers2 = _
      From publisher In SampleData.Publishers _
      Select New With { _
        .Publisher = publisher.Name, _
        .TotalPrice = publisher.Books(SampleData.Books).TotalPrice() _
      }
    ObjectDumper.Write(publishers2)

    ' Using the IsExpensive custom query operator
    Dim books = _
      From book In SampleData.Books _
      Group book.Title By Key = book.IsExpensive() Into bookGroup = Group _
      Select New With {.Expensive = Key, .Books = bookGroup}

    ObjectDumper.Write(books, 1)
  End Sub

End Module
