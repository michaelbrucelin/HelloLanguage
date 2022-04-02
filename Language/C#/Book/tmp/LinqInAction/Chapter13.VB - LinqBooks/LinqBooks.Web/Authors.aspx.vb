Imports LinqBooks.Entities

Partial Public Class Authors
  Inherits System.Web.UI.Page

#Region "AuthorPresentationModel"

  Class AuthorPresentationModel
    Private _ID As Guid
    Public Property ID() As Guid
      Get
        Return _ID
      End Get
      Set(ByVal value As Guid)
        _ID = value
      End Set
    End Property

    Private _FullName As String
    Public Property FullName() As String
      Get
        Return _FullName
      End Get
      Set(ByVal value As String)
        _FullName = value
      End Set
    End Property

    Private _Books As IEnumerable(Of Book)
    Public Property Books() As IEnumerable(Of Book)
      Get
        Return _Books
      End Get
      Set(ByVal value As IEnumerable(Of Book))
        _Books = value
      End Set
    End Property
  End Class

#End Region

  Private _DataContext As LinqBooksDataContext

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    _DataContext = New LinqBooksDataContext()

    If Not IsPostBack Then
      DisplayAuthors()
    End If
  End Sub

  Private Sub DisplayAuthors()
    Dim query = _
      From author In _DataContext.Authors _
      Order By author.LastName, author.FirstName _
      Select New AuthorPresentationModel With _
               { _
                 .ID = author.ID, _
                 .FullName = author.LastName.ToUpper() & " " & author.FirstName, _
                 .Books = author.BookAuthors.Select(Function(bookAuthors) bookAuthors.BookObject) _
               }
    GridViewAuthors.DataSource = query.ToList()
    GridViewAuthors.DataBind()
  End Sub

  Protected Sub GridViewAuthors_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    If e.Row.DataItem Is Nothing Then
      Return
    End If

    Dim author = CType(e.Row.DataItem, AuthorPresentationModel)
    Dim bookList = CType(e.Row.FindControl("BookList"), BookList)
    bookList.Books = author.Books
    bookList.DataBind()
  End Sub

  Protected Sub btnShowAddAuthor_Click(ByVal sender As Object, ByVal e As EventArgs)
    divAddAuthor.Visible = True
    btnShowAddAuthor.Visible = False
  End Sub

  Protected Sub btnAddAuthor_Click(ByVal sender As Object, ByVal e As EventArgs)
    ' Create new author
    Dim author = New Author()
    author.ID = Guid.NewGuid()
    author.FirstName = txtFirstName.Text
    author.LastName = txtLastName.Text

    ' Add author
    _DataContext.Authors.InsertOnSubmit(author)
    _DataContext.SubmitChanges()

    ' Update display
    DisplayAuthors()

    divAddAuthor.Visible = False
    btnShowAddAuthor.Visible = True
  End Sub
End Class