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

            XElement books = XElement.Load(@"./books.xml");
            XDocument output = new XDocument();
            using (XmlWriter writer = output.CreateWriter())
            {
                XslCompiledTransform xslTransformer = new XslCompiledTransform();
                xslTransformer.Load(XmlReader.Create(new StringReader(xsl)));
                xslTransformer.Transform(books.CreateReader(), writer);
            }

            Console.WriteLine(output);

            Console.ReadKey();
        }
    }
}

/*
使用XSLT转换XElement

<html>
    <title>Book Catalog</title>
    <ul>
        <li>LINQ in Action by Fabrice Marguerie, Steve Eichert, Jim Wooley</li>
        <li>Ajax in Action by Dave Crane</li>
        <li>Enterprise Application Architecture by Martin Fowler</li>
    </ul>
</html>
*/