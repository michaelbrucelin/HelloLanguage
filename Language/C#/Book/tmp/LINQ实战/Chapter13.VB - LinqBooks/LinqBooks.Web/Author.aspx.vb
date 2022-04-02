Imports LinqBooks.Entities
Imports System.Transactions

Partial Public Class AuthorPage
  Inherits System.Web.UI.Page

  Private _DataContext As LinqBooksDataContext
  Private _AuthorId As Guid

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim tmpString As String

    tmpString = Request.QueryString("ID")
    If String.IsNullOrEmpty(tmpString) Then
      Throw New ArgumentNullException("ID")
    End If

    _AuthorId = New Guid(tmpString)

    _DataContext = New LinqBooksDataContext()

    Dim query = _
      From author In _DataContext.Authors _
      Where author.ID = _AuthorId _
      Select author
    DetailsView1.DataSource = query
    DetailsView1.DataBind()
  End Sub

  Protected Sub DetailsView1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    Dim author = CType(DetailsView1.DataItem, Author)
    Dim bookList = CType(DetailsView1.FindControl("BookList"), BookList)
    bookList.Books = author.BookAuthors.Select(Function(bookAuthor) bookAuthor.BookObject)
    bookList.DataBind()
  End Sub

  Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
    Using transaction = New TransactionScope()
      Dim author = _DataContext.Authors.Single(Function(a) a.ID = _AuthorId)
      _DataContext.Authors.DeleteOnSubmit(author)
      _DataContext.SubmitChanges()

      transaction.Complete()
    End Using

    Response.Redirect("~/Authors.aspx")
  End Sub
End Class