
Partial Class Step1
    Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim books As String() = {"Funny Stories", "All your base are belong to us", _
        "LINQ rules", "C# on Rails", "Bonjour mon Amour"}

    GridView1.DataSource = _
      From book In books _
      Where book.Length > 10 _
      Order By book _
      Select book.ToUpper()
    GridView1.DataBind()
  End Sub
End Class