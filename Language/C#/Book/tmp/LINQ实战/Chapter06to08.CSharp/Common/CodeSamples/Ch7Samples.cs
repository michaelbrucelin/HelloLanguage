using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using LinqInAction.Chapter06to08.Common;
using LinqInAction.Chapter06to08.Common.SampleHarness;

namespace LinqInAction.Chapter06to08.Common.CodeSamples
{
    public class Ch7Samples : SampleClass
    {
        public Ch7Samples() : base() { }

        /// <summary>
        /// Listing 7.2:	Attaching the external XML mapping to the DataContext
        /// </summary>
        [Sample(7, 2, "7-2: Attaching the external XML mapping to the DataContext")]
        public void XmlMapping_7_2()
        {
            XmlMappingSource map = XmlMappingSource.FromXml(System.IO.File.ReadAllText(@"lia.xml"));

            DataContext dataContext = new DataContext(LinqInAction.Chapter06to08.Common.Properties.Settings.Default.liaConnectionString, map);

            var authors = dataContext.GetTable<LinqInAction.Chapter06to08.Common.SampleClasses.Ch7.AuthorXml>();
            ObjectDumper.Write(authors);
        }

        [Sample(7, 3, "7.3: Query expressed as expressions")]
        public void QueryExpressions_7_3()
        {
            LinqBooksDataContext context = new LinqBooksDataContext();

            var bookParam = Expression.Parameter(typeof(Book), "book");

            var query = context.Books.Where<Book>(Expression.Lambda<Func<Book, bool>>
                    (Expression.GreaterThan(
                        Expression.Property(
                            bookParam,
                            typeof(Book).GetProperty("Price")),
                        Expression.Constant(30M, typeof(decimal?))),
                    new ParameterExpression[] { bookParam }));

            ObjectDumper.Write(query);
        }

        [Sample(7, 4, "7.4: Identity management and change tracking")]
        public void LifecycleTestWithoutSubmit_7_4()
        {
            LinqBooksDataContext context1 = new LinqBooksDataContext();
            LinqBooksDataContext context2 = new LinqBooksDataContext();

            context1.Log = Console.Out;
            context2.Log = Console.Out;

            Guid Id = new Guid("92f10ca6-7970-473d-9a25-1ff6cab8f682");

            Subject editingSubject = context1.Subjects.Where(s => s.SubjectId == Id).SingleOrDefault();

            Console.WriteLine("Before Change:");
            ObjectDumper.Write(editingSubject);
            ObjectDumper.Write(context2.Subjects.Where(s => s.SubjectId == Id));

            editingSubject.Description = @"Testing update";

            Console.WriteLine("After Change:");
            ObjectDumper.Write(context1.Subjects.Where(s => s.SubjectId == Id));
            ObjectDumper.Write(context2.Subjects.Where(s => s.SubjectId == Id));
        }

        [Sample(7, 5, "7-5: Submitting changes with identity and change tracking")]
        public void LifecycleTest_7_5()
        {
            LinqBooksDataContext context1 = new LinqBooksDataContext();
            LinqBooksDataContext context2 = new LinqBooksDataContext();
            context1.Log = Console.Out;
            context2.Log = Console.Out;

            Guid Id = new Guid("92f10ca6-7970-473d-9a25-1ff6cab8f682");

            Subject editingSubject = context1.Subjects.Where(s => s.SubjectId == Id).SingleOrDefault();

            Console.WriteLine("Before Change:");
            ObjectDumper.Write(editingSubject);
            ObjectDumper.Write(context2.Subjects.Where(s => s.SubjectId == Id));

            editingSubject.Description = @"Testing update";

            Console.WriteLine("After Change:");
            ObjectDumper.Write(context1.Subjects.Where(s => s.SubjectId == Id));
            ObjectDumper.Write(context2.Subjects.Where(s => s.SubjectId == Id));

            context1.SubmitChanges();

            Console.WriteLine("After Submit Changes:");
            ObjectDumper.Write(context1.Subjects.Where(s => s.SubjectId == Id));
            ObjectDumper.Write(context2.Subjects.Where(s => s.SubjectId == Id));
            LinqBooksDataContext context3 = new LinqBooksDataContext();
            ObjectDumper.Write(context3.Subjects.Where(s => s.SubjectId == Id));

            //Reset values
            editingSubject.Description = "Original Value";
            context1.SubmitChanges();
        }

        [Sample(7, 6, "7-6: Updating records in a disconnected environment")]
        public void DisconnectedTest_7_6()
        {
            LinqBooksDataContext context1 = new LinqBooksDataContext();
            context1.Log = Console.Out;

            /* Objects can only be attached to a single context at any given time. 
             * This is done to avoid the potential to update child objects erroneously. 
             * For the purposes of this example, we purposefully set up context1 up so that
             * it wouldn’t track the changes by setting the ObjectTrackingEnabled to false.
             * Attempting to attach an object to a second context will result in a NotSupportedException.  */
            context1.ObjectTrackingEnabled = false;

            Subject cachedSubject = context1.Subjects.First();
            Console.WriteLine("Starting name: {0}", cachedSubject.Name);

            // In a real application, this object would now be cached or remoted via a web service
            // Use second context to simulate disconnected environment

            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                UpdateSubject(cachedSubject);
                Console.WriteLine("Updated name: {0}", cachedSubject.Name);
                //Rollback the change after running the demo
            }
        }
        public void UpdateSubject(Subject cachedSubject)
        {
            LinqBooksDataContext context = new LinqBooksDataContext();
            context.Log = Console.Out;
            context.Subjects.Attach(cachedSubject);
            cachedSubject.Name = @"Testing update";

            context.SubmitChanges();
        }

