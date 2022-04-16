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
            // 1. 函数式创建XML文档
            XDocument doc1 = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XProcessingInstruction("XML-stylesheet", "friendly-rss.xsl"),
                new XElement("rss",
                    new XElement("channel", "my channel")
                )
            );
            Console.WriteLine("doc1:");
            Console.WriteLine(doc1);

            // 2. 创建带有XML样式表处理指令的XML文档
            XDocument doc2 = new XDocument(
                new XProcessingInstruction("XML-stylesheet", "href='http://iqueryable.com/friendly-rss.xsl' type='text/xsl' media = 'screen'"),
                new XElement("rss",
                    new XAttribute("version", "2.0"),
                    new XElement("channel",
                        new XElement("item", "my item")
                    )
                )
            );
            Console.WriteLine("doc2:");
            Console.WriteLine(doc2);

            // 3. 使用XDocumentType创建带有文档类型声明的HTML文档
            XDocument doc3 = new XDocument(
                new XDocumentType("HTML", "-//W3C//DTD HTML 4.01//EN", "http://www.w3.org/TR/html4/strict.dtd", null),
                new XElement("html",
                    new XElement("body", "This is the body!")
                )
            );
            Console.WriteLine("doc3:");
            Console.WriteLine(doc3);

            Console.ReadKey();
        }
    }
}

/*
创建XML文档
前面示例中的所有应用于元素（XElement）的方法，都能够应用到XDocument上，二者之间的不同之处在于其允许添加的子节点类型。
对于XElement来说，其子节点可以是XElement对象、XAttribute对象、XText、IEnumerable以及字符串。
而XDocument则允许添加如下类型的子节点：
- 一个XDocumentType对象，用来表示DTD；
- 一个XDeclaration对象，用来表示XML声明中的相关信息，包括XML版本、文档的字符编码以及该XML文档是否为独立等；
- 任意数量的XProcessingInstruction对象，用来提供某些处理XML时将用到的信息；
- 一个XElement对象，作为该XML文档的根节点；
- 任意数量的XComment对象，这些注释将成为根节点的兄弟节点，不过XComment对象不能作为参数列表的第一个，因为以注释开头的XML文档是不合法的。

doc1:
<?XML-stylesheet friendly-rss.xsl?>
<rss>
    <channel>my channel</channel>
</rss>

doc2:
<?XML-stylesheet href='http://iqueryable.com/friendly-rss.xsl' type='text/xsl' media = 'screen'?>
<rss version="2.0">
    <channel>
        <item>my item</item>
    </channel>
</rss>

doc3:
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
    <body>This is the body!</body>
</html>
*/