#region Imports

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using LinqBooks.Entities;
using LinqBooks.Web.Controls;

#endregion Imports

namespace LinqBooks.Web
{
  public partial class AuthorPage : System.Web.UI.Page
  {
    private LinqBooksDataContext _DataContext;
    private Guid _AuthorId;

    protected void Page_Load(object sender, EventArgs e)
    {
      String tmpString;

      tmpString = Request.QueryString["ID"];
      if (String.IsNullOrEmpty(tmpString))
        throw new ArgumentNullException("ID");
      _AuthorId = new Guid(tmpString);

      _DataContext = new LinqBooksDataContext();

      var query =
        from author in _DataContext.Authors
        where author.ID == _AuthorId
        select author;
      DetailsView1.DataSource = query;
      DetailsView1.DataBind();
    }

    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
      Author author = (Author)DetailsView1.DataItem;
      BookList bookList = (BookList)DetailsView1.FindControl("BookList");
      bookList.Books = author.BookAuthors.Select(bookAuthor => bookAuthor.BookObject);
      bookList.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      using (TransactionScope transaction = new TransactionScope())
      {
        Author author = _DataContext.Authors.Single(a => a.ID == _AuthorId);
        _DataContext.Authors.DeleteOnSubmit(author);
        _DataContext.SubmitChanges();

        transaction.Complete();
      }

      Response.Redirect("~/Authors.aspx");
    }
  }
}