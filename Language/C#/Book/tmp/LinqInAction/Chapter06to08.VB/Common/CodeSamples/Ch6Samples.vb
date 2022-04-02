Option Strict On
Imports System.Linq
Imports System.Text
Imports System.Data.Linq
Imports LinqInAction.Chapter06to08.Common.SampleClasses.Ch6
Imports System.Data.SqlClient

Namespace CodeSamples
  Public Class Ch6Samples
    Inherits SampleClass

    <Sample(6, 0, "Fetch subjects using ADO")> _
    Private Sub SubjectOld()
      Dim subjects = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Subject.GetSubjects
      ObjectDumper.Write(subjects)
    End Sub

    <Sample(6, 0, "Fetch Books using ADO")> _
    Private Sub BookOld()
      Dim books = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book.GetBooks()
      ObjectDumper.Write(books)
    End Sub

    <Sample(6, 1, "6-1: Querying Subjects and Books with LINQ to Objects")> _
    Public Sub StartingQuery_6_1()
      Dim books As IEnumerable(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book) = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book.GetBooks()
      Dim subjects As IEnumerable(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Subject) = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Subject.GetSubjects()
      Dim query = From _subject In subjects _
                  Join _book In books On _subject.SubjectId Equals _book.SubjectId _
                  Where _book.Price < 30 _
                  Order By _subject.Description, _book.Title _
                  Select _subject.Description, _
                         _book.Title, _
                         _book.Price

      ObjectDumper.Write(query, 1)
    End Sub

    <Sample(6, 2, "6-2: Selecting the book title and price for books less than $30")> _
    Public Sub StartingBooksUnmapped_6_2()
      Dim books As IEnumerable(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book) = LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped.Book.GetBooks()

      Dim query = From _book In books _
                  Where _book.Price < 30 _
                  Order By _book.Title _
                  Select _book.Title, _book.Price

      ObjectDumper.Write(query, 1)
    End Sub

    <Sample(6, 5, "6-5: Fetch books using LINQ to SQL")> _
    Public Sub StartingBooksFetch_6_5()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)
      dataContext.Log = Console.Out

      Dim query As IQueryable(Of Book) = From book In dataContext.GetTable(Of Book)() _
                                         Select book

      ObjectDumper.Write(query)
    End Sub

    <Sample(6, 6, "6-6: Fetch the list of book titles")> _
    Public Sub StartingBooksFetchWithProjection_6_6()

      Dim dataContext As New DataContext(My.Settings.liaConnectionString)
      dataContext.Log = Console.Out

      Dim query As IEnumerable(Of String) = From book In dataContext.GetTable(Of Book)() _
                                            Select book.Title

      ObjectDumper.Write(query)
    End Sub

    <Sample(6, 7, "6-7: Project into an anonymous type")> _
    Public Sub StartingBooksFetchWithAnonymousProjection_6_7()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)
      dataContext.Log = Console.Out

      Dim query = From book In dataContext.GetTable(Of Book)() _
                  Select book.Title, book.Price

      ObjectDumper.Write(query)
    End Sub

    ''' <summary>
    ''' Listing 6.8:	Adding data paging using composition
    ''' </summary>
    <Sample(6, 8, "6-8: Adding data paging using composition")> _
    Public Sub FetchingWithPaging_6_8()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim books = dataContext.GetTable(Of Book)()
      Dim query = From book In books _
                  Select book.Title, book.Price

      Dim pagedTitles = query.Skip(2)
      Dim titlesToShow = pagedTitles.Take(2)

      ObjectDumper.Write(titlesToShow)
    End Sub

    ''' <summary>
    ''' Listing 7.9:	Adding data paging using composition
    ''' </summary>
    <Sample(6, 9, "6-9: VB Syntax for paging data")> _
    Public Sub FetchingWithPagingVB_6_9()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim books = dataContext.GetTable(Of Book)()
      Dim query = From book In books _
                  Skip 2 _
                  Take 2 _
                  Select book.Title, book.Price

      ObjectDumper.Write(query)
    End Sub

    ''' <summary>
    ''' Listing 6.10: Filtering using a range
    ''' </summary>
    <Sample(6, 10, "6-10: Filtering using a range")> _
    Public Sub FilteringUsingRange_6_10()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)
      dataContext.Log = Console.Out

      Dim books = dataContext.GetTable(Of Book)()
      Dim query = From book In books _
                  Where (book.Price < 30) _
                  Select book

      ObjectDumper.Write(query)
    End Sub

    ''' <summary>
    ''' Listing 6.11: Using mapped CLR methods
    ''' </summary>
    <Sample(6, 11, "6-11: Using mapped CLR methods")> _
    Public Sub FilteringMappedClrMethods_6_11()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim books = dataContext.GetTable(Of Book)()
      Dim query = _
              From book In books _
              Where book.Title.Contains("on") _
              Select book.Title

      ObjectDumper.Write(query)
    End Sub

    ''' <summary>
    ''' Listing 6.11a: Using unmapped CLR methods
    ''' </summary>
    <Sample(6, 11, "6-11a: Filtering using Unmapped CLR methods")> _
    Public Sub FilteringUnmappedClrMethods_6_11a()
      Console.WriteLine("This example will intentionally fail because we are trying to use unmapped CLR methods")

      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim books = dataContext.GetTable(Of Book)()
      Dim query = From book In books _
                  Where book.PubDate >= DateTime.Parse("1/1/2007") _
                  Select book.PubDate.Value.ToString("MM/dd/yyyy")

      ObjectDumper.Write(query)

    End Sub
    ''' <summary>
    ''' Listing 6.12: Sorting with LINQ to SQL
    ''' </summary>
    <Sample(6, 12, "6-12: Sorting with LINQ to SQL")> _
    Public Sub Sorting_6_12()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim books = dataContext.GetTable(Of Book)()
      Dim query = _
              From book In books _
              Where book.Price < 30 _
              Order By book.Title _
              Select book.Title

      ObjectDumper.Write(query)
    End Sub

    ''' <summary>
    ''' Listing 6.13: Grouping and Sorting with LINQ to SQL
    ''' </summary>
    <Sample(6, 13, "6-13: Grouping and Sorting")> _
    Public Sub Grouping_6_13()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim query = From _book In dataContext.GetTable(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Book)() _
                  Group By key = _book.SubjectId Into Group _
                  Select id = key, groupedBooks = Group

      For Each groupedBook In query
        Console.WriteLine("Subject: {0}", groupedBook.id)
        For Each _Book In groupedBook.groupedBooks
          Console.WriteLine("Book: {0}", _Book.Title)
        Next
      Next
    End Sub

    ''' <summary>
    ''' Listing 6.14: Including aggregates in the results
    ''' </summary>
    <Sample(6, 14, "6-14: Including aggregates in the results")> _
    Public Sub Aggregates_6_14()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)
      dataContext.Log = Console.Out
      Dim books As Table(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Book) = dataContext.GetTable(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Book)()

      Dim query = From book In books _
                  Group By key = book.SubjectId Into Group _
                  Select id = key, BookCount = Group.Count

      ObjectDumper.Write(query, 1)
    End Sub

    ''' <summary>
    ''' Listing 6.15: Using multiple aggregates
    ''' </summary>
    <Sample(6, 15, "6-15: Using multiple aggregates")> _
    Public Sub Aggregates_6_15()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim books As Table(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Book) = dataContext.GetTable(Of LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Book)()

      Dim query = From book In books _
                  Group By key = book.SubjectId Into Group _
                  Select id = key, _
                      BookCount = Group.Count, _
                      TotalPrice = Group.Sum(Function(_book) _book.Price), _
                      LowPrice = Group.Min(Function(_book) _book.Price), _
                      HighPrice = Group.Max(Function(_book) _book.Price), _
                      AveragePrice = Group.Average(Function(_book) _book.Price)

      ObjectDumper.Write(query, 1)
    End Sub

    ''' <summary>
    ''' Listing 6.16: Joining Books and Subjects
    ''' </summary>
    <Sample(6, 16, "6-16: Joining Books and Subjects")> _
    Public Sub Joining_6_16()

      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim subjects = dataContext.GetTable(Of Subject)()
      Dim books = dataContext.GetTable(Of Book)()
      Dim query = _
              From subject In subjects _
              From book In books _
              Where subject.SubjectId = book.SubjectId _
              Select subject.Name, book.Title, book.Price

      ObjectDumper.Write(query)
    End Sub

    ''' <summary>
    ''' Listing 6.17: Joining with the Join keyword
    ''' </summary>
    <Sample(6, 17, "6-17: Joining with the Join keyword")> _
    Public Sub Joining_6_17()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim subjects = dataContext.GetTable(Of Subject)()
      Dim books = dataContext.GetTable(Of Book)()

      Dim query = _
              From subject In subjects _
              Join book In books _
              On subject.SubjectId Equals book.SubjectId _
              Select subject.Name, book.Title, book.Price

      ObjectDumper.Write(query)
    End Sub

    ''' <summary>
    ''' Listing 6.18: Approximating an Outer Join
    ''' </summary>
    <Sample(6, 18, "6-18: Approximating an Outer Join")> _
    Public Sub Joining_6_18()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim books = dataContext.GetTable(Of Book)()
      Dim Subjects = dataContext.GetTable(Of Subject)()
      Dim query = _
              From subject In Subjects _
              Group Join book In books _
                 On subject.SubjectId Equals book.SubjectId Into joinedBooks = Group _
              From joinedBook In joinedBooks.DefaultIfEmpty() _
              Select subject.Name, joinedBook.Title, joinedBook.Price

      ObjectDumper.Write(query)
    End Sub

    <Sample(6, 19, "6-19: Rewriting the original example using LINQ to SQL")> _
    Public Sub OriginalRewritten_6_19()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim subjects As Table(Of Subject) = dataContext.GetTable(Of Subject)()
      Dim books As Table(Of Book) = dataContext.GetTable(Of Book)()

      Dim query = _
              From subject In subjects _
              Join book In books _
              On subject.SubjectId Equals book.SubjectId _
              Where book.Price < 30 _
              Order By subject.Name _
              Select subject.Name, book.Title, book.Price

      ObjectDumper.Write(query)
    End Sub

    ''' <summary>
    ''' Listing 6.21: Itering over object trees
    ''' </summary>
    <Sample(6, 21, "6-21: Iterating over object trees")> _
    Public Sub ObjectTrees_6_21()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      For Each _subject As Subject In dataContext.GetTable(Of Subject)()
        Console.WriteLine(_subject.Name)
        For Each _book As Book In _subject.Books

          Console.WriteLine("     {0}", _book.Title)
        Next
      Next
    End Sub

    ''' <summary>
    ''' Listing 6.22: Using Any to achieve an inner join on object trees
    ''' </summary>
    <Sample(6, 22, "6-22: Using Any to achieve an inner join on object trees")> _
    Public Sub ObjectTreesWithAny_6_22()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out
      Dim Subjects = dataContext.GetTable(Of Subject)()

      Dim query = From _subject In Subjects _
                  Where _subject.Books.Any() _
                  Select _subject

      ObjectDumper.Write(query, 1)
    End Sub

    ''' <summary>
    ''' Listing 6.22a: Using Not Any to find orphans
    ''' </summary>
    <Sample(6, 22, "6-22a: Using Not Any to find orphans")> _
    Public Sub ObjectOrphansWithAny_6_22a()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out
      Dim Subjects = dataContext.GetTable(Of Subject)()

      Dim query = From _subject In Subjects _
                  Where Not _subject.Books.Any() _
                  Select _subject

      ObjectDumper.Write(query, 1)
    End Sub

    ''' <summary>
    ''' Listing 6.23: Filtering child objects using All
    ''' </summary>
    <Sample(6, 23, "6-23: Filtering child objects using All")> _
    Public Sub ObjectTreesFilteringWithAll_6_23()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out
      Dim Subjects = dataContext.GetTable(Of Subject)()

      Dim query = From _Subject In Subjects _
                  Where _Subject.Books.All(Function(book As Book) CBool(book.Price < 30)) _
                  Select _Subject

      ObjectDumper.Write(query, 1)
    End Sub

    ''' <summary>
    ''' Running Query using object heirarchies 6.24
    ''' </summary>
    ''' <remarks></remarks>
    <Sample(6, 24, "6-24: Running query using object heirarchies")> _
    Public Sub OriginalRewrittenHeirarchical_6_24()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim subjects As Table(Of Subject) = dataContext.GetTable(Of Subject)()

      Dim query = _
              From subject In subjects _
              Order By subject.Name _
              Select subject.Name, _
              Books = From book In subject.Books _
                      Where book.Price < 30 _
                      Select book.Title, book.Price

      ObjectDumper.Write(query, 1)
    End Sub

    ''' <summary>
    ''' Lazy Loading Children 6.25
    ''' </summary>
    ''' <remarks></remarks>
    <Sample(6, 25, "6-25: Lazy loading child objects")> _
    Public Sub LazyLoadingChildren_6_25()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)
      dataContext.Log = Console.Out

      Dim subjects As Table(Of Subject) = dataContext.GetTable(Of Subject)()
      ObjectDumper.Write(subjects, 1)
    End Sub

    ''' <summary>
    ''' Listing 6.27: Using the DataLoadOptions to optimize object loading
    ''' </summary>
    <Sample(6, 27, "6-27: Using the DataLoadOptions to optimize object loading")> _
    Public Sub LoadOptions_6_27()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      dataContext.Log = Console.Out

      Dim options As New DataLoadOptions()
      options.LoadWith(Of Subject)(Function(subject As Subject) subject.Books)
      dataContext.LoadOptions = options

      Dim query = dataContext.GetTable(Of Subject)()

      ObjectDumper.Write(query, 1)
    End Sub

    ''' <summary>
    ''' Listing 6.28:	Updating values and committing them to the database
    ''' </summary>
    <Sample(6, 28, "6-28: Updating values and commiting them to the database")> _
    Public Sub Updating_6_28()

      Dim dataContext As New DataContext(My.Settings.liaConnectionString)

      Dim ExpensiveBooks = _
          From b In dataContext.GetTable(Of Book)() _
          Where b.Price > 30 _
          Select b

      For Each _book As Book In ExpensiveBooks
        _book.Price -= 5
      Next
      Console.WriteLine(DemoHelper.GetChangeText(dataContext))
    End Sub

    ''' <summary>
    '''  Listing 6.29:	Adding and removing items from a table
    ''' </summary>
    <Sample(6, 29, "6-29: Adding and removing items from a table")> _
    Public Sub Insert_6_29()
      Dim dataContext As New DataContext(My.Settings.liaConnectionString)
      Dim books As Table(Of Book) = dataContext.GetTable(Of Book)()

      Dim newBook As New Book()
      newBook.Price = 40
      newBook.PubDate = System.DateTime.Today
      newBook.Title = "LINQ In Action"
      newBook.PublisherId = New Guid("4ab0856e-51f3-4b67-9355-8b11510119ba")
      newBook.SubjectId = New Guid("a0e2a5d7-88c6-4dfe-a416-10eadb978b0b")

      books.InsertOnSubmit(newBook)

      Console.WriteLine(DemoHelper.GetChangeText(dataContext))

      'Now delete it
      books.DeleteOnSubmit(newBook)

      Console.WriteLine(DemoHelper.GetChangeText(dataContext))
    End Sub
  End Class
End Namespace