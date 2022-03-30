Imports LinqBooks.Entities

Partial Public Class Publishers
  Inherits System.Web.UI.Page

  Private _DataContext As LinqBooksDataContext

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    _DataContext = New LinqBooksDataContext()

    If Not IsPostBack Then
      DisplayPublishers()
    End If
  End Sub

  Private Sub DisplayPublishers()
    Dim query = _
      From publisher In _DataContext.Publishers _
      Order By publisher.Name _
      Select publisher
    GridViewPublishers.DataSource = query
    GridViewPublishers.DataBind()
  End Sub

  Protected Sub GridViewPublishers_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    If e.Row.DataItem Is Nothing Then
      Return
    End If

    Dim publisher = CType(e.Row.DataItem, Publisher)
    Dim bookList = CType(e.Row.FindControl("BookList"), BookList)
    bookList.Books = publisher.Books
    bookList.DataBind()
  End Sub

  Protected Sub btnShowAddPublisher_Click(ByVal sender As Object, ByVal e As EventArgs)
    divAddPublisher.Visible = True
    btnShowAddPublisher.Visible = False
  End Sub

  Protected Sub btnAddPublisher_Click(ByVal sender As Object, ByVal e As EventArgs)
    ' Create new publisher
    Dim publisher As Publisher = New Publisher()
    publisher.ID = Guid.NewGuid()
    publisher.Name = txtName.Text

    ' Add publisher
    _DataContext.Publishers.InsertOnSubmit(publisher)
    _DataContext.SubmitChanges()

    ' Update display
    DisplayPublishers()

    divAddPublisher.Visible = False
    btnShowAddPublisher.Visible = True
  End Sub
End Class