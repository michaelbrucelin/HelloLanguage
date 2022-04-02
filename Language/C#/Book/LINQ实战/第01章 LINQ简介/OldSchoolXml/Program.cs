using System;
using System.Xml;

class Book
{
    public string Title;
    public string Publisher;
    public int Year;

    public Book(string title, string publisher, int year)
    {
        Title = title;
        Publisher = publisher;
        Year = year;
    }
}

static class OldSchoolXml
{
    static void Main()
    {
        // Our book collection
        Book[] books = new Book[] {
            new Book("Ajax in Action", "Manning", 2005),
            new Book("Windows Forms in Action", "Manning", 2006),
            new Book("RSS and Atom in Action", "Manning", 2006)
        };

        // Build the XML fragment based on the collection
        XmlDocument doc = new XmlDocument();
        XmlElement root = doc.CreateElement("books");
        foreach (Book book in books)
        {
            if (book.Year == 2006)
            {
                XmlElement element = doc.CreateElement("book");
                element.SetAttribute("title", book.Title);

                XmlElement publisher = doc.CreateElement("publisher");
                publisher.InnerText = book.Publisher;
                element.AppendChild(publisher);

                root.AppendChild(element);
            }
        }
        doc.AppendChild(root);

        // Display the result XML
        doc.Save(Console.Out);
    }
}