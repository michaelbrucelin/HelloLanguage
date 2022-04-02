Option Strict On

Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Imports System.Text
Imports System.Data.SqlClient
Imports System.Reflection
Imports LinqInAction.Chapter06to08.Common.SampleClasses.Ch8
Imports LinqInAction.Chapter06to08.Common.DemoHelper

Namespace CodeSamples
  Public Class Ch8Samples
    Inherits SampleClass

    Private ReadOnly Property NewContext() As Ch8DataContext
      Get
        Dim target As New Ch8DataContext
        target.Log = Console.Out
        Return target
      End Get
    End Property

    <Sample(8, 2, "8-2: Default concurrency implementation with LINQ to SQL")> _
    Public Sub DefaultConcurrencyImplementation_8_2()
      Dim context = NewContext
      Dim MostExpensiveBook = _
                      (From book In context.Books _
                       Order By book.Price Descending _
                       Select book).First()

      Dim discount As Decimal = 0.1D
      MostExpensiveBook.Price -= MostExpensiveBook.Price * discount

      'Rather than committing a change, just view the SQL that would be used
      Console.WriteLine(context.GetChangeText)
    End Sub

    <Sample(8, 3, "8-3: Optimistic Concurrency with Authors using a timestamp column")> _
        Public Sub ConcurrencyWithTimestamp_8_3()
      Dim context As New LinqBooksDataContext
      context.Log = Console.Out

      Dim AuthorToChange = context.Authors.First()

      AuthorToChange.FirstName = "Jim"
      AuthorToChange.LastName = "Wooley"

      'Rather than committing a change, just view the SQL that would be used
      Console.WriteLine(context.GetChangeText)
    End Sub

    <Sample(8, 4, "8-4: Resolving change conflicts with KeepChanges")> _
    Public Sub ConcurrencyKeepChanges_8_4()
      Dim context = NewContext
      'Make some changes
      Me.MakeConcurrentChanges(context)

      Try
        context.SubmitChanges(ConflictMode.ContinueOnConflict)
      Catch e As ChangeConflictException
        context.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges)
        'resubmit the merged values
        context.SubmitChanges()
      End Try
    End Sub

    <Sample(8, 5, "8-5: Resolving multiple conflicts replacing the users values with ones from the database")> _
    Public Sub ConcurrencyOverwriteCurrentValues_8_5()
      Dim context = NewContext
      'Make some changes
      Me.MakeConcurrentChanges(context)

      Try
        context.SubmitChanges(ConflictMode.ContinueOnConflict)
      Catch e As ChangeConflictException
        context.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues)
      End Try
    End Sub

    ''' <summary>
    ''' Force a concurrency error and display the old values, 
    ''' new values and current database values for the user to 
    ''' manually resolve.
    ''' </summary>
    <Sample(8, 6, "8-6: Displaying conflict details")> _
    Public Sub ConcurrencyDisplayingChanges_8_6()
      Dim context = NewContext
      'Make some changes
      Me.MakeConcurrentChanges(context)

      Try
        context.SubmitChanges(ConflictMode.ContinueOnConflict)
      Catch e As ChangeConflictException
        Dim ExceptionDetail = _
         From conflict In context.ChangeConflicts() _
         From member In conflict.MemberConflicts() _
             Select New With { _
                        .TableName = DemoHelper.GetTableName(context, conflict.Object), _
                        .MemberName = member.Member.Name, _
                        .CurrentValue = member.CurrentValue.ToString(), _
                        .DatabaseValue = member.DatabaseValue.ToString(), _
                        .OriginalValue = member.OriginalValue.ToString() _
                    }
        ObjectDumper.Write(ExceptionDetail)
      End Try
    End Sub

    <Sample(8, 7, "8-7: Managing the transaction through the DataContext")> _
    Public Sub TransactionsDataContext_8_7()
      Dim context = NewContext

      Me.MakeConcurrentChanges(context)

      Try
        context.Connection.Open()
        context.Transaction = context.Connection.BeginTransaction()
        context.SubmitChanges(ConflictMode.ContinueOnConflict)
        context.Transaction.Commit()
      Catch e As ChangeConflictException
        context.Transaction.Rollback()
      End Try
    End Sub

    <Sample(8, 8, "8-8: Managing transactinos with the TransactionScope object")> _
    Public Sub TransactionsSqlTransactionScope_8_9()
      Dim context = NewContext

      Me.MakeConcurrentChanges(context)

      Using scope As New System.Transactions.TransactionScope()
        context.SubmitChanges(ConflictMode.ContinueOnConflict)
        scope.Complete()
      End Using
    End Sub

    <Sample(8, 9, "8-9: Dynamic SQL pass-through")> _
    Public Sub DynamicSql_8_9()
      DynamicSql("Wooley")
    End Sub

    <Sample(8, 9, "8-9a: Dynamic SQL pass-through allowing SQL Injection")> _
    Public Sub DyanmicSqlWithInjection_8_9a()
      'Malicious string entered by the user
      Dim SearchName = "Good' OR ''='"
      DynamicSql(SearchName)
    End Sub

    Private Sub DynamicSql(ByVal searchName As String)
      Dim context = NewContext

      Dim SQL As String = "Select ID, LastName, FirstName, WebSite, TimeStamp    " & _
          "From dbo.Author " & _
          "Where LastName = '" & searchName & "'"

      Dim authors As IEnumerable(Of Author) = context.ExecuteQuery(Of Author)(SQL)
      ObjectDumper.Write(authors)
    End Sub

    <Sample(8, 10, "8-10: Dynamic SQL pass-through with parameters")> _
   Public Sub DynamicSqlParameters_8_10()

      Dim SearchName As String = "Good' OR ''='"

      Dim context = NewContext
      Dim SQL As String = "Select ID, LastName, FirstName, WebSite, TimeStamp  " & _
          "From dbo.Author " & _
          "Where LastName = {0}"

      ' We should actually have 0 records returned in this case.
      ObjectDumper.Write(context.ExecuteQuery(Of Author)(SQL, SearchName))
    End Sub

    <Sample(8, 11, "8-11: Using a Stored Procedure to return results")> _
    Public Sub StoredProc_8_11()
      Dim context = NewContext
      Dim query As IEnumerable(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch8.Book) = _
                     context.GetBook(New Guid("0737c167-e3d9-4a46-9247-2d0101ab18d1"), _
                     System.Threading.Thread.CurrentPrincipal.Identity.Name)

      ObjectDumper.Write(query)
    End Sub

    <Sample(8, 13, "8-13: Using a stored procedure to return a scalar value")> _
    Public Sub StoredProcScalar_8_13()
      Dim publisherId = New System.Guid("851e3294-145d-4fff-a190-3cab7aa95f76")
      Dim context = NewContext
      Console.WriteLine(String.Format("Books found: {0}", _
                                      context.BookCountForPublisher(publisherId)).ToString())
    End Sub

    <Sample(8, 16, "8-16: Consuming the upate stored procedure using LINQ")> _
    Public Sub UpdateProcedures_8_16()
      Dim context = NewContext
      Dim changingAuthor = context.Authors.FirstOrDefault()
      changingAuthor.FirstName = "Changing"
      Using ts As New System.Transactions.TransactionScope()
        context.SubmitChanges()
        'Let the transaction rollback
      End Using
    End Sub

    <Sample(8, 19, "8-19: LINQ code generated for the scalar function")> _
    Public Sub UserDefinedScalarFunctions_8_19()
      Dim context = NewContext

      Dim PublisherId As New Guid("855cb02e-dc29-473d-9f40-6c3405043fa3")
      Console.WriteLine(context.fnBookCountForPublisher(PublisherId))
    End Sub

    <Sample(8, 20, "8-20: Using a scalar user defined function in a query")> _
    Public Sub UserDefinedFunctionsInQuery_8_20()
      Dim context = NewContext

      Dim query = _
          From _publisher In context.GetTable(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch8.Publisher)() _
          Select New With { _
              _publisher.Name, _
              .BookCount = context.fnBookCountForPublisher(_publisher.ID)}

      ObjectDumper.Write(query)
    End Sub

    <Sample(8, 22, "8-22: Defining and consuming a Table-valued function.")> _
    Public Sub UserDefinedFunctions_8_22()
      Dim context = NewContext

      Dim PublisherId As New Guid("855cb02e-dc29-473d-9f40-6c3405043fa3")
      Dim query = _
          From book In context.fnGetPublishersBooks(PublisherId) _
            Select New With { _
                   book.Title, _
                  .OtherBookCount = context.fnBookCountForPublisher(book.Publisher) - 1}

      ObjectDumper.Write(query)
    End Sub

    <Sample(8, 23, "8-23: Precompiling a query")> _
    Public Sub CompiledQuery_8_23()
      ObjectDumper.Write(Ch8DataContext.GetExpensiveBooks(30))
    End Sub

    <Sample(8, 25, "8-25: Querying with a property from the partial class.")> _
    Public Sub QueryingPartialClass_8_25()
      Dim context = NewContext
      Dim partialAuthors = _
       From author In context.Authors _
          Select New With {author.FormattedName, author.WebSite}

      ObjectDumper.Write(partialAuthors)
    End Sub

    <Sample(8, 26, "8-26: Implementing IDataErrorInfo in the custom partial class.")> _
    Public Sub ConsumingIDataErrorInfo_8_26()
      Dim frm As New EditingForm
      frm.ShowDialog()
    End Sub

    <Sample(8, 28, "8-28a: Consuming inherited LINQ to SQL objects.")> _
    Public Sub QueryingInheritance_8_28a()
      Dim context As New LinqInAction.Chapter06to08.Common.LinqBooksDataContext()
      context.Log = Console.Out

      Console.WriteLine("All Users")
      'Get all users from the base instance
      Dim query = _
          From user In context.UserBases _
          Select user.Name
      ObjectDumper.Write(query)
    End Sub

    <Sample(8, 28, "8-28b: Filtering inherited LINQ to SQL objects using Where TypeOf.")> _
        Public Sub QueryingInheritance_8_28b()
      Dim context As New LinqInAction.Chapter06to08.Common.LinqBooksDataContext()
      context.Log = Console.Out

      Console.WriteLine("Authors:")
      'Get only the authors
      Dim authors = _
          From user In context.UserBases _
          Where TypeOf user Is AuthorUser _
          Select user.Name
      ObjectDumper.Write(authors)
    End Sub

    <Sample(8, 28, "8-28c: Filtering inherited LINQ to SQL objects using OfType.")> _
        Public Sub QueryingInheritance_8_28c()
      Dim context As New LinqInAction.Chapter06to08.Common.LinqBooksDataContext()
      context.Log = Console.Out

      Console.WriteLine("Publishers")
      'Get the publishers using the OfType extension method
      Dim publishers = _
          From user In context.UserBases.OfType(Of PublisherUser)() _
          Select user.Name
      ObjectDumper.Write(publishers)

    End Sub

    Private Sub MakeConcurrentChanges(ByVal context As Ch8DataContext)
      Dim dataContext1 = NewContext

      'First user raises the price of each book
      Dim books1 = dataContext1.Books
      For Each Book In books1
        Book.Price += 2
      Next

      'Second user lowers the price of each book
      Dim books2 = context.Books
      For Each Book In books2
        Book.Price -= 1
      Next

      'Go ahead and submit the first changes. 
      'The submit using the context passed in to this method will fail.
      dataContext1.SubmitChanges()
    End Sub
  End Class
End Namespace