Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Threading
Imports System.Reflection

Namespace SampleClasses.Ch8
    Partial Public Class Ch8DataContext
        <System.Data.Linq.Mapping.Function(Name:="dbo.UpdateAuthorWithoutTimestamp")> _
        Public Function UpdateAuthorWithoutTimestamp( _
            <Parameter(Name:="ID")> ByVal iD As Guid?, _
            <Parameter(Name:="LastName")> ByVal lastName As String, _
            <Parameter(Name:="FirstName")> ByVal firstName As String, _
            <Parameter(Name:="WebSite")> ByVal webSite As String, _
            <Parameter(Name:="OriginalLastName")> ByVal originalLastName As String, _
            <Parameter(Name:="OriginalFirstName")> ByVal originalFirstName As String, _
            <Parameter(Name:="OriginalWebSite")> ByVal originalWebSite As String, _
            <Parameter(Name:="UserName")> ByVal userName As String) As Integer
            Dim result As IExecuteResult = Me.ExecuteMethodCall( _
                            Me, _
                          DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
                            iD, lastName, firstName, webSite, _
                            originalLastName, originalFirstName, originalWebSite, userName)
            iD = DirectCast(result.GetParameterValue(0), Guid)
            Return DirectCast(result.ReturnValue, Integer)
        End Function

        Private Sub UpdateAuthor(ByVal instance As Author)
            Dim original As Author = Authors.GetOriginalEntityState(instance)
            Me.UpdateAuthorWithoutTimestamp( _
                instance.ID, instance.LastName, instance.FirstName, instance.WebSite, _
                original.LastName, original.FirstName, original.WebSite, _
                System.Threading.Thread.CurrentPrincipal.Identity.Name)
        End Sub

        <System.Data.Linq.Mapping.Function(Name:="dbo.UpdateAuthor")> _
        Public Function AuthorUpdate( _
            <Parameter(Name:="ID")> ByVal id As System.Guid, _
            <Parameter(Name:="LastName")> ByVal lastName As String, _
            <Parameter(Name:="FirstName")> ByVal firstName As String, _
            <Parameter(Name:="WebSite")> ByVal webSite As String, _
            <Parameter(Name:="UserName")> ByVal userName As String, _
            <Parameter(Name:="TimeStamp")> ByVal timeStamp As Byte()) As Integer

            If userName Is Nothing Then userName = Thread.CurrentPrincipal.Identity.Name

            Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, _
                            DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
                            id, lastName, firstName, webSite, userName, timeStamp)
            id = DirectCast(result.GetParameterValue(0), Guid)
            Dim RowsAffected As Integer = CInt(result.ReturnValue)
            If (RowsAffected = 0) Then Throw New ChangeConflictException()
            Return RowsAffected
        End Function

        <System.Data.Linq.Mapping.Function(Name:="dbo.InsertAuthor")> _
        Public Function AuthorInsert(<Parameter(Name:="ID")> ByVal iD As System.Guid?, _
                                      <Parameter(Name:="LastName")> ByVal lastName As String, _
                                      <Parameter(Name:="FirstName")> ByVal firstName As String, _
                                      <Parameter(Name:="WebSite")> ByVal webSite As String, _
                                      <Parameter(Name:="UserName")> ByVal userName As String, _
                                      <Parameter(Name:="TimeStamp")> ByVal timeStamp As Byte()) As Integer

            Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, _
                DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
                iD, lastName, firstName, webSite, userName, timeStamp)

            iD = DirectCast(result.GetParameterValue(0), Guid?)
            Return CInt(result.ReturnValue)
        End Function

        'partial sub UpdateAuthor(Author instance)
        '{
        '    this.AuthorUpdate(instance.ID, instance.LastName, instance.FirstName, instance.WebSite, System.Threading.Thread.CurrentPrincipal.Identity.Name, instance.TimeStamp);
        '}

        <System.Data.Linq.Mapping.Function(Name:="dbo.GetBook")> _
        Public Function GetBook( _
            <Parameter(Name:="@BookId")> ByVal BookId As Guid, _
            <Parameter(Name:="@UserName")> ByVal UserName As String) As ISingleResult(Of Book)

            Dim result As IExecuteResult = _
                Me.ExecuteMethodCall(Me, DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
                    BookId, UserName)
            Return DirectCast(result.ReturnValue, ISingleResult(Of Book))
        End Function

        <System.Data.Linq.Mapping.Function(Name:="dbo.BookCountForPublisher")> _
        Public Function BookCountForPublisher( _
            <Parameter(Name:="@PublisherId")> ByVal PublisherId As Guid) As Integer

            Dim result As IExecuteResult = Me.ExecuteMethodCall( _
                            Me, DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), PublisherId)
            Return CInt(result.ReturnValue)
        End Function

        <System.Data.Linq.Mapping.Function(Name:="dbo.UpdateAuthor")> _
        Public Function UpdateAuthor2( _
          <Parameter(Name:="@ID")> ByVal ID As Guid, _
          <Parameter(Name:="@LastName")> ByVal LastName As String, _
          <Parameter(Name:="@FirstName")> ByVal FirstName As String, _
          <Parameter(Name:="@WebSite")> ByVal WebSite As String, _
          <Parameter(Name:="@UserName")> ByVal UserName As String, _
          <Parameter(Name:="@TimeStamp")> ByVal TimeStamp As Byte()) As Integer

            If UserName Is Nothing Then UserName = Thread.CurrentPrincipal.Identity.Name

            Dim result As IExecuteResult = Me.ExecuteMethodCall( _
                         Me, DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
                          ID, LastName, FirstName, WebSite, UserName, TimeStamp)
            ID = DirectCast(result.GetParameterValue(0), Guid)
            Dim RecordsAffected As Integer = CInt(result.ReturnValue)
            If RecordsAffected = 0 Then Throw New ChangeConflictException()
            Return RecordsAffected
        End Function

        Private Sub UpdateAuthor1(ByVal original As Author, ByVal current As Author)
            If Not (original.FirstName.Equals(current.FirstName) AndAlso _
                original.LastName.Equals(current.LastName) AndAlso _
                original.WebSite.Equals(current.WebSite)) Then

                Me.UpdateAuthor2(current.ID, _
                   current.LastName, current.FirstName, _
                   current.WebSite, Nothing, current.TimeStamp)
            End If
        End Sub

        '        '<System.Data.Linq.Mapping.Function(Name := "dbo.fnBookCountForPublisher", IsComposable = true)>
        '        'public System.Nullable<int> fnBookCountForPublisher(<Parameter(Name := "PublisherId", DbType = "UniqueIdentifier")> System.Nullable<System.Guid> publisherId)
        '        '{
        '        '    return ((System.Nullable<int>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisherId).ReturnValue));
        '        '}

        <System.Data.Linq.Mapping.Function(Name:="dbo.fnBookCountForPublisher", IsComposable:=True)> _
        Public Function fnBookCountForPublisher1( _
            <Parameter(Name:="PublisherId")> ByVal publisherId As Guid?) As Integer?

            Return (Me.ExecuteMethodCall(Me, DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), publisherId).ReturnValue)
        End Function

        <System.Data.Linq.Mapping.Function(Name:="dbo.fnGetPublishersBooks", IsComposable:=True)> _
        Public Function fnGetPublishersBooks( _
            <Parameter(Name:="Publisher")> ByVal publisher As Guid?) As IQueryable(Of Book)

            Return Me.CreateMethodCallQuery(Of Book)( _
                 Me, MethodInfo.GetCurrentMethod(), publisher)
        End Function

        ''' <summary>
        ''' Precompiled version of the Expensive Books query
        ''' </summary>
        Public Shared ExpensiveBooks As Func(Of Ch8DataContext, Decimal, IQueryable(Of Book)) = _
            CompiledQuery.Compile(Function(context As Ch8DataContext, minimumPrice As Decimal) _
            From book In context.Books() _
            Where (book.Price >= minimumPrice) _
                    Select book)

        ''' <summary>
        ''' Helper method to encapsulate the context instance which calls the 
        ''' <see cref="ExpensiveBooks">ExpensiveBooks compiled query</see>
        ''' </summary>
        ''' <param name="minimumPrice"></param>
        ''' <returns>Enumerable list of Books whith a price higher than the minimumPrice</returns>
        Public Shared Function GetExpensiveBooks(ByVal minimumPrice As Decimal) As IQueryable(Of Book)
            Dim context As New Ch8DataContext(My.Settings.liaConnectionString)
            Return ExpensiveBooks(context, minimumPrice)
        End Function

    End Class

End Namespace