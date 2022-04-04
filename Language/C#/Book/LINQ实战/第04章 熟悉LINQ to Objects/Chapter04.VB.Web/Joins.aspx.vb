Imports LinqInAction.LinqBooks.Common

Partial Class Joins
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    GridViewGroupJoin.DataSource = _
      From publisher In SampleData.Publishers _
      Group Join book In SampleData.Books On publisher Equals book.Publisher Into publisherBooks = Group _
      Select New With {.Publisher = publisher.Name, .Books = publisherBooks}
    GridViewGroupJoin.DataBind()

    GridViewInnerJoin.DataSource = _
      From publisher In SampleData.Publishers _
      Join book In SampleData.Books On publisher Equals book.Publisher _
      Select New With {.Publisher = publisher.Name, .Book = book.Title}
    GridViewInnerJoin.DataBind()

    GridViewLeftOuterJoin.DataSource = _
      From publisher In SampleData.Publishers _
      Group Join book In SampleData.Books On publisher Equals book.Publisher Into publisherBooks = Group _
      From book In publisherBooks.DefaultIfEmpty() _
      Select New With { _
        .Publisher = publisher.Name, _
        .Book = If(book Is Nothing, "(no books)", book.Title) _
      }
    GridViewLeftOuterJoin.DataBind()

        GridViewCrossJoin.DataSource = _
          From publisher In SampleData.Publishers _
          From book In SampleData.Books _
          Select New With { _
            .Correct = publisher.ReferenceEquals(publisher, book.Publisher), _
            .Publisher = publisher.Name, _
            .Book = book.Title _
          }
    GridViewCrossJoin.DataBind()
  End Sub
End Class