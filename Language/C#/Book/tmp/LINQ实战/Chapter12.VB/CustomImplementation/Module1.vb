' Import System.Linq instead of LinqInAction.Chapter12.CustomImplementation.QueryOperators if you want to use the default implementation
' Note that System.Linq has been removed from the namespaces imported in the project properties

'Imports System.Linq
Imports LinqInAction.Chapter12.CustomImplementation.QueryOperators
Imports LinqInAction.LinqBooks.Common

Module Module1

  Sub Main()
    Dim books = _
      From book In SampleData.Books _
      Where book.Price < 30 _
      Select book.Title

    ObjectDumper.Write(books)
  End Sub

End Module