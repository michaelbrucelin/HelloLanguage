#region Imports

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
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
  public partial class Publishers : System.Web.UI.Page
  {
    private LinqBooksDataContext _DataContext;

    protected void Page_Load(object sender, EventArgs e)
    {
      _DataContext = new LinqBooksDataContext();

      if (!IsPostBack)
      {
        DisplayPublishers();
      }
    }

    private void DisplayPublishers()
    {
      var query =
        from publisher in _DataContext.Publishers
        orderby publisher.Name
        select publisher;
      GridViewPublishers.DataSource = query;
      GridViewPublishers.DataBind();
    }

    protected void GridViewPublishers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.DataItem == null)
        return;

      Publisher publisher = (Publisher)e.Row.DataItem;
      BookList bookList = (BookList)e.Row.FindControl("BookList");
      bookList.Books = publisher.Books;
      bookList.DataBind();
    }

    protected void btnShowAddPublisher_Click(object sender, EventArgs e)
    {
      divAddPublisher.Visible = true;
      btnShowAddPublisher.Visible = false;
    }

    protected void btnAddPublisher_Click(object sender, EventArgs e)
    {
      // Create new publisher
      Publisher publisher = new Publisher();
      publisher.ID = Guid.NewGuid();
      publisher.Name = txtName.Text;

      // Add publisher
      _DataContext.Publishers.InsertOnSubmit(publisher);
      _DataContext.SubmitChanges();

      // Update display
      DisplayPublishers();

      divAddPublisher.Visible = false;
      btnShowAddPublisher.Visible = true;
    }
  }
}