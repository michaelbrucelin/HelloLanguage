using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

// A custom class like the one below is not required if we use an anonymous type.
// See the collection initializer used in Main.
// class Book
// {
//     public string Publisher;
//     public string Title;
//     public int Year;
// 
//     public Book(string title, string publisher, int year)
//     {
//         Title = title;
//         Publisher = publisher;
//         Year = year;
//     }
// }

static class HelloLinqToXml
{
    static void Main()
    {
        // Our book collection
        // Without using an anonymous type
        // Book[] books = {
        //     new Book("Ajax in Action", "Manning", 2005),
        //     new Book("Windows Forms in Action", "Manning", 2006),
        //     new Book("RSS and Atom in Action", "Manning", 2006)
        // };

        // Without using an anonymous type but with a collection initializer
        // Book[] books = {
        //     new Book {Title = "Ajax in Action", Publisher = "Manning", Year = 2005},
        //     new Book {Title = "Windows Forms in Action", Publisher = "Manning", Year = 2006},
        //     new Book {Title = "RSS and Atom in Action", Publisher = "Manning", Year = 2006}
        // };

        // With an anonymous type
        var books = new[] {
            new { Title="Ajax in Action", Publisher="Manning", Year=2005 },
            new { Title="Windows Forms in Action", Publisher="Manning", Year=2006 },
            new { Title="RSS and Atom in Action", Publisher="Manning", Year=2006 }
        };

        // Build the XML fragment based on the collection
        XElement xml = new XElement("books", from book in books
                                             where book.Year == 2006
                                             select new XElement("book",
                                                new XAttribute("title", book.Title),
                                                new XElement("publisher", book.Publisher)
                                             )
        );

        // Dump the XML to the console
        Console.WriteLine(xml);
    }
}

/*
<books>
    <book title="Windows Forms in Action">
        <publisher>Manning</publisher>
    </book>
    <book title="RSS and Atom in Action">
        <publisher>Manning</publisher>
    </book>
</books>
*/