#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

#endregion Imports

namespace LinqInAction.Chapter14
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    #region Data loading

    #region Untyped DataSet

    private static void FillDataSetUsingDataAdapter(DataSet dataSet)
    {
      // Create the DataAdapter
      var dataAdapter = new SqlDataAdapter(
        @"SELECT ID, Name
          FROM Publisher
          ;          
          SELECT ID, Title, Subject, Publisher, Price
          FROM Book
          WHERE DATEPART(YEAR, PubDate) > 1950",
        Properties.Settings.Default.LinqBooksConnectionString);

      // Map the results to tables in the DataSet
      dataAdapter.TableMappings.Add("Table", "Publisher");
      dataAdapter.TableMappings.Add("Table1", "Book");

      // Execute the SQL queries and load the data into the DataSet
      dataAdapter.Fill(dataSet);
    }

    // This method is the most direct, but it requires creating the DataTables by hand.
    private static void FillDataSetUsingLinqToSql1(DataSet dataSet)
    {
      DataTable table;

      // Prepare the LINQ to SQL DataContext
      var linqBooks = new LinqBooks(Properties.Settings.Default.LinqBooksConnectionString);

      // Query the Publisher table
      var publisherQuery =
        from publisher in linqBooks.Publisher
        select new { publisher.ID, publisher.Name };
      // Query the Book table
      var bookQuery =
        from book in linqBooks.Book
        where book.PubDate.Value.Year > 1950
        select new
        {
          book.ID, book.Title, book.Subject, book.Publisher,
          Price = book.Price.HasValue ? book.Price.Value : 0
        };

      // Prepare the Publisher DataTable
      table = new DataTable();
      table.Columns.Add("ID", typeof(Guid));
      table.Columns.Add("Name", typeof(String));
      // Load data into the Publisher DataTable
      foreach (var publisher in publisherQuery)
        table.LoadDataRow(new Object[] { publisher.ID, publisher.Name }, true);
      dataSet.Tables.Add(table);

      // Prepare the Book DataTable
      table = new DataTable();
      table.Columns.Add("ID", typeof(Guid));
      table.Columns.Add("Title", typeof(String));
      table.Columns.Add("Subject", typeof(Guid));
      table.Columns.Add("Publisher", typeof(Guid));
      table.Columns.Add("Price", typeof(Decimal));
      // Load data into the Book DataTable
      foreach (var book in bookQuery)
        table.LoadDataRow(new Object[] { book.ID, book.Title, book.Subject, book.Publisher, book.Price }, true);
      // Add the Book DataTable
      dataSet.Tables.Add(table);
    }

    // This method uses the ToDataTable query operator to automatically create the DataTables.
    private static void FillDataSetUsingLinqToSql2(DataSet dataSet)
    {
      // Prepare the LINQ to SQL DataContext
      var linqBooks = new LinqBooks(Properties.Settings.Default.LinqBooksConnectionString);

      // Query the Publisher table
      var publisherQuery =
        from publisher in linqBooks.Publisher
        select new { publisher.ID, publisher.Name };
      // Query the Book table
      var bookQuery =
        from book in linqBooks.Book
        where book.PubDate.Value.Year > 1950
        select new {
          book.ID, book.Title, book.Subject, book.Publisher, book.PageCount,
          Price = book.Price.HasValue ? book.Price.Value : 0
        };

      // Execute the queries and load the data into the DataSet
      dataSet.Tables.Add(publisherQuery.ToDataTable());
      dataSet.Tables.Add(bookQuery.ToDataTable());
    }

    #endregion Untyped DataSet

    #region Typed DataSet

    // This method is the most direct, but it requires loading the DataTables by hand.
    private static void FillDataSetUsingLinqToSql1(LinqBooksDataSet dataSet)
    {
      // Prepare the LINQ to SQL DataContext
      var linqBooks = new LinqBooks(Properties.Settings.Default.LinqBooksConnectionString);

      // Query the Publisher table
      var publisherQuery =
        from publisher in linqBooks.Publisher
        select new { publisher.ID, publisher.Name };
      // Query the Book table
      var bookQuery =
        from book in linqBooks.Book
        where book.PubDate.Value.Year > 1950
        select book;

      // Execute the queries and load the data into the DataSet
      foreach (var publisher in publisherQuery)
      {
        dataSet.Publisher.AddPublisherRow(publisher.ID, publisher.Name, null, null);
      }
      foreach (var book in bookQuery)
      {
        dataSet.Book.AddBookRow(book.ID, book.Title, book.Subject,
          dataSet.Publisher.FindByID(book.Publisher),
          book.PubDate.Value, book.Price.HasValue ? book.Price.Value : 0,
          book.PageCount, book.Isbn, book.Summary, book.Notes);
      }
    }

    // This method uses the LoadSequence query operator to automatically create the DataTables.
    private static void FillDataSetUsingLinqToSql2(LinqBooksDataSet dataSet)
    {
      // Prepare the LINQ to SQL DataContext
      var linqBooks = new LinqBooks(Properties.Settings.Default.LinqBooksConnectionString);

      // Query the Publisher table
      var publisherQuery =
        from publisher in linqBooks.Publisher
        select new { publisher.ID, publisher.Name };
      // Query the Book table
      var bookQuery =
        from book in linqBooks.Book
        where book.PubDate.Value.Year > 1950
        select new {
          book.ID, book.Title, book.Subject, book.Publisher, book.PageCount,
          Price = book.Price.HasValue ? book.Price.Value : 0
        };

      // Execute the queries and load the data into the DataSet
      publisherQuery.LoadSequence(dataSet.Publisher, null);
      bookQuery.LoadSequence(dataSet.Book, null);
    }

    private static void FillDataSetUsingTableAdapters(LinqBooksDataSet dataSet)
    {
      new LinqBooksDataSetTableAdapters.PublisherTableAdapter().Fill(dataSet.Publisher);
      new LinqBooksDataSetTableAdapters.BookTableAdapter().Fill(dataSet.Book);
    }

    #endregion Typed DataSet

    #endregion Data loading

    #region Event handlers

    #region Loading

    private void btnTestLoading_Click(object sender, EventArgs e)
    {
      // Load the DataSet
      var dataSet = new DataSet();
      FillDataSetUsingDataAdapter(dataSet);

      Decimal? theValue = null;
      DataRow book = dataSet.Tables[1].Rows[0];
      book["Price"] = theValue == null ? DBNull.Value : (Object)theValue;
      book["Price"] = theValue ?? (Object)DBNull.Value;
      book.SetField<Decimal?>("Price", theValue);

      // Display the content of the DataSet
      dataGridView1.DataSource = dataSet.Tables[0];
      dataGridView2.DataSource = dataSet.Tables[1];
    }

    #endregion Loading

    #region Without LINQ

    private DataTable CreateDataTable(DataTable sourceTable, DataRow[] rows)
    {
      DataTable result;

      result = sourceTable.Clone();
      foreach (DataRow row in rows)
        result.Rows.Add(row.ItemArray);
      return result;
    }

    private void btnDataTableSelect_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      var dataSet = new DataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Retrieve subsets of rows from the tables
      DataRow[] publishers = dataSet.Tables[0].Select("LEN(Name) > 5");
      DataRow[] books = dataSet.Tables[1].Select("(Price > 15) AND (Title LIKE '*i*')", "Title DESC");
      // Display the results
      dataGridView1.DataSource = CreateDataTable(dataSet.Tables[0], publishers);
      dataGridView2.DataSource = CreateDataTable(dataSet.Tables[1], books);
    }

    private void btnDataViews_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      var dataSet = new DataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Create and display DataViews
      dataGridView1.DataSource = new DataView(dataSet.Tables[0],
        "LEN(Name) > 5", String.Empty, DataViewRowState.Unchanged);
      dataGridView2.DataSource = new DataView(dataSet.Tables[1],
        "(Price > 15) AND (Title LIKE '*i*')", "Title DESC", DataViewRowState.Unchanged);
    }

    private void btnDataViewsRelationships_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      var dataSet = new DataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Create a relation between a publisher and its books
      dataSet.Relations.Add("PublisherBooks",
        dataSet.Tables[0].Columns["ID"], dataSet.Tables[1].Columns["Publisher"]);

      // Create and display a DataView that filters publishers using a relation
      dataGridView1.DataSource = new DataView(dataSet.Tables[0],
        "COUNT(CHILD(PublisherBooks).Title) > 0", String.Empty, DataViewRowState.Unchanged);
    }

    #endregion Without LINQ

    #region Untyped DataSet

    private void btnUntypedSimple_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      var dataSet = new DataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Retrieve a DataTable from the DataSet
      DataTable bookTable = dataSet.Tables[1];

      // Query the DataTable
      var filteredBooks =
        from book in bookTable.AsEnumerable()
        where book.Field<String>("Title").StartsWith("L")
        select new
        {
          Title = book.Field<String>("Title"),
          Price = book.Field<Decimal?>("Price")
        };

      // Display the results
      dataGridView2.DataSource = filteredBooks.ToList();
    }

    private void btnUntypedJoin_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      var dataSet = new DataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Retrieve the DataTables from the DataSet
      DataTable publisherTable = dataSet.Tables[0];
      DataTable bookTable = dataSet.Tables[1];

      // Query the DataTables
      var publisherBooks =
        from publisher in publisherTable.AsEnumerable()
        join book in bookTable.AsEnumerable()
          on publisher.Field<Guid>("ID") equals book.Field<Guid>("Publisher")
        select new
        {
          Publisher = publisher.Field<String>("Name"),
          Book = book.Field<String>("Title")
        };

      // Display the results
      dataGridView1.DataSource = publisherBooks.ToList();
    }

    private void btnUntypedRelationship_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      var dataSet = new DataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Retrieve the DataTables from the DataSet
      DataTable publisherTable = dataSet.Tables[0];
      DataTable bookTable = dataSet.Tables[1];

      // Create a relationship between a publisher and its books
      dataSet.Relations.Add("PublisherBooks",
        publisherTable.Columns["ID"], bookTable.Columns["Publisher"]);

      // Query the DataTables
      var publisherBooks =
        from publisher in publisherTable.AsEnumerable()
        from book in publisher.GetChildRows("PublisherBooks")
        select new
        {
          Publisher = publisher.Field<String>("Name"),
          Book = book.Field<String>("Title")
        };

      // Display the results
      dataGridView1.DataSource = publisherBooks.ToList();
    }

    private void btnUntypedDataView_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      DataSet dataSet = new DataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Retrieve the DataTables from the DataSet
      DataTable bookTable = dataSet.Tables[1];

      // Query the DataTable
      var books =
        from book in bookTable.AsEnumerable()
        where book.Field<String>("Title").Length > 10
        orderby book.Field<String>("Title")
        select book;

      // Create a view on the query and bind it to the first DataGridView
      DataView view = books.AsDataView();
      dataGridView1.DataSource = view;

      // Bind the Book DataTable to the second DataGridView
      dataGridView2.DataSource = bookTable;

      // You can now sort the results in the grids and make changes in
      // the first one to see the updates reflected in the second,
      // as well as the filtering condition applied in the first grid.
    }

    #endregion Untyped DataSet

    #region Typed DataSet

    private void btnTypedSimple_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      LinqBooksDataSet dataSet = new LinqBooksDataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Query the DataTables
      var query =
        from book in dataSet.Book
        where book.Title.StartsWith("L")
        select new { book.Title, book.Price };

      // Display the results
      dataGridView2.DataSource = query.ToList();
    }

    private void btnTypedJoin_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      LinqBooksDataSet dataSet = new LinqBooksDataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Query the DataTables
      var query =
        from publisher in dataSet.Publisher
        join book in dataSet.Book
          on publisher.ID equals book.Publisher
        select new
        {
          Publisher = publisher.Name,
          Book = book.Title
        };

      // Display the results
      dataGridView1.DataSource = query.ToList();
    }

    private void btnTypedRelationship_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      LinqBooksDataSet dataSet = new LinqBooksDataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Query the DataTables
      var query =
        from publisher in dataSet.Publisher
        from book in publisher.GetBookRows()
        select new
        {
          Publisher = publisher.Name,
          Book = book.Title
        };

      // Display the results
      dataGridView1.DataSource = query.ToList();
    }

    private void btnTypedDataView_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      LinqBooksDataSet dataSet = new LinqBooksDataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Query a DataTable
      var books =
        from book in dataSet.Book.AsEnumerable()
        where book.Title.Length > 10
        orderby book.Title
        select book;

      // Create a view on the query and bind it to the first DataGridView
      DataView view = books.AsDataView();
      dataGridView1.DataSource = view;

      // Bind the Book DataTable to the second DataGridView
      dataGridView2.DataSource = dataSet.Book;

      // You can now sort the results in the grids and make changes in
      // the first one to see the updates reflected in the second,
      // as well as the filtering condition applied in the first grid.
    }

    #endregion Typed DataSet

    #region CopyToDataTable

    private LinqBooksDataSet _CopyToDataTableOriginalDataSet;

    private void btnCopyToDataTable_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      _CopyToDataTableOriginalDataSet = new LinqBooksDataSet();
      FillDataSetUsingLinqToSql2(_CopyToDataTableOriginalDataSet);
      _CopyToDataTableOriginalDataSet.AcceptChanges();

      // Query the Book DataTable
      var books = 
        from book in _CopyToDataTableOriginalDataSet.Book
        where book.Title.Contains("a")
        orderby book.Title
        select book;

      // Display the results
      dataGridView2.DataSource = books.CopyToDataTable();

      // Now that the results of the query are databound to a DataGridView, they can be edited.
      // Once this is done, the updated data can be merged back into the original DataSet.
      btnShowChanges.Enabled = true;
    }

    private void btnShowChanges_Click(object sender, EventArgs e)
    {
      // Merged back the updated data into the original DataSet
      DataTable dataTable = (DataTable)dataGridView2.DataSource;
      _CopyToDataTableOriginalDataSet.Book.Merge(dataTable);

      // Finally, you can update the database using the Update method of a DataAdapter,
      // or simply deal with the changes in any other way.
      // Here we look at the changes that have been performed.

      DataTable changesTable = _CopyToDataTableOriginalDataSet.Book.GetChanges();
      if (changesTable == null || changesTable.Rows.Count < 1)
      {
        MessageBox.Show("No changes"); 
        dataGridView1.DataSource = null;
      }
      else
      {
        var changes =
          from change in changesTable.AsEnumerable()
          select new {
            State = change.RowState,
            OriginalTitle = change.Field<String>("Title", DataRowVersion.Original),
            NewTitle = change.RowState != DataRowState.Deleted ?
              change.Field<String>("Title", DataRowVersion.Current) : String.Empty
          };

        dataGridView1.DataSource = changes.ToList();
      }
    }

    #endregion CopyToDataTable

    #region DataRowComparer and set query operators

    private void btnIntersect_Click(object sender, EventArgs e)
    {
      // Load a DataSet
      LinqBooksDataSet dataSet = new LinqBooksDataSet();
      FillDataSetUsingLinqToSql2(dataSet);

      // Create two tables
      var query1 =
        from book in dataSet.Book.AsEnumerable()
        where book.Price < 30
        select book;
      var query2 =
        from book in dataSet.Book.AsEnumerable()
        where book.PageCount > 100
        select book;
      var books1 = new LinqBooksDataSet.BookDataTable();
      query1.CopyToDataTable(books1, LoadOption.PreserveChanges);
      var books2 = new LinqBooksDataSet.BookDataTable();
      query2.CopyToDataTable(books2, LoadOption.PreserveChanges);

      // Find the intersection of the two tables
      IEqualityComparer<LinqBooksDataSet.BookRow> comparer =
        new DataRowComparer<LinqBooksDataSet.BookRow>();
      var books = books1.AsEnumerable()
        .Intersect(books2.AsEnumerable(), comparer)
        .Select(book => new { book.Title, book.Price, book.PageCount });

      // Display the results:
      //   the books costing less than 30 that have more than 100 pages
      dataGridView2.DataSource = books.ToList();
    }

    // Generic DataRow comparer that works with typed DataSets
    // .NET 3.5 should include a similar class post Beta 2
    public class DataRowComparer<TDataRow> : IEqualityComparer<TDataRow>
      where TDataRow : DataRow
    {
      #region IEqualityComparer<TDataRow> Members

      public bool Equals(TDataRow x, TDataRow y)
      {
        return DataRowComparer.Default.Equals(x, y);
      }

      public int GetHashCode(TDataRow obj)
      {
        return DataRowComparer.Default.GetHashCode(obj);
      }

      #endregion
    }

    #endregion DataRowComparer and set query operators
  
    #endregion Event handlers
  }
}