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
            try
            {
                XElement x = XElement.Parse(@"<books>
    <book>
        <author>Don Box</author>
        <title>Essential .NET</title>
    </book>
    <book>
        <author>Martin Fowler</author>
        <title>Patterns of Enterprise Application Architecture</title>
    </book>
</books>");

                Console.WriteLine(x);
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}

/*
解析字符串中的XML

<books>
    <book>
        <author>Don Box</author>
        <title>Essential .NET</title>
    </book>
    <book>
        <author>Martin Fowler</author>
        <title>Patterns of Enterprise Application Architecture</title>
    </book>
</books>
*/