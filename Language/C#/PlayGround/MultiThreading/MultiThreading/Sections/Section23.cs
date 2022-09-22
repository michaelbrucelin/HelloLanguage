using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Section23 : Form
    {
        public Section23()
        {
            InitializeComponent();
        }

        private void Section23_Load(object sender, EventArgs e)
        {

        }

        private void btnSample01_Click(object sender, EventArgs e)
        {
            Assembly assembly = typeof(System.Data.DataSet).Assembly;

            ShowObsoleteMethods(assembly);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }

        /// <summary>
        /// PLINQ是指Parallel LINQ，其设计目标是让LINQ查询能够将处理过程分布到多个CPU或内核上，且只需要按照现有方法编写LINQ查询。
        /// 要让自己的LINQ to Objects查询使用PLINQ，必须将自己的顺序查询（基于IEnumerable或者IEnumerable<T>）转换成并行查询（基于ParallelQuery或者ParallelQuery<T>），
        /// 这是用ParallelEnumerable的AsParallel扩展方法实现的：
        ///     public static ParallelQuery<TSource> AsParallel<TSource>(this IEnumerable<TSource> source)
        ///     public static ParallelQuery AsParallel(this IEnumerable source)
        ///
        /// 通过AsParallel()可以把顺序操作的LINQ改为并行操作的PLINQ，反过来，通过AsSequential()可以把并行操作的PLINQ改为顺序操作的LINQ，虽然很少这么干。
        /// </summary>
        /// <param name="assembly"></param>
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
            // foreach (var result in query) Console.WriteLine(result);  // 顺序执行
            query.ForAll(Console.WriteLine);                             // 并行执行
            // 这里只是为了演示，才并行调用Console.WriteLine()方法，现实中不要这样做，只有在需要对每个结果执行计算时，才使用ForAll方法
            // Console类内部会对线程进行同步，确保每次只有一个线程可以访问控制台窗口，避免来自多个线程的文本在最后显示时乱作一团
        }
    }
}
