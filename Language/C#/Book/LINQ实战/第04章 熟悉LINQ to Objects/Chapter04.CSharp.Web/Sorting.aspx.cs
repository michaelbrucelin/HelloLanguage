using System;
using System.Linq;

using LinqInAction.LinqBooks.Common;

public partial class Sorting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = from book in SampleData.Books
                               orderby book.Publisher.Name, book.Price descending, book.Title
                               select new { Publisher = book.Publisher.Name, book.Price, book.Title };
        GridView1.DataBind();
    }
}