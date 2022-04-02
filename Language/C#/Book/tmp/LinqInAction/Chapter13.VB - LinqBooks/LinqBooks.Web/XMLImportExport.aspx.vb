Imports LinqBooks.Entities

Partial Public Class XMLImportExport
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

  End Sub

  Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim dataSet As LinqBooksDataSet

    dataSet = New LinqBooksDataSet()
    dataSet.ReadXml(uploadXml.FileContent)
    Session("DataSet") = dataSet

    DisplayData()
  End Sub

  Private Sub DisplayData()
    Dim dataContext As LinqBooksDataContext
    Dim dataSet As LinqBooksDataSet

    dataContext = New LinqBooksDataContext()
    Dim knownTitles As IEnumerable(Of String) = dataContext.Books.Select(Function(book) book.Title)

    dataSet = CType(Session("DataSet"), LinqBooksDataSet)
    Dim queryExisting = _
      From book In dataSet.Book _
      Where knownTitles.Contains(book.Title) _
      Order By book.Title _
      Select New With { _
               .Title = book.Title, _
               .Publisher = book.PublisherRow.Name, _
               .ISBN = book.Field(Of String)("Isbn"), _
               .Subject = book.SubjectRow.Name _
             }
    GridViewDataSetExisting.DataSource = queryExisting
    GridViewDataSetExisting.DataBind()

    Dim queryNew = _
      From book In dataSet.Book _
      Where Not knownTitles.Contains(book.Title) _
      Order By book.Title _
        Select New With { _
                 .Id = book.ID, _
                 .Title = book.Title, _
                 .Publisher = book.PublisherRow.Name, _
                 .ISBN = book.Field(Of String)("Isbn"), _
                 .Subject = book.SubjectRow.Name _
               }
    GridViewDataSetNew.DataSource = queryNew
    GridViewDataSetNew.DataBind()

    divData.Visible = True
    btnImport.Visible = GridViewDataSetNew.Rows.Count > 0
  End Sub


  Protected Sub btnImport_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim dataContext As LinqBooksDataContext
    Dim dataSet As LinqBooksDataSet

    dataContext = New LinqBooksDataContext()
    dataSet = CType(Session("DataSet"), LinqBooksDataSet)

    For Each gridRow As GridViewRow In GridViewDataSetNew.Rows
      Dim chkImport = CType(gridRow.FindControl("chkImport"), CheckBox)
      If Not chkImport.Checked Then
        Continue For
      End If

      ' Retrieve data
      Dim bookId = CType(GridViewDataSetNew.DataKeys(gridRow.RowIndex).Value, Guid)

      ' Find book
      Dim bookRow As LinqBooksDataSet.BookRow = dataSet.Book.FindByID(bookId)

      ' Find or create publisher
      Dim publisherId As Guid = _
        dataContext.Publishers() _
          .Where(Function(p) p.Name = bookRow.PublisherRow.Name) _
          .Select(Function(p) p.ID) _
          .SingleOrDefault()
      If publisherId = Guid.Empty Then
        publisherId = bookRow.Publisher
        Dim publisher = New Publisher()
        publisher.ID = publisherId
        publisher.Name = bookRow.PublisherRow.Name
        dataContext.Publishers.InsertOnSubmit(publisher)
      End If

      ' Find or create authors
      For Each bookAuthorRow As LinqBooksDataSet.BookAuthorRow In bookRow.GetBookAuthorRows()
        Dim tempBookAuthorRow = bookAuthorRow
        Dim authorId As Guid = _
          dataContext.Authors _
            .Where(Function(a) (a.FirstName = tempBookAuthorRow.AuthorRow.FirstName) AndAlso (a.LastName = tempBookAuthorRow.AuthorRow.LastName)) _
            .Select(Function(s) s.ID) _
            .SingleOrDefault()
        If authorId = Guid.Empty Then
          authorId = bookAuthorRow.Author
          Dim author = New Author()
          author.ID = authorId
          author.FirstName = bookAuthorRow.AuthorRow.FirstName
          author.LastName = bookAuthorRow.AuthorRow.LastName
          dataContext.Authors.InsertOnSubmit(author)
        End If

        Dim bookAuthor = New BookAuthor()
        bookAuthor.Author = authorId
        bookAuthor.Book = bookRow.ID
        dataContext.BookAuthors.InsertOnSubmit(bookAuthor)
      Next

      ' Find or create subject
      Dim subjectId As Guid = _
        dataContext.Subjects() _
          .Where(Function(s) s.Name = bookRow.SubjectRow.Name) _
          .Select(Function(s) s.ID) _
          .SingleOrDefault()
      If subjectId = Guid.Empty Then
        subjectId = bookRow.Subject
        Dim subject = New Subject()
        subject.ID = subjectId
        subject.Name = bookRow.SubjectRow.Name
        dataContext.Subjects.InsertOnSubmit(subject)
      End If

      ' Create book
      Dim book = New Book()
      book.ID = bookRow.ID
      book.Title = bookRow.Title
      book.Isbn = bookRow.Isbn
      book.Price = bookRow.Field(Of Decimal?)("Price")
      book.Publisher = publisherId
      book.Subject = subjectId
      dataContext.Books.InsertOnSubmit(book)
    Next

    dataContext.SubmitChanges()

    Response.Redirect("~/Books.aspx")
  End Sub
End Class