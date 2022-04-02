using System;
using System.Linq;

using LinqInAction.LinqBooks.Common;

public partial class Grouping : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    GridView1.DataSource =
      from book in SampleData.Books
      group book by book.Publisher into publisherBooks
      select new { Publisher=publisherBooks.Key.Name, Books=publisherBooks };
    GridView1.DataBind();
  }
}
