Imports LinqInAction.LinqBooks.Common

Module Module1

  Sub Main()
    ' The VB language offers more keywords mapped to query operators. This includes Take and Distinct.
    ' Consequently, the query we wrote in C# can be written completely in VB as a query expression without having to resort to query operators
    Dim authors = _
      From distinctAuthor In ( _
        From book In SampleData.Books _
        Where book.Title.Contains("LINQ") _
        From author In Book.Authors _
        Take 1 _
        Select author) _
      Distinct _
      Select New With {distinctAuthor.FirstName, distinctAuthor.LastName}

    Console.WriteLine("Query expression with operators:")
    For Each author In authors
      Console.WriteLine(author)
    Next
  End Sub

End Module