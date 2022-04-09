using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LinqInAction.Chapter06to08.Common
{
    public partial class LinqBooksDataContext
    {
        [Function(Name = "dbo.GetBook")]
        public ISingleResult<Book> GetBook(
            [Parameter(Name = "@BookId")] Guid bookId,
            [Parameter(Name = "@UserName")] string userName)
        {
            ISingleResult<Book> result = (ISingleResult<Book>)(this.ExecuteMethodCall(this, (MethodInfo)(MethodInfo.GetCurrentMethod()), bookId, userName).ReturnValue);
            return result;
        }
    }
}