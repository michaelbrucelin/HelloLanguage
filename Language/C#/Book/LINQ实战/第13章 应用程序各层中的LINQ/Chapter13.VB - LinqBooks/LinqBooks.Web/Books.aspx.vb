Imports LinqBooks.Entities

Partial Public Class Books
  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim dataContext As LinqBooksDataContext

    dataContext = New LinqBooksDataContext()

    ' Total price
    lblTotalPrice.Text = dataContext.Books.TotalPrice().ToString("F2")

    ' Biggest book
    Dim biggestBook As Book = dataContext.Books.Where(Function(book) book.Title.Length > 0).MaxElement(Function(book) book.PageCount)
    lnkBiggestBook.Text = biggestBook.Title
    lnkBiggestBook.NavigateUrl = "~/Book.aspx?ID=" & biggestBook.ID.ToString()
    lblPageCount.Text = biggestBook.PageCount.ToString()

    ' Best book
    Dim ratings = _
      From book In dataContext.Books _
      Let rating = Convert.ToInt32(book.Reviews.Where(Function(review) review.Rating.HasValue).Average(Function(review) review.Rating.Value)) _
      Order By rating Descending _
      Select New With {.Book = book, .Rating = rating}
    Dim bestBook = ratings.First()
    lnkBestBook.Text = bestBook.Book.Title
    lnkBestBook.NavigateUrl = "~/Book.aspx?ID=" & bestBook.Book.ID.ToString()
    lblRating.Text = bestBook.Rating.ToString()
  End Sub

  Protected Sub LinqDataSource1_Selecting(ByVal sender As Object, ByVal e As LinqDataSourceSelectEventArgs)
    e.Result = _
      From book In New LinqBooksDataContext().Books _
      Order By book.Title _
      Select New With _
       { _
         .Id = book.ID, _
         .Title = book.Title, _
         .Publisher = book.PublisherObject.Name, _
         .Price = book.Price _
       }
  End Sub


End Class