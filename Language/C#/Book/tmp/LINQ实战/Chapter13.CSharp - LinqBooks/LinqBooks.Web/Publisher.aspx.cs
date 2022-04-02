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
  public partial class PublisherPage : System.Web.UI.Page
  {
    private LinqBooksDataContext _DataContext;
    private Guid _PublisherId;

    protected void Page_Load(object sender, EventArgs e)
    {
      String tmpString;

      tmpString = Request.QueryString["ID"];
      if (String.IsNullOrEmpty(tmpString))
        throw new ArgumentNullException("ID");
      _PublisherId = new Guid(tmpString);

      _DataContext = new LinqBooksDataContext();

      var query =
        from publisher in _DataContext.Publishers
        where publisher.ID == _PublisherId
        select publisher;
      DetailsView1.DataSource = query;
      DetailsView1.DataBind();
    }

    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
      Publisher publisher = (Publisher)DetailsView1.DataItem;
      BookList bookList = (BookList)DetailsView1.FindControl("BookList");
      bookList.Books = publisher.Books;
      bookList.DataBind();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      using (TransactionScope transaction = new TransactionScope())
      {
        Publisher publisher = _DataContext.Publishers.Single(p => p.ID == _PublisherId);
        _DataContext.Publishers.DeleteOnSubmit(publisher);
        _DataContext.SubmitChanges();

        transaction.Complete();
      }

      Response.Redirect("~/Publishers.aspx");
    }
  }
}