using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string url =
"http://ecs.amazonaws.com/onca/xml?Service=AWSECommerceService" +
"&AWSAccessKeyId={Your Access Key Here}" +
"&Version=2007-07-16" +
"&Operation=TagLookup" +
"&ResponseGroup=Tags,Small" +
"&TagName=dotnet" +
"&Count=20";
            XNamespace ns = "http://webservices.amazon.com/AWSECommerceService/2007-07-16";

            // XElement tags = XElement.Load(url);
            XElement tags = XElement.Load(@"./amazon-dotnet-tagged.xml");

            var wpfBooks = from book in tags.Descendants(ns + "Item")
                           let bookAttributes = book.Element(ns + "ItemAttributes")
                           let title = ((string)bookAttributes.Element(ns + "Title"))
                           where title.Contains("Windows Presentation Foundation")
                           select title;
            foreach (string title in wpfBooks)
            {
                Console.WriteLine(title);
            }

            Console.ReadKey();
        }
    }
}