        [Sample(7, 6, "7-6a: Updating records in a disconnected environment with a timestamp")]
        public void DisconnectedTestWithTimestamp_7_6a()
        {
            LinqBooksDataContext context1 = new LinqBooksDataContext();
            context1.Log = Console.Out;

            /* Objects can only be attached to a single context at any given time. 
             * This is done to avoid the potential to update child objects erroneously. 
             * For the purposes of this example, we purposefully set up context1 up so that
             * it wouldn’t track the changes by setting the ObjectTrackingEnabled to false.
             * Attempting to attach an object to a second context will result in a NotSupportedException.  */
            context1.ObjectTrackingEnabled = false;

            Author cachedAuthor = context1.Authors.First();
            Console.WriteLine("Starting name: {0}", cachedAuthor.FirstName);

            // In a real application, this object would now be cached or remoted via a web service
            // Use second context to simulate disconnected environment

            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                UpdateAuthor(cachedAuthor);
                Console.WriteLine("Updated name: {0}", cachedAuthor.FirstName);
                //Rollback the change after running the demo
            }
        }
        public void UpdateAuthor(Author cachedAuthor)
        {
            LinqBooksDataContext context = new LinqBooksDataContext();
            context.Log = Console.Out;
            cachedAuthor.FirstName = @"Testing update";
            context.Authors.Attach(cachedAuthor, true);

            context.SubmitChanges();
        }

        [Sample(7, 6, "7-6b: Updating records in a disconnected environment passing in object proprerties")]
        public void DisconnectedTest_7_6b()
        {
            LinqBooksDataContext context1 = new LinqBooksDataContext();
            context1.Log = Console.Out;

            /* Objects can only be attached to a single context at any given time. 
             * This is done to avoid the potential to update child objects erroneously. 
             * For the purposes of this example, we purposefully set up context1 up so that
             * it wouldn’t track the changes by setting the ObjectTrackingEnabled to false.
             * Attempting to attach an object to a second context will result in a NotSupportedException.  */
            context1.ObjectTrackingEnabled = false;

            Author cachedAuthor = context1.Authors.First();
            Console.WriteLine("Starting name: {0}", cachedAuthor.FirstName);

            // In a real application, this object would now be cached or remoted via a web service
            // Use second context to simulate disconnected environment

            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                UpdateAuthor(cachedAuthor.ID, cachedAuthor.FirstName, "Testing change", cachedAuthor.WebSite, cachedAuthor.TimeStamp);
                //refetch it and show the database value now
                ObjectDumper.Write(from a in context1.Authors where a.ID == cachedAuthor.ID select a);

                //Rollback the change after running the demo
            }
        }

        public void UpdateAuthor(Guid id, String firstName, String lastName, String webSite, Byte[] timeStamp)
        {
            LinqBooksDataContext context = new LinqBooksDataContext();
            context.Log = Console.Out;
            context.Authors.Attach(new Author
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                WebSite = webSite,
                TimeStamp = timeStamp
            }, true);

            context.SubmitChanges();
        }

        [Sample(7, 6, "7-6c: Updating records in a disconnected environment using attach with old and new versions.")]
        public void DisconnectedTest_7_6c()
        {
            LinqBooksDataContext context1 = new LinqBooksDataContext();
            context1.Log = Console.Out;

            /* Objects can only be attached to a single context at any given time. 
             * This is done to avoid the potential to update child objects erroneously. 
             * For the purposes of this example, we purposefully set up context1 up so that
             * it wouldn’t track the changes by setting the ObjectTrackingEnabled to false.
             * Attempting to attach an object to a second context will result in a NotSupportedException.  */
            context1.ObjectTrackingEnabled = false;

            Subject cachedSubject = context1.Subjects.First();
            Subject newVersion = new Subject
            {
                Name = "Testing a change",
                SubjectId = cachedSubject.SubjectId,
                Description = cachedSubject.Description
            };

            Console.WriteLine("Starting name: {0}", cachedSubject.Name);

            // In a real application, this object would now be cached or remoted via a web service
            // Use second context to simulate disconnected environment
            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                UpdateSubject(cachedSubject, newVersion);
                //Rollback the change after running the demo
            }
        }

        public void UpdateSubject(Subject cachedVersion, Subject newVersion)
        {
            LinqBooksDataContext context = new LinqBooksDataContext();
            context.Log = Console.Out;
            context.Subjects.Attach(newVersion, cachedVersion);
            context.SubmitChanges();

            Console.WriteLine("New value: ");
            ObjectDumper.Write(from s in context.Subjects where s.SubjectId == newVersion.SubjectId select s);
        }

        [Sample(7, 7, "7-7: Updating a disconnected object that has already been updated")]
        public void SoaTest_7_7()
        {
            LinqBooksDataContext context1 = new LinqBooksDataContext();
            context1.Log = Console.Out;

            Guid Id = new Guid("92f10ca6-7970-473d-9a25-1ff6cab8f682");

            Subject existingSubject = context1.Subjects.Where(s => s.SubjectId == Id).SingleOrDefault();
            Console.WriteLine("Starting name: {0}", existingSubject.Name);

            Subject changingSubject = new Subject { SubjectId = existingSubject.SubjectId };
            changingSubject.Name = @"Testing update";

            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                //Apply the changes through a mimiced service
                Subject.UpdateSubject(changingSubject);

                //Rollback the change after running the demo
            }
        }
    }
}