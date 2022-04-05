Imports System.Data.SqlClient


Public Class FormMain

#Region "Data loading"

#Region "Untyped DataSet"

  Private Shared Sub FillDataSetUsingDataAdapter(ByVal dataSet As DataSet)
    ' Create the DataAdapter
    Dim dataAdapter = New SqlDataAdapter( _
      "SELECT ID, Name " + _
      "FROM Publisher " + _
      "; " + _
      "SELECT ID, Title, Subject, Publisher, Price " + _
      "FROM Book " + _
      "WHERE DATEPART(YEAR, PubDate) > 1950 ", _
      My.MySettings.Default.LinqBooksConnectionString)

    ' Map the results to tables in the DataSet
    dataAdapter.TableMappings.Add("Table", "Publisher")
    dataAdapter.TableMappings.Add("Table1", "Book")

    ' Execute the SQL queries and load the data into the DataSet
    dataAdapter.Fill(dataSet)
  End Sub

  ' This method is the most direct, but it requires creating the DataTables by hand.
  Private Shared Sub FillDataSetUsingLinqToSql1(ByVal dataSet As DataSet)
    Dim table As DataTable

    ' Prepare the LINQ to SQL DataContext
    Dim linqBooks = New LinqInAction.Chapter14.LinqBooks(My.MySettings.Default.LinqBooksConnectionString)

    ' Query the Publisher table
    Dim publisherQuery = _
      From publisher In linqBooks.Publisher _
        Select New With {publisher.ID, publisher.Name}
    ' Query the Book table
    Dim bookQuery = _
      From book In linqBooks.Book _
      Where book.PubDate.Value.Year > 1950 _
      Select New With _
        { _
          book.ID, _
          book.Title, _
          book.Subject, _
          book.Publisher, _
          .Price = If(book.Price.HasValue, book.Price.Value, 0) _
        }

    ' Prepare the Publisher DataTable
    table = New DataTable()
    table.Columns.Add("ID", GetType(Guid))
    table.Columns.Add("Name", GetType(String))
    ' Load data into the Publisher DataTable
    For Each publisher In publisherQuery
      table.LoadDataRow(New Object() {publisher.ID, publisher.Name}, True)
    Next
    ' Add the Publisher DataTable
    dataSet.Tables.Add(table)

    ' Prepare the Book DataTable
    table = New DataTable()
    table.Columns.Add("ID", GetType(Guid))
    table.Columns.Add("Title", GetType(String))
    table.Columns.Add("Subject", GetType(Guid))
    table.Columns.Add("Publisher", GetType(Guid))
    table.Columns.Add("Price", GetType(Decimal))
    ' Load data into the Book DataTable
    For Each book In bookQuery
      table.LoadDataRow(New Object() {book.ID, book.Title, book.Subject, book.Publisher, book.Price}, True)
    Next
    ' Add the Book DataTable
    dataSet.Tables.Add(table)
  End Sub

  ' This method uses the ToDataTable query operator to automatically create the DataTables.
  Private Shared Sub FillDataSetUsingLinqToSql2(ByVal dataSet As DataSet)
    ' Prepare the LINQ to SQL DataContext
    Dim linqBooks = New LinqInAction.Chapter14.LinqBooks(My.MySettings.Default.LinqBooksConnectionString)

    ' Query the Publisher table
    Dim publisherQuery = _
      From publisher In linqBooks.Publisher _
      Select New With {publisher.ID, publisher.Name}
    ' Query the Book table
    Dim bookQuery = _
      From book In linqBooks.Book _
      Where book.PubDate.Value.Year > 1950 _
      Select New With _
      { _
        book.ID, book.Title, book.Subject, book.Publisher, book.PageCount, _
        .Price = If(book.Price.HasValue, book.Price.Value, 0) _
      }

    ' Execute the queries and load the data into the DataSet
    dataSet.Tables.Add(publisherQuery.ToDataTable())
    dataSet.Tables.Add(bookQuery.ToDataTable())
  End Sub

