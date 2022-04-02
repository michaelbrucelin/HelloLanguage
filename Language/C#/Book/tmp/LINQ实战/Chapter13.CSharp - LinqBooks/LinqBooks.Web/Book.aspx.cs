#region Imports

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using AjaxControlToolkit;

using LinqBooks.Entities;
using LinqBooks.Web.Controls;

#endregion Imports

namespace LinqBooks.Web
{
  public partial class BookPage : System.Web.UI.Page
  {
    //class BookPresentationModel
    //{
    //  public Guid       ID { get; set; }
    //  public String     Title { get; set; }
    //  public String     Isbn { get; set; }
    //  public String     Summary { get; set; }
    //  public String     Notes { get; set; }
    //  public Int32?     PageCount { get; set; }
    //  public Decimal?   Price { get; set; }
    //  public DateTime?  PubDate { get; set; }
    //  public Guid       PublisherId { get; set; }
    //  public String     PublisherName { get; set; }
    //  public IEnumerable<Author> Authors { get; set; }
    //  public String     Subject { get; set; }
    //  public Int32?     AverageRating { get; set; }
    //}

    class ReviewPresentationModel
    {
      public Guid ID { get; set; }
      public Int32? Rating { get; set; }
      public String Comments { get; set; }
    }

    private Guid _BookId;
    private LinqBooksDataContext _DataContext;

    protected void Page_Load(object sender, EventArgs e)
    {
      String  tmpString;

      tmpString = Request.QueryString["ID"];
      if (String.IsNullOrEmpty(tmpString))
        throw new ArgumentNullException("ID");
      _BookId = new Guid(tmpString);

      _DataContext = new LinqBooksDataContext();

      if (!IsPostBack)
      {
        // Book details
        DisplayBook();

        // Reviews
        DisplayReviews();
      }

      AuthorList authorList = (AuthorList)DetailsView1.FindControl("AuthorList");
      authorList.DeleteAuthor += authorList_DeleteAuthor;
    }

    private void DisplayBook()
    {
      var books =
        from book in _DataContext.Books
        where book.ID == _BookId
        select new
          {
            Title = book.Title,
            Isbn = book.Isbn,
            Summary = book.Summary,
            Notes = book.Notes,
            PageCount = book.PageCount,
            Price = book.Price,
            PubDate = book.PubDate,
            PublisherId = book.Publisher,
            PublisherName = book.PublisherObject.Name,
            Authors = book.BookAuthors.Select(bookAuthor => bookAuthor.AuthorObject),
            Subject = book.SubjectObject.Name,
            AverageRating = book.Reviews.Average(review => (double?)review.Rating)
          };
      DetailsView1.DataSource = books;
      DetailsView1.DataBind();

      var theBook = books.Single();

      // Authors
      DisplayAuthors(theBook.Authors);

      // Average rating
      Rating rating = (Rating)DetailsView1.FindControl("Rating");
      if (theBook.AverageRating.HasValue)
        rating.CurrentRating = (int)theBook.AverageRating;
      else
        rating.Visible = false;
    }

    private void DisplayAuthors(IEnumerable<Author> authors)
    {
      AuthorList authorList = (AuthorList)DetailsView1.FindControl("AuthorList");
      authorList.Authors = authors;
      authorList.DataBind();
    }

    void authorList_DeleteAuthor(object sender, AuthorList.AuthorEventArgs e)
    {
      // Delete BookAuthor
      BookAuthor bookAuthor = _DataContext.BookAuthors.Single(ba => (ba.Book == _BookId) && (ba.Author == e.AuthorId));
      _DataContext.BookAuthors.DeleteOnSubmit(bookAuthor);
      _DataContext.SubmitChanges();

      // Update display
      DisplayAuthors(_DataContext.BookAuthors.Where(ba => ba.Book == _BookId).Select(ba => ba.AuthorObject));
      divAddAuthor.Visible = false;
      btnShowAddAuthor.Visible = true;
    }

