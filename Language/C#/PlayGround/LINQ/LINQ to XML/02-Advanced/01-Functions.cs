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
            XElement root = XElement.Load("./categorizedBooks.xml");

            // 1. Element()轴方法返回第一个名称匹配的XML子元素，注意是子元素，不包含孙子元素
            Console.WriteLine("1. Element()");
            XElement dotNetCategory = root.Element("category");
            Console.WriteLine(dotNetCategory);

            // 2. Attribute()轴方法返回元素中第一个名称匹配的属性
            Console.WriteLine("2. Attribute()");
            XAttribute name = dotNetCategory.Attribute("name");
            Console.WriteLine(name);
            Console.WriteLine((string)name);

            // 3. Elements()轴方法返回全部名称匹配的XML子元素，注意是子元素，不包含孙子元素
            Console.WriteLine("3. Elements()");
            XElement books = dotNetCategory.Element("books");
            IEnumerable<XElement> bookElements = books.Elements("book");
            Console.WriteLine((string)dotNetCategory);
            foreach (XElement bookElement in bookElements)
            {
                Console.WriteLine(" - " + (string)bookElement);
            }

            // 4. Descendants()轴方法与Elements()轴方法类似，不过Elements()只查找当前元素下的直接子节点，而Descendants()则会遍历当前元素下任意层级的子元素
            // 与Descendants()轴方法类似的还有一个DescendantNodes()轴方法，二者的区别在于DescendantNodes()还返回了非元素类型的节点，例如XComment、XProcessingInstruction
            Console.WriteLine("4. Descendants()");
            foreach (XElement bookElement in root.Descendants("book"))
            {
                Console.WriteLine((string)bookElement);
            }

            // 5. Descendants()与DescendantsAndSelf()
            Console.WriteLine("5. Descendants()与DescendantsAndSelf()");
            IEnumerable<XElement> categories = root.Descendants("category");
            Console.WriteLine("Descendants");
            foreach (XElement categoryElement in categories)
            {
                Console.WriteLine(" - " + (string)categoryElement.Attribute("name"));
            }
            categories = root.DescendantsAndSelf("category");
            Console.WriteLine("DescendantsAndSelf");
            foreach (XElement categoryElement in categories)
            {
                Console.WriteLine(" - " + (string)categoryElement.Attribute("name"));
            }

            // 6. Ancestors()轴方法与Descendants()轴方法类似，不过Ancestors()是向上查找，即查找父节点、祖宗节点
            // Ancestors()轴方法也提供了对应的AncestorsAndSelf()轴方法
            Console.WriteLine("6. Ancestors()");
            XElement dddBook = root.Descendants("book").Where(book => (string)book == "Domain Driven Design").First();
            IEnumerable<XElement> ancestors = dddBook.Ancestors("category").Reverse();
            string categoryPath = String.Join("/", ancestors.Select(e => (string)e.Attribute("name")).ToArray());
            Console.WriteLine((string)dddBook + " is in the: " + categoryPath + " category.");

            // 7. ElementsAfterSelf(), NodesAfterSelf(), ElementsBeforeSelf(), and NodesBeforeSelf()
            Console.WriteLine("7. ElementsAfterSelf(), NodesAfterSelf(), ElementsBeforeSelf(), and NodesBeforeSelf()");
            XElement dddBook1 = root.Descendants("book").Where(book => (string)book == "Domain Driven Design").First();
            IEnumerable<XElement> beforeSelf = dddBook1.ElementsBeforeSelf();
            foreach (XElement element in beforeSelf)
            {
                Console.WriteLine((string)element);
            }

            Console.ReadKey();
        }
    }
}

/*
一些常用的方法

1. Element()
<category name=".NET">
    <books>
        <book>CLR via C#</book>
        <book>Essential .NET</book>
    </books>
</category>

2. Attribute()
name=".NET"
.NET

3. Elements()
CLR via C#Essential .NET
 - CLR via C#
 - Essential .NET

4. Descendants()
CLR via C#
Essential .NET
Refactoring
Domain Driven Design
Patterns of Enterprise Application Architecture
Extreme Programming Explained
Pragmatic Unit Testing with C#
Head First Design Patterns

5. Descendants()与DescendantsAndSelf()
Descendants
 - .NET
 - Design
DescendantsAndSelf
 - Technical
 - .NET
 - Design

6. Ancestors()
Domain Driven Design is in the: Technical/Design category.

7. ElementsAfterSelf(), NodesAfterSelf(), ElementsBeforeSelf(), and NodesBeforeSelf()
Refactoring
*/