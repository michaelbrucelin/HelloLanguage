using System;
using System.Linq;

using LinqInAction.LinqBooks.Common;

public partial class Step1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String[] books = { "Funny Stories", "All your base are belong to us", "LINQ rules", "C# on Rails", "Bonjour mon Amour" };

        GridView1.DataSource = from book in books
                               where book.Length > 10
                               orderby book
                               select book.ToUpper();
        GridView1.DataBind();
    }
}
