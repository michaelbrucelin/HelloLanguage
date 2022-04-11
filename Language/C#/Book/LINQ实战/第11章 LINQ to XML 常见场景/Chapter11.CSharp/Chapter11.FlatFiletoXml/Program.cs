using System;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace Chapter11.FlatFileToXml {
  class Program {
    static void Main(string[] args) {
      XElement xml = 
        new XElement("books",
        from line in File.ReadAllLines("books.txt")
        where !line.StartsWith("#")
        let items = line.Split(',')
        select new XElement("book",
				  new XElement("title", items[1]),
					new XElement("authors",
					from authorFullName in items[2].Split(';')
					let authorNameParts = authorFullName.Split(' ')
					select new XElement("author",
					  new XElement("firstName", authorNameParts[0]),
						new XElement("lastName", authorNameParts[1])
					)
				),
				new XElement("publisher", items[3]),
				new XElement("publicationDate", items[4]),
				new XElement("price", items[5]),
				new XElement("isbn", items[0])
				)
      );
      Console.WriteLine(xml);
    }
  }
}