using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string file = @"PATH/TO/consolidated.xml";

            InitOFACData3(file);

            Console.WriteLine("done");
            Console.ReadLine();
        }

        /// <summary>
        /// 由于xml中包含命名空间，所以下面的查询没有结果
        /// <sdnList xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://tempuri.org/sdnList.xsd">
        /// </summary>
        /// <param name="xmlpath"></param>
        private static void InitOFACData(string xmlpath)
        {
            XDocument doc = XDocument.Load(xmlpath);
            XElement root = doc.Root;

            int counter = 1;
            foreach (XElement entry in root.Elements("sdnEntry"))
            {
                Console.WriteLine($"{counter++} entry, {entry.Element("uid").Value}");

                if (entry.Elements("akaList").FirstOrDefault() == null) continue;
                foreach (XElement aka in entry.Element("akaList").Elements("aka"))
                {
                    Console.WriteLine($"{counter++} aka, {aka.Element("uid").Value}");
                }
            }
        }

        /// <summary>
        /// 查询中指定xmlns（xml namespace）就可以查询了
        /// <sdnList xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://tempuri.org/sdnList.xsd">
        /// </summary>
        /// <param name="xmlpath"></param>
        private static void InitOFACData1(string xmlpath)
        {
            XDocument doc = XDocument.Load(xmlpath);
            XNamespace xNS = "http://tempuri.org/sdnList.xsd";
            XElement root = doc.Root;

            int counter = 1;
            foreach (XElement entry in root.Elements(xNS + "sdnEntry"))
            {
                Console.WriteLine($"{counter++} entry, {entry.Element(xNS + "uid").Value}");

                if (entry.Elements(xNS + "akaList").FirstOrDefault() == null) continue;
                foreach (XElement aka in entry.Element(xNS + "akaList").Elements(xNS + "aka"))
                {
                    Console.WriteLine($"{counter++} aka, {aka.Element(xNS + "uid").Value}");
                }
            }
        }

        /// <summary>
        /// 个人不喜欢使用xmlns，可以考虑将内存中的xmlns移除
        /// <sdnList xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://tempuri.org/sdnList.xsd">
        /// </summary>
        /// <param name="xmlpath"></param>
        private static void InitOFACData2(string xmlpath)
        {
            XDocument doc = XDocument.Load(xmlpath);
            XElement root = doc.Root;
            // 将所有节点的名称改为本地名称，就可以忽略xmlns直接查询了
            foreach (XElement e in root.DescendantsAndSelf())
                e.Name = e.Name.LocalName;

            int counter = 1;
            foreach (XElement entry in root.Elements("sdnEntry"))
            {
                Console.WriteLine($"{counter++} entry, {entry.Element("uid").Value}");

                if (entry.Elements("akaList").FirstOrDefault() == null) continue;
                foreach (XElement aka in entry.Element("akaList").Elements("aka"))
                {
                    Console.WriteLine($"{counter++} aka, {aka.Element("uid").Value}");
                }
            }
        }

        /// <summary>
        /// 也可以考虑再将xml加载到内存前就移除xmlns，理论上这样更快（感觉）,但是占用了2倍的内存
        /// <sdnList xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://tempuri.org/sdnList.xsd">
        /// </summary>
        /// <param name="xmlpath"></param>
        private static void InitOFACData3(string xmlpath)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(xmlpath))
            {
                sb.Append(reader.ReadLine());                                                          // 读取xml的第一行，必须提前了解xml的结构
                sb.Append(reader.ReadLine().Replace("xmlns=\"http://tempuri.org/sdnList.xsd\"", ""));  // 删除xmlns，必须提前了解xml的结构

                string line;
                while ((line = reader.ReadLine()) != null)
                    sb.Append(line);

                XDocument doc = XDocument.Parse(sb.ToString());
                XElement root = doc.Root;

                int counter = 1;
                foreach (XElement entry in root.Elements("sdnEntry"))
                {
                    Console.WriteLine($"{counter++} entry, {entry.Element("uid").Value}");

                    if (entry.Elements("akaList").FirstOrDefault() == null) continue;
                    foreach (XElement aka in entry.Element("akaList").Elements("aka"))
                    {
                        Console.WriteLine($"{counter++} aka, {aka.Element("uid").Value}");
                    }
                }
            }
        }
    }
}
