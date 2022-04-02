Imports LinqInAction.LinqBooks.Common

Module Module1

  Sub Main()
    Dim titles As IEnumerable(Of String) = SampleData.Books.Select(Function(book) book.Title)

    Console.WriteLine("ToArray:")
    Dim array As String() = titles.ToArray()
    ObjectDumper.Write(array)

    Console.WriteLine()

    Console.WriteLine("ToList:")
    Dim list As List(Of String) = titles.ToList()
    ObjectDumper.Write(list)

    Console.WriteLine()

    Console.WriteLine("ToDictionary:")
    Dim isbnRef As Dictionary(Of String, Book) = SampleData.Books.ToDictionary(Function(book) book.Isbn)
    Dim linqRules As Book = isbnRef("0-111-77777-2")
    Console.WriteLine("Book found: " + linqRules.ToString())
  End Sub

End Module