using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WindowsFormsApp0
{
    public static class MyUtilsSerializer
    {
        //Binary，将对象序列化为字符串
        public static string BinarySerializeToString<T>(T t)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        //Binary，将对象序列化为文件
        public static void BinarySerializeToFile<T>(T t, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
                stream.Flush();
            }
        }

        //Binary，将字符串反序列为对象
        public static T BinaryDeSerializeFromString<T>(string s) where T : class
        {
            byte[] buffer = Encoding.UTF8.GetBytes(s);
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as T;
            }
        }

        //Binary，将文件反序列为对象
        public static T BinaryDeSerializeFromFile<T>(string path) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as T;
            }
        }

        //Xml，将对象序列化为字符串
        public static string XmlSerializeToString<T>(T t) where T : class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(stream, t);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        //Xml，将对象序列化为文件
        public static void XmlSerializeToFile<T>(T t, string path) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(stream, t);
            }
        }

        //Xml，将字符串反序列为对象
        public static T XmlDeSerializeFromString<T>(string s) where T : class
        {
            byte[] buffer = Encoding.UTF8.GetBytes(s);
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                return formatter.Deserialize(stream) as T;
            }
        }

        //Xml，将文件反序列为对象
        public static T XmlDeSerializeFromFile<T>(string path) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                return formatter.Deserialize(stream) as T;
            }
        }

        //Json，将对象序列化为字符串
        public static string JsonSerializeToString<T>(T t) where T : class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
                formatter.WriteObject(stream, t);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        //Json，将对象序列化为文件
        public static void JsonSerializeToFile<T>(T t, string path) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
                formatter.WriteObject(stream, t);
            }
        }

        //Json，将字符串反序列为对象
        public static T JsonDeSerializeFromString<T>(string s) where T : class
        {
            byte[] buffer = Encoding.UTF8.GetBytes(s);
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
                return formatter.ReadObject(stream) as T;
            }
        }

        //Json，将文件反序列为对象
        public static T JsonDeSerializeFromFile<T>(string path) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
                return formatter.ReadObject(stream) as T;
            }
        }

        //Soap，将对象序列化为字符串
        //Soap序列化不支持泛型?
        public static string SoapSerializeToString<T>(T t) where T : class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, t);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        //Soap，将对象序列化为文件
        //Soap序列化不支持泛型?
        public static void SoapSerializeToFile<T>(T t, string path) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, t);
            };
        }

        //Soap，将字符串反序列为对象
        public static T SoapDeSerializeFromString<T>(string s) where T : class
        {
            byte[] buffer = Encoding.UTF8.GetBytes(s);
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                return formatter.Deserialize(stream) as T;
            }
        }

        //Soap，将文件反序列为对象
        public static T SoapDeSerializeFromFile<T>(string path) where T : class
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                SoapFormatter formatter = new SoapFormatter();
                return formatter.Deserialize(stream) as T;
            }
        }

        //自己写一个xml序列化器，只是为了练习反射和Attribute，了解.Net内部的实现原理
        //实现的比较简单，如果类型的属性为类型或者泛型等，方法会异常
        public static void MyXmlSerializer(string path, object obj)
        {
            Type type = obj.GetType();
            //xml根节点为类型的名称
            string clsName = type.Name;
            XDocument xdoc = new XDocument();
            XElement xroot = new XElement(clsName);
            xdoc.Add(xroot);

            //类型的每个属性为xml的一个xml元素
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo item in properties)
            {
                //检查属性是否有CanNotSerializableAttribute特性，如果有，该属性就无需序列化
                object[] atts = item.GetCustomAttributes(typeof(CanNotSerializableAttribute), false);
                if (atts.Length == 0)
                {
                    XElement xElement = new XElement(item.Name, item.GetValue(obj, null));
                    xroot.Add(xElement);
                }
            }

            xdoc.Save(path);
        }
    }

    public class CanNotSerializableAttribute : Attribute
    {

    }
}