#End Region

#Region "Typed DataSet"

  ' This method is the most direct, but it requires loading the DataTables by hand.
  Private Shared Sub FillDataSetUsingLinqToSql1(ByVal dataSet As LinqBooksDataSet)
    ' Prepare the LINQ to SQL DataContext
    Dim linqBooks = New LinqInAction.Chapter14.LinqBooks(My.MySettings.Default.LinqBooksConnectionString)

    ' Query the Publisher table
    Dim publisherQuery = _
      From publisher In linqBooks.Publisher _
      Select New With {publisher.ID, publisher.Name}
    ' Query the Book table
    Dim bookQuery = _
      From book In linqBooks.Book _
      Where book.PubDate.Value.Year > 1950 _
      Select book

    ' Execute the queries and load the data into the DataSet
    For Each publisher In publisherQuery
      dataSet.Publisher.AddPublisherRow(publisher.ID, publisher.Name, Nothing, Nothing)
    Next
    For Each book In bookQuery
      dataSet.Book.AddBookRow(book.ID, book.Title, book.Subject, _
        dataSet.Publisher.FindByID(book.Publisher), _
        book.PubDate.Value, If(book.Price.HasValue, book.Price.Value, 0), _
        book.PageCount, book.Isbn, book.Summary, book.Notes)
    Next
  End Sub

  ' This method uses the LoadSequence query operator to automatically create the DataTables.
  Private Shared Sub FillDataSetUsingLinqToSql2(ByVal dataSet As LinqBooksDataSet)
    ' Prepare the LINQ to SQL DataContext
    Dim linqBooks = New LinqInAction.Chapter14.LinqBooks(My.MySettings.Default.LinqBooksConnectionString)

    ' Query the Publisher table
    Dim publisherQuery = _
      From publisher In linqBooks.Publisher _
      Select New With {publisher.ID, publisher.Name}
    ' Query the Book table
    Dim bookQuery = _
      From book In linqBooks.Book _
      Where book.PubDate.Value.Year > 1950 _
      Select New With _
      { _
        book.ID, book.Title, book.Subject, book.Publisher, book.PageCount, _
        .Price = If(book.Price.HasValue, book.Price.Value, 0) _
      }

    ' Execute the queries and load the data into the DataSet
    publisherQuery.LoadSequence(dataSet.Publisher, Nothing)
    bookQuery.LoadSequence(dataSet.Book, Nothing)
  End Sub

  Private Shared Sub FillDataSetUsingTableAdapters(ByVal dataSet As LinqBooksDataSet)
    Dim publisherTableAdapter = New LinqBooksDataSetTableAdapters.PublisherTableAdapter()
    publisherTableAdapter.Fill(dataSet.Publisher)
    Dim bookTableAdapter = New LinqBooksDataSetTableAdapters.BookTableAdapter()
    bookTableAdapter.Fill(dataSet.Book)
  End Sub

#End Region

#End Region

#Region "Event handlers"

#Region "Loading"

  Private Sub btnTestLoading_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTestLoading.Click
    ' Load the DataSet
    Dim dataSet = New DataSet()
    FillDataSetUsingDataAdapter(dataSet)

    Dim theValue As Decimal? = Nothing
    Dim book As DataRow = dataSet.Tables(1).Rows(0)
    book("Price") = IIf(theValue Is Nothing, DBNull.Value, CType(theValue, Object))
    book("Price") = IIf(theValue Is Nothing, CType(DBNull.Value, Object), theValue)
    book.SetField(Of Decimal?)("Price", theValue)

    ' Display the content of the DataSet
    dataGridView1.DataSource = dataSet.Tables(0)
    dataGridView2.DataSource = dataSet.Tables(1)
  End Sub

#End Region

