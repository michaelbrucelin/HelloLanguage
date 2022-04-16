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

            // 使用Select操作符对XML数据进行投影
            var titles = tags.Descendants(ns + "Title").Select(titleElement => (string)titleElement);
            foreach (string title in titles)
            {
                Console.WriteLine(title);
            }

            // 使用查询表达式对XML数据进行投影
            var titles2 = from title in tags.Descendants(ns + "Title")
                          select (string)title;

            Console.ReadKey();
        }
    }
}