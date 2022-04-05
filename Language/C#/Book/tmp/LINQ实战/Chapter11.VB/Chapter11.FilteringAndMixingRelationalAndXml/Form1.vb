Imports System.Xml.Linq
Imports System.Data.Linq
Imports LinqInAction.LinqToSql
Imports AmazonCommon

Public Class Form1
  Dim ns As XNamespace = Amazon.AmazonNS
  Dim amazonXml As XElement

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    subjectComboBox.DataSource = New LinqInActionDataContext().Subjects.ToList()
  End Sub

  Private Sub searchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchButton.Click
    Dim signHelper = New SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com")

    Dim parameters = New Dictionary(Of String, String)()
    parameters("Service") = Amazon.ServiceName
    parameters("Version") = Amazon.ServiceVersion
    parameters("Operation") = "ItemSearch"
    parameters("SearchIndex") = "Books"
    parameters("ResponseGroup") = "Large"
    parameters("Keywords") = keywords.Text

    Dim requestUrl = signHelper.Sign(parameters)
    amazonXml = XElement.Load(requestUrl)

    Dim books = From result In amazonXml.Descendants(ns + "Item") _
    Let attributes = result.Element(ns + "ItemAttributes") _
    Select New Book With { _
    .Isbn = CType(attributes.Element(ns + "ISBN"), String), _
    .Title = CType(attributes.Element(ns + "Title"), String) _
    }

    bookBindingSource.DataSource = books

    Dim ctx As LinqInActionDataContext = New LinqInActionDataContext()
    Dim rows = From row In bookDataGridView.Rows.OfType(Of DataGridViewRow)() _
     Join book In ctx.Books On CType(row.DataBoundItem, Book).Isbn.Trim() Equals book.Isbn.Trim() _
     Select row

    Console.WriteLine(rows.Count())

    For Each row As DataGridViewRow In rows
      row.DefaultCellStyle.BackColor = Color.LightGray
      row.Cells(0).ReadOnly = True
      row.Cells(1).Value = "** Already Exists ** - " + row.Cells(1).Value
    Next
  End Sub

  Private Sub importButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles importButton.Click
    Dim selectedBooks = From row In bookDataGridView.Rows.OfType(Of DataGridViewRow)() _
     Where CType(row.Cells(0).EditedFormattedValue, Boolean) = True _
     Select CType(row.DataBoundItem, Book)

    Dim ctx As LinqInActionDataContext = New LinqInActionDataContext()

    Dim booksToImport = From amazonItem In amazonXml.Descendants(ns + "Item") _
     Join selectedBook In selectedBooks On CType(amazonItem.Element(ns + "ItemAttributes").Element(ns + "ISBN"), String).Trim() Equals selectedBook.Isbn.Trim() _
     Group Join publisher In ctx.Publishers On CType(amazonItem.Element(ns + "ItemAttributes").Element(ns + "Publisher"), String).Trim() Equals publisher.Name.Trim() Into Group _
     From existingPublisher In Group.DefaultIfEmpty() _
     Let attributes = amazonItem.Element(ns + "ItemAttributes") _
     Select New Book With { _
     .ID = Guid.NewGuid(), _
     .Isbn = CType(attributes.Element(ns + "ISBN"), String), _
     .Title = CType(attributes.Element(ns + "Title"), String), _
     .Subject = CType(subjectComboBox.SelectedItem, Subject), _
     .PubDate = CType(attributes.Element(ns + "PublicationDate"), Date), _
     .Price = ParsePrice(attributes.Element(ns + "ListPrice")), _
     .Publisher = If(existingPublisher IsNot Nothing, existingPublisher, New Publisher With { _
     .ID = Guid.NewGuid(), _
     .Name = CType(attributes.Element(ns + "Publisher"), String) _
     }), _
     .BookAuthors = GetAuthors(ctx, attributes.Elements(ns + "Author")) _
     }

    Dim attachedSubjects As HashSet(Of Subject) = New HashSet(Of Subject)
    Dim attachedPublisher As HashSet(Of Publisher) = New HashSet(Of Publisher)

    For Each book As Book In booksToImport
      ctx.Books.InsertOnSubmit(book)

      If attachedSubjects.Contains(book.Subject) = False Then
        ctx.Subjects.Attach(book.Subject)
        attachedSubjects.Add(book.Subject)
      End If
      If attachedPublisher.Contains(book.Publisher) = False Then
        ctx.Publishers.Contains(book.Publisher)
        attachedPublisher.Add(book.Publisher)
      End If
    Next

    Try
      ctx.SubmitChanges()
      MessageBox.Show(booksToImport.Count().ToString() + " books imported.")
    Catch ex As Exception
      MessageBox.Show("An error occured while attempting to import the selected books. " + Environment.NewLine + Environment.NewLine + ex.Message)
    End Try
  End Sub

  Function GetAuthors(ByVal ctx As LinqInActionDataContext, ByVal authorElements As IEnumerable(Of XElement)) As EntitySet(Of BookAuthor)
    Dim bookAuthors = From authorElement In authorElements _
     Group Join author In ctx.Authors On CType(authorElement, String).Trim() Equals author.FirstName + " " + author.LastName Into Group _
     From existingAuthor In Group.DefaultIfEmpty() _
     Let nameParts = CType(authorElement, String).Split(" ") _
     Select New BookAuthor With { _
     .ID = Guid.NewGuid(), _
     .Author = If(existingAuthor IsNot Nothing, existingAuthor, New Author With { _
     .ID = Guid.NewGuid(), _
     .FirstName = nameParts(0), _
     .LastName = nameParts(1) _
     }) _
     }

    Dim authorSet As EntitySet(Of BookAuthor) = New EntitySet(Of BookAuthor)
    authorSet.AddRange(bookAuthors)
    Return authorSet
  End Function

  Function ParsePrice(ByVal priceElement As XElement) As Decimal
    Return Convert.ToDecimal(CType(priceElement.Element(ns + "FormattedPrice"), String).Replace("$", String.Empty))
  End Function
End Class
