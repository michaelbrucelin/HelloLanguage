';'pImports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq.Expressions

Namespace CodeSamples
  Public Class Ch7Samples
    Inherits SampleClass

    ''' <summary>
    ''' Listing 7.2:	Attaching the external XML mapping to the DataContext
    ''' </summary>
    <Sample(7, 2, "7-2: Attaching the external XML mapping to the DataContext")> _
    Public Sub XmlMapping_7_2()

      Dim map As XmlMappingSource = _
              XmlMappingSource.FromXml(System.IO.File.ReadAllText("lia.xml"))

      Dim dataContext As New DataContext(My.Settings.liaConnectionString, map)
      dataContext.Log = Console.Out

      Dim authors = dataContext.GetTable(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch7.AuthorXml)()
      ObjectDumper.Write(authors)
    End Sub

    <Sample(7, 3, "7.3: Query expressed as expressions")> _
    Public Sub QueryExpressions_7_3()
      Dim context As New LinqBooksDataContext
      Dim bookParam = Expression.Parameter(GetType(Book), "book")
      Dim query = _
          context.Books.Where(Expression.Lambda(Of Func(Of Book, Boolean)) _
                               (Expression.GreaterThan( _
                                    Expression.Property( _
                                        bookParam, _
                                        GetType(Book).GetProperty("Price")), _
                                    Expression.Constant(30D, GetType(Decimal?))), _
                                New ParameterExpression() {bookParam}))

      ObjectDumper.Write(query)
    End Sub
    <Sample(7, 4, "7.4: Identity management and change tracking")> _
    Public Sub LifecycleTestWithoutSubmit_7_4()
      Dim context1 As New LinqBooksDataContext()
      Dim context2 As New LinqBooksDataContext()

      context1.Log = Console.Out
      context2.Log = Console.Out

      Dim Id As New Guid("92f10ca6-7970-473d-9a25-1ff6cab8f682")

      Dim editingSubject As Subject = context1.Subjects.Where(Function(s) s.SubjectId = Id).SingleOrDefault()

      Console.WriteLine("Before Change:")
      ObjectDumper.Write(editingSubject)
      ObjectDumper.Write(context2.Subjects.Where(Function(s) s.SubjectId = Id))

      editingSubject.Description = "Testing update"

      Console.WriteLine("After Change:")
      ObjectDumper.Write(context1.Subjects.Where(Function(s) s.SubjectId = Id))
      ObjectDumper.Write(context2.Subjects.Where(Function(s) s.SubjectId = Id))
    End Sub

    <Sample(7, 5, "7.5: Submitting changes with identity and change tracking management")> _
    Public Sub LifecycleTestWithUpdate_7_5()
      Dim context1 As New LinqBooksDataContext()
      Dim context2 As New LinqBooksDataContext()
      context1.Log = Console.Out
      context2.Log = Console.Out

      Dim Id As New Guid("92f10ca6-7970-473d-9a25-1ff6cab8f682")

      Dim editingSubject As Subject = context1.Subjects.Where(Function(s) s.SubjectId = Id).SingleOrDefault()

      Console.WriteLine("Before Change:")
      ObjectDumper.Write(editingSubject)
      ObjectDumper.Write(context2.Subjects.Where(Function(s) s.SubjectId = Id))

      editingSubject.Description = "Testing update"

      Console.WriteLine("After Change:")
      ObjectDumper.Write(context1.Subjects.Where(Function(s) s.SubjectId = Id))
      ObjectDumper.Write(context2.Subjects.Where(Function(s) s.SubjectId = Id))

      context1.SubmitChanges()

      Console.WriteLine("After Submit Changes:")
      ObjectDumper.Write(context1.Subjects.Where(Function(s) s.SubjectId = Id))
      ObjectDumper.Write(context2.Subjects.Where(Function(s) s.SubjectId = Id))
      Dim context3 = New LinqBooksDataContext
      ObjectDumper.Write(context3.Subjects.Where(Function(s) s.SubjectId = Id))

      'Reset values
      editingSubject.Description = "Original Value"
      context1.SubmitChanges()
    End Sub

    <Sample(7, 6, "7-6: Updating records in a disconnected environment")> _
    Public Sub DisconnectedTest_7_6()
      Dim context1 As New LinqBooksDataContext()
      context1.Log = Console.Out

      'Objects can only be attached to a single context at any given time.
      'This is done to avoid the potential to update child objects erroneously.
      'For the purposes of this example, we purposefully set up context 1 so that 
      'it wouldn't track the changes by setting the ObjectTrackingEnabled to false.
      'Attempting to attach an object to a second context will result in a NotSupportedException
      context1.ObjectTrackingEnabled = False

      Dim cachedSubject = context1.Subjects.First
      Console.WriteLine("Starting Name: {0}", cachedSubject.Name)

      'In a real application, this object would now be cached or remoted via a web service.
      'Use a second context to simulate the disconnected environment.
      Using ts As New System.Transactions.TransactionScope
        UpdateSubject(cachedSubject)

        Console.WriteLine("Updated Name: {0}", cachedSubject.Name)
        'rollback changes
      End Using
    End Sub

    Public Sub UpdateSubject(ByVal cachedSubject As Subject)
      Dim context = New LinqBooksDataContext
      context.Log = Console.Out
      context.Subjects.Attach(cachedSubject)
      cachedSubject.Name = "Testing update"
      context.SubmitChanges()
    End Sub

    <Sample(7, 6, "7-6a: Updating records in a disconnected environment with a timestamp")> _
    Public Sub DisconnectedTestWithTimestamp_7_6a()
      Dim context1 As New LinqBooksDataContext()
      context1.Log = Console.Out

      'Objects can only be attached to a single context at any given time.
      'This is done to avoid the potential to update child objects erroneously.
      'For the purposes of this example, we purposefully set up context 1 so that 
      'it wouldn't track the changes by setting the ObjectTrackingEnabled to false.
      'Attempting to attach an object to a second context will result in a NotSupportedException
      context1.ObjectTrackingEnabled = False

      Dim cachedAuthor = context1.Authors.First
      Console.WriteLine("Starting Name: {0}", cachedAuthor.FirstName)

      'In a real application, this object would now be cached or remoted via a web service.
      'Use a second context to simulate the disconnected environment.
      Using ts As New System.Transactions.TransactionScope
        UpdateAuthor(cachedAuthor)
        Console.WriteLine("Updated Name: {0}", cachedAuthor.FirstName)
        'rollback changes
      End Using
    End Sub

    ' Use second context to simulate disconnected environment
    Public Sub UpdateAuthor(ByVal cachedAuthor As Author)
      Dim context As New LinqBooksDataContext()
      context.Log = Console.Out

      cachedAuthor.LastName = "Testing update"
      context.Authors.Attach(cachedAuthor, True)

      context.SubmitChanges()

    End Sub

    <Sample(7, 6, "7-6b: Updating records in a disconnected environment passing in object properties")> _
    Public Sub DisconnectedTest_7_6b()
      Dim context1 As New LinqBooksDataContext()
      context1.ObjectTrackingEnabled = False

      context1.Log = Console.Out

      Dim editingAuthor As Author = context1.Authors.First
      Console.WriteLine("Starting Author Name: {0}", editingAuthor.LastName)

      Using ts As New System.Transactions.TransactionScope
        UpdateAuthor(editingAuthor.ID, editingAuthor.FirstName, "Testing change", editingAuthor.WebSite, editingAuthor.TimeStamp)


        'Refetch it and show the database value now
        ObjectDumper.Write(From a In context1.Authors Where a.ID = editingAuthor.ID Select a)
        'rollback changes
      End Using
    End Sub


    Public Sub UpdateAuthor(ByVal id As Guid, ByVal firstName As String, _
                            ByVal lastName As String, ByVal webSite As String, _
                            ByVal timeStamp As Byte())
      Dim context As New LinqBooksDataContext()
      context.Log = Console.Out
      context.Authors.Attach(New Author With { _
                                  .ID = id, _
                                  .FirstName = firstName, _
                                  .LastName = lastName, _
                                  .WebSite = webSite, _
                                  .TimeStamp = timeStamp}, _
                           True)
      context.SubmitChanges()

    End Sub


    <Sample(7, 6, "7-6c: Updating records in a disconnected environment using attach with old and new versions")> _
    Public Sub DisconnectedTest_7_6c()
      Dim context1 As New LinqBooksDataContext()
      context1.Log = Console.Out

      'Objects can only be attached to a single context at any given time.
      'This is done to avoid the potential to update child objects erroneously.
      'For the purposes of this example, we purposefully set up context 1 so that 
      'it wouldn't track the changes by setting the ObjectTrackingEnabled to false.
      'Attempting to attach an object to a second context will result in a NotSupportedException
      context1.ObjectTrackingEnabled = False

      Dim cachedSubject As Subject = context1.Subjects.First
      Dim newVersion As New Subject With {.Name = "Testing a change", _
                                          .SubjectId = cachedSubject.SubjectId, _
                                          .Description = cachedSubject.Description}

      Console.WriteLine("Starting subject Name: {0}", cachedSubject.Name)

      Using ts As New System.Transactions.TransactionScope
        UpdateSubject(cachedSubject, newVersion)

        'rollback changes
      End Using
    End Sub

    Public Sub UpdateSubject(ByVal cachedVersion As Subject, ByVal newVersion As Subject)
      Dim context As New LinqBooksDataContext
      context.Log = Console.Out
      context.Subjects.Attach(newVersion, cachedVersion)
      context.SubmitChanges()

      Console.Write("New value: ")
      ObjectDumper.Write(From s In context.Subjects Where s.SubjectId = newVersion.SubjectId Select s)

    End Sub

    <Sample(7, 7, "7-7: Updating a disconnected object that has already been changed")> _
    Public Sub SoaTest_7_7()
      Dim context1 As New LinqBooksDataContext()
      context1.Log = Console.Out

      Dim Id As New Guid("92f10ca6-7970-473d-9a25-1ff6cab8f682")

      Dim editingSubject As Subject = context1.Subjects.Where(Function(s) s.SubjectId = Id).SingleOrDefault()

      editingSubject.Description = "Testing update"
      'Apply the changes through a mimiced service
      Subject.UpdateSubject(editingSubject)

      'Reset values
      editingSubject.Description = "Original Value"
      Subject.UpdateSubject(editingSubject)
    End Sub

  End Class
End Namespace