#Region "Without LINQ"

  Private Function CreateDataTable(ByVal sourceTable As DataTable, ByVal rows As DataRow()) As DataTable
    Dim result As DataTable

    result = sourceTable.Clone()
    For Each row As DataRow In rows
      result.Rows.Add(row.ItemArray)
    Next
    Return result
  End Function

  Private Sub btnDataTableSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDataTableSelect.Click
    ' Load a DataSet
    Dim dataSet = New DataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Retrieve subsets of rows from the tables
    Dim publishers As DataRow() = dataSet.Tables(0).Select("LEN(Name) > 5")
    Dim books As DataRow() = dataSet.Tables(1).Select("(Price > 15) AND (Title LIKE '*i*')", "Title DESC")
    ' Display the results
    dataGridView1.DataSource = CreateDataTable(dataSet.Tables(0), publishers)
    dataGridView2.DataSource = CreateDataTable(dataSet.Tables(1), books)
  End Sub

  Private Sub btnDataViews_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDataViews.Click
    ' Load a DataSet
    Dim dataSet = New DataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Create and display DataViews
    dataGridView1.DataSource = New DataView(dataSet.Tables(0), _
        "LEN(Name) > 5", String.Empty, DataViewRowState.Unchanged)
    dataGridView2.DataSource = New DataView(dataSet.Tables(1), _
        "(Price > 15) AND (Title LIKE '*i*')", "Title DESC", DataViewRowState.Unchanged)
  End Sub

  Private Sub btnDataViewsRelationships_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDataViewsRelationships.Click
    ' Load a DataSet
    Dim dataSet = New DataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Create a relation between a publisher and its books
    dataSet.Relations.Add("PublisherBooks", _
      dataSet.Tables(0).Columns("ID"), dataSet.Tables(1).Columns("Publisher"))

    ' Create and display a DataView that filters publishers using a relation
    dataGridView1.DataSource = New DataView(dataSet.Tables(0), _
        "COUNT(CHILD(PublisherBooks).Title) > 0", String.Empty, DataViewRowState.Unchanged)
  End Sub

#End Region

#Region "Untyped DataSet"

  Private Sub btnUntypedSimple_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUntypedSimple.Click
    ' Load a DataSet
    Dim dataSet = New DataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Retrieve a DataTable from the DataSet
    Dim bookTable As DataTable = dataSet.Tables(1)

    ' Query the DataTable
    Dim filteredBooks = _
      From book In bookTable.AsEnumerable() _
      Where book.Field(Of String)("Title").StartsWith("L") _
      Select New With _
        { _
          .Title = book.Field(Of String)("Title"), _
          .Price = book.Field(Of Decimal?)("Price") _
        }

    ' Display the results
    dataGridView2.DataSource = filteredBooks.ToList()
  End Sub

  Private Sub btnUntypedJoin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUntypedJoin.Click
    ' Load a DataSet
    Dim dataSet = New DataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Retrieve the DataTables from the DataSet
    Dim publisherTable As DataTable = dataSet.Tables(0)
    Dim bookTable As DataTable = dataSet.Tables(1)

    ' Query the DataTables
    Dim publisherBooks = _
      From publisher In publisherTable.AsEnumerable() _
      Join book In bookTable.AsEnumerable() _
        On publisher.Field(Of Guid)("ID") Equals book.Field(Of Guid)("Publisher") _
      Select New With _
        { _
          .Publisher = publisher.Field(Of String)("Name"), _
          .Book = book.Field(Of String)("Title") _
        }

    ' Display the results
    dataGridView1.DataSource = publisherBooks.ToList()
  End Sub

  Private Sub btnUntypedRelationship_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUntypedRelationship.Click
    ' Load a DataSet
    Dim dataSet = New DataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Retrieve the DataTables from the DataSet
    Dim publisherTable As DataTable = dataSet.Tables(0)
    Dim bookTable As DataTable = dataSet.Tables(1)

    ' Create a relationship between a publisher and its books
    dataSet.Relations.Add("PublisherBooks", _
      publisherTable.Columns("ID"), bookTable.Columns("Publisher"))

    ' Query the DataTables
    Dim publisherBooks = _
      From publisher In publisherTable.AsEnumerable() _
      From book In publisher.GetChildRows("PublisherBooks") _
      Select New With _
        { _
          .Publisher = publisher.Field(Of String)("Name"), _
          .Book = book.Field(Of String)("Title") _
        }

    ' Display the results
    dataGridView1.DataSource = publisherBooks.ToList()
  End Sub

  Private Sub btnUntypedDataView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUntypedDataView.Click
    ' Load a DataSet
    Dim dataSet As System.Data.DataSet = New System.Data.DataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Retrieve the DataTables from the DataSet
    Dim bookTable As DataTable = dataSet.Tables(1)

    ' Query the DataTable
    Dim books = _
      From book In bookTable.AsEnumerable() _
        Where book.Field(Of String)("Title").Length > 10 _
    Order By book.Field(Of String)("Title") _
    Select book

    ' Create a view on the query and bind it to the first DataGridView
    Dim view As DataView = books.AsDataView()
    dataGridView1.DataSource = view

    ' Bind the Book DataTable to the second DataGridView
    dataGridView2.DataSource = bookTable

    ' You can now sort the results in the grids and make changes in
    ' the first one to see the updates reflected in the second,
    ' as well as the filtering condition applied in the first grid.
  End Sub

