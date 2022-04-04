Imports LinqInAction.LinqBooks.Common

Module Module1

  Sub Main()
    Dim books As Book() = { _
      New Book With {.Title = "LINQ in Action"}, _
      New Book With {.Title = "LINQ for Fun"}, _
      New Book With {.Title = "Extreme LINQ"}}

    Dim titles = _
      books _
        .Where(Function(book) book.Title.Contains("Action")) _
        .Select(Function(book) book.Title)

    ObjectDumper.Write(titles)
  End Sub

End Module