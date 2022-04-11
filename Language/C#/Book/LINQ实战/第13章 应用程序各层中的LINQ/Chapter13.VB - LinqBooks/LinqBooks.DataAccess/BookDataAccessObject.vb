Imports LinqBooks.Entities

Public Class BookDataAccessObject
  Inherits DataAccessObject

  Public Function GetBooksBySubjectName(ByVal subjectName As String) As List(Of Book)
    Dim query = _
      From book In DataContext.Books _
      Where book.SubjectObject.Name = subjectName _
      Select book
    Return query.ToList()
  End Function

End Class