Imports System.Data.Linq
Imports LinqBooks.Entities

Public Class SubjectDataAccessObject
  Inherits DataAccessObject

  ''' <summary>
  ''' Returns the list of all subjects in the database ordered by name.
  ''' </summary>
  Public Function GetSubjects() As List(Of Subject)
    Return DataContext.Subjects.OrderBy(Function(subject) subject.Name).ToList()
  End Function

  ''' <summary>
  ''' Returns the list of all subjects in the database ordered by name,
  ''' with associated books loaded.
  ''' </summary>
  ''' <remarks>Deferred loading is disabled</remarks>
  Public Function GetSubjectsWithBooksLoaded() As List(Of Subject)
    Dim dataContext = New LinqBooksDataContext()

    ' Disable lazy loading
    dataContext.DeferredLoadingEnabled = False

    ' Specify that the books should be loaded with each subject 
    Dim loadOptions = New DataLoadOptions()
    loadOptions.LoadWith(Of Subject)(Function(subject) subject.Books)
    dataContext.LoadOptions = loadOptions

    ' Query all subjects ordered by name
    Dim query = dataContext.Subjects.OrderBy(Function(subject) subject.Name)

    Return query.ToList()
  End Function

End Class