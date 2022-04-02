Imports LinqBooks.Entities
Imports System.Transactions

Partial Public Class PublisherPage
  Inherits System.Web.UI.Page

  Private _DataContext As LinqBooksDataContext
  Private _PublisherId As Guid

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim tmpString As String

    tmpString = Request.QueryString("ID")
    If String.IsNullOrEmpty(tmpString) Then
      Throw New ArgumentNullException("ID")
    End If
    _PublisherId = New Guid(tmpString)

    _DataContext = New LinqBooksDataContext()

    Dim query = _
      From publisher In _DataContext.Publishers _
      Where publisher.ID = _PublisherId _
      Select publisher
    DetailsView1.DataSource = query
    DetailsView1.DataBind()
  End Sub

  Protected Sub DetailsView1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    Dim publisher = CType(DetailsView1.DataItem, Publisher)
    Dim bookList = CType(DetailsView1.FindControl("BookList"), BookList)
    bookList.Books = publisher.Books
    bookList.DataBind()
  End Sub

  Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
    Using transaction = New TransactionScope()
      Dim publisher = _DataContext.Publishers.Single(Function(p) p.ID = _PublisherId)
      _DataContext.Publishers.DeleteOnSubmit(publisher)
      _DataContext.SubmitChanges()

      transaction.Complete()
    End Using

    Response.Redirect("~/Publishers.aspx")
  End Sub
End Class