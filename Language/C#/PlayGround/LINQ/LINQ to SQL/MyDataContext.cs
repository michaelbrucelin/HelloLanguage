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

        // 标量值函数
        // IsComposable = true表示组合LINQ查询时，可以在数据库中进行，存储过程这个属性默认为false
        [Function(Name = "dbo.fnBookCountForPublisher", IsComposable = true)]
        public int? fnBookCountForPublisher([Parameter(Name = "PublisherId")] Guid? publisherId)
        {
            return (int?)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisherId).ReturnValue);
        }
    }
}
