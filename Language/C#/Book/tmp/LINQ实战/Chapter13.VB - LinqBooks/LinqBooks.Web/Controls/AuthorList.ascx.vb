Imports LinqBooks.Entities

Partial Public Class AuthorList
  Inherits System.Web.UI.UserControl

  Public Class AuthorEventArgs
    Inherits EventArgs

    Private _AuthorID As Guid
    Public Property AuthorID() As Guid
      Get
        Return _AuthorID
      End Get
      Set(ByVal value As Guid)
        _AuthorID = value
      End Set
    End Property
  End Class

  Public Event DeleteAuthor As EventHandler(Of AuthorEventArgs)

  Private _Authors As IEnumerable(Of Author)

  Public WriteOnly Property Authors() As IEnumerable(Of Author)
    Set(ByVal value As IEnumerable(Of Author))
      _Authors = value
    End Set
  End Property

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Public Overrides Sub DataBind()
    MyBase.DataBind()
    If Not _Authors Is Nothing Then
      DisplayAuthors()
    End If
  End Sub

  Private Sub DisplayAuthors()
    If Not _Authors Is Nothing Then
      GridViewAuthors.DataSource = _
        _Authors.Select(Function(author) New With {.ID = author.ID, .FullName = author.FullName})
    Else
      GridViewAuthors.DataSource = Nothing
    End If
    GridViewAuthors.DataBind()
  End Sub

  Protected Sub GridViewAuthors_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
    OnDeleteAuthor(CType(GridViewAuthors.DataKeys(e.RowIndex).Value, Guid))
  End Sub

  Private Sub OnDeleteAuthor(ByVal authorId As Guid)
    RaiseEvent DeleteAuthor(Me, New AuthorEventArgs With {.AuthorID = authorId})
  End Sub
End Class