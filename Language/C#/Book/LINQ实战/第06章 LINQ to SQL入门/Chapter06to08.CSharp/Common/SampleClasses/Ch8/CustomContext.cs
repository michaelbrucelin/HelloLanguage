using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch8
{
    public class CustomContext : DataContext
    {
        public CustomContext() : base(global::LinqInAction.Chapter06to08.Common.Properties.Settings.Default.liaConnectionString)
        {
        }

        public global::System.Data.Linq.Table<Book> Books
        {
            get
            {
                return this.GetTable<Book>();
            }
        }

        [Function(Name = "dbo.GetBook")]
        public IEnumerable<Book> GetBook([Parameter(Name = "@BookId")] Guid BookId, [Parameter(Name = "@UserName")] string UserName)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), BookId, UserName);
            return (ISingleResult<Book>)(result.ReturnValue);
        }

        [Function(Name = "dbo.BookCountForPublisher")]
        public int BookCountForPublisher([Parameter(Name = "@PublisherId")] Guid PublisherId)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), PublisherId);
            return ((int)(result.ReturnValue));
        }

        [Function(Name = "dbo.UpdateAuthor")]
        public int UpdateAuthor(
            [Parameter(Name = "@ID")] Guid ID,
            [Parameter(Name = "@LastName")] string LastName,
            [Parameter(Name = "@FirstName")] string FirstName,
            [Parameter(Name = "@WebSite")] string WebSite,
            [Parameter(Name = "@UserName")] string UserName,
            [Parameter(Name = "@TimeStamp")] byte[] TimeStamp)
        {
            if (UserName == null)
            {
                UserName = Thread.CurrentPrincipal.Identity.Name;
            }
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ID, LastName, FirstName, WebSite, UserName, TimeStamp);
            ID = ((Guid)(result.GetParameterValue(0)));
            int RecordsAffected = (int)result.ReturnValue;
            if (RecordsAffected == 0)
            {
                throw new ChangeConflictException();
            }
            return RecordsAffected;
        }
        private void UpdateAuthor(Author original, Author current)
        {
            if ((original.FirstName != current.FirstName) || (original.LastName != current.LastName) || (original.WebSite != current.WebSite))
            {
                this.UpdateAuthor(current.ID, current.LastName, current.FirstName, current.WebSite, null, current.TimeStamp);
            }
        }

        /// <summary>
        /// Precompiled version of the Expensive Books query
        /// </summary>
        public static Func<CustomContext, decimal, IQueryable<Book>>
            ExpensiveBooks = CompiledQuery.Compile(
                (CustomContext context, decimal minimumPrice) => from book in context.Books
                                                                 where book.Price >= minimumPrice
                                                                 select book);

        /// <summary>
        /// Helper method to encapsulate the context instance which calls the 
        /// <see cref="ExpensiveBooks">ExpensiveBooks compiled query</see>
        /// </summary>
        /// <param name="minimumPrice"></param>
        /// <returns>Queryable list of Books whith a price higher than the minimumPrice</returns>
        public static IQueryable<Book> GetExpensiveBooks(decimal minimumPrice)
        {
            CustomContext context = new CustomContext();
            return ExpensiveBooks(context, minimumPrice);
        }
    }
}