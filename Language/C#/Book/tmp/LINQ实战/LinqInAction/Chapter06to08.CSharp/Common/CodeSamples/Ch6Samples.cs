using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using LinqInAction.Chapter06to08.Common.SampleHarness;
using LinqInAction.Chapter06to08.Common.SampleClasses.Ch6;
using System.Data.SqlClient;

namespace LinqInAction.Chapter06to08.Common.CodeSamples
{
  public class Ch6Samples : SampleClass
  {
    public Ch6Samples() : base() { }

    [Sample(6, 0, "Fetch subjects using ADO")]
    public void SubjectOld()
    {
      IEnumerable<LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Subject> subjects = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Subject.GetSubjects();
      ObjectDumper.Write(subjects);
    }

    [Sample(6, 0, "Fetch Books using ADO")]
    public void BookOld()
    {
      IEnumerable<LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book> books = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book.GetBooks();
      ObjectDumper.Write(books);
    }

    [Sample(6, 1, "6-1: Querying Subjects and Books with LINQ to Objects")]
    public void StartingQuery_6_1()
    {

      IEnumerable<LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book> books = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book.GetBooks();
      IEnumerable<LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Subject> subjects = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Subject.GetSubjects();

      var query = from subject in subjects
                  join book in books on subject.SubjectId equals book.SubjectId
                  where book.Price < 30
                  orderby subject.Description, book.Title
                  select new
                  {
                    subject.Description,
                    book.Title,
                    book.Price
                  };
      ObjectDumper.Write(query, 1);
    }

    [Sample(6, 2, "6-2: Selecting the book title and price for books less than $30")]
    public void StartingBooksUnmapped_6_2()
    {
      IEnumerable<LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book> books = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book.GetBooks();

      var query = from book in books
                  where book.Price < 30
                  orderby book.Title
                  select new
                  {
                    book.Title,
                    book.Price
                  };
      ObjectDumper.Write(query, 1);

    }

    [Sample(6, 5, "6-5: Fetch books using LINQ to SQL")]
    public void StartingBooksFetch_6_5()
    {
      DataContext dataContext = new DataContext(Properties.Settings.Default.liaConnectionString);
      dataContext.Log = Console.Out;

      IQueryable<Book> query = from book in dataContext.GetTable<Book>()
                               select book;

      ObjectDumper.Write(query);
    }

    [Sample(6, 6, "6-6: Fetch the list of book titles")]
    public void StartingBooksFetchWithProjection_6_6()
    {
      DataContext dataContext = new DataContext(Properties.Settings.Default.liaConnectionString);
      dataContext.Log = Console.Out;

      IEnumerable<String> query =
          from book in dataContext.GetTable<Book>()
          select book.Title;

      ObjectDumper.Write(query);
    }

    [Sample(6, 7, "6-7: Project into an anonymous type")]
    public void StartingBooksFetchWithAnonymousProjection_6_7()
    {
      DataContext dataContext = new DataContext(Properties.Settings.Default.liaConnectionString);
      dataContext.Log = Console.Out;

      var query = from book in dataContext.GetTable<Book>()
                  select new
                  {
                    book.Title,
                    book.Price
                  };

      ObjectDumper.Write(query);
    }

    /// <summary>
    /// Listing 6.8:	Adding data paging using composition
    /// </summary>
    [Sample(6, 8, "6-8: Adding data paging using composition")]
    public void FetchingWithPaging_6_8()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      var books = dataContext.GetTable<Book>();
      var query = from book in books
                  select new
                  {
                    book.Title,
                    book.Price
                  };
      var pagedTitles = query.Skip(2);
      var titlesToShow = pagedTitles.Take(2);

      ObjectDumper.Write(titlesToShow);
    }

    /// <summary>
    /// Listing 6.10: Filtering using a range
    /// </summary>
    [Sample(6, 10, "6-10: Filtering using a range")]
    public static void FilteringUsingRange_6_10()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      var books = dataContext.GetTable<Book>();
      var query = from book in books
                  where book.Price < 30
                  select book;

