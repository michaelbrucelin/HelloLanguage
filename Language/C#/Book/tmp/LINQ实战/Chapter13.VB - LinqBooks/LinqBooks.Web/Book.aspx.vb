Imports System.Transactions
Imports LinqBooks.Entities

Partial Public Class BookPage
  Inherits System.Web.UI.Page

#Region "ReviewPresentationModel"

  Class ReviewPresentationModel
    Private _ID As Guid
    Public Property ID() As Guid
      Get
        Return _ID
      End Get
      Set(ByVal value As Guid)
        _ID = value
      End Set
    End Property

    Private _Rating As Int32?
    Public Property Rating() As Int32?
      Get
        Return _Rating
      End Get
      Set(ByVal value As Int32?)
        _Rating = value
      End Set
    End Property

    Private _Comments As String
    Public Property Comments() As String
      Get
        Return _Comments
      End Get
      Set(ByVal value As String)
        _Comments = value
      End Set
    End Property

  End Class

#End Region

  Private _BookId As Guid
  Private _DataContext As LinqBooksDataContext

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim tmpString As String

    tmpString = Request.QueryString("ID")
    If String.IsNullOrEmpty(tmpString) Then
      Throw New ArgumentNullException("ID")
    End If
    _BookId = New Guid(tmpString)

    _DataContext = New LinqBooksDataContext()

    If Not IsPostBack Then
      ' Book details
      DisplayBook()

      ' Reviews
      DisplayReviews()
    End If

    Dim authorList = CType(DetailsView1.FindControl("AuthorList"), AuthorList)
    AddHandler authorList.DeleteAuthor, AddressOf authorList_DeleteAuthor
  End Sub

  Private Sub DisplayBook()
    Dim books = _
      From book In _DataContext.Books _
        Where book.ID = _BookId _
        Select New With _
          { _
            .Title = book.Title, _
            .Isbn = book.Isbn, _
            .Summary = book.Summary, _
            .Notes = book.Notes, _
            .PageCount = book.PageCount, _
            .Price = book.Price, _
            .PubDate = book.PubDate, _
            .PublisherId = book.Publisher, _
            .PublisherName = book.PublisherObject.Name, _
            .Authors = book.BookAuthors.Select(Function(bookAuthor) bookAuthor.AuthorObject), _
            .Subject = book.SubjectObject.Name, _
            .AverageRating = book.Reviews.Average(Function(review) CType(review.Rating, Double?)) _
          }
    DetailsView1.DataSource = books
    DetailsView1.DataBind()

    Dim theBook = books.Single()

    ' Authors
    DisplayAuthors(theBook.Authors)

    ' Average rating
    Dim rating = CType(DetailsView1.FindControl("Rating"), AjaxControlToolkit.Rating)
    If theBook.AverageRating.HasValue Then
      rating.CurrentRating = CType(theBook.AverageRating, Integer)
    Else
      rating.Visible = False
    End If
  End Sub

  Private Sub DisplayAuthors(ByVal authors As IEnumerable(Of Author))
    Dim authorList = CType(DetailsView1.FindControl("AuthorList"), AuthorList)
    authorList.Authors = authors
    authorList.DataBind()
  End Sub

  Private Sub authorList_DeleteAuthor(ByVal sender As Object, ByVal e As AuthorList.AuthorEventArgs)
    ' Delete BookAuthor
    Dim bookAuthor = _DataContext.BookAuthors.Single(Function(ba) (ba.Book = _BookId) And (ba.Author = e.AuthorID))
    _DataContext.BookAuthors.DeleteOnSubmit(bookAuthor)
    _DataContext.SubmitChanges()

    ' Update display
    DisplayAuthors(_DataContext.BookAuthors.Where(Function(ba) ba.Book = _BookId).Select(Function(ba) ba.AuthorObject))
    divAddAuthor.Visible = False
    btnShowAddAuthor.Visible = True
  End Sub

  Private Sub DisplayReviews()
    Dim reviews = _
      From review In _DataContext.Reviews _
      Where review.Book = _BookId _
      Select New ReviewPresentationModel With {.ID = review.ID, .Comments = review.Comments, .Rating = review.Rating}
    GridViewReviews.DataSource = reviews
    GridViewReviews.DataBind()
  End Sub

  Protected Sub GridViewReviews_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    If e.Row.DataItem Is Nothing Then
      Return
    End If

    Dim review = CType(e.Row.DataItem, ReviewPresentationModel)
    Dim rating = CType(e.Row.FindControl("Rating"), AjaxControlToolkit.Rating)
    rating.CurrentRating = If(Not review.Rating Is Nothing, review.Rating, 0)
  End Sub

  Protected Sub btnShowAddAuthor_Click(ByVal sender As Object, ByVal e As EventArgs)
    divAddAuthor.Visible = True
    btnShowAddAuthor.Visible = False

    ' List of authors
    ddlAuthor.Items.Clear()
    ddlAuthor.Items.Add(New ListItem("(select a value)", "0"))
    ddlAuthor.DataSource = _
      From author In _DataContext.Authors _
      Where author.BookAuthors.Where(Function(bookAuthor) bookAuthor.Book = _BookId).Count < 1 _
      Order By author.LastName, author.FirstName _
      Select New With {.ID = author.ID, .FullName = author.LastName.ToUpper() & " " & author.FirstName}
    ddlAuthor.DataValueField = "ID"
    ddlAuthor.DataTextField = "FullName"
    ddlAuthor.DataBind()
  End Sub

  Protected Sub btnAddAuthor_Click(ByVal sender As Object, ByVal e As EventArgs)
    ' Create new BookAuthor
    Dim bookAuthor = New BookAuthor()
    bookAuthor.Book = _BookId
    bookAuthor.Author = New Guid(ddlAuthor.SelectedValue)

    ' Add BookAuthor
    _DataContext.BookAuthors.InsertOnSubmit(bookAuthor)
    _DataContext.SubmitChanges()

    ' Update display
    DisplayBook()

    divAddAuthor.Visible = False
    btnShowAddAuthor.Visible = True
  End Sub

  Protected Sub btnShowAddReview_Click(ByVal sender As Object, ByVal e As EventArgs)
    divAddReview.Visible = True
    btnShowAddReview.Visible = False
  End Sub

  Protected Sub btnAddReview_Click(ByVal sender As Object, ByVal e As EventArgs)
    ' Create new review
    Dim review = New Review()
    review.ID = Guid.NewGuid()
    review.Book = _BookId
    review.User = AppCommon.User.ID
    review.Comments = txtReviewComments.Text
    If ReviewRating.CurrentRating > 0 Then
      review.Rating = ReviewRating.CurrentRating
    End If

    ' Add review
    _DataContext.Reviews.InsertOnSubmit(review)
    _DataContext.SubmitChanges()

    ' Update display
    DisplayBook()
    DisplayReviews()

    divAddReview.Visible = False
    btnShowAddReview.Visible = True
  End Sub

  Protected Sub GridViewReviews_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
    ' Delete review
    Dim reviewId = CType(GridViewReviews.DataKeys(e.RowIndex).Value, Guid)
    Dim review = _DataContext.Reviews.Single(Function(r) r.ID = reviewId)
    _DataContext.Reviews.DeleteOnSubmit(review)
    _DataContext.SubmitChanges()

    ' Update display
    DisplayBook()
    DisplayReviews()
  End Sub

  Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
    Using transaction = New TransactionScope()
      Dim book = _DataContext.Books.Single(Function(b) b.ID = _BookId)
      _DataContext.BookAuthors.DeleteAllOnSubmit(book.BookAuthors)
      _DataContext.Books.DeleteOnSubmit(book)
      _DataContext.SubmitChanges()

      transaction.Complete()
    End Using

    Response.Redirect("~/Books.aspx")
  End Sub
End Class