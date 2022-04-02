Imports LinqInAction.LinqBooks.Common

Partial Class Partitioning
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not IsPostBack Then
      ' Display the complete list
      GridViewComplete.DataSource = _
        SampleData.Books _
          .Select(Function(book, index) New With {.Index = index, .Book = book.Title})
      GridViewComplete.DataBind()

      ' Prepare the comboboxes
      Dim count As Integer = SampleData.Books.Count()
      For i = 0 To count - 1
        ddlStart.Items.Add(i.ToString())
        ddlEnd.Items.Add(i.ToString())
      Next

      ddlStart.SelectedIndex = 2
      ddlEnd.SelectedIndex = 3

      ' Display the filtered list
      DisplayPartialData()
    End If
  End Sub

  Protected Sub ddlStart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStart.SelectedIndexChanged
    DisplayPartialData()
  End Sub

  Private Sub DisplayPartialData()  
    ' Retrieve the start and end indexes
    Dim startIndex As Integer = Integer.Parse(ddlStart.SelectedValue)
    Dim endIndex As Integer = Integer.Parse(ddlEnd.SelectedValue)

    ' Display the filtered list
    GridViewPartial.DataSource = _
      SampleData.Books _
        .Select(Function(book, index) New With {.Index = index, .Book = book.Title}) _
        .Skip(startIndex).Take(endIndex - startIndex + 1)
    GridViewPartial.DataBind()
  End Sub
End Class