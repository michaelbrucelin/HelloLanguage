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
  public partial class BookList : System.Web.UI.UserControl
  {
    private IEnumerable<Book> _Books;

    public IEnumerable<Book> Books
    {
      set { _Books = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void DataBind()
    {
      base.DataBind();
      GridViewBooks.DataSource = _Books;
      GridViewBooks.DataBind();
    }
  }
}