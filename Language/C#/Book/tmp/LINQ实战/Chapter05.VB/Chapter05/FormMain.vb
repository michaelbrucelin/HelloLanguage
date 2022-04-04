Imports System.IO
Imports System.Linq.Expressions
Imports LinqInAction.LinqBooks.Common

Public Class FormMain

  Private dictionaryResults As IDictionary(Of String, IList(Of Book))
  Private results As List(Of Book)
  Private testBooks As List(Of Book)

  Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    cbxSortOrder.SelectedIndex = 0
    cbxSortOrder.SelectedIndex = 0

    dataGridView1.AutoGenerateColumns = False
    dataGridView1.Columns.Clear()
    dataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Title", .HeaderText = "Title"})
    dataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "PageCount", .HeaderText = "Pages"})
    dataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Publisher", .HeaderText = "Publisher"})
  End Sub

#Region "Non-generic collections"

  ''' <summary>
  ''' Simulates code that prepares an ArrayList containing Book objects
  ''' </summary>
  Private Function GetArrayList() As ArrayList
    Return New ArrayList(SampleData.Books)
  End Function

  Private Sub btnQueryArrayListWithExplicitCast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQueryArrayListWithExplicitCast.Click
    Dim books As ArrayList = GetArrayList()

    Dim query = _
      From book In books.Cast(Of Book)() _
      Where book.PageCount > 150 _
      Select New With {book.Title, book.Publisher.Name}

    dataGridView2.DataSource = query.ToList()
  End Sub

  Private Sub btnQueryArrayListWithImplicitCast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQueryArrayListWithImplicitCast.Click
    Dim books As ArrayList = GetArrayList()

    Dim query = _
      From book As Book In books _
      Where book.PageCount > 150 _
      Select New With {book.Title, book.Publisher.Name}

    dataGridView2.DataSource = query.ToList()
  End Sub

#End Region

#Region "Grouping"

  Private Sub btnGrouping1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrouping1.Click
    ' Groups books by publisher and subject

    Dim query = _
      From book In SampleData.Books _
      Group book By book.Publisher, book.Subject Into grouping = Group _
      Select New With { _
        .Publisher = Publisher.Name, _
        .Subject = Subject.Name, _
        .Books = grouping _
      }

    Using writer = New StringWriter()
      ObjectDumper.Write(query, 1, writer)
      txtGroupingResults.Text = writer.ToString()
    End Using
  End Sub

  Private Sub btnGrouping2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrouping2.Click
    ' Groups book titles by publisher and subject

    Dim query = _
      From book In SampleData.Books _
      Group book.Title By book.Publisher, book.Subject Into grouping = Group _
      Select New With { _
        .Publisher = Publisher.Name, _
        .Subject = Subject.Name, _
        .Titles = grouping _
      }

    Using writer = New StringWriter()
      ObjectDumper.Write(query, 1, writer)
      txtGroupingResults.Text = writer.ToString()
    End Using
  End Sub

  Private Sub btnGrouping3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrouping3.Click
    ' Groups books by subject and returns the title and publisher of each book

    Dim query = _
      From book In SampleData.Books _
      Group New With {book.Title, book.Publisher.Name} By book.Subject Into grouping = Group _
      Select New With {.Subject = Subject.Name, .Books = grouping}

    Using writer = New StringWriter()
      ObjectDumper.Write(query, 1, writer)
      txtGroupingResults.Text = writer.ToString()
    End Using
  End Sub

#End Region

#Region "Dynamic queries"

  Private Sub ChangingVariable()
    Dim minPageCount As Integer = 0

    Dim books = _
      From book In SampleData.Books _
      Where book.PageCount >= minPageCount _
      Select book

    minPageCount = 200
    MessageBox.Show(String.Format("Books with at least {0} pages: {1}", _
      minPageCount, books.Count()))
    minPageCount = 50
    MessageBox.Show(String.Format("Books with at least {0} pages: {1}", _
      minPageCount, books.Count()))
  End Sub

  Private Sub ParameterizedQuery(ByVal minPageCount As Integer)
    Dim books = _
      From book In SampleData.Books _
      Where book.PageCount >= minPageCount _
      Select book

    MessageBox.Show(String.Format("Books with at least {0} pages: {1}", _
        minPageCount, books.Count()))
  End Sub

  Private Sub CustomSort(Of TKey)(ByVal selector As Func(Of Book, TKey))
    ' Method syntax (explicit dot notation)
    'Dim books = SampleData.Books.OrderBy(selector)
    ' dataGridView1.DataSource = books.ToList()

    ' Query expression
    Dim books = _
      From book In SampleData.Books _
      Order By selector(book) _
      Select book
    dataGridView1.DataSource = books.ToList()
  End Sub

  Private Sub CustomSort(Of TKey)(ByVal selector As Func(Of Book, TKey), ByVal ascending As Boolean)
    Dim books As IEnumerable(Of Book) = SampleData.Books
    books = If(ascending, books.OrderBy(selector), books.OrderByDescending(selector))
    dataGridView1.DataSource = books.ToList()
  End Sub

  Private Sub btnChangingVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangingVariable.Click
    ChangingVariable()
  End Sub

  Private Sub btnParameterizedQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParameterizedQuery.Click
    ParameterizedQuery(200)
    ParameterizedQuery(50)
  End Sub

  Private Sub btnCustomSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomSort.Click
    Select Case cbxSortOrder.SelectedIndex
      Case 0
        CustomSort(Function(book) book.Title)
      Case 1
        CustomSort(Function(book) book.Title, False)
      Case 2
        CustomSort(Function(book) book.Publisher.Name)
      Case 3
        CustomSort(Function(book) book.PageCount)
    End Select
  End Sub

  Private Sub btnConditionalQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConditionalQuery.Click
    Using form = New FormConditionalQuery()
      form.ShowDialog()
    End Using
  End Sub

  Private Sub btnDynamicQueryExpressionTree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDynamicQueryExpressionTree.Click
    'The code below dynamically creates a query at run-time that is equivalent to the following query:
    'Dim query = _
    '  From book In SampleData.Books _
    '  Where (book.Title <> "Funny Stories") And (book.PageCount > 100) _
    '  Select book

    ' define the book variable
    Dim book = Expression.Parameter(GetType(Book), "book")
    ' book.Title <> "Funny Stories"
    Dim titleExpression = Expression.NotEqual( _
      Expression.Property(book, "Title"), Expression.Constant("Funny Stories"))
    ' book.PageCount > 100
    Dim pageCountExpression = Expression.GreaterThan( _
      Expression.Property(book, "PageCount"), Expression.Constant(100))
    ' and
    Dim andExpression = Expression.And(titleExpression, pageCountExpression)
    ' create the where clause
    Dim predicate = Expression.Lambda(andExpression, book)
    Dim query = Enumerable.Where(SampleData.Books, CType(predicate.Compile(), Func(Of Book, Boolean)))

    dataGridView1.DataSource = query.ToList()
  End Sub

#End Region

#Region "LINQ to Text Files"

  Private Sub btnLinqtoTextFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinqtoTextFiles.Click
    Dim books = _
      From line In File.ReadAllLines("books.csv") _
      Where Not line.StartsWith("#") _
        Let parts = line.Split(",") _
        Select New With {.Isbn = parts(0), .Title = parts(1), .Publisher = parts(3)}

    Using writer = New StringWriter()
      ObjectDumper.Write(books, 1, writer)
      txtLinqToTextFilesResults.Text = writer.ToString()
    End Using
  End Sub

#End Region

#Region "Design Patterns"

  Private Sub btnFunctionalConstructionAnonymous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFunctionalConstructionAnonymous.Click
    Dim books = _
      From line In File.ReadAllLines("books.csv") _
      Where Not line.StartsWith("#") _
      Let parts = line.Split(",") _
      Select New With { _
        .Isbn = parts(0), _
        .Title = parts(1), _
        .Publisher = parts(3), _
        .Authors = _
          From authorFullName In parts(2).Split(";") _
          Let authorNameParts = authorFullName.Split(" ") _
          Select New With { _
            .FirstName = authorNameParts(0), _
            .LastName = authorNameParts(1) _
          } _
      }

    Using writer = New StringWriter()
      ObjectDumper.Write(books, 1, writer)
      txtDesignPatternsResults.Text = writer.ToString()
    End Using
  End Sub

  Private Sub btnFunctionalConstruction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFunctionalConstruction.Click
    Dim books = _
      From line In File.ReadAllLines("books.csv") _
      Where Not line.StartsWith("#") _
      Let parts = line.Split(",") _
      Select New Book With { _
        .Isbn = parts(0), _
        .Title = parts(1), _
        .Publisher = New Publisher With {.Name = parts(3)}, _
        .Authors = _
          From authorFullName In parts(2).Split(";") _
          Let authorNameParts = authorFullName.Split(" ") _
          Select New Author With { _
            .FirstName = authorNameParts(0), _
            .LastName = authorNameParts(1) _
          } _
      }

    Using writer = New StringWriter()
      ObjectDumper.Write(books, 1, writer)
      txtDesignPatternsResults.Text = writer.ToString()
    End Using
  End Sub

  Private Sub btnForEach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForEach.Click
    MsgBox("ForEach cannot be used in VB because it requires a statement lambda and VB.NET 9.0 does not offer support for statement lambdas.")

    ' ForEach cannot be used in VB because it requires a statement lambda
    '  and VB.NET 9.0 does not offer support for statement lambdas.
    '  The samples we have in C# cannot be converted to VB.

    ' The calls to ForEach in the statements below produce the following
    '  error at compile-time: "Expression does not produce a value".

    'SampleData.Books _
    '  .Where(Function(Book) Book.PageCount > 150) _
    '  .ForEach(Function(book) txtDesignPatternsResults.AppendText(book.Title + Environment.NewLine))

    'txtDesignPatternsResults.AppendText(Environment.NewLine)

    'Dim query = _
    '  From book In SampleData.Books _
    '  Where book.PageCount > 150 _
    '  Select book
    'query.ForEach(Function(book) txtDesignPatternsResults.AppendText(book.Title + Environment.NewLine))
  End Sub

#End Region

#Region "Performance"

#Region "Utility methods"

  Private Function GetBooksForPerformance() As List(Of Book)
    ' Seed 123 will return 499357 results for PageCount > 500
    Dim rndBooks = New Random(123)
    Dim rndPublishers = New Random(123)
    Dim publisherCount = SampleData.Publishers.Count()

    Dim result = New List(Of Book)()
    For i = 1 To 1000000
      Dim publisher = SampleData.Publishers.Skip(rndPublishers.Next(publisherCount)).First()
      Dim pageCount = rndBooks.Next(1000)
      result.Add(New Book With _
                 { _
                   .Title = pageCount.ToString(), _
                   .PageCount = pageCount, _
                   .Publisher = publisher _
                 })
    Next

    Return result
  End Function

  Private Sub Run(ByVal times As Integer, ByVal prepareFunc As MethodInvoker, ByVal executeFunc As MethodInvoker, ByVal textBox As TextBox)
    Dim oldCursor As Cursor

    oldCursor = Cursor.Current
    Cursor.Current = Cursors.WaitCursor
    Try
      Dim runs = New List(Of Long)(times)

      If Not prepareFunc Is Nothing Then
        prepareFunc()
      End If
      GC.Collect()
      GC.WaitForPendingFinalizers()

      Dim stopwatch = New Stopwatch()
      For i = 1 To times
        stopwatch.Start()
        executeFunc()
        stopwatch.Stop()
        runs.Add(stopwatch.ElapsedMilliseconds)
        stopwatch.Reset()
      Next

      textBox.AppendText(String.Format("Avg: {0:000}; Min: {1:000}; Max: {2:000}; Runs: {3}{4}", _
         runs.Average(), runs.Min(), runs.Max(), times, Environment.NewLine))
    Finally
      Cursor.Current = oldCursor
    End Try
  End Sub

  Private Sub btnCollect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollect.Click
    GC.Collect()
    GC.WaitForPendingFinalizers()
  End Sub

#End Region

#Region "LINQ to Text Files"

  Private Sub btnPerformanceLinqToTextFilesBad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformanceLinqToTextFilesBad.Click
    ' ReadAllLines = All content in memory!
    Dim books = _
      From line In File.ReadAllLines("books.csv") _
      Where Not line.StartsWith("#") _
      Let parts = line.Split(",") _
      Select New With {.Isbn = parts(0), .Title = parts(1), .Publisher = parts(3)}

    Using writer = New StringWriter()
      ObjectDumper.Write(books, 1, writer)
      txtLinqToTextFilesPerformanceResults.Text = writer.ToString()
    End Using
  End Sub

  Private Sub btnPerformanceLinqToTextFilesGood_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformanceLinqToTextFilesGood.Click
    Using reader = New StreamReader("books.csv")
      Dim books = _
        From line In reader.Lines() _
        Where Not line.StartsWith("#") _
        Let parts = line.Split(",") _
        Select New With {.Isbn = parts(0), .Title = parts(1), .Publisher = parts(3)}

      Using writer = New StringWriter()
        ' This is where the processing happens
        ObjectDumper.Write(books, 1, writer)
        txtLinqToTextFilesPerformanceResults.Text = writer.ToString()
      End Using
    End Using
    ' Warning, the reader should not be disposed while we are likely to enumerate the query!
    ' Don't forget that deferred execution happens here
  End Sub

#End Region

#Region "Immediate complete iteration"

  Private Sub btnImmediateCompleteIteration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImmediateCompleteIteration.Click
    Using reader = New StreamReader("books.csv")
      Dim books = _
        From line In reader.Lines().Reverse() _
        Where Not line.StartsWith("#") _
        Let parts = line.Split(",") _
        Select New With {.Isbn = parts(0), .Title = parts(1), .Publisher = parts(3)}

      Using writer = New StringWriter()
        ' This is where the processing happens
        ObjectDumper.Write(books, 1, writer)
        txtImmediateCompleteIterationResults.Text = writer.ToString()
      End Using
    End Using
  End Sub

#End Region

#Region "MaxElement"

  Private Sub TestMaxElementWithoutLinq()
    Dim maxBook As Book = Nothing

    For Each book In testBooks
      If (maxBook Is Nothing) Then
        maxBook = book
      ElseIf book.PageCount > maxBook.PageCount Then
        maxBook = book
      End If
    Next
  End Sub

  Private Sub btnMaxElementWithoutLinq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaxElementWithoutLinq.Click

    testBooks = GetBooksForPerformance()

    Run( _
      CType(updMaxElementsRuns.Value, Integer), _
      Nothing, _
      New MethodInvoker(AddressOf TestMaxElementWithoutLinq), _
      txtMaxElementResults _
    )
  End Sub

  Private Sub TestMaxElementWithOrderByAndFirst()
    Dim sortedList = _
      From book In testBooks _
      Order By book.PageCount Descending _
      Select book
    Dim maxBook = sortedList.First()
  End Sub

  Private Sub btnMaxElementOrderbyAndFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaxElementOrderbyAndFirst.Click
    testBooks = GetBooksForPerformance()

    Run( _
      CType(updMaxElementsRuns.Value, Integer), _
      Nothing, _
      New MethodInvoker(AddressOf TestMaxElementWithOrderByAndFirst), _
      txtMaxElementResults _
    )
  End Sub

  Private Sub TestMaxElementWithSubQuery()
    Dim maxList = _
      From book In testBooks _
      Where book.PageCount = testBooks.Max(Function(b) b.PageCount) _
      Select book
    Dim maxBook = maxList.First()
  End Sub

  Private Sub btnMaxElementSubquery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaxElementSubquery.Click
    testBooks = GetBooksForPerformance()

    Run( _
      CType(updMaxElementsRuns.Value, Integer), _
      Nothing, _
      New MethodInvoker(AddressOf TestMaxElementWithSubQuery), _
      txtMaxElementResults _
    )
  End Sub

  Private Sub TestMaxElementWithTwoQueries()
    Dim maxPageCount = testBooks.Max(Function(book) book.PageCount)
    Dim maxList = _
      From book In testBooks _
      Where book.PageCount = maxPageCount _
      Select book
    Dim maxBook = maxList.First()
  End Sub

  Private Sub btnMaxElementTwoQueries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaxElementTwoQueries.Click
    testBooks = GetBooksForPerformance()

    Run( _
      CType(updMaxElementsRuns.Value, Integer), _
      Nothing, _
      New MethodInvoker(AddressOf TestMaxElementWithTwoQueries), _
      txtMaxElementResults _
    )
  End Sub

  Private Sub TestMaxElementWithCustomOperator()
    Dim maxBook = testBooks.MaxElement(Function(book) book.PageCount)
  End Sub

  Private Sub btnMaxElementCustomOperator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaxElementCustomOperator.Click
    testBooks = GetBooksForPerformance()

    Run( _
      CType(updMaxElementsRuns.Value, Integer), _
      Nothing, _
      New MethodInvoker(AddressOf TestMaxElementWithCustomOperator), _
      txtMaxElementResults _
    )
  End Sub

#End Region

#Region "LINQ's overhead"

  Private Sub ClearResults()
    results.Clear()
  End Sub

#Region "For Each"

  Private Sub TestPerformance_ForEach_FilterOnInt()
    For Each book In testBooks
      If book.PageCount > 500 Then
        results.Add(book)
      End If
    Next
  End Sub
  Private Sub TestPerformance_ForEach_FilterOnString()
    For Each book In testBooks
      If book.Title.StartsWith("1") Then
        results.Add(book)
      End If
    Next
  End Sub
  Private Sub TestPerformance_ForEach_Sort()
    For Each book In testBooks
      If book.PageCount > 500 Then
        results.Add(book)
      End If
    Next
    results.Sort(Function(book1, book2) book1.Title.CompareTo(book2.Title))
  End Sub
  Private Sub TestPerformance_ForEach_Join()
    For Each publisher In SampleData.Publishers
      For Each book In testBooks
        If publisher.ReferenceEquals(book.Publisher, publisher) And book.PageCount > 500 Then
          results.Add(book)
        End If
      Next
    Next
  End Sub

  Private Sub btnPerformanceForeach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformanceForeach.Click
    testBooks = GetBooksForPerformance()

    If rdbFilterOnInt.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_ForEach_FilterOnInt), _
        txtPerformanceResults _
      )
    ElseIf rdbFilterOnString.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_ForEach_FilterOnString), _
        txtPerformanceResults _
      )
    ElseIf rdbSort.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_ForEach_Sort), _
        txtPerformanceResults _
      )
    ElseIf rdbJoin.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_ForEach_Join), _
        txtPerformanceResults _
      )
    Else
      Throw New NotImplementedException()
    End If
  End Sub

#End Region

#Region "For"

  Private Sub TestPerformance_For_FilterOnInt()
    For i = 0 To testBooks.Count - 1
      Dim book = testBooks(i)
      If book.PageCount > 500 Then
        results.Add(book)
      End If
    Next
  End Sub
  Private Sub TestPerformance_For_FilterOnString()
    For i = 0 To testBooks.Count - 1
      Dim book = testBooks(i)
      If book.Title.StartsWith("1") Then
        results.Add(book)
      End If
    Next
  End Sub

  Private Sub btnPerformanceFor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformanceFor.Click
    testBooks = GetBooksForPerformance()

    If rdbFilterOnInt.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_For_FilterOnInt), _
        txtPerformanceResults _
      )
    ElseIf rdbFilterOnString.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_For_FilterOnString), _
        txtPerformanceResults _
      )
    Else
      Throw New NotImplementedException()
    End If
  End Sub

#End Region

#Region "List(Of T).FindAll"

  Private Sub TestPerformance_ListFindAll_FilterOnInt()
    results = testBooks.FindAll(Function(book) book.PageCount > 500)
  End Sub
  Private Sub TestPerformance_ListFindAll_FilterOnString()
    results = testBooks.FindAll(Function(book) book.Title.StartsWith("1"))
  End Sub

  ' Does not return titles
  ' Does not pre-size the list
  Private Sub btnPerformanceListFindAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformanceListFindAll.Click
    testBooks = GetBooksForPerformance()

    If rdbFilterOnInt.Checked Then
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        Nothing, _
        New MethodInvoker(AddressOf TestPerformance_ListFindAll_FilterOnInt), _
        txtPerformanceResults _
      )
    ElseIf rdbFilterOnString.Checked Then
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        Nothing, _
        New MethodInvoker(AddressOf TestPerformance_ListFindAll_FilterOnString), _
        txtPerformanceResults _
      )
    Else
      Throw New NotImplementedException()
    End If
  End Sub

#End Region

#Region "List(Of T).ForEach"

  Private Sub ListForEach_FilterOnInt(ByVal book As Book)
    If book.PageCount > 500 Then
      results.Add(book)
    End If
  End Sub
  Private Sub ListForEach_FilterOnString(ByVal book As Book)
    If book.Title.StartsWith("1") Then
      results.Add(book)
    End If
  End Sub

  Private Sub TestPerformance_ListForEach_FilterOnInt()
    testBooks.ForEach(AddressOf ListForEach_FilterOnInt)
  End Sub
  Private Sub TestPerformance_ListForEach_FilterOnString()
    testBooks.ForEach(AddressOf ListForEach_FilterOnString)
  End Sub

  Private Sub btnPerformanceListForEach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformanceListForEach.Click
    testBooks = GetBooksForPerformance()

    If rdbFilterOnInt.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_ListForEach_FilterOnInt), _
        txtPerformanceResults _
      )
    ElseIf rdbFilterOnString.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_ListForEach_FilterOnString), _
        txtPerformanceResults _
      )
    Else
      Throw New NotImplementedException()
    End If
  End Sub

#End Region

#Region "LINQ with ToList"

  Private Sub TestPerformance_ToList_FilterOnInt()
    Dim query = _
      From book In testBooks _
      Where book.PageCount > 500 _
      Select book
    query.ToList()
  End Sub
  Private Sub TestPerformance_ToList_FilterOnString()
    Dim query = _
      From book In testBooks _
      Where book.Title.StartsWith("1") _
      Select book
    query.ToList()
  End Sub

  ' Does not pre-size the list
  Private Sub btnPerformanceToList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformanceToList.Click
    testBooks = GetBooksForPerformance()

    If rdbFilterOnInt.Checked Then
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        Nothing, _
        New MethodInvoker(AddressOf TestPerformance_ToList_FilterOnInt), _
        txtPerformanceResults _
      )
    ElseIf rdbFilterOnString.Checked Then
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        Nothing, _
        New MethodInvoker(AddressOf TestPerformance_ToList_FilterOnString), _
        txtPerformanceResults _
      )
    Else
      Throw New NotImplementedException()
    End If
  End Sub

#End Region

#Region "LINQ with presized list"

  Private Sub TestPerformance_LinqPresized_FilterOnInt()
    Dim query = _
      From book In testBooks _
      Where book.PageCount > 500 _
      Select book
    For Each book In query
      results.Add(book)
    Next
  End Sub
  Private Sub TestPerformance_LinqPresized_FilterOnString()
    Dim query = _
      From book In testBooks _
      Where book.Title.StartsWith("1") _
      Select book
    For Each book In query
      results.Add(book)
    Next
  End Sub
  Private Sub TestPerformance_LinqPresized_Sort()
    Dim query = _
      From book In testBooks _
      Where book.PageCount > 500 _
      Order By book.Title _
      Select book
    For Each book In query
      results.Add(book)
    Next
  End Sub
  Private Sub TestPerformance_LinqPresized_Join()
    Dim query = _
      From publisher In SampleData.Publishers _
      Join book In testBooks On publisher Equals book.Publisher _
      Where book.PageCount > 500 _
      Select book
    For Each book In query
      results.Add(book)
    Next
  End Sub

  Private Sub btnPerformanceLinqPresized_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPerformanceLinqPresized.Click
    testBooks = GetBooksForPerformance()

    If rdbFilterOnInt.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_LinqPresized_FilterOnInt), _
        txtPerformanceResults _
      )
    ElseIf rdbFilterOnString.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_LinqPresized_FilterOnString), _
        txtPerformanceResults _
      )
    ElseIf rdbSort.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_LinqPresized_Sort), _
        txtPerformanceResults _
      )
    ElseIf rdbJoin.Checked Then
      results = New List(Of Book)(499357)
      Run( _
        CType(updOverheadRuns.Value, Integer), _
        New MethodInvoker(AddressOf ClearResults), _
        New MethodInvoker(AddressOf TestPerformance_LinqPresized_Join), _
        txtPerformanceResults _
      )
    Else
      Throw New NotImplementedException()
    End If
  End Sub

#End Region

#End Region

#Region "Grouping"

  Private Sub ClearDictionaryResults()
    dictionaryResults.Clear()
  End Sub

  Private Sub TestGroupingWithLinq()
    Dim query = _
      From book In testBooks _
      Group book By book.Publisher Into publisherBooks = Group _
      Order By Publisher.Name _
      Select New With {Publisher.Name, .Books = publisherBooks}
    query.ToList()
  End Sub

  Private Sub TestGroupingWithoutLinq()
    For Each book In testBooks
      Dim publisherBooks As IList(Of Book) = Nothing

      If Not dictionaryResults.TryGetValue(book.Publisher.Name, publisherBooks) Then
        publisherBooks = New List(Of Book)()
        dictionaryResults(book.Publisher.Name) = publisherBooks
      End If
      publisherBooks.Add(book)
    Next
  End Sub

  Private Sub btnGroupingWithoutLinq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupingWithoutLinq.Click
    ' Create book groups sorted by publisher name
    dictionaryResults = New SortedDictionary(Of String, IList(Of Book))()

    For Each book In SampleData.Books
      Dim publisherBooks As IList(Of Book) = Nothing

      If Not dictionaryResults.TryGetValue(book.Publisher.Name, publisherBooks) Then
        publisherBooks = New List(Of Book)()
        dictionaryResults(book.Publisher.Name) = publisherBooks
      End If
      publisherBooks.Add(book)
    Next

    ' Display
    Using writer = New StringWriter()
      For Each publisher In dictionaryResults
        writer.WriteLine(publisher.Key)
        For Each book In publisher.Value
          writer.WriteLine(vbTab & book.Title)
        Next
      Next
      txtPerformanceGroupingResults.Text = writer.ToString()
    End Using
  End Sub

  Private Sub btnGroupingWithLinq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupingWithLinq.Click
    ' Create book groups sorted by publisher name
    Dim results = _
      From book In SampleData.Books _
      Group book By book.Publisher Into publisherBooks = Group _
      Order By Publisher.Name _
      Select New With {Publisher.Name, .Books = publisherBooks}

    ' Display
    Using writer = New StringWriter()
      For Each publisher In results
        writer.WriteLine(publisher.Name)
        For Each book In publisher.Books
          writer.WriteLine(vbTab & book.Title)
        Next
      Next
      txtPerformanceGroupingResults.Text = writer.ToString()
    End Using
  End Sub

  Private Sub btnGroupingWithoutLinqPerf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupingWithoutLinqPerf.Click
    testBooks = GetBooksForPerformance()
    dictionaryResults = New SortedDictionary(Of String, IList(Of Book))()

    Run( _
      CType(updGroupingRuns.Value, Integer), _
      New MethodInvoker(AddressOf ClearDictionaryResults), _
      New MethodInvoker(AddressOf TestGroupingWithoutLinq), _
      txtPerformanceGroupingResults _
    )
  End Sub

  Private Sub btnGroupingWithLinqPerf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupingWithLinqPerf.Click
    testBooks = GetBooksForPerformance()
    dictionaryResults = New SortedDictionary(Of String, IList(Of Book))()

    Run( _
      CType(updGroupingRuns.Value, Integer), _
      New MethodInvoker(AddressOf ClearDictionaryResults), _
      New MethodInvoker(AddressOf TestGroupingWithLinq), _
      txtPerformanceGroupingResults _
    )
  End Sub

#End Region

#End Region

End Class