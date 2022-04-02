Imports LinqBooks.Entities

Partial Public Class AddBooks
  Inherits System.Web.UI.Page

  Private _DataContext As LinqBooksDataContext

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    _DataContext = New LinqBooksDataContext()

    If Not IsPostBack Then
      ddlPublisher.DataSource = _DataContext.Publishers.OrderBy(Function(publisher) publisher.Name)
      ddlPublisher.DataValueField = "ID"
      ddlPublisher.DataTextField = "Name"
      ddlPublisher.DataBind()

      ddlSubjectByHand.DataSource = _DataContext.Subjects.OrderBy(Function(subject) subject.Name)
      ddlSubjectByHand.DataValueField = "ID"
      ddlSubjectByHand.DataTextField = "Name"
      ddlSubjectByHand.DataBind()

      ddlSubjectFromAmazon.DataSource = _DataContext.Subjects.OrderBy(Function(subject) subject.Name)
      ddlSubjectFromAmazon.DataValueField = "ID"
      ddlSubjectFromAmazon.DataTextField = "Name"
      ddlSubjectFromAmazon.DataBind()
    End If
  End Sub

  Protected Sub btnAddByHand_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim book = New Book()
    book.ID = Guid.NewGuid()
    book.Title = txtTitle.Text
    book.Isbn = txtIsbn.Text
    book.Notes = txtNotes.Text
    If Not String.IsNullOrEmpty(txtPageCount.Text) Then
      book.PageCount = Int32.Parse(txtPageCount.Text)
    End If
    If Not String.IsNullOrEmpty(txtPrice.Text) Then
      book.Price = Decimal.Parse(txtPrice.Text)
    End If
    If PubDate.SelectedDate <> DateTime.MinValue Then
      book.PubDate = PubDate.SelectedDate
    End If
    book.Publisher = New Guid(ddlPublisher.SelectedValue)
    If ddlSubjectByHand.SelectedIndex > 0 Then
      book.Subject = New Guid(ddlSubjectByHand.SelectedValue)
    End If
    book.Summary = txtSummary.Text

    _DataContext.Books.InsertOnSubmit(book)
    _DataContext.SubmitChanges()

    Response.Redirect("~/Books.aspx")
  End Sub

  Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim query = _
      From book In New AmazonBookSearch() _
      Where _
        book.Title.Contains(txtSearchKeywords.Text) AndAlso _
        book.Publisher = txtSearchPublisher.Text AndAlso _
        book.Price <= 25 AndAlso _
        book.Condition = BookCondition.New _
      Order By book.Title _
      Select book

    GridViewAmazonBooks.DataSource = query
    GridViewAmazonBooks.DataBind()

    divImport.Visible = GridViewAmazonBooks.Rows.Count > 0
  End Sub

  Protected Sub btnImport_Click(ByVal sender As Object, ByVal e As EventArgs)
    For Each row As GridViewRow In GridViewAmazonBooks.Rows
      Dim chkImport = CType(row.FindControl("chkImport"), CheckBox)
      If Not chkImport.Checked Then
        Continue For
      End If

      ' Retrieve data
      Dim title As String = row.Cells(1).Text
      Dim publisherName As String = row.Cells(2).Text
      Dim isbn As String = row.Cells(3).Text
      Dim price As Decimal? = If(String.IsNullOrEmpty(row.Cells(5).Text), Nothing, Decimal.Parse(row.Cells(5).Text))
      Dim pageCount As Int32 = Int32.Parse(row.Cells(6).Text)

      ' Find publisher
      Dim publisherId As Guid = _DataContext.Publishers.Where(Function(p) p.Name = publisherName).Select(Function(p) p.ID).SingleOrDefault()
      ' Create publisher if not found
      If publisherId = Guid.Empty Then
        publisherId = Guid.NewGuid()
        Dim publisher = New Publisher()
        publisher.ID = publisherId
        publisher.Name = publisherName
        _DataContext.Publishers.InsertOnSubmit(publisher)
      End If

      ' Add book
      Dim book = New Book()
      book.ID = Guid.NewGuid()
      book.Title = title
      book.Isbn = isbn
      book.PageCount = pageCount
      book.Price = price
      book.Publisher = publisherId
      If ddlSubjectFromAmazon.SelectedIndex > 0 Then
        book.Subject = New Guid(ddlSubjectFromAmazon.SelectedValue)
      End If
      _DataContext.Books.InsertOnSubmit(book)
    Next

    _DataContext.SubmitChanges()

    Response.Redirect("~/Books.aspx")
  End Sub
End Class