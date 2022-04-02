using System;
using System.Linq;

using LinqInAction.LinqBooks.Common;

public partial class Step2a : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    GridView1.DataSource =
      from book in SampleData.Books
      where book.Title.Length > 10
      orderby book.Price
      select book;
    GridView1.DataBind();
  }
}
