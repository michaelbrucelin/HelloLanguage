using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement xml = new XElement("books",from line in File.ReadAllLines("./books.csv")
                                                where !line.StartsWith("#")
                                                let items = line.Split(',')
                                                select new XElement("book",
                                                new XElement("title", items[1]),
                                                new XElement("authors", from authorFullName in items[2].Split(';')
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

            Console.ReadKey();
        }
    }
}

/*
将CSV转为XML，如果CSV文件较大，可以使用ReadCSV2中的扩展方法，使用流的方式读取文件，这里为了方便，直接一次性读取全部数据

<books>
    <book>
        <title>CLR via C#</title>
        <authors>
            <author>
                <firstName>Jeffrey</firstName>
                <lastName>Richter</lastName>
            </author>
        </authors>
        <publisher>Microsoft Press</publisher>
        <publicationDate>02-22-2006</publicationDate>
        <price>59.99</price>
        <isbn>0735621632</isbn>
    </book>
    <book>
        <title>Patterns Of Enterprise Application Architecture</title>
        <authors>
            <author>
                <firstName>Martin</firstName>
                <lastName>Fowler</lastName>
            </author>
        </authors>
        <publisher>Addison-Wesley</publisher>
        <publicationDate> 11-05-2002</publicationDate>
        <price>54.99</price>
        <isbn>0321127420</isbn>
    </book>
    <book>
        <title>Enterprise Integration Patterns</title>
        <authors>
            <author>
                <firstName>Gregor</firstName>
                <lastName>Hohpe</lastName>
            </author>
        </authors>
        <publisher>Addison-Wesley</publisher>
        <publicationDate>10-10-2003</publicationDate>
        <price>54.99</price>
        <isbn>0321200683</isbn>
    </book>
    <book>
        <title>Domain-Driven Design</title>
        <authors>
            <author>
                <firstName>Eric</firstName>
                <lastName>Evans</lastName>
            </author>
        </authors>
        <publisher>Addison-Wesley Professional</publisher>
        <publicationDate>08-22-2003</publicationDate>
        <price>54.99</price>
        <isbn>0321125215</isbn>
    </book>
    <book>
        <title>Ajax In Action</title>
        <authors>
            <author>
                <firstName>Dave</firstName>
                <lastName>Crane</lastName>
            </author>
            <author>
                <firstName>Eric</firstName>
                <lastName>Pascarello</lastName>
            </author>
            <author>
                <firstName>Darren</firstName>
                <lastName>James</lastName>
            </author>
        </authors>
        <publisher>Manning Publications</publisher>
        <publicationDate>10-01-2005</publicationDate>
        <price>44.95</price>
        <isbn>1932394613</isbn>
    </book>
</books>
*/