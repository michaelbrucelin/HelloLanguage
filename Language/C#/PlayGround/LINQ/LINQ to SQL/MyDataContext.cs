using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class MyDataContext : DataContext
    {
        private static string testconnection = "";
        public MyDataContext() : base(testconnection)
        {
        }

        // protected internal IExecuteResult ExecuteMethodCall(object instance, MethodInfo methodInfo, params object[] parameters)
        // 上面是ExecuteMethodCall()的签名，由于是protected internal修饰的，所以不能在类的外面直接调用，这里就继承通过子类调用
        public MyDataContext(string connection) : base(connection)
        {
        }

        // 存储过程
        [Function(Name = "dbo.GetBook")]
        public ISingleResult<Book> GetBook(
            [Parameter(Name = "BookId", DbType = "UniqueIdentifier")] Nullable<Guid> bookId,
            [Parameter(Name = "UserName", DbType = "NVarChar(50)")] string userName)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), bookId, userName);
            return ((ISingleResult<Book>)(result.ReturnValue));
        }

        // 存储过程
        [Function(Name = "dbo.BookCountForPublisher")]
        public int BookCountForPublisher([Parameter(Name = "PublisherId", DbType = "UniqueIdentifier")] Nullable<System.Guid> publisherId)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisherId);
            return ((int)(result.ReturnValue));
        }

        // 存储过程
        [Function(Name = "dbo.UpdateAuthor")]
        public int AuthorUpdate(
            [Parameter(Name = "ID")] Guid iD,
            [Parameter(Name = "LastName")] string lastName,
            [Parameter(Name = "FirstName")] string firstName,
            [Parameter(Name = "WebSite")] string webSite,
            [Parameter(Name = "UserName")] string userName,
            [Parameter(Name = "TimeStamp")] byte[] timeStamp)
        {
            if (userName == null)
            {
                userName = Thread.CurrentPrincipal.Identity.Name;
            }

            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, lastName, firstName, webSite, userName, timeStamp);
            iD = (Guid)(result.GetParameterValue(0));
            int RowsAffected = ((int)(result.ReturnValue));
            if (RowsAffected == 0)
            {
                throw new ChangeConflictException();
            }

            return RowsAffected;
        }

        // 这个方法命名符合下列规范
        // InsertT(T instance), UpdateT(T instance), DeleteT(T instance).
        // DataContext中包含了上面规范的方法，在执行SubmitChanges方法时，就会使用上面定义的方法，而不是依赖于LINQ动态生成的SQL语句。
        private void UpdateAuthor(Author instance)
        {
            this.AuthorUpdate(instance.ID, instance.LastName, instance.FirstName, instance.WebSite, null, instance.TimeStamp);
        }

        // 标量值函数
        // IsComposable = true表示组合LINQ查询时，可以在数据库中进行，存储过程这个属性默认为false
        [Function(Name = "dbo.fnBookCountForPublisher", IsComposable = true)]
        public int? fnBookCountForPublisher([Parameter(Name = "PublisherId")] Guid? publisherId)
        {
            return (int?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisherId).ReturnValue);
        }

        // 表函数
        [Function(Name = "dbo.fnGetPublishersBooks", IsComposable = true)]
        public IQueryable<Book> fnGetPublishersBooks([Parameter(Name = "Publisher", DbType = "UniqueIdentifier")] Nullable<System.Guid> publisher)
        {
            return this.CreateMethodCallQuery<Book>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisher);
        }

        // 预编译版本的函数，这样每次调用这个查询时，就不会动态生成SQL，而是使用已经编译好的SQL
        // 有点类似于数据库中缓存的查询计划的意思，这里就是个演示
        public static Func<MyDataContext, decimal, IQueryable<Book>> ExpensiveBooks = CompiledQuery.Compile(
                (MyDataContext context, decimal minimumPrice) => from book in context.GetBook()
                                                                 where book.Price >= minimumPrice
                                                                 select book);
        private IQueryable<Book> GetBook()
        {
            throw new NotImplementedException();
        }

        public static IQueryable<Book> GetExpensiveBooks(decimal minimumPrice)
        {
            MyDataContext context = new MyDataContext();
            return ExpensiveBooks(context, minimumPrice);
        }
    }
}
