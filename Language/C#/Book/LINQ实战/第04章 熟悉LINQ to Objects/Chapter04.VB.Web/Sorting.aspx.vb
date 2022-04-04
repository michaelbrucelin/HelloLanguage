Imports LinqInAction.LinqBooks.Common

Partial Class Sorting
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    GridView1.DataSource = _
      From book In SampleData.Books _
      Order By book.Publisher.Name, book.Price Descending, book.Title _
      Select New With {.Publisher = book.Publisher.Name, book.Price, book.Title}
    GridView1.DataBind()
  End Sub
End Class