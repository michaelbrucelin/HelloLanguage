Imports LinqBooks.Entities

Partial Public Class BookList
  Inherits System.Web.UI.UserControl

  Private _Books As IEnumerable(Of Book)

  Public WriteOnly Property Books() As IEnumerable(Of Book)
    Set(ByVal value As IEnumerable(Of Book))
      _Books = value
    End Set
  End Property

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Public Overrides Sub DataBind()
    MyBase.DataBind()
    GridViewBooks.DataSource = _Books
    GridViewBooks.DataBind()
  End Sub
End Class