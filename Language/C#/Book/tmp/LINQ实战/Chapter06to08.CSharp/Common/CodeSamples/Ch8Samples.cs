using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Provider;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using LinqInAction.Chapter06to08.Common;
using LinqInAction.Chapter06to08.Common.CodeSamples;
using LinqInAction.Chapter06to08.Common.SampleClasses.Ch8;
using LinqInAction.Chapter06to08.Common.SampleHarness;

namespace LinqInAction.Chapter06to08.Common.CodeSamples
{
    public class Ch8Samples : SampleClass
    {
        Ch8DataContext NewContext
        {
            get
            {
                return new Ch8DataContext() { Log = Console.Out };
            }
        }

        [Sample(8, 2, "8-2: Default concurrency implementation with LINQ to SQL")]
        public void DefaultConcurrencyImplementation_8_2()
        {
            Ch8DataContext context = this.NewContext;
            var mostExpensiveBook = (from book in context.Books
                                     orderby book.Price descending
                                     select book).First();

            decimal discount = .1M;
            mostExpensiveBook.Price -= mostExpensiveBook.Price * discount;

            //context.SubmitChanges();

            //Rather than committing a change, just view the SQL that would be used
            Console.WriteLine(context.GetChangeText());
        }

        [Sample(8, 3, "8-3: Optimistic Concurrency with Authors using a timestamp")]
        public void ConcurrencyWithTimestamp_8_3()
        {
            LinqBooksDataContext context = new LinqBooksDataContext();

            var authorToChange = (context.Authors).First();

            authorToChange.FirstName = "Jim";
            authorToChange.LastName = "Wooley";

            //Rather than committing a change, just view the SQL that would be used
            Console.WriteLine(context.GetChangeText());
        }

        [Sample(8, 4, "8-4: Resolving change conflicts with KeepChanges")]
        public void ConcurrencyKeepChanges_8_4()
        {
            Ch8DataContext context = this.NewContext;
            //Make some changes
            this.MakeConcurrentChanges(context);

            try
            {
                context.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
                context.ChangeConflicts.ResolveAll(
                    RefreshMode.KeepChanges);
                //resubmit the merged values
                context.SubmitChanges();
            }
        }

        [Sample(8, 5, "8-5: Resolving multiple conflits replacing the users values with ones from the database")]
        public void ConcurrencyOverwriteCurrentValues_8_5()
        {
            Ch8DataContext context = this.NewContext;
            //Make some changes
            this.MakeConcurrentChanges(context);

            try
            {
                context.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
                context.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
            }
        }

        /// <summary>
        /// Force a concurrency error and display the old values, 
        /// new values and current database values for the user to 
        /// manually resolve.
        /// </summary>
        [Sample(8, 6, "8-6: Displaying conflict details")]
        public void ConcurrencyDisplayingChanges_8_6()
        {
            Ch8DataContext context = new Ch8DataContext();
            //Make some changes
            this.MakeConcurrentChanges(context);

            try
            {
                context.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException)
            {
                var exceptionDetail =
                    from conflict in context.ChangeConflicts
                    from member in conflict.MemberConflicts
                    select new
                    {
                        TableName = Helpers.GetTableName(context, conflict.Object),
                        MemberName = member.Member.Name,
                        CurrentValue = member.CurrentValue.ToString(),
                        DatabaseValue = member.DatabaseValue.ToString(),
                        OriginalValue = member.OriginalValue.ToString()
                    };
                ObjectDumper.Write(exceptionDetail);
            }
        }

        [Sample(8, 7, "8-7: Managing the transaction through the DataContext")]
        public void TransactionsDataContext_8_8()
        {
            Ch8DataContext context = this.NewContext;

            this.MakeConcurrentChanges(context);

            try
            {
                context.Connection.Open();
                context.Transaction = context.Connection.BeginTransaction();
                context.SubmitChanges(ConflictMode.ContinueOnConflict);
                context.Transaction.Commit();
            }
            catch (ChangeConflictException)
            {
                context.Transaction.Rollback();
            }
        }

        [Sample(8, 8, "8-8: Managing transactions with the TransactionScope object")]
        public void TransactionsSqlTransactionScope_8_8()
        {
            Ch8DataContext context = this.NewContext;

            this.MakeConcurrentChanges(context);

            using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
            {
                context.SubmitChanges(ConflictMode.ContinueOnConflict);
                scope.Complete();
            }

        }

        [Sample(8, 9, "8-9: Dynamic SQL pass-through")]
        public void DynamicSql_8_9()
        {
            string SearchName = "Wooley";

            DynamicSql(SearchName);
        }

        [Sample(8, 9, "8-9a: Dunamic pass-through allowing SQL injection")]
        public void DyanmicSqlWithInjection_8_9a()
        {
            //Malicious string entered by the user
            string SearchName = "Good' OR ''='";
            DynamicSql(SearchName);
        }

        private void DynamicSql(string searchName)
        {
            Ch8DataContext context = this.NewContext;

            string sql = @"Select ID, LastName, FirstName, WebSite, TimeStamp    " +
                "From dbo.Author " +
                "Where LastName = '" + searchName + "'";

            IEnumerable<Author> authors = context.ExecuteQuery<Author>(sql);
            ObjectDumper.Write(authors);
        }

