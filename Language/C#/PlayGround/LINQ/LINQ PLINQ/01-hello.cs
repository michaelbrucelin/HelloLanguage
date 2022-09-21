using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == "System.Data.DataSet");
            // Assembly assembly = Assembly.LoadFile(@"C:\...\Data.dll");
            Assembly assembly = typeof(System.Data.DataSet).Assembly;

            ShowObsoleteMethods(assembly);
        }

        private static void ShowObsoleteMethods(Assembly assembly)
        {
            if (assembly == null) { Console.WriteLine("assembly is null."); return; }

            var query = from type in assembly.GetExportedTypes().AsParallel()
                        from method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                        let obsoleteAttrType = typeof(ObsoleteAttribute)
                        where Attribute.IsDefined(method, obsoleteAttrType)
                        orderby type.FullName
                        let obsoleteAttrObj = (ObsoleteAttribute)Attribute.GetCustomAttribute(method, obsoleteAttrType)
                        select string.Format("Type={0}\nMethod={1}\nMessage={2}\n", type.FullName, method.ToString(), obsoleteAttrObj.Message);

            // 显示结果
            foreach (var result in query) Console.WriteLine(result);
        }
    }
}

/*
PLINQ是指Parallel LINQ，其设计目标是让LINQ查询能够将处理过程分布到多个CPU或内核上，且只需要按照现有方法编写LINQ查询。
要让自己的LINQ to Objects查询使用PLINQ，必须将自己的顺序查询（基于IEnumerable或者IEnumerable<T>）转换成并行查询（基于ParallelQuery或者ParallelQuery<T>），
这是用ParallelEnumerable的AsParallel扩展方法实现的：
    public static ParallelQuery<TSource>  AsParallel<TSource>(this IEnumerable<TSource> source)
    public static ParallelQuery           AsParallel(this IEnumerable source)
*/
