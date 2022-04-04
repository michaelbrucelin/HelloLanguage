using System;
using System.Linq;

using LinqInAction.LinqBooks.Common;

public partial class Joins : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewGroupJoin.DataSource = from publisher in SampleData.Publishers
                                       join book in SampleData.Books on publisher equals book.Publisher into publisherBooks
                                       select new { Publisher = publisher.Name, Books = publisherBooks };
        GridViewGroupJoin.DataBind();

        GridViewInnerJoin.DataSource = from publisher in SampleData.Publishers
                                       join book in SampleData.Books on publisher equals book.Publisher
                                       select new { Publisher = publisher.Name, Book = book.Title };
        GridViewInnerJoin.DataBind();

        GridViewLeftOuterJoin.DataSource = from publisher in SampleData.Publishers
                                           join book in SampleData.Books on publisher equals book.Publisher into publisherBooks
                                           from book in publisherBooks.DefaultIfEmpty()
                                           select new
                                           {
                                               Publisher = publisher.Name,
                                               Book = book == default(Book) ? "(no books)" : book.Title
                                           };
        GridViewLeftOuterJoin.DataBind();

        GridViewCrossJoin.DataSource = from publisher in SampleData.Publishers
                                       from book in SampleData.Books
                                       select new
                                       {
                                           Correct = publisher == book.Publisher,
                                           Publisher = publisher.Name,
                                           Book = book.Title
                                       };
        GridViewCrossJoin.DataBind();
    }
}
