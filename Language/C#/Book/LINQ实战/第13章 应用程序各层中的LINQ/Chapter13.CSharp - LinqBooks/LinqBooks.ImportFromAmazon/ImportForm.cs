#region Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

using LinqBooks.Entities;
using AmazonCommon;

#endregion Imports
  
namespace LinqBooks.ImportFromAmazon
{
  public partial class ImportForm : Form
  {
    LinqBooksDataContext ctx = new LinqBooksDataContext(Properties.Settings.Default.liaConnectionString);
    XNamespace ns = Amazon.AmazonNS;
    XElement amazonXml;

    public ImportForm()
    {
      InitializeComponent();
      this.Load += new EventHandler(ImportForm_Load);
    }

    void ImportForm_Load(object sender, EventArgs e)
    {
      categoryComboBox.DataSource = ctx.Subjects.OrderBy(subject => subject.Name).ToList();
    }

    void searchButton_Click(object sender, EventArgs e)
    {
      Cursor oldCursor;

      oldCursor = Cursor.Current;
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        var signHelper = new SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com");
        var parameters = new Dictionary<String, String>() {
          { "Service", Amazon.ServiceName},
          { "Version", Amazon.ServiceVersion },
          { "Operation", "ItemSearch" },
          { "SearchIndex", "Books" },
          { "ResponseGroup", "Large" },
          { "Keywords", keywords.Text }
        };

        var url = signHelper.Sign(parameters);
        amazonXml = XElement.Load(url);

        var books = from result in amazonXml.Descendants(ns + "Item")
                    let attributes = result.Element(ns + "ItemAttributes")
                    select new Book
                           {
                             Isbn = (string)attributes.Element(ns + "ISBN"),
                             Title = (string)attributes.Element(ns + "Title"),
                           };

        bookBindingSource.DataSource = books;
      }
      finally
      {
        Cursor.Current = oldCursor;
      }
    }

    void importButton_Click(object sender, EventArgs e)
    {
      var selectedBooks =
        from row in bookDataGridView.Rows.OfType<DataGridViewRow>()
        where (bool)row.Cells[0].EditedFormattedValue
        select (Book)row.DataBoundItem;

      var booksToImport =
        from amazonItem in amazonXml.Descendants(ns + "Item")
        join selectedBook in selectedBooks
          on (string)amazonItem.Element(ns + "ItemAttributes").Element(ns + "ISBN")
          equals selectedBook.Isbn
        join p in ctx.Publishers
          on (string)amazonItem.Element(ns + "ItemAttributes").Element(ns + "Publisher")
          equals p.Name
          into publishers
        from existingPublisher in publishers.DefaultIfEmpty()
        let attributes = amazonItem.Element(ns + "ItemAttributes")
        select new Book
               {
                 ID = Guid.NewGuid(),
                 Isbn = (string)attributes.Element(ns + "ISBN"),
                 Title = (string)attributes.Element(ns + "Title"),
                 PublisherObject = (existingPublisher ??
                            new Publisher
                            {
                              ID = Guid.NewGuid(),
                              Name = (string)attributes.Element(ns + "Publisher")
                            }
                 ),
                 SubjectObject = (Subject)categoryComboBox.SelectedItem,
                 PubDate = (DateTime)attributes.Element(ns + "PublicationDate"),
                 Price = ParsePrice(attributes.Element(ns + "ListPrice")),
                 BookAuthors = GetAuthors(attributes.Elements(ns + "Author"))
               };

      foreach (Book book in booksToImport)
      {
        ctx.Books.InsertOnSubmit(book);
      }

      try
      {
        ctx.SubmitChanges();
        MessageBox.Show(booksToImport.Count() + " books imported.");
      }
      catch (Exception ex)
      {
        MessageBox.Show("An error occured while attempting to import the selected " +
          "books. " + Environment.NewLine + Environment.NewLine + ex.Message);
      }
    }

    private EntitySet<BookAuthor> GetAuthors(IEnumerable<XElement> authorElements)
    {
      var bookAuthors =
        from authorElement in authorElements
        join a in ctx.Authors on (string)authorElement equals a.FirstName + " " +
            a.LastName into authors
        from existingAuthor in authors.DefaultIfEmpty()
        let nameParts = ((string)authorElement).Split(' ')
        select new BookAuthor
               {
                 AuthorObject = existingAuthor ??
                 new Author
                 {
                   ID = Guid.NewGuid(),
                   FirstName = nameParts[0],
                   LastName = nameParts[1]
                 }
               };

      EntitySet<BookAuthor> set = new EntitySet<BookAuthor>();
      set.AddRange(bookAuthors);
      return set;
    }

    private decimal ParsePrice(XElement priceElement)
    {
      return Convert.ToDecimal(((string)priceElement.Element(ns +
               "FormattedPrice")).Replace("$", String.Empty));
    }
  }
}