#region Imports

using System;
using System.Data;
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

#endregion Imports

namespace LinqBooks.Web.Controls
{
  public partial class AuthorList : System.Web.UI.UserControl
  {
    public class AuthorEventArgs : EventArgs
    {
      public Guid AuthorId { get; set; }
    }

    public event EventHandler<AuthorEventArgs> DeleteAuthor;

    private IEnumerable<Author> _Authors;

    public IEnumerable<Author> Authors
    {
      set { _Authors = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void DataBind()
    {
      base.DataBind();
      if (_Authors != null)
      {
        DisplayAuthors();
      }
    }

    private void DisplayAuthors()
    {
      if (_Authors != null)
      {
        GridViewAuthors.DataSource =
          _Authors.Select(author => new { ID = author.ID, FullName = author.FullName });
      }
      else
      {
        GridViewAuthors.DataSource = null;
      }
      GridViewAuthors.DataBind();
    }

    protected void GridViewAuthors_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      OnDeleteAuthor((Guid)GridViewAuthors.DataKeys[e.RowIndex].Value);
    }

    private void OnDeleteAuthor(Guid authorId)
    {
      if (DeleteAuthor != null)
      {
        DeleteAuthor(this, new AuthorEventArgs { AuthorId = authorId });
      }
    }
  }
}