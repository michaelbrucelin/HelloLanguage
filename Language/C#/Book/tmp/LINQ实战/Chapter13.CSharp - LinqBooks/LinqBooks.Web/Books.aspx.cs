#region Imports

using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Linq;

using LinqBooks.Entities;

#endregion Imports

namespace LinqBooks.Web
{
  public partial class Books : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      LinqBooksDataContext dataContext;

      dataContext = new LinqBooksDataContext();

      //// Books
      //var query =
      //  from book in dataContext.Books
      //  orderby book.Title
      //  select new
      //         {
      //           Id = book.ID,
      //           Title = book.Title,
      //           Publisher = book.PublisherObject.Name,
      //           Price = book.Price
      //         };
      //GridViewBooks.DataSource = query;
      //GridViewBooks.DataBind();

      // Total price
      lblTotalPrice.Text = dataContext.Books.TotalPrice().ToString("F2");

      // Biggest book
      Book biggestBook = dataContext.Books.Where(book => book.Title.Length > 0).MaxElement(book => book.PageCount);
      lnkBiggestBook.Text = biggestBook.Title;
      lnkBiggestBook.NavigateUrl = "~/Book.aspx?ID=" + biggestBook.ID;
      lblPageCount.Text = biggestBook.PageCount.ToString();

      // Best book
      var ratings =
        from book in dataContext.Books
        let rating = Convert.ToInt32(book.Reviews.Where(review => review.Rating.HasValue).Average(review => review.Rating.Value))
        orderby rating descending
        select new { Book = book, Rating = rating };
      var bestBook = ratings.First();
      lnkBestBook.Text = bestBook.Book.Title;
      lnkBestBook.NavigateUrl = "~/Book.aspx?ID="+bestBook.Book.ID;
      lblRating.Text = bestBook.Rating.ToString();
    }

    protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
      e.Result =
        from book in new LinqBooksDataContext().Books
        orderby book.Title
        select new
         {
           Id = book.ID,
           Title = book.Title,
           Publisher = book.PublisherObject.Name,
           Price = book.Price
         };
    }
  }
}