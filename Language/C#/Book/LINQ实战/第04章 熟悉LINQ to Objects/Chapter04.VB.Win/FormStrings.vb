Public Class FormStrings

  Private Sub FormStrings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim books As String() = {"Funny Stories", "All your base are belong to us", _
          "LINQ rules", "C# on Rails", "Bonjour mon Amour"}

    Dim query = _
      From book In books _
      Where book.Length > 10 _
      Order By book _
      Select New With {.Book = book.ToUpper()}

    dataGridView1.DataSource = query.ToList()
  End Sub
End Class