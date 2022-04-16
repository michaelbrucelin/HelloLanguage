using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string xsl = @"<?xml version='1.0' encoding='UTF-8' ?>
<xsl:stylesheet version='1.0'
xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
<xsl:template match='books'>
<html>
<title>Book Catalog</title>
<ul>
<xsl:apply-templates select='book'/>
</ul>
</html>
</xsl:template>
<xsl:template match='book'>
<li>
<xsl:value-of select='title'/> by
<xsl:apply-templates select='author'/>
</li>
</xsl:template>
<xsl:template match='author'>
<xsl:if test='position() > 1'>, </xsl:if>
<xsl:value-of select='.'/>
</xsl:template>
</xsl:stylesheet>";

            XElement books = XElement.Load(@"E:\vs2019\Templates\TestCSharpClassic\TempTestCSharp\files\books.xml");
            XDocument output = books.XslTransform(xsl);

            Console.WriteLine(output);

            Console.ReadKey();
        }
    }

    public static class XmlExtensions
    {
        public static XDocument XslTransform(this XNode node, string xsl)
        {
            XDocument output = new XDocument();
            using (XmlWriter writer = output.CreateWriter())
            {
                XslCompiledTransform xslTransformer = new XslCompiledTransform();
                xslTransformer.Load(XmlReader.Create(new StringReader(xsl)));
                xslTransformer.Transform(node.CreateReader(), writer);
            }
            return output;
        }
    }
}

/*
通过XSL转换XNode的扩展方法

<html>
    <title>Book Catalog</title>
    <ul>
        <li>LINQ in Action by Fabrice Marguerie, Steve Eichert, Jim Wooley</li>
        <li>Ajax in Action by Dave Crane</li>
        <li>Enterprise Application Architecture by Martin Fowler</li>
    </ul>
</html>
*/