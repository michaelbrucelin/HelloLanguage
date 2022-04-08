using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp0
{
    public static class MyUtilsJson
    {
        //判断字符串是否是json
        //Json.NET Schema提供方法验证，但是包收费，这里就自己封装一个
        //https://www.newtonsoft.com/jsonschema
        public static bool IsJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]")))   //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException)
                {
                    //Exception in parsing json
                    //Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception) //some other exception
                {
                    //Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //下面的Json递归遍历不完善，参考
        //https://stackoverflow.com/questions/16181298/how-to-do-recursive-descent-of-json-using-json-net
        //https://stackoverflow.com/questions/39673815/how-to-recursively-populate-a-treeview-with-json-data

        //递归遍历，对Json的值按照传入的委托进行操作
        public static void WalkNode(JToken node, Action<JObject> action)
        {
            if (node.Type == JTokenType.Object)
            {
                action((JObject)node);

                foreach (JProperty child in node.Children<JProperty>())
                {
                    WalkNode(child.Value, action);
                }
            }
            else if (node.Type == JTokenType.Array)
            {
                foreach (JToken child in node.Children())
                {
                    WalkNode(child, action);
                }
            }
        }

        //递归遍历,对Json的值按照传入的委托进行操作，这里操作的是将Json加载到TreeView上
        public static void WalkNodeToTreeView(JToken node, TreeNode td, Func<TreeNode, string, TreeNode> func)
        {
            if (node.Type == JTokenType.Object)
            {
                TreeNode tdNew = func(td, ((JObject)node).ToString());
                foreach (JProperty child in node.Children<JProperty>())
                {
                    WalkNodeToTreeView(child.Value, tdNew, func);
                }
            }
            else if (node.Type == JTokenType.Array)
            {
                foreach (JToken child in node.Children())
                {
                    TreeNode tdNew = func(td, child.ToString());
                    WalkNodeToTreeView(child, tdNew, func);
                }
            }
            else if (node.Type == JTokenType.Property)
            {
                TreeNode tdNew = func(td, ((JProperty)node).Name);
                MyUtilsJson.WalkNodeToTreeView(((JProperty)node).Value, td, func);
            }
            else
            {
                TreeNode tdNew = func(td, node.ToString());
                //MyUtilsJson.WalkNodeToTreeView(((JProperty)node).Value, td, func);
            }
        }
    }
}
