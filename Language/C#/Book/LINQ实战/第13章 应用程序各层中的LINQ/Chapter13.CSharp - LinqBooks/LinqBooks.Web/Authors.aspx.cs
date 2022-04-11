#region Imports

using System;
using System.Data;
using System.Data.Linq;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
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
  public partial class Authors : System.Web.UI.Page
  {
    class AuthorPresentationModel
    {
      public Guid ID { get; set; }
      public String FullName { get; set; }
      public IEnumerable<Book> Books { get; set; }
    }

    private LinqBooksDataContext _DataContext;

    protected void Page_Load(object sender, EventArgs e)
    {
      _DataContext = new LinqBooksDataContext();

      if (!IsPostBack)
      {
        DisplayAuthors();
      }
    }

    private void DisplayAuthors()
    {
      var query =
        from author in _DataContext.Authors
        orderby author.LastName, author.FirstName
        select new AuthorPresentationModel
               {
                 ID = author.ID,
                 FullName = author.LastName.ToUpper()+" "+author.FirstName,
                 Books = author.BookAuthors.Select(bookAuthors => bookAuthors.BookObject)
               };
      GridViewAuthors.DataSource = query.ToList();
      GridViewAuthors.DataBind();
    }

    protected void GridViewAuthors_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.DataItem == null)
        return;

      AuthorPresentationModel author = (AuthorPresentationModel)e.Row.DataItem;
      BookList bookList = (BookList)e.Row.FindControl("BookList");
      bookList.Books = author.Books;
      bookList.DataBind();
    }

    protected void btnShowAddAuthor_Click(object sender, EventArgs e)
    {
      divAddAuthor.Visible = true;
      btnShowAddAuthor.Visible = false;
    }

    protected void btnAddAuthor_Click(object sender, EventArgs e)
    {
      // Create new author
      Author author = new Author();
      author.ID = Guid.NewGuid();
      author.FirstName = txtFirstName.Text;
      author.LastName = txtLastName.Text;

      // Add author
      _DataContext.Authors.InsertOnSubmit(author);
      _DataContext.SubmitChanges();

      // Update display
      DisplayAuthors();

      divAddAuthor.Visible = false;
      btnShowAddAuthor.Visible = true;
    }
  }
}