      ObjectDumper.Write(query);
    }

    /// <summary>
    /// Listing 6.11: Using mapped CLR methods
    /// </summary>
    [Sample(6, 11, "6-11: Using mapped CLR methods")]
    public void FilteringMappedClrMethods()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      var books = dataContext.GetTable<Book>();
      var query = from book in books
                  where book.Title.Contains("on")
                  select book.Title;

      ObjectDumper.Write(query);
    }

    /// <summary>
    /// Listing 6.12: Using unmapped CLR methods
    /// </summary>
    [Sample(6, 11, "6-11a: Using unmapped CLR methods")]
    public void FilteringUnmappedClrMethods_6_11a()
    {
      Console.WriteLine("This example will intentionally fail because it uses CLR methods improperly.");

      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      var books = dataContext.GetTable<Book>();

      var query =
          from book in books
          where book.PublicationDate >= DateTime.Parse("1/1/2007")
          select book.PublicationDate.ToString("MM/dd/yyyy");


      ObjectDumper.Write(query);
    }

    /// <summary>
    /// Listing 6.12: Sorting with LINQ to SQL
    /// </summary>
    [Sample(6, 12, "6-12: Sorting with LINQ to SQL")]
    public void Sorting_6_12()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      var books = dataContext.GetTable<Book>();
      var query = from book in books
                  where book.Price < 30
                  orderby book.Title
                  select book.Title;

      ObjectDumper.Write(query);
    }

    /// <summary>
    /// Listing 6.13: Grouping and Sorting with LINQ to SQL
    /// </summary>
    [Sample(6, 13, "Grouping and Sorting")]
    public void Grouping_6_13()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      var query =
          from book in dataContext.GetTable<Book>()
          group book by book.SubjectId into groupedBooks
          orderby groupedBooks.Key
          select new
          {
            SubjectId = groupedBooks.Key,
            Books = groupedBooks
          };

      foreach (var groupedBook in query)
      {
        Console.WriteLine("Subject: {0}", groupedBook.SubjectId);
        foreach (Book item in groupedBook.Books)
        {
          Console.WriteLine("Book: {0}", item.Title);
        }
      }
    }

    /// <summary>
    /// Listing 6.14: Including aggregates in the results
    /// </summary>
    [Sample(6, 14, "Including aggregates in the results")]
    public void Aggregates_6_14()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      Table<Book> books = dataContext.GetTable<Book>();
      var query = from book in books
                  group book by book.SubjectId into groupedBooks
                  select new
                  {
                    groupedBooks.Key,
                    BookCount = groupedBooks.Count()
                  };

      ObjectDumper.Write(query, 1);

    }

    /// <summary>
    /// Listing 6.15: Using multiple aggregates
    /// </summary>
    [Sample(6, 15, "6-15: Using multiple aggregates")]
    public void Aggregates_6_15()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      Table<LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Book> books = dataContext.GetTable<LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Book>();
      var query =
          from book in books
          group book by book.SubjectId into groupedBooks
          select new
          {
            groupedBooks.Key,
            TotalPrice = groupedBooks.Sum(b => b.Price),
            LowPrice = groupedBooks.Min(b => b.Price),
            HighPrice = groupedBooks.Max(b => b.Price),
            AveragePrice = groupedBooks.Average(b => b.Price)
          };

      ObjectDumper.Write(query, 1);

    }

    /// <summary>
    /// Listing 6.16: Joining Books and Subjects
    /// </summary>
    [Sample(6, 16, "6-16: Joining Books and Subjects")]
    public void Joining_6_16()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      var subjects = dataContext.GetTable<Subject>();
      var books = dataContext.GetTable<Book>();
      var query = from subject in subjects
                  from book in books
                  where subject.SubjectId == book.SubjectId
                  select new { subject.Name, book.Title, book.Price };

      ObjectDumper.Write(query);
    }

    /// <summary>
    /// Listing 6.17: Joining with the Join keyword
    /// </summary>
    [Sample(6, 17, "6-17: Joining with the Join keyword")]
    public void Joining_6_17()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      var subjects = dataContext.GetTable<Subject>();
      var books = dataContext.GetTable<Book>();

      var query = from subject in subjects
                  join book in books
                     on subject.SubjectId equals book.SubjectId
                  select new { subject.Name, book.Title, book.Price };

      ObjectDumper.Write(query);
    }

    /// <summary>
    /// Listing 6.18: Approximating an Outer Join
    /// </summary>
    [Sample(6, 18, "6-18: Approximating an Outer Join")]
    public void Joining_6_18()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      var books = dataContext.GetTable<Book>();
      var Subjects = dataContext.GetTable<Subject>();
      var query =
          from subject in Subjects
          join book in books
             on subject.SubjectId equals book.SubjectId into joinedBooks
          from joinedBook in joinedBooks.DefaultIfEmpty()
          select new
          {
            subject.Name,
            joinedBook.Title,
            joinedBook.Price
          };


      ObjectDumper.Write(query);
    }

    [Sample(6, 19, "6-19: Rewriting the original example using LINQ to SQL")]
    public void OriginalRewritten_6_19()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      Table<Subject> subjects = dataContext.GetTable<Subject>();
      Table<Book> books = dataContext.GetTable<Book>();

      var query = from subject in subjects
                  join book in books
                     on subject.SubjectId equals book.SubjectId
                  where book.Price < 30
                  orderby subject.Name
                  select new
                  {
                    subject.Name,
                    book.Title,
                    book.Price
                  };

      ObjectDumper.Write(query);
    }

    /// <summary>
    /// Listing 6.21: Itering over object trees
    /// </summary>
    [Sample(6, 21, "6-21: Iterating over object trees")]
    public static void ObjectTrees_6_21()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      foreach (Subject subject in dataContext.GetTable<Subject>())
      {
        Console.WriteLine(subject.Name);
        foreach (Book book in subject.Books)
        {
          Console.WriteLine("...{0}", book.Title);
        }
      }

    }

    /// <summary>
    /// Listing 6.22: Using Any to achieve an inner join on object trees
    /// </summary>
    [Sample(6, 22, "6-22: Using Any to achieve an inner join on object trees")]
    public static void ObjectTrees_6_22()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;
      var Subjects = dataContext.GetTable<Subject>();

      var query = from subject in Subjects
                  where subject.Books.Any()
                  select subject;

      ObjectDumper.Write(query, 1);

    }

    /// <summary>
    /// Listing 6.22a: Using Any to achieve an inner join on object trees
    /// </summary>
    [Sample(6, 22, "6-22a: Using !Any to find orpbans")]
    public static void ObjectTrees_6_22a()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;
      var Subjects = dataContext.GetTable<Subject>();

      var query = from subject in Subjects
                  where !subject.Books.Any()
                  select subject;

      ObjectDumper.Write(query, 1);

    }

    /// <summary>
    /// Listing 6.23: Filtering child objects using All
    /// </summary>
    [Sample(6, 23, "6-23: Filtering child objects using All")]
    public static void ObjectTrees_6_23()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;
      var Subjects = dataContext.GetTable<Subject>();

      var query = from subject in Subjects
                  where subject.Books.All(b => b.Price < 30)
                  select subject;

      ObjectDumper.Write(query, 1);

    }

    [Sample(6, 24, "6-24: Running query using object heirarchies")]
    public void OriginalRewrittenHeirarchical_6_24()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      Table<Subject> subjects = dataContext.GetTable<Subject>();

      var query = from subject in subjects
                  orderby subject.Name
                  select new
                  {
                    subject.Name,
                    Books = from book in subject.Books
                            where book.Price < 30
                            select new { book.Title, book.Price }
                  };

      ObjectDumper.Write(query, 1);
    }

    [Sample(6, 25, "6-25: Lazy loading child objects")]
    public void LazyLoadingChildren_6_25()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);
      dataContext.Log = Console.Out;

      Table<Subject> subjects = dataContext.GetTable<Subject>();
      ObjectDumper.Write(subjects, 1);
    }

    /// <summary>
    /// Listing 6.27: Using the DataLoadOptions to optimize object loading
    /// </summary>
    [Sample(6, 27, "6-27: Using DataLoadOptions to optimize object loading")]
    public void LoadOptions_6_27()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      dataContext.Log = Console.Out;

      DataLoadOptions options = new DataLoadOptions();
      options.LoadWith<Subject>(Subject => Subject.Books);
      dataContext.LoadOptions = options;

      var query = dataContext.GetTable<Subject>();

      ObjectDumper.Write(query, 1);

    }

    /// <summary>
    /// Listing 6.28:	Updating values and committing them to the database
    /// </summary>
    [Sample(6, 28, "6-28: Updating values and commiting them to the database")]
    public void Updating_6_28()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);

      var ExpensiveBooks =
          from b in dataContext.GetTable<Book>()
          where b.Price > 30
          select b;

      foreach (Book b in ExpensiveBooks)
      {
        b.Price -= 5;
      }
      //Rather than commiting the update, we'll just print out the SQL to keep the database values.
      Console.WriteLine(LinqInAction.Chapter06to08.Common.Helpers.GetChangeText(dataContext));
      //dataContext.SubmitChanges();

    }
    /// <summary>
    ///  Listing 6.29:	Adding and removing items from a table
    /// </summary>
    [Sample(6, 29, "6-29: Adding and removing items from a table")]
    public void Insert_6_29()
    {
      DataContext dataContext =
          new DataContext(Properties.Settings.Default.liaConnectionString);
      Table<Book> books = dataContext.GetTable<Book>();

      Book newBook = new Book();
      newBook.Price = 40;
      newBook.PublicationDate = System.DateTime.Today;
      newBook.Title = "LINQ In Action";
      newBook.PublisherId = new Guid("4ab0856e-51f3-4b67-9355-8b11510119ba");
      newBook.SubjectId = new Guid("a0e2a5d7-88c6-4dfe-a416-10eadb978b0b");

      books.InsertOnSubmit(newBook);

      //Rather than commiting the update, we'll just print out the SQL to keep the database values.
      Console.WriteLine(LinqInAction.Chapter06to08.Common.Helpers.GetChangeText(dataContext));
      //dataContext.SubmitChanges();

      //Now delete it
      books.DeleteOnSubmit(newBook);

      //Rather than commiting the update, we'll just print out the SQL to keep the database values.
      Console.WriteLine(LinqInAction.Chapter06to08.Common.Helpers.GetChangeText(dataContext));
      //dataContext.SubmitChanges();
    }
  }
}