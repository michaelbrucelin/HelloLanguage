using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Data.Linq;
using AmazonCommon;
using LinqInAction.LinqToSql;

namespace Chapter11.WinForms {
  public partial class ImportForm : Form {

		LinqInActionDataContext ctx;
    XNamespace ns = Amazon.AmazonNS;
    XElement amazonXml;

    public ImportForm() {
      InitializeComponent();
      this.Load += new EventHandler(ImportForm_Load);
			ctx = new LinqInActionDataContext();
    }

    void ImportForm_Load(object sender, EventArgs e) {
      subjectComboBox.DataSource = ctx.Subjects.ToList();
    }

    void searchButton_Click(object sender, EventArgs e) {

      var signHelper = new SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com");

      var parameters = new Dictionary<String, String>() {
        { "Service", Amazon.ServiceName},
        { "Version", Amazon.ServiceVersion },
        { "Operation", "ItemSearch" },
        { "SearchIndex", "Books" },
        { "ResponseGroup", "Large" },
        { "Keywords", keywords.Text } 
      };

      string requestUrl = signHelper.Sign(parameters);
      amazonXml = XElement.Load(requestUrl);

      var books =
         from result in amazonXml.Descendants(ns + "Item")
					let attributes = result.Element(ns + "ItemAttributes")
					select new Book {
							Isbn=(string) attributes.Element(ns + "ISBN"), 
							Title=(string) attributes.Element(ns + "Title"),
					};

      bookBindingSource.DataSource = books;
    
      var rows =
        from row in bookDataGridView.Rows.OfType<DataGridViewRow>()
				let dataBoundBook =((Book) row.DataBoundItem)
			  join book in ctx.Books on dataBoundBook.Isbn equals book.Isbn.Trim()
				select row;

      foreach(DataGridViewRow row in rows) {
        row.DefaultCellStyle.BackColor = Color.LightGray;
        row.Cells[0].ReadOnly = true;
        row.Cells[1].Value = "** Already Exists ** - " + row.Cells[1].Value;
      }
    }

    void importButton_Click(object sender, EventArgs e) {
      var selectedBooks =
        from row in bookDataGridView.Rows.OfType<DataGridViewRow>()
				where ((bool) row.Cells[0].EditedFormattedValue) == true
				select (Book) row.DataBoundItem;

			using (var newContext = new LinqInActionDataContext()) {
				var booksToImport =
					from amazonItem in amazonXml.Descendants(ns + "Item")
					join selectedBook in selectedBooks
						on (string)amazonItem.Element(ns + "ItemAttributes").Element(ns + "ISBN")
							equals selectedBook.Isbn
					join p in newContext.Publishers
						on ((string)amazonItem.Element(ns + "ItemAttributes").Element(ns + "Publisher")).ToUpper()
							equals p.Name.Trim().ToUpper() into publishers
					from existingPublisher in publishers.DefaultIfEmpty()
					let attributes = amazonItem.Element(ns + "ItemAttributes")
					select new Book {
						ID = Guid.NewGuid(),
						Isbn = (string)attributes.Element(ns + "ISBN"),
						Title = (string)attributes.Element(ns + "Title"),
						Publisher = (existingPublisher ??
											 new Publisher {
												 ID = Guid.NewGuid(),
												 Name = (string)attributes.Element(ns + "Publisher")
											 }
						),
						Subject = (Subject)subjectComboBox.SelectedItem,
						PubDate = (DateTime)attributes.Element(ns + "PublicationDate"),
						Price = ParsePrice(attributes.Element(ns + "ListPrice")),
						BookAuthors = GetAuthors(attributes.Elements(ns + "Author"))
					};

				newContext.Subjects.Attach((Subject)subjectComboBox.SelectedItem);
				foreach (Book book in booksToImport) {
					newContext.Books.InsertOnSubmit(book);
				}

				try {
					newContext.SubmitChanges();
					MessageBox.Show(booksToImport.Count() + " books imported.");
				}
				catch (Exception ex) {
					MessageBox.Show("An error occured while attempting to import the selected books. " + Environment.NewLine + Environment.NewLine + ex.Message);
				}
			}
    }

    private EntitySet<BookAuthor> GetAuthors(IEnumerable<XElement> authorElements) {
      var bookAuthors =
        from authorElement in authorElements
        join author in ctx.Authors on (string) authorElement equals author.FirstName + " " + author.LastName into authors
        from existingAuthor in authors.DefaultIfEmpty()
        let nameParts = ((string)authorElement).Split(' ')
        select new BookAuthor {
          ID=Guid.NewGuid(),
          Author=existingAuthor ?? 
            new Author {
              ID=Guid.NewGuid(),
              FirstName=nameParts[0], 
              LastName=nameParts[1]
            }
        };

      EntitySet<BookAuthor> set = new EntitySet<BookAuthor>();
      set.AddRange(bookAuthors);
      return set;
    }

    private decimal ParsePrice(XElement priceElement) {
      return Convert.ToDecimal(((string)priceElement.Element(ns + "FormattedPrice")).Replace("$", String.Empty));
    }
  }
}