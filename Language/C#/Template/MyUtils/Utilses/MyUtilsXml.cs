using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp0
{
    public static class MyUtilsXml
    {
        //判断字符串是否是xml
        public static bool IsXml(string strInput)
        {
            if (!string.IsNullOrEmpty(strInput) && strInput.TrimStart().StartsWith("<"))
            {
                try
                {
                    XDocument.Parse(strInput);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //XmlDocument，通用模板1，处理整个XML
        public static void ReadXml_XmlDocument(string path, Action action)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(path);
            XmlNode xmlroot = xmldoc.DocumentElement;
            ReadXml_XmlDocument(xmlroot, action);
        }

        //XmlDocument，通用模板2，从传入的XElement开始向下处理XML
        public static void ReadXml_XmlDocument(XmlNode element, Action action)
        {
            foreach (XmlNode item in element.ChildNodes)
            {
                //对xml的操作，例如加载到TreeView上；
                action();
                ReadXml_XmlDocument(item, action);
            }
        }

        //XmlDocument，对xml的值按照传入的委托进行操作，这里操作的是将Xml加载到TreeView上
        public static void ReadXml_XmlDocument(XmlNode element, TreeNode td, Func<TreeNode, string, TreeNode> func)
        {
            foreach (XmlNode item in element.ChildNodes)
            {
                TreeNode tdNew;
                if (item.HasChildNodes)
                {
                    tdNew = func(td, item.Name);
                }
                else
                {
                    tdNew = func(td, item.Name + ": " + item.Value);
                }

                ReadXml_XmlDocument(item, tdNew, func);
            }
        }

        //XDocument，通用模板1，处理整个XML
        public static void ReadXml_XDocument(string path, Action action)
        {
            XDocument xdoc = XDocument.Load(path);
            XElement xroot = xdoc.Root;
            ReadXml_XDocument(xroot, action);

            ////匿名委托递归方式
            //Action<XElement> GetXml = null;
            //GetXml = delegate (XElement element)
            //         {
            //             foreach (XElement item in element.Elements())
            //             {
            //                 //对xml的操作，例如加载到TreeView上；
            //                 GetXml(item);
            //             }
            //         };

            //GetXml(xroot);
        }

        //XDocument，通用模板2，从传入的XElement开始向下处理XML
        public static void ReadXml_XDocument(XElement element, Action action)
        {
            foreach (XElement item in element.Elements())
            {
                //对xml的操作，例如加载到TreeView上；
                action();
                ReadXml_XDocument(item, action);
            }
        }

        //XDocument，对xml的值按照传入的委托进行操作，这里操作的是将Xml加载到TreeView上
        public static void ReadXml_XDocument(XElement element, TreeNode td, Func<TreeNode, string, TreeNode> func)
        {
            foreach (XElement item in element.Elements())
            {
                TreeNode tdNew;
                if (item.Elements().Count() > 0)
                {
                    tdNew = func(td, item.Name.ToString());
                }
                else
                {
                    tdNew = func(td, item.Name.ToString() + ": " + item.Value);
                }

                ReadXml_XDocument(item, tdNew, func);
            }
        }

        //XmlReader、XmlTextReader、XmlWriter、XmlTextWriter

        //LinqtoXml
    }
}
