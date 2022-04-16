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
            // XElement rss = XElement.Load("http://iqueryable.com/rss.aspx");
            XElement rss = XElement.Load(@"./keyprinciple-namespace.xml");
            XNamespace dc = "http://purl.org/dc/elements/1.1/";
            XNamespace slash = "http://purl.org/rss/1.0/modules/slash/";
            XNamespace wfw = "http://wellformedweb.org/CommentAPI/";

            // 使用完全展开后的XNamespace和XName查询
            IEnumerable<XElement> comments = rss.Descendants(slash + "comments");
            foreach (XElement comment in comments)
            {
                Console.WriteLine($"conment: {(int)comment}");
            }

            // 使用本地名称查询
            IEnumerable<XElement> titles = rss.Descendants("title");
            foreach (XElement title in titles)
            {
                Console.WriteLine($"title: {(string)title}");
            }

            Console.ReadKey();
        }
    }
}

/*
在LINQ to XML中操作带有命名空间的XML文档
在操作元素以及属性时总是给出其完整的名称。

conment: 1
title: Steve Eichert
title: Parsing WordML using LINQ to XML
*/