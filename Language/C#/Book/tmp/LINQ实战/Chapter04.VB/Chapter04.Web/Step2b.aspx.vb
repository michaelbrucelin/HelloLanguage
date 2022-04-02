Imports LinqInAction.LinqBooks.Common

Partial Class Step2b
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    GridView1.DataSource = _
      From book In SampleData.Books _
      Where book.Title.Length > 10 _
      Order By book.Price _
      Select New With {book.Title, book.Price}
    GridView1.DataBind()
  End Sub
End Class