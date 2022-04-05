Imports LinqInAction.LinqBooks.Common

Public Class FormConditionalQuery

  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    cbxPageCount.DisplayMember = "Key"
    cbxPageCount.ValueMember = "Value"
    cbxPageCount.DataSource = New KeyValuePair(Of String, Integer?)() { _
      New KeyValuePair(Of String, Integer?)("any", Nothing), _
      New KeyValuePair(Of String, Integer?)("at least 100", 100), _
      New KeyValuePair(Of String, Integer?)("at least 200", 200), _
      New KeyValuePair(Of String, Integer?)("at least 300", 300) _
    }

        cbxPageCount.SelectedIndex = 0
    cbxSortOrder.SelectedIndex = 0

    dataGridView.AutoGenerateColumns = False
    dataGridView.Columns.Clear()
    dataGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Title", .HeaderText = "Title"})
    dataGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "PageCount", .HeaderText = "Pages"})
    dataGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Publisher", .HeaderText = "Publisher"})
  End Sub

  Private Sub ConditionalQuery(Of TSortKey)(ByVal minPageCount As Integer?, ByVal titleFilter As String, ByVal sortSelector As Func(Of Book, TSortKey))
    Dim query As IEnumerable(Of Book)

    query = SampleData.Books
    If minPageCount.HasValue Then
      query = query.Where(Function(book) book.PageCount >= minPageCount.Value)
    End If
    If Not String.IsNullOrEmpty(titleFilter) Then
      query = query.Where(Function(book) book.Title.Contains(titleFilter))
    End If
    If Not sortSelector Is Nothing Then
      query = query.OrderBy(sortSelector)
    End If
    Dim completeQuery = query.Select(Function(book) New With {book.Title, book.PageCount, .Publisher = book.Publisher.Name})

    dataGridView.DataSource = completeQuery.ToList()
  End Sub

  Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    Dim minPageCount As Integer?
    Dim titleFilter As String

    minPageCount = CType(cbxPageCount.SelectedValue, Integer?)
    titleFilter = txtTitleFilter.Text
    If cbxSortOrder.SelectedIndex = 1 Then
      ConditionalQuery(minPageCount, titleFilter, Function(book) book.Title)
    ElseIf cbxSortOrder.SelectedIndex = 2 Then
      ConditionalQuery(minPageCount, titleFilter, Function(book) book.Publisher.Name)
    ElseIf cbxSortOrder.SelectedIndex = 3 Then
      ConditionalQuery(minPageCount, titleFilter, Function(book) book.PageCount)
    Else
      ConditionalQuery(Of Object)(minPageCount, titleFilter, Nothing)
    End If
  End Sub
End Class