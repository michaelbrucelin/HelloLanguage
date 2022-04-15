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
            XmlDocument doc = new XmlDocument();
            // doc.Load("http://iqueryable.com/rss.aspx");
            doc.Load(@"./keyprinciple-namespace.xml");

            // 如果查询带有前缀的元素，必须先创建一个XMLNamespaceManager对象，并在每次查询时使用它。
            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            ns.AddNamespace("slash", "http://purl.org/rss/1.0/modules/slash/");
            ns.AddNamespace("wfw", "http://wellformedweb.org/CommentAPI/");

            XmlNodeList commentNodes = doc.SelectNodes("//slash:comments", ns);
            foreach (XmlNode node in commentNodes)
            {
                Console.WriteLine($"comment: {node.InnerText}");
            }

            // 如果查询不带前缀的元素，则无需创建XMLNamespaceManager对象，我们可以直接根据PATH查询。
            XmlNodeList titleNodes = doc.SelectNodes("/rss/channel/item/title");
            foreach (XmlNode node in titleNodes)
            {
                Console.WriteLine($"title: {node.InnerText}");
            }

            Console.ReadKey();
        }
    }
}

/*
在DOM中操作带有命名空间的XML文档

comment: 1
title: Parsing WordML using LINQ to XML
*/