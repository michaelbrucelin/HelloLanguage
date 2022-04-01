using System;
using System.Data.Linq;
using System.Linq;
using System.Xml.Linq;
using LinqInAction.LinqToSql;

namespace Chapter11.CreateXmlFromDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqInActionDataContext ctx = new LinqInActionDataContext();
            ctx.Log = Console.Out;

            XElement xml = new XElement("books",
                from book in ctx.Books
                orderby book.Title
                select new XElement("book",
                        new XElement("title", book.Title),
                        new XElement("authors",
                                from bookAuthor in book.BookAuthors
                                orderby bookAuthor.AuthorOrder
                                select new XElement("author",
                                        new XElement("firstName", bookAuthor.Author.FirstName),
                                        new XElement("lastName", bookAuthor.Author.LastName),
                                        new XElement("webSite", bookAuthor.Author.WebSite)
                                )
                        ),
                        new XElement("subject",
                                new XElement("name", book.Subject.Name),
                                new XElement("description", book.Subject.Description)
                        ),
                        new XElement("publisher", book.Publisher.Name),
                        new XElement("publicationDate", book.PubDate),
                        new XElement("price", book.Price),
                        new XElement("isbn", book.Isbn),
                        new XElement("notes", book.Notes),
                        new XElement("summary", book.Summary),
                        new XElement("reviews",
                            from review in book.Reviews
                            orderby review.Rating
                            select new XElement("review",
                                        new XElement("user", review.User.Name),
                                        new XElement("rating", review.Rating),
                                        new XElement("comments", review.Comments)
                                )
                        )
                )
            );
            Console.WriteLine(xml.ToString());
        }
    }
}
