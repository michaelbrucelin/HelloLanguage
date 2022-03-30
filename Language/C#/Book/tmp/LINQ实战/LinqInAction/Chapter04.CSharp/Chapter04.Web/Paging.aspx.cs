using System;
using System.Linq;
using System.Web.UI.WebControls;

using LinqInAction.LinqBooks.Common;

public partial class Paging : System.Web.UI.Page
{
  private void BindData()
  {
    GridView1.DataSource =
      SampleData.Books
        .Select(book => book.Title).ToList();
    GridView1.DataBind();
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
      BindData();
  }

  protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
  {
    GridView1.PageIndex = e.NewPageIndex;
    BindData();
  }
}
