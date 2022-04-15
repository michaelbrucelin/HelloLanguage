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
            // doc.Load(@"E:\vs2019\Templates\TestCSharpClassic\TempTestCSharp\files\rss.xml");

            // 1. 从本地的存储中加载xml文档
            XElement x1 = XElement.Load(@"E:\vs2019\Templates\TestCSharpClassic\TempTestCSharp\files\books.xml");
            // 2. 从某个网站加载xml文档
            // XElement x2 = XElement.Load("http://path/to/books.xml");

            Console.WriteLine("x1:");
            Console.WriteLine(x1);

            // 3. 从现有的XmlReader中加载xml文档
            // LINQ to XML（XDocument/XElement）是借助XmlReader类从文件或URL中加载XML，所以LINQ to XML也可以直接从XmlReader中加载xml
            XElement x3;
            using (XmlReader reader = XmlReader.Create(@"E:\vs2019\Templates\TestCSharpClassic\TempTestCSharp\files\books.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                        break;
                }
                x3 = (XElement)XNode.ReadFrom(reader);
            }
            Console.WriteLine("x3:");
            Console.WriteLine(x3);

            // 4. 使用XmlReader中的某一段xml创建XElement对象
            // 这里加载的是books.xml中的第一个book元素
            XElement x4;
            using (XmlReader reader = XmlTextReader.Create(@"E:\vs2019\Templates\TestCSharpClassic\TempTestCSharp\files\books.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "book")
                        break;
                }
                x4 = (XElement)XNode.ReadFrom(reader);
            }
            Console.WriteLine("x4:");
            Console.WriteLine(x4);

            // 5. XDocument
            // 如果想要加载XML声明（XDeclaration）、XML处理命令（XProcessingInstruction）、XML文档类型定义（XDocumentType）、XML注释（XConment）等内容
            // 则应该将XML文档加载到XDocument对象，而不是XElement对象。
            // 将XML文档加载到XDocument对象与将XML文档加载到XElement对象方式基本一致，这里就不演示了。

            // XElement与XDocument的主要区别在于XDocument必须要包含一个作为根元素的XElement对象，并且能够包含：
            // ---- 一个XML声明
            // ---- 一个XML文档类型
            // ---- XML处理指令

            Console.ReadKey();
        }
    }
}

/*
加载XML文档

x1:
<books>
    <book>
        <title>LINQ in Action</title>
        <author>Fabrice Marguerie</author>
        <author>Steve Eichert</author>
        <author>Jim Wooley</author>
        <publisher>Manning</publisher>
        <rating>4</rating>
    </book>
    <book>
        <title>Ajax in Action</title>
        <author>Dave Crane</author>
        <publisher>Manning</publisher>
        <rating>3</rating>
    </book>
    <book>
        <title>Enterprise Application Architecture</title>
        <author>Martin Fowler</author>
        <publisher>APress</publisher>
        <rating>5</rating>
    </book>
</books>

x3:
<books>
    <book>
        <title>LINQ in Action</title>
        <author>Fabrice Marguerie</author>
        <author>Steve Eichert</author>
        <author>Jim Wooley</author>
        <publisher>Manning</publisher>
        <rating>4</rating>
    </book>
    <book>
        <title>Ajax in Action</title>
        <author>Dave Crane</author>
        <publisher>Manning</publisher>
        <rating>3</rating>
    </book>
    <book>
        <title>Enterprise Application Architecture</title>
        <author>Martin Fowler</author>
        <publisher>APress</publisher>
        <rating>5</rating>
    </book>
</books>

x4:
<book>
    <title>LINQ in Action</title>
    <author>Fabrice Marguerie</author>
    <author>Steve Eichert</author>
    <author>Jim Wooley</author>
    <publisher>Manning</publisher>
    <rating>4</rating>
</book>
*/