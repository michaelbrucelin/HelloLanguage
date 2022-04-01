using System;
using System.Linq;
using System.Xml.Linq;
using LinqInAction.LinqBooks.Common;

namespace Chapter11.CreateObjectsFromXml
{
    class Program
    {
        static void Main(string[] args)
        {

            // load the XML document
            XElement booksXml = XElement.Load("books.xml");

            // build our objects using query expressions and object initializers
            var books =
              from bookElement in booksXml.Elements("book")
              select new LinqInAction.LinqBooks.Common.Book
              {
                  Title = (string)bookElement.Element("title"),
                  Publisher = new Publisher
                  {
                      Name = (string)bookElement.Element("publisher")
                  },
                  PublicationDate = (DateTime)bookElement.Element("publicationDate"),
                  Price = (decimal)bookElement.Element("price"),
                  Isbn = (string)bookElement.Element("isbn"),
                  Notes = (string)bookElement.Element("notes"),
                  Summary = (string)bookElement.Element("summary"),
                  Authors =
        from authorElement in bookElement.Descendants("author")
        select new Author
        {
            FirstName = (string)authorElement.Element("firstName"),
            LastName = (string)authorElement.Element("lastName")
        },
                  Reviews =
        from reviewElement in bookElement.Descendants("review")
        select new Review
        {
            User = new User
            {
                Name = (string)reviewElement.Element("user")
            },
            Rating = (int)reviewElement.Element("rating"),
            Comments = (string)reviewElement.Element("comments")
        }
              };

            // print out the results
            ObjectDumper.Write(books);
        }
    }
}
