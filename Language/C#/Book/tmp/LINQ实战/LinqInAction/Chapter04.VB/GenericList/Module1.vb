Imports LinqInAction.LinqBooks.Common

Module Module1

  Sub Main()
    Dim books As List(Of Book) = New List(Of Book)()
    books.Add(New Book With {.Title = "LINQ in Action"})
    books.Add(New Book With {.Title = "LINQ for Fun"})
    books.Add(New Book With {.Title = "Extreme LINQ"})

    Dim titles = _
      books _
        .Where(Function(book) book.Title.Contains("Action")) _
        .Select(Function(book) book.Title)

    ObjectDumper.Write(titles)
  End Sub

End Module