        [Sample(8, 10, "8-10: Dynamic SQL pass-through with parameters")]
        public void DynamicSqlParameters_8_10()
        {
            string searchName = "Good' OR ''='";

            Ch8DataContext context = this.NewContext;
            string sql = @"Select ID, LastName, FirstName, WebSite, TimeStamp  " +
                "From dbo.Author " +
                "Where LastName = {0}";

            // We should actually have 0 records returned in this case.
            ObjectDumper.Write(context.ExecuteQuery<Author>(sql, searchName));

        }

        [Sample(8, 11, "8-11: Using a Stored Procedure to return results")]
        public void StoredProc_8_11()
        {
            Guid bookId = new Guid("0737c167-e3d9-4a46-9247-2d0101ab18d1");
            Ch8DataContext context = this.NewContext;
            IEnumerable<LinqInAction.Chapter06to08.Common.SampleClasses.Ch8.Book> query =
                context.GetBook(bookId,
                System.Threading.Thread.CurrentPrincipal.Identity.Name);

            ObjectDumper.Write(query);
        }

        [Sample(8, 13, "8-13: Using a stored procedure to return a Scalar value")]
        public void StoredProcScalar_8_13()
        {
            Guid publisherId = new Guid("851e3294-145d-4fff-a190-3cab7aa95f76");
            Ch8DataContext context = this.NewContext;
            Console.WriteLine(String.Format("Books found: {0}",
                context.BookCountForPublisher(publisherId).ToString()));
        }

        [Sample(8, 16, "8-16: Consuing the update stored procedure using LINQ")]
        public void UpdateProcedures_8_16()
        {
            Ch8DataContext context = this.NewContext;
            var changingAuthor = context.Authors.FirstOrDefault<LinqInAction.Chapter06to08.Common.SampleClasses.Ch8.Author>();
            changingAuthor.FirstName = "Changing";
            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                context.SubmitChanges();
                //Let the transaction rollback
            }
        }

        [Sample(8, 19, "8-19: LINQ code generated for the scalar function")]
        public void UserDefinedScalarFunctions_8_19()
        {
            Ch8DataContext context = this.NewContext;

            Guid? PublisherId = new Guid(@"855cb02e-dc29-473d-9f40-6c3405043fa3");
            Console.WriteLine(context.fnBookCountForPublisher(PublisherId));
        }

        [Sample(8, 20, "8-20: Using a scalar user defined function in a query")]
        public void UserDefinedFunctionsInQuery_8_20()
        {
            Ch8DataContext context = this.NewContext;

            var query =
                from publisher in context.GetTable<Publisher>()
                select new
                {
                    publisher.Name,
                    BookCount = context.fnBookCountForPublisher(publisher.ID)
                };

            ObjectDumper.Write(query);
        }

        [Sample(8, 22, "8-22: Defining and consuming a table-valued function.")]
        public void UserDefinedFunctions_8_22()
        {
            Ch8DataContext context = this.NewContext;

            Guid publisherId = new Guid("855cb02e-dc29-473d-9f40-6c3405043fa3");
            var query1 = from book in context.fnGetPublishersBooks(publisherId)
                         select new
                         {
                             book.Title,
                             OtherBookCount = context.fnBookCountForPublisher1(book.Publisher) - 1
                         };
            ObjectDumper.Write(query1);
        }

        [Sample(8, 23, "8-23: Precompiling a query")]
        public void CompiledQuery_8_23()
        {
            ObjectDumper.Write(Ch8DataContext.GetExpensiveBooks(30));
        }

        [Sample(8, 25, "8-25: Querying with a property from the partial class.")]
        public void QueryingPartialClass_8_25()
        {
            Ch8DataContext context = this.NewContext;
            var partialAuthors = from author in context.Authors
                                 select author;

            ObjectDumper.Write(partialAuthors);

        }

        [Sample(8, 26, "8-26: Implementing IDataErrorInfo in the partial class.")]
        public void ConsumingIDataErrorInfo_9_26()
        {
            EditingForm frm = new EditingForm();
            frm.ShowDialog();
        }

        [Sample(8, 28, "8-28: Querying Inheritance.")]
        public void QueryingInheritance_8_28()
        {
            LinqInAction.Chapter06to08.Common.LinqBooksDataContext context = new LinqInAction.Chapter06to08.Common.LinqBooksDataContext();
            context.Log = Console.Out;

            //Get all users from the base instance
            Console.WriteLine("All users:");
            var query = from user in context.UserBases
                        select user.Name;
            ObjectDumper.Write(query);

            Console.WriteLine();
            Console.WriteLine("Authors: ");
            //Get only the authors
            var authors = from user in context.UserBases
                          where user is LinqInAction.Chapter06to08.Common.AuthorUser
                          select user.Name;
            ObjectDumper.Write(authors);

            Console.WriteLine();
            Console.WriteLine("Publishers: ");
            //Get the publishers using the OfType extension method
            var publishers = from user in context.UserBases.OfType<LinqInAction.Chapter06to08.Common.PublisherUser>()
                             select user.Name;
            ObjectDumper.Write(publishers);

        }

        private void MakeConcurrentChanges(Ch8DataContext context)
        {
            Ch8DataContext context1 = this.NewContext;

            //First user raises the price of each book
            var books1 = context1.Books;
            foreach (var book in books1)
            {
                book.Price += 2;
            }

            //Second user lowers the price of each book
            var books2 = context.Books;
            foreach (var book in books2)
            {
                book.Price -= 1;
            }
            //Go ahead and submit the first changes. 
            //The submit using the context passed in to this method will fail.
            context1.SubmitChanges();
        }
    }
}