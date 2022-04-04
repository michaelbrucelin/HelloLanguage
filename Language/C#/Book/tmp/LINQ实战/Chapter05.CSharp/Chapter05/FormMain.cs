#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

using LinqInAction.LinqBooks.Common;

#endregion Imports

namespace LinqInAction.Chapter05
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            cbxSortOrder.SelectedIndex = 0;
            cbxSortOrder.SelectedIndex = 0;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Title", HeaderText = "Title" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "PageCount", HeaderText = "Pages" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Publisher", HeaderText = "Publisher" });
        }

        #region Non-generic collections

        /// <summary>
        /// Simulates code that prepares an ArrayList containing Book objects
        /// </summary>
        private ArrayList GetArrayList()
        {
            return new ArrayList(SampleData.Books);
        }

        private void btnQueryArrayListWithExplicitCast_Click(object sender, EventArgs e)
        {
            ArrayList books = GetArrayList();

            var query = from book in books.Cast<Book>()
                        where book.PageCount > 150
                        select new { book.Title, book.Publisher.Name };

            dataGridView2.DataSource = query.ToList();
        }

        private void btnQueryArrayListWithImplicitCast_Click(object sender, EventArgs e)
        {
            ArrayList books = GetArrayList();

            var query = from Book book in books
                        where book.PageCount > 150
                        select new { book.Title, book.Publisher.Name };

            dataGridView2.DataSource = query.ToList();
        }

        #endregion Non-generic collections

        #region Grouping

        private void btnGrouping1_Click(object sender, EventArgs e)
        {
            // Groups books by publisher and subject

            var query = from book in SampleData.Books
                        group book by new { book.Publisher, book.Subject } into grouping
                        select new
                        {
                            Publisher = grouping.Key.Publisher.Name,
                            Subject = grouping.Key.Subject.Name,
                            Books = grouping
                        };

            using (var writer = new StringWriter())
            {
                ObjectDumper.Write(query, 1, writer);
                txtGroupingResults.Text = writer.ToString();
            }
        }

        private void btnGrouping2_Click(object sender, EventArgs e)
        {
            // Groups book titles by publisher and subject

            var query = from book in SampleData.Books
                        group book.Title by new { book.Publisher, book.Subject } into grouping
                        select new
                        {
                            Publisher = grouping.Key.Publisher.Name,
                            Subject = grouping.Key.Subject.Name,
                            Titles = grouping
                        };

            using (var writer = new StringWriter())
            {
                ObjectDumper.Write(query, 1, writer);
                txtGroupingResults.Text = writer.ToString();
            }
        }

        private void btnGrouping3_Click(object sender, EventArgs e)
        {
            // Groups books by subject and returns the title and publisher of each book

            var query = from book in SampleData.Books
                        group new { book.Title, book.Publisher.Name } by book.Subject into grouping
                        select new { Subject = grouping.Key.Name, Books = grouping };

            using (var writer = new StringWriter())
            {
                ObjectDumper.Write(query, 1, writer);
                txtGroupingResults.Text = writer.ToString();
            }
        }

        #endregion Grouping

        #region Dynamic queries

        private void ChangingVariable()
        {
            int minPageCount = 0;

            var books = from book in SampleData.Books
                        where book.PageCount >= minPageCount
                        select book;

            minPageCount = 200;
            MessageBox.Show(String.Format("Books with at least {0} pages: {1}", minPageCount, books.Count()));
            minPageCount = 50;
            MessageBox.Show(String.Format("Books with at least {0} pages: {1}", minPageCount, books.Count()));
        }

        private void ParameterizedQuery(int minPageCount)
        {
            var books = from book in SampleData.Books
                        where book.PageCount >= minPageCount
                        select book;

            MessageBox.Show(String.Format("Books with at least {0} pages: {1}", minPageCount, books.Count()));
        }

        private void CustomSort<TKey>(Func<Book, TKey> selector)
        {
            // Method syntax (explicit dot notation)
            // var books = SampleData.Books.OrderBy(selector);
            // dataGridView1.DataSource = books.ToList();

            // Query expression
            var books = from book in SampleData.Books
                        orderby selector(book)
                        select book;
            dataGridView1.DataSource = books.ToList();
        }

        private void CustomSort<TKey>(Func<Book, TKey> selector, Boolean ascending)
        {
            IEnumerable<Book> books = SampleData.Books;
            books = ascending ? books.OrderBy(selector) : books.OrderByDescending(selector);
            dataGridView1.DataSource = books.ToList();
        }

        private void btnChangingVariable_Click(object sender, EventArgs e)
        {
            ChangingVariable();
        }

        private void btnParameterizedQuery_Click(object sender, EventArgs e)
        {
            ParameterizedQuery(200);
            ParameterizedQuery(50);
        }

        private void btnCustomSort_Click(object sender, EventArgs e)
        {
            switch (cbxSortOrder.SelectedIndex)
            {
                case 0:
                    CustomSort(book => book.Title);
                    break;
                case 1:
                    CustomSort(book => book.Title, false);
                    break;
                case 2:
                    CustomSort(book => book.Publisher.Name);
                    break;
                case 3:
                    CustomSort(book => book.PageCount);
                    break;
            }
        }

        private void btnConditionalQuery_Click(object sender, EventArgs e)
        {
            using (var form = new FormConditionalQuery())
            {
                form.ShowDialog();
            }
        }

        private void btnDynamicQueryExpressionTree_Click(object sender, EventArgs e)
        {
            //The code below dynamically creates a query at run-time that is equivalent to the following query:
            //var query =
            //  from book in SampleData.Books
            //  where (book.Title != "Funny Stories") && (book.PageCount > 100)
            //  select book;

            // define the book variable
            var book = Expression.Parameter(typeof(Book), "book");
            // book.Title != "Funny Stories"
            var titleExpression = Expression.NotEqual(Expression.Property(book, "Title"), Expression.Constant("Funny Stories"));
            // book.PageCount > 100
            var pageCountExpression = Expression.GreaterThan(Expression.Property(book, "PageCount"), Expression.Constant(100));
            // and
            var andExpression = Expression.And(titleExpression, pageCountExpression);
            // create the where clause
            var predicate = Expression.Lambda(andExpression, book);
            var query = Enumerable.Where(SampleData.Books, (Func<Book, Boolean>)predicate.Compile());

            dataGridView1.DataSource = query.ToList();
        }

        #endregion Dynamic queries

        #region LINQ to Text Files

        private void btnLinqtoTextFiles_Click(object sender, EventArgs e)
        {
            var books = from line in File.ReadAllLines("books.csv")
                        where !line.StartsWith("#")
                        let parts = line.Split(',')
                        select new { Isbn = parts[0], Title = parts[1], Publisher = parts[3] };

            using (var writer = new StringWriter())
            {
                ObjectDumper.Write(books, 1, writer);
                txtLinqToTextFilesResults.Text = writer.ToString();
            }
        }

        #endregion LINQ to Text Files

        #region Design Patterns

        private void btnFunctionalConstructionAnonymous_Click(object sender, EventArgs e)
        {
            var books = from line in File.ReadAllLines("books.csv")
                        where !line.StartsWith("#")
                        let parts = line.Split(',')
                        select new
                        {
                            Isbn = parts[0],
                            Title = parts[1],
                            Publisher = parts[3],
                            Authors = from authorFullName in parts[2].Split(';')
                                      let authorNameParts = authorFullName.Split(' ')
                                      select new
                                      {
                                          FirstName = authorNameParts[0],
                                          LastName = authorNameParts[1]
                                      }
                        };

            using (var writer = new StringWriter())
            {
                ObjectDumper.Write(books, 1, writer);
                txtDesignPatternsResults.Text = writer.ToString();
            }
        }

        private void btnFunctionalConstruction_Click(object sender, EventArgs e)
        {
            var books = from line in File.ReadAllLines("books.csv")
                        where !line.StartsWith("#")
                        let parts = line.Split(',')
                        select new Book
                        {
                            Isbn = parts[0],
                            Title = parts[1],
                            Publisher = new Publisher { Name = parts[3] },
                            Authors =
                            from authorFullName in parts[2].Split(';')
                            let authorNameParts = authorFullName.Split(' ')
                            select new Author
                            {
                                FirstName = authorNameParts[0],
                                LastName = authorNameParts[1]
                            }
                        };

            using (var writer = new StringWriter())
            {
                ObjectDumper.Write(books, 1, writer);
                txtDesignPatternsResults.Text = writer.ToString();
            }
        }

        private void btnForEach_Click(object sender, EventArgs e)
        {
            // explicit dot notation
            SampleData.Books
                .Where(book => book.PageCount > 150)
                .ForEach(book => txtDesignPatternsResults.AppendText(book.Title + Environment.NewLine));

            txtDesignPatternsResults.AppendText(Environment.NewLine);

            // query expression
            (from book in SampleData.Books
             where book.PageCount > 150
             select book)
                .ForEach(book => txtDesignPatternsResults.AppendText(book.Title + Environment.NewLine));

            txtDesignPatternsResults.AppendText(Environment.NewLine);

            // statement body
            SampleData.Books
                .Where(book => book.PageCount > 150)
                .ForEach(book =>
                {
                    MessageBox.Show(book.Title);
                    txtDesignPatternsResults.AppendText(book.Title + Environment.NewLine);
                });

            txtDesignPatternsResults.AppendText(Environment.NewLine);

            // statement body with update
            SampleData.Books
                .Where(book => book.PageCount > 150)
                .ForEach(book =>
                {
                    book.Title += " (long)";
                    MessageBox.Show(book.Title);
                });
        }

        #endregion Design Patterns

        #region Performance

        #region Utility methods

        private List<Book> GetBooksForPerformance()
        {
            // Seed 123 will return 499357 results for PageCount > 500
            var rndBooks = new Random(123);
            var rndPublishers = new Random(123);
            var publisherCount = SampleData.Publishers.Count();

            var result = new List<Book>();
            for (int i = 0; i < 1000000; i++)
            {
                var publisher = SampleData.Publishers.Skip(rndPublishers.Next(publisherCount)).First();
                var pageCount = rndBooks.Next(1000);
                result.Add(new Book
                {
                    Title = pageCount.ToString(),
                    PageCount = pageCount,
                    Publisher = publisher
                });
            }

            return result;
        }

        private void Run(int times, MethodInvoker prepareFunc, MethodInvoker executeFunc, TextBox textBox)
        {
            Cursor oldCursor;

            oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var runs = new List<long>(times);

                if (prepareFunc != null)
                    prepareFunc();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                var stopwatch = new Stopwatch();
                for (int i = 0; i < times; i++)
                {
                    stopwatch.Start();
                    executeFunc();
                    stopwatch.Stop();
                    runs.Add(stopwatch.ElapsedMilliseconds);
                    stopwatch.Reset();
                }

                textBox.AppendText(String.Format("Avg: {0:000}; Min: {1:000}; Max: {2:000}; Runs: {3}{4}",
                    runs.Average(), runs.Min(), runs.Max(), times, Environment.NewLine));
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #endregion Utility methods

        #region Immediate complete iteration

        private void btnImmediateCompleteIteration_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("books.csv"))
            {
                var books = from line in reader.Lines().Reverse()
                            where !line.StartsWith("#")
                            let parts = line.Split(',')
                            select new { Isbn = parts[0], Title = parts[1], Publisher = parts[3] };

                using (var writer = new StringWriter())
                {
                    // This is where the processing happens
                    ObjectDumper.Write(books, 1, writer);
                    txtImmediateCompleteIterationResults.Text = writer.ToString();
                }
            }
        }

        #endregion Immediate complete iteration

        #region MaxElement

        private void btnMaxElementWithoutLinq_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            Run((int)updMaxElementsRuns.Value,
                null,
                delegate
                {
                    Book maxBook = null;

                    foreach (var book in books)
                    {
                        if ((maxBook == null) || (book.PageCount > maxBook.PageCount))
                            maxBook = book;
                    }
                },
                txtMaxElementResults
            );
        }

        private void btnMaxElementOrderbyAndFirst_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            Run((int)updMaxElementsRuns.Value,
                null,
                delegate
                {
                    var sortedList = from book in books
                                     orderby book.PageCount descending
                                     select book;
                    var maxBook = sortedList.First();
                },
                txtMaxElementResults
            );
        }

        private void btnMaxElementSubquery_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            Run((int)updMaxElementsRuns.Value,
                null,
                delegate
                {
                    var maxList = from book in books
                                  where book.PageCount == books.Max(b => b.PageCount)
                                  select book;
                    var maxBook = maxList.First();
                },
                txtMaxElementResults
            );
        }

        private void btnMaxElementTwoQueries_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            Run((int)updMaxElementsRuns.Value,
                null,
                delegate
                {
                    var maxPageCount = books.Max(book => book.PageCount);
                    var maxList = from book in books
                                  where book.PageCount == maxPageCount
                                  select book;
                    var maxBook = maxList.First();
                },
                txtMaxElementResults
            );
        }

        private void btnMaxElementCustomOperator_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            Run((int)updMaxElementsRuns.Value,
                null,
                delegate
                {
                    var maxBook = books.MaxElement(book => book.PageCount);
                },
                txtMaxElementResults
            );
        }

        #endregion MaxElement

        #region LINQ's overhead

        #region foreach

        private void btnPerformanceForEach_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            if (rdbFilterOnInt.Checked)
            {
                var results = new List<Book>(499357);
                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        foreach (var book in books)
                        {
                            if (book.PageCount > 500)
                                results.Add(book);
                        }
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbFilterOnString.Checked)
            {
                var results = new List<Book>(499357);
                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        foreach (var book in books)
                        {
                            if (book.Title.StartsWith("1"))
                                results.Add(book);
                        }
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbSort.Checked)
            {
                var results = new List<Book>(499357);
                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        foreach (var book in books)
                        {
                            if (book.PageCount > 500)
                                results.Add(book);
                        }
                        results.Sort((book1, book2) => book1.Title.CompareTo(book2.Title));
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbJoin.Checked)
            {
                var results = new List<Book>(499357);
                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        foreach (var publisher in SampleData.Publishers)
                            foreach (var book in books)
                            {
                                if ((book.Publisher == publisher) && (book.PageCount > 500))
                                    results.Add(book);
                            }
                    },
                    txtPerformanceResults
                );
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #endregion foreach

        #region for

        private void btnPerformanceFor_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            if (rdbFilterOnInt.Checked)
            {
                var results = new List<Book>(499357);
                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        for (int i = 0; i < books.Count; i++)
                        {
                            Book book = books[i];
                            if (book.PageCount > 500)
                                results.Add(book);
                        }
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbFilterOnString.Checked)
            {
                var results = new List<Book>(499357);
                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        for (int i = 0; i < books.Count; i++)
                        {
                            Book book = books[i];
                            if (book.Title.StartsWith("1"))
                                results.Add(book);
                        }
                    },
                    txtPerformanceResults
                );
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #endregion for

        #region List<T>.FindAll

        // Does not return titles
        // Does not pre-size the list
        private void btnPerformanceListFindAll_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            if (rdbFilterOnInt.Checked)
            {
                Run((int)updOverheadRuns.Value,
                    null,
                    delegate
                    {
                        var results = books.FindAll(book => book.PageCount > 500);
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbFilterOnString.Checked)
            {
                Run((int)updOverheadRuns.Value,
                    null,
                    delegate
                    {
                        var results = books.FindAll(book => book.Title.StartsWith("1"));
                    },
                    txtPerformanceResults
                );
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #endregion List<T>.FindAll

        #region List<T>.ForEach

        private void btnPerformanceListForEach_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            if (rdbFilterOnInt.Checked)
            {
                var results = new List<Book>(499357);
                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        books.ForEach(delegate (Book book)
                                      {
                                          if (book.PageCount > 500)
                                              results.Add(book);
                                      });
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbFilterOnString.Checked)
            {
                var results = new List<Book>(499357);
                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        books.ForEach(book =>
                                     {
                                         if (book.Title.StartsWith("1"))
                                             results.Add(book);
                                     });
                    },
                    txtPerformanceResults
                );
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #endregion List<T>.ForEach

        #region LINQ with ToList

        // Does not pre-size the list
        private void btnPerformanceToList_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            if (rdbFilterOnInt.Checked)
            {
                Run((int)updOverheadRuns.Value,
                    null,
                    delegate
                    {
                        var query = from book in books
                                    where book.PageCount > 500
                                    select book.Title;
                        query.ToList();
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbFilterOnString.Checked)
            {
                Run((int)updOverheadRuns.Value,
                    null,
                    delegate
                    {
                        var query = from book in books
                                    where book.Title.StartsWith("1")
                                    select book;
                        query.ToList();
                    },
                    txtPerformanceResults
                );
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #endregion LINQ with ToList

        #region LINQ with presized list

        private void btnPerformanceLinqPresized_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            if (rdbFilterOnInt.Checked)
            {
                var results = new List<Book>(499357);

                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        var query = from book in books
                                    where book.PageCount > 500
                                    select book;
                        foreach (var book in query)
                        {
                            results.Add(book);
                        }
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbFilterOnString.Checked)
            {
                var results = new List<Book>(499357);

                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        var query = from book in books
                                    where book.Title.StartsWith("1")
                                    select book;
                        foreach (var book in query)
                        {
                            results.Add(book);
                        }
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbSort.Checked)
            {
                var results = new List<Book>(499357);

                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        var query = from book in books
                                    where book.PageCount > 500
                                    orderby book.Title
                                    select book;
                        foreach (var book in query)
                        {
                            results.Add(book);
                        }
                    },
                    txtPerformanceResults
                );
            }
            else if (rdbJoin.Checked)
            {
                var results = new List<Book>(499357);

                Run((int)updOverheadRuns.Value,
                    delegate { results.Clear(); },
                    delegate
                    {
                        var query = from publisher in SampleData.Publishers
                                    join book in books on publisher equals book.Publisher
                                    where book.PageCount > 500
                                    select book;
                        foreach (var book in query)
                        {
                            results.Add(book);
                        }
                    },
                    txtPerformanceResults
                );
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #endregion LINQ with presized list

        #endregion LINQ's overhead

        #region LINQ to Text Files

        private void btnPerformanceLinqToTextFilesBad_Click(object sender, EventArgs e)
        {
            var books = from line in File.ReadAllLines("books.csv") // All content in memory!
                        where !line.StartsWith("#")
                        let parts = line.Split(',')
                        select new { Isbn = parts[0], Title = parts[1], Publisher = parts[3] };

            using (var writer = new StringWriter())
            {
                ObjectDumper.Write(books, 1, writer);
                txtLinqToTextFilesPerformanceResults.Text = writer.ToString();
            }
        }

        private void btnPerformanceLinqToTextFilesGood_Click(object sender, EventArgs e)
        {
            using (var reader = new StreamReader("books.csv"))
            {
                var books = from line in reader.Lines()
                            where !line.StartsWith("#")
                            let parts = line.Split(',')
                            select new { Isbn = parts[0], Title = parts[1], Publisher = parts[3] };

                using (var writer = new StringWriter())
                {
                    // This is where the processing happens
                    ObjectDumper.Write(books, 1, writer);
                    txtLinqToTextFilesPerformanceResults.Text = writer.ToString();
                }
            }
            // Warning, the reader should not be disposed while we are likely to enumerate the query!
            // Don't forget that deferred execution happens here
        }

        #endregion LINQ to Text Files

        #region Grouping

        private void btnGroupingWithoutLinq_Click(object sender, EventArgs e)
        {
            // Create book groups sorted by publisher name
            var results = new SortedDictionary<String, IList<Book>>();

            foreach (var book in SampleData.Books)
            {
                IList<Book> publisherBooks;

                if (!results.TryGetValue(book.Publisher.Name, out publisherBooks))
                {
                    publisherBooks = new List<Book>();
                    results[book.Publisher.Name] = publisherBooks;
                }
                publisherBooks.Add(book);
            }

            // Display
            using (var writer = new StringWriter())
            {
                foreach (var publisher in results)
                {
                    writer.WriteLine(publisher.Key);
                    foreach (var book in publisher.Value)
                        writer.WriteLine("\t" + book.Title);
                }
                txtPerformanceGroupingResults.Text = writer.ToString();
            }
        }

        private void btnGroupingWithLinq_Click(object sender, EventArgs e)
        {
            // Create book groups sorted by publisher name
            var results = from book in SampleData.Books
                          group book by book.Publisher.Name into publisherBooks
                          orderby publisherBooks.Key
                          select publisherBooks;

            // Display
            using (var writer = new StringWriter())
            {
                foreach (var publisher in results)
                {
                    writer.WriteLine(publisher.Key);
                    foreach (var book in publisher)
                        writer.WriteLine("\t" + book.Title);
                }
                txtPerformanceGroupingResults.Text = writer.ToString();
            }
        }

        private void btnGroupingWithoutLinqPerf_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();
            var results = new SortedDictionary<String, IList<Book>>();

            Run((int)updGroupingRuns.Value,
                delegate { results.Clear(); },
                delegate
                {
                    foreach (var book in books)
                    {
                        IList<Book> publisherBooks;

                        if (!results.TryGetValue(book.Publisher.Name, out publisherBooks))
                        {
                            publisherBooks = new List<Book>();
                            results[book.Publisher.Name] = publisherBooks;
                        }
                        publisherBooks.Add(book);
                    }
                },
                txtPerformanceGroupingResults
            );
        }

        private void btnGroupingWithLinqPerf_Click(object sender, EventArgs e)
        {
            var books = GetBooksForPerformance();

            Run((int)updGroupingRuns.Value,
                null,
                delegate
                {
                    var query = from book in books
                                group book by book.Publisher.Name into publisherBooks
                                orderby publisherBooks.Key
                                select publisherBooks;
                    var results = query.ToList();
                },
                txtPerformanceGroupingResults
            );
        }

        #endregion Grouping

        #endregion Performance
    }
}