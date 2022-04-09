Imports System.Data.Linq.Mapping
Imports System.Data.Linq
Imports System.Reflection

Partial Public Class LinqBooksDataContext
    <System.Data.Linq.Mapping.Function(Name:="dbo.GetBook")> _
    Public Function GetBook( _
        <Parameter(Name:="@BookId")> ByVal bookId As Guid, _
        <Parameter(Name:="@UserName")> ByVal userName As String) As ISingleResult(Of Book)

        Dim result As ISingleResult(Of Book) = Me.ExecuteMethodCall( _
            Me, _
            DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
            bookId, userName).ReturnValue
        Return Result
    End Function

    Private Sub DeleteAuthor(ByVal original As Author, ByVal current As Author)
        Me.DeleteAuthor(current.ID, Nothing, current.TimeStamp)
    End Sub

    <System.Data.Linq.Mapping.Function(Name:="dbo.DeleteAuthor")> _
        Public Sub DeleteAuthor( _
            <Parameter(Name:="@ID")> ByVal ID As Guid, _
            <Parameter(Name:="@UserName")> ByVal UserName As String, _
            <Parameter(Name:="@TimeStamp")> ByVal TimeStamp As Byte())

        If UserName Is Nothing Then UserName = System.Threading.Thread.CurrentPrincipal.Identity.Name

        Dim result As IExecuteResult = Me.ExecuteMethodCall( _
            Me, DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
            ID, UserName, TimeStamp)
        Dim RecordsAffected As Integer = CInt(result.ReturnValue)
        If RecordsAffected = 0 Then Throw New System.Data.Linq.ChangeConflictException()
    End Sub

    Private Sub UpdateAuthor(ByVal original As Author, ByVal current As Author)

        If (original.FirstName <> current.FirstName) OrElse _
            (original.LastName <> current.LastName) OrElse _
            (original.WebSite <> current.WebSite) Then

            Me.UpdateAuthor(current.ID, current.LastName, current.FirstName, current.WebSite, Nothing, current.TimeStamp)
        End If
    End Sub

    <System.Data.Linq.Mapping.Function(Name:="dbo.UpdateAuthor")> _
    Public Sub UpdateAuthor( _
        <Parameter(Name:="@ID")> ByVal ID As Guid, _
        <Parameter(Name:="@LastName")> ByVal LastName As String, _
        <Parameter(Name:="@FirstName")> ByVal FirstName As String, _
        <Parameter(Name:="@WebSite")> ByVal WebSite As String, _
        <Parameter(Name:="@UserName")> ByVal UserName As String, _
        <Parameter(Name:="@TimeStamp")> ByVal TimeStamp As Byte())

        If UserName Is Nothing Then UserName = System.Threading.Thread.CurrentPrincipal.Identity.Name

        Dim result As IExecuteResult = Me.ExecuteMethodCall( _
                        Me, DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
                        ID, LastName, FirstName, WebSite, UserName, TimeStamp)
        ID = DirectCast(result.GetParameterValue(0), Guid)
        Dim RecordsAffected = CInt(result.ReturnValue)
        If RecordsAffected = 0 Then Throw New System.Data.Linq.ChangeConflictException()
    End Sub

    Private Sub InsertAuthor(ByVal instance As Author)
        Me.InsertAuthor(instance.ID, instance.LastName, instance.FirstName, instance.WebSite, Nothing, instance.TimeStamp)
    End Sub

    <System.Data.Linq.Mapping.Function(Name:="dbo.InsertAuthor")> _
    Public Sub InsertAuthor( _
        <Parameter(Name:="@ID")> ByVal ID As Guid, _
        <Parameter(Name:="@LastName")> ByVal LastName As String, _
        <Parameter(Name:="@FirstName")> ByVal FirstName As String, _
        <Parameter(Name:="@WebSite")> ByVal WebSite As String, _
        <Parameter(Name:="@UserName")> ByVal UserName As String, _
         <Parameter(Name:="@TimeStamp")> ByVal TimeStamp As Byte())

        If UserName Is Nothing Then UserName = System.Threading.Thread.CurrentPrincipal.Identity.Name

        Dim result As IExecuteResult = Me.ExecuteMethodCall( _
              Me, DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), _
              ID, LastName, FirstName, WebSite, UserName, TimeStamp)
        ID = DirectCast(result.GetParameterValue(0), Guid)
        Dim RecordsAffected = CInt(result.ReturnValue)
        If RecordsAffected = 0 Then Throw New System.Data.Linq.ChangeConflictException()
    End Sub

    <System.Data.Linq.Mapping.Function(Name:="dbo.fnGetPublishersBooks")> _
    Public Function fnPublishersBooks(<Parameter(Name:="@Publisher")> ByVal Publisher As Guid) As IEnumerable(Of Book)
        Return Me.CreateMethodCallQuery(Of Book)(Me, DirectCast(MethodInfo.GetCurrentMethod(), MethodInfo), Publisher)
    End Function

    <System.Data.Linq.Mapping.Function(Name:="dbo.DiscountBooks")> _
    Public Sub DiscountBooks(<Parameter(Name:="@DiscountPercent")> ByVal DiscountPercent As Decimal)
        Me.ExecuteCommand("dbo.DiscountBooks", DiscountPercent)
    End Sub
End Class
