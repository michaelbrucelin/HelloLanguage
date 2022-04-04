Imports LinqInAction.LinqBooks.Common

Partial Class Grouping
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    GridView1.DataSource = _
      From book In SampleData.Books _
      Group book By publisher = book.Publisher Into publisherBooks = Group _
      Select New With {.Publisher = publisher.Name, .Books = publisherBooks}
    GridView1.DataBind()
  End Sub
End Class