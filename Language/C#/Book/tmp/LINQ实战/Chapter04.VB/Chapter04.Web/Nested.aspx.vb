Imports LinqInAction.LinqBooks.Common

Partial Class Nested
    Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    GridView1.DataSource = _
      From publisher In SampleData.Publishers _
      Order By publisher.Name _
      Select New With { _
        .Publisher = publisher.Name, _
        .Books = _
          From book In SampleData.Books _
          Where publisher.ReferenceEquals(book.Publisher, publisher) _
          Select book}
    GridView1.DataBind()
  End Sub
End Class