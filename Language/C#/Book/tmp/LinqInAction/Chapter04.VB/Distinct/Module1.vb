Imports LinqInAction.LinqBooks.Common

Module Module1

  Sub WithoutDistinct()
    'Dim authors = _
    '  SampleData.Books _
    '    .SelectMany(Function(book) book.Authors) _
    '    .Select(Function(author) author.FirstName + " " + author.LastName)
    Dim authors = _
      From book In SampleData.Books _
      From author In book.Authors _
      Select author.FirstName + " " + author.LastName
    ObjectDumper.Write(authors)
  End Sub

  Sub WithDistinct()
    'Dim authors = _
    '  SampleData.Books _
    '    .SelectMany(Function(book) book.Authors) _
    '    .Distinct() _
    '    .Select(Function(author) author.FirstName + " " + author.LastName)
    Dim authors = _
      From book In SampleData.Books _
      From author In book.Authors _
      Select author.FirstName + " " + author.LastName _
      Distinct
    ObjectDumper.Write(authors)
  End Sub

  Sub Main()
    Console.WriteLine("Without Distinct:")
    WithoutDistinct()

    Console.WriteLine()

    Console.WriteLine("With Distinct:")
    WithDistinct()
  End Sub

End Module