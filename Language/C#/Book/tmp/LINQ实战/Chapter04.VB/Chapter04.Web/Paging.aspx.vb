Imports LinqInAction.LinqBooks.Common

Partial Class Paging
  Inherits System.Web.UI.Page

  Private Sub BindData()
    GridView1.DataSource = _
      SampleData.Books _
        .Select(Function(book) book.Title).ToList()
    GridView1.DataBind()
  End Sub

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      BindData()
    End If
  End Sub

  Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
    GridView1.PageIndex = e.NewPageIndex
    BindData()
  End Sub
End Class