    private void DisplayReviews()
    {
      var reviews =
        //from review in AppCommon.User.Reviews
        //where review.Book == _BookId
        //select new ReviewPresentationModel { review.ID, review.Comments, review.Rating };
        from review in _DataContext.Reviews
        where /*(review.User == AppCommon.User.ID) &&*/ (review.Book == _BookId)
        select new ReviewPresentationModel { ID=review.ID, Comments=review.Comments, Rating=review.Rating };
      GridViewReviews.DataSource = reviews;
      GridViewReviews.DataBind();
    }

    protected void GridViewReviews_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.DataItem == null)
        return;

      ReviewPresentationModel review = (ReviewPresentationModel)e.Row.DataItem;
      Rating rating = (Rating)e.Row.FindControl("Rating");
      rating.CurrentRating = review.Rating ?? 0;
    }

    protected void btnShowAddAuthor_Click(object sender, EventArgs e)
    {
      divAddAuthor.Visible = true;
      btnShowAddAuthor.Visible = false;

      // List of authors
      ddlAuthor.Items.Clear();
      ddlAuthor.Items.Add(new ListItem("(select a value)", "0"));
      ddlAuthor.DataSource =
        from author in _DataContext.Authors
        where author.BookAuthors.Count<BookAuthor>(bookAuthor => bookAuthor.Book == _BookId) < 1
        orderby author.LastName, author.FirstName
        select new { ID = author.ID, FullName = author.LastName.ToUpper()+" "+author.FirstName };
      ddlAuthor.DataValueField = "ID";
      ddlAuthor.DataTextField = "FullName";
      ddlAuthor.DataBind();
    }

    protected void btnAddAuthor_Click(object sender, EventArgs e)
    {
      // Create new BookAuthor
      BookAuthor bookAuthor = new BookAuthor();
      bookAuthor.Book = _BookId;
      bookAuthor.Author = new Guid(ddlAuthor.SelectedValue);

      // Add BookAuthor
      _DataContext.BookAuthors.InsertOnSubmit(bookAuthor);
      _DataContext.SubmitChanges();

      // Update display
      DisplayBook();

      divAddAuthor.Visible = false;
      btnShowAddAuthor.Visible = true;
    }

    protected void btnShowAddReview_Click(object sender, EventArgs e)
    {
      divAddReview.Visible = true;
      btnShowAddReview.Visible = false;
    }

    protected void btnAddReview_Click(object sender, EventArgs e)
    {
      // Create new review
      Review review = new Review();
      review.ID = Guid.NewGuid();
      review.Book = _BookId;
      review.User = AppCommon.User.ID;
      review.Comments = txtReviewComments.Text;
      if (ReviewRating.CurrentRating > 0)
        review.Rating = ReviewRating.CurrentRating;

      // Add review
      _DataContext.Reviews.InsertOnSubmit(review);
      _DataContext.SubmitChanges();

      // Update display
      DisplayBook();
      DisplayReviews();

      divAddReview.Visible = false;
      btnShowAddReview.Visible = true;
    }

    protected void GridViewReviews_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      // Delete review
      Guid reviewId = (Guid)GridViewReviews.DataKeys[e.RowIndex].Value;
      Review review = _DataContext.Reviews.Single(r => r.ID == reviewId);
      _DataContext.Reviews.DeleteOnSubmit(review);
      _DataContext.SubmitChanges();

      // Update display
      DisplayBook();
      DisplayReviews();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      using (TransactionScope transaction = new TransactionScope())
      {
        Book book = _DataContext.Books.Single(b => b.ID == _BookId);
        _DataContext.BookAuthors.DeleteAllOnSubmit(book.BookAuthors);
        _DataContext.Books.DeleteOnSubmit(book);
        _DataContext.SubmitChanges();

        transaction.Complete();
      }

      Response.Redirect("~/Books.aspx");
    }
  }
}