#End Region

#Region "Typed DataSet"

  Private Sub btnTypedSimple_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTypedSimple.Click
    ' Load a DataSet
    Dim dataSet As LinqBooksDataSet = New LinqBooksDataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Query the DataTables
    Dim query = _
      From book In dataSet.Book _
      Where book.Title.StartsWith("L") _
      Select New With {book.Title, book.Price}

    ' Display the results
    dataGridView2.DataSource = query.ToList()
  End Sub

  Private Sub btnTypedJoin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTypedJoin.Click
    ' Load a DataSet
    Dim dataSet = New LinqBooksDataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Query the DataTables
    Dim query = _
      From publisher In dataSet.Publisher _
        Join book In dataSet.Book _
          On publisher.ID Equals book.Publisher _
        Select New With _
        { _
          .Publisher = publisher.Name, _
          .Book = book.Title _
        }

    ' Display the results
    dataGridView1.DataSource = query.ToList()
  End Sub

  Private Sub btnTypedRelationship_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTypedRelationship.Click
    ' Load a DataSet
    Dim dataSet = New LinqBooksDataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Query the DataTables
    Dim query = _
      From publisher In dataSet.Publisher _
      From book In publisher.GetBookRows() _
      Select New With _
        { _
          .Publisher = publisher.Name, _
          .Book = book.Title _
        }

    ' Display the results
    dataGridView1.DataSource = query.ToList()
  End Sub

  Private Sub btnTypedDataView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTypedDataView.Click
    ' Load a DataSet
    Dim dataSet = New LinqBooksDataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Query a DataTable
    Dim books = _
      From book In dataSet.Book.AsEnumerable() _
      Where book.Title.Length > 10 _
      Order By book.Title _
      Select book

    ' Create a view on the query and bind it to the first DataGridView
    Dim view As DataView = books.AsDataView()
    dataGridView1.DataSource = view

    ' Bind the Book DataTable to the second DataGridView
    dataGridView2.DataSource = dataSet.Book

    ' You can now sort the results in the grids and make changes in
    ' the first one to see the updates reflected in the second,
    ' as well as the filtering condition applied in the first grid.
  End Sub

#End Region

