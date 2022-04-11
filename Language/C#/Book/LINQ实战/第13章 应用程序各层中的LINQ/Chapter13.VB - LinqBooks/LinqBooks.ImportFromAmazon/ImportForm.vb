Imports System.Data.Linq
Imports LinqBooks.Entities
Imports AmazonCommon

Public Class ImportForm

  Dim ctx As LinqBooksDataContext = New LinqBooksDataContext(My.MySettings.Default.liaConnectionString)
  Dim ns As XNamespace = Amazon.AmazonNS
  Dim amazonXml As XElement

  Private Sub ImportForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    categoryComboBox.DataSource = ctx.Subjects.OrderBy(Function(subject) subject.Name).ToList()
  End Sub

  Private Sub searchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchButton.Click
    Dim oldCursor As Cursor

    oldCursor = Cursor.Current
    Cursor.Current = Cursors.WaitCursor
    Try
      Dim signHelper = New SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com")
      Dim parameters = New Dictionary(Of String, String)
      parameters("Service") = Amazon.ServiceName
      parameters("Version") = Amazon.ServiceVersion
      parameters("Operation") = "ItemSearch"
      parameters("SearchIndex") = "Books"
      parameters("ResponseGroup") = "Large"
      parameters("Keywords") = keywords.Text

      Dim url = signHelper.Sign(parameters)
      amazonXml = XElement.Load(url)

      Dim books = From result In amazonXml.Descendants(ns + "Item") _
                  Let attributes = result.Element(ns + "ItemAttributes") _
                  Select New Book With _
                         { _
                           .Isbn = CType(attributes.Element(ns + "ISBN"), String), _
                           .Title = CType(attributes.Element(ns + "Title"), String) _
                         }

      bookBindingSource.DataSource = books
    Finally
      Cursor.Current = oldCursor
    End Try

  End Sub

  Private Sub importButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles importButton.Click
    Dim selectedBooks = _
      From row In bookDataGridView.Rows.OfType(Of DataGridViewRow)() _
      Where CType(row.Cells(0).EditedFormattedValue, Boolean) _
      Select CType(row.DataBoundItem, Book)

    Dim booksToImport = _
      From amazonItem In amazonXml.Descendants(ns + "Item") _
        Join selectedBook In selectedBooks _
          On CType(amazonItem.Element(ns + "ItemAttributes").Element(ns + "ISBN"), String) Equals selectedBook.Isbn _
        Group Join p In ctx.Publishers _
          On CType(amazonItem.Element(ns + "ItemAttributes").Element(ns + "Publisher"), String) Equals p.Name Into publishers = Group _
        From existingPublisher In publishers.DefaultIfEmpty() _
        Let attributes = amazonItem.Element(ns + "ItemAttributes") _
        Select New Book With _
               { _
                 .ID = Guid.NewGuid(), _
                 .Isbn = CType(attributes.Element(ns + "ISBN"), String), _
                 .Title = CType(attributes.Element(ns + "Title"), String), _
                 .PublisherObject = If(Not existingPublisher Is Nothing, existingPublisher, _
                            New Publisher With _
                            { _
                              .ID = Guid.NewGuid(), _
                              .Name = CType(attributes.Element(ns + "Publisher"), String) _
                            } _
                 ), _
                 .SubjectObject = CType(categoryComboBox.SelectedItem, Subject), _
                 .PubDate = CType(attributes.Element(ns + "PublicationDate"), DateTime), _
                 .Price = ParsePrice(attributes.Element(ns + "ListPrice")), _
                 .BookAuthors = GetAuthors(attributes.Elements(ns + "Author")) _
               }

    For Each book In booksToImport
      ctx.Books.InsertOnSubmit(book)
    Next

    Try
      ctx.SubmitChanges()
      MsgBox(booksToImport.Count() & " books imported.")
    Catch ex As Exception
      MsgBox("An error occured while attempting to import the selected " & _
        "books. " & Environment.NewLine & Environment.NewLine & ex.Message)
    End Try
  End Sub

  Private Function GetAuthors(ByVal authorElements As IEnumerable(Of XElement)) As EntitySet(Of BookAuthor)
    Dim bookAuthors = _
      From authorElement In authorElements _
      Group Join a In ctx.Authors On CType(authorElement, String) Equals a.FirstName & " " & a.LastName Into authors = Group _
      From existingAuthor In authors.DefaultIfEmpty() _
      Let nameParts = CType(authorElement, String).Split(" ") _
      Select New BookAuthor With _
             { _
               .AuthorObject = If(Not existingAuthor Is Nothing, existingAuthor, _
                   New Author With _
                   { _
                     .ID = Guid.NewGuid(), _
                     .FirstName = nameParts(0), _
                     .LastName = nameParts(1) _
                   }) _
             }

    Dim result = New EntitySet(Of BookAuthor)()
    result.AddRange(bookAuthors)
    Return result
  End Function

  Private Function ParsePrice(ByVal priceElement As XElement) As Decimal
    Dim formattedPrice = CType(priceElement.Element(ns + "FormattedPrice"), String)
    Return Convert.ToDecimal(formattedPrice.Replace("$", String.Empty))
  End Function

End Class