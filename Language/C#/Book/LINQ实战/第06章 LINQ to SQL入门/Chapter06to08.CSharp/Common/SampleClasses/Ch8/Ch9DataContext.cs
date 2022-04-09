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
    public partial class Ch8DataContext
    {
        [Function(Name = "dbo.UpdateAuthorWithoutTimestamp")]
        public int UpdateAuthorWithoutTimestamp(
            [Parameter(Name = "ID")] System.Guid? iD,
            [Parameter(Name = "LastName")] string lastName,
            [Parameter(Name = "FirstName")] string firstName,
            [Parameter(Name = "WebSite")] string webSite,
            [Parameter(Name = "OriginalLastName")] string originalLastName,
            [Parameter(Name = "OriginalFirstName")] string originalFirstName,
            [Parameter(Name = "OriginalWebSite")] string originalWebSite,
            [Parameter(Name = "UserName")] string userName)
        {
            IExecuteResult result = this.ExecuteMethodCall(
                this,
                ((MethodInfo)(MethodInfo.GetCurrentMethod())),
                iD, lastName, firstName, webSite,
                originalLastName, originalFirstName, originalWebSite, userName);
            iD = ((System.Nullable<System.Guid>)(result.GetParameterValue(0)));
            return ((int)(result.ReturnValue));
        }

        partial void UpdateAuthor(Author instance)
        {
            Author original = Authors.GetOriginalEntityState(instance);
            this.UpdateAuthorWithoutTimestamp(
                instance.ID, instance.LastName, instance.FirstName, instance.WebSite,
                original.LastName, original.FirstName, original.WebSite,
                System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        [Function(Name = "dbo.UpdateAuthor")]
        public int AuthorUpdate(
            [Parameter(Name = "ID", DbType = "UniqueIdentifier")] System.Guid iD,
            [Parameter(Name = "LastName", DbType = "VarChar(50)")] string lastName,
            [Parameter(Name = "FirstName", DbType = "VarChar(50)")] string firstName,
            [Parameter(Name = "WebSite", DbType = "VarChar(200)")] string webSite,
            [Parameter(Name = "UserName", DbType = "VarChar(50)")] string userName,
            [Parameter(Name = "TimeStamp", DbType = "Timestamp")] byte[] timeStamp)
        {
            if (userName == null) { userName = Thread.CurrentPrincipal.Identity.Name; }

            IExecuteResult result = this.ExecuteMethodCall(this,
                ((MethodInfo)(MethodInfo.GetCurrentMethod())),
                iD, lastName, firstName, webSite, userName, timeStamp);
            iD = (System.Guid)(result.GetParameterValue(0));
            int RowsAffected = ((int)(result.ReturnValue));
            if (RowsAffected == 0) { throw new ChangeConflictException(); }
            return RowsAffected;
        }

        [Function(Name = "dbo.InsertAuthor")]
        public int AuthorInsert([Parameter(Name = "ID", DbType = "UniqueIdentifier")] ref System.Nullable<System.Guid> iD, [Parameter(Name = "LastName", DbType = "VarChar(50)")] string lastName, [Parameter(Name = "FirstName", DbType = "VarChar(50)")] string firstName, [Parameter(Name = "WebSite", DbType = "VarChar(200)")] string webSite, [Parameter(Name = "UserName", DbType = "VarChar(50)")] string userName, [Parameter(Name = "TimeStamp", DbType = "Timestamp")] byte[] timeStamp)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, lastName, firstName, webSite, userName, timeStamp);
            iD = ((System.Nullable<System.Guid>)(result.GetParameterValue(0)));
            return ((int)(result.ReturnValue));
        }

        //partial void UpdateAuthor(Author instance)
        //{
        //    this.AuthorUpdate(instance.ID, instance.LastName, instance.FirstName, instance.WebSite, System.Threading.Thread.CurrentPrincipal.Identity.Name, instance.TimeStamp);
        //}
        //[Function(Name = "dbo.GetBook")]
        //public ISingleResult<Book> GetBook(
        //    [Parameter(Name = "@BookId")] Guid BookId,
        //    [Parameter(Name = "@UserName")]  string UserName)
        //{
        //    IExecuteResult result =
        //        this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())),
        //            BookId, UserName);
        //    return (ISingleResult<Book>)(result.ReturnValue);
        //}

        //[Function(Name = "dbo.BookCountForPublisher")]
        //public int BookCountForPublisher(
        //    [Parameter(Name = "@PublisherId")] Guid PublisherId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(
        //        this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), PublisherId);
        //    return ((int)(result.ReturnValue));
        //}

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
            { UserName = Thread.CurrentPrincipal.Identity.Name; }
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ID, LastName, FirstName, WebSite, UserName, TimeStamp);
            ID = ((Guid)(result.GetParameterValue(0)));
            int RecordsAffected = (int)result.ReturnValue;
            if (RecordsAffected == 0) { throw new ChangeConflictException(); }
            return RecordsAffected;
        }
        private void UpdateAuthor(Author original, Author current)
        {
            if ((original.FirstName != current.FirstName) || (original.LastName != current.LastName) || (original.WebSite != current.WebSite))
            {
                this.UpdateAuthor(current.ID, current.LastName, current.FirstName, current.WebSite, null, current.TimeStamp);
            }
        }

        //[Function(Name = "dbo.fnBookCountForPublisher", IsComposable = true)]
        //public System.Nullable<int> fnBookCountForPublisher([Parameter(Name = "PublisherId", DbType = "UniqueIdentifier")] System.Nullable<System.Guid> publisherId)
        //{
        //    return ((System.Nullable<int>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisherId).ReturnValue));
        //}
        [Function(Name = "dbo.fnBookCountForPublisher", IsComposable = true)]
        public int? fnBookCountForPublisher1([Parameter(Name = "PublisherId")] Guid? publisherId)
        {
            return (int?)(this.ExecuteMethodCall(
                this,
                ((MethodInfo)(MethodInfo.GetCurrentMethod())),
                publisherId).ReturnValue);
        }

        [Function(Name = "dbo.fnGetPublishersBooks", IsComposable = true)]
        public IQueryable<Book> fnGetPublishersBooks1(
            [Parameter(Name = "Publisher", DbType = "UniqueIdentifier")]
            System.Nullable<System.Guid> publisher)
        {
            return this.CreateMethodCallQuery<Book>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisher);
        }

        //    [Function(Name = "dbo.fnGetPublishersBooks", IsComposable = true)]
        //    public IQueryable<Book> fnGetPublishersBooks([Parameter(Name = "Publisher", DbType = "UniqueIdentifier")] System.Nullable<System.Guid> publisher)
        //    {
        //        IQueryable<Book> result = this.CreateMethodCallQuery<Book>(
        //this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisher);
        //        return result; 

        //     //   return this.CreateMethodCallQuery<Book>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), publisher);
        //    }

        /// <summary>
        /// Precompiled version of the Expensive Books query
        /// </summary>
        public static Func<Ch8DataContext, decimal, IQueryable<Book>> ExpensiveBooks = CompiledQuery.Compile(
            (Ch8DataContext context, decimal minimumPrice) => from book in context.Books
                                                              where book.Price >= minimumPrice
                                                              select book);

        /// <summary>
        /// Helper method to encapsulate the context instance which calls the 
        /// <see cref="ExpensiveBooks">ExpensiveBooks compiled query</see>
        /// </summary>
        /// <param name="minimumPrice"></param>
        /// <returns>Enumerable list of Books whith a price higher than the minimumPrice</returns>
        public static IQueryable<Book> GetExpensiveBooks(decimal minimumPrice)
        {
            Ch8DataContext context = new Ch8DataContext(LinqInAction.Chapter06to08.Common.Properties.Settings.Default.liaConnectionString);
            return ExpensiveBooks(context, minimumPrice);
        }
    }
}
