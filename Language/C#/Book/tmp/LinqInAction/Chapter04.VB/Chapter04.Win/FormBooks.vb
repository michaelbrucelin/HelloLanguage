Imports LinqInAction.LinqBooks.Common

Public Class FormBooks

  Private Sub FormBooks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim query = _
      From book In SampleData.Books _
      Where book.Title.Length > 10 _
      Order By book.Price _
      Select New With {.Book = book.Title, book.Price}

    dataGridView1.DataSource = query.ToList()
  End Sub
End Class