#Region "CopyToDataTable"

  Private _CopyToDataTableOriginalDataSet As LinqBooksDataSet

  Private Sub btnCopyToDataTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCopyToDataTable.Click
    ' Load a DataSet
    _CopyToDataTableOriginalDataSet = New LinqBooksDataSet()
    FillDataSetUsingLinqToSql2(_CopyToDataTableOriginalDataSet)
    _CopyToDataTableOriginalDataSet.AcceptChanges()

    ' Query the Book DataTable
    Dim books = _
      From book In _CopyToDataTableOriginalDataSet.Book _
      Where book.Title.Contains("a") _
      Order By book.Title _
      Select book

    ' Display the results
    dataGridView2.DataSource = books.CopyToDataTable()

    ' Now that the results of the query are databound to a DataGridView, they can be edited.
    ' Once this is done, the updated data can be merged back into the original DataSet.
    btnShowChanges.Enabled = True
  End Sub

  Private Sub btnShowChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowChanges.Click
    ' Merged back the updated data into the original DataSet
    Dim dataTable As DataTable = CType(dataGridView2.DataSource, DataTable)
    _CopyToDataTableOriginalDataSet.Book.Merge(dataTable)

    ' Finally, you can update the database using the Update method of a DataAdapter,
    ' or simply deal with the changes in any other way.
    ' Here we look at the changes that have been performed.

    Dim changesTable As DataTable = _CopyToDataTableOriginalDataSet.Book.GetChanges()
    Dim hasChanges As Boolean
    If changesTable Is Nothing Then
      hasChanges = False
    ElseIf changesTable.Rows.Count < 1 Then
      hasChanges = False
    Else
      hasChanges = True
    End If
    If Not hasChanges Then
      MessageBox.Show("No changes")
      dataGridView1.DataSource = Nothing
    Else
      Dim changes = _
        From change In changesTable.AsEnumerable() _
        Select New With { _
            .State = change.RowState, _
            .OriginalTitle = change.Field(Of String)("Title", DataRowVersion.Original), _
            .NewTitle = IIf(change.RowState <> DataRowState.Deleted, _
                            change.Field(Of String)("Title", DataRowVersion.Current), _
                            String.Empty) _
          }

      dataGridView1.DataSource = changes.ToList()
    End If
  End Sub

#End Region

#Region "DataRowComparer and set query operators"

  Private Sub btnIntersect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIntersect.Click
    ' Load a DataSet
    Dim dataSet = New LinqBooksDataSet()
    FillDataSetUsingLinqToSql2(dataSet)

    ' Create two tables
    Dim query1 = _
      From book In dataSet.Book.AsEnumerable() _
      Where book.Price < 30 _
      Select book
    Dim query2 = _
      From book In dataSet.Book.AsEnumerable() _
      Where book.PageCount > 100 _
      Select book
    Dim books1 = New LinqBooksDataSet.BookDataTable()
    query1.CopyToDataTable(books1, LoadOption.PreserveChanges)
    Dim books2 = New LinqBooksDataSet.BookDataTable()
    query2.CopyToDataTable(books2, LoadOption.PreserveChanges)

    ' Find the intersection of the two tables
    Dim comparer As IEqualityComparer(Of LinqBooksDataSet.BookRow) = _
        New DataRowComparer(Of LinqBooksDataSet.BookRow)()
    Dim books = _
      books1.AsEnumerable() _
        .Intersect(books2.AsEnumerable(), comparer) _
        .Select(Function(book) New With {book.Title, book.Price, book.PageCount})

    ' Display the results:
    '   the books costing less than 30 that have more than 100 pages
    dataGridView2.DataSource = books.ToList()
  End Sub

  ' Generic DataRow comparer that works with typed DataSets
  ' .NET 3.5 should include a similar class post Beta 2
  Public Class DataRowComparer(Of TDataRow As DataRow)
    Implements IEqualityComparer(Of TDataRow)

#Region "IEqualityComparer(Of TDataRow) Members"

    Function IEqualityComparer_Equals(ByVal x As TDataRow, ByVal y As TDataRow) As Boolean _
      Implements IEqualityComparer(Of TDataRow).Equals

      Return DataRowComparer.Default.Equals(x, y)
    End Function

    Function IEqualityComparer_GetHashCode(ByVal obj As TDataRow) As Integer _
      Implements IEqualityComparer(Of TDataRow).GetHashCode

      Return DataRowComparer.Default.GetHashCode(obj)
    End Function

#End Region

  End Class

#End Region

#End Region

End Class