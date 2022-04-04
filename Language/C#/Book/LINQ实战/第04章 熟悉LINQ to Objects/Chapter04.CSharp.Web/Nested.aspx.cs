using System;
using System.Linq;

using LinqInAction.LinqBooks.Common;

public partial class Nested : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = from publisher in SampleData.Publishers
                               orderby publisher.Name
                               select new
                               {
                                   Publisher = publisher.Name,
                                   Books = from book in SampleData.Books
                                           where book.Publisher == publisher
                                           select book
                               };
        GridView1.DataBind();
    }
}
