Option Infer On

Imports System.Xml.Linq
Imports LinqInAction.LinqBooks.Common

Module Module1

	Sub Main()
		' load the XML document
		Dim booksXml As XElement = XElement.Load("books.xml")

		' build our objects using query expressions and object initializers
		Dim books = _
		 From bookElement In booksXml.Elements("book") _
		Select New Book With { _
		.Title = CType(bookElement.Element("title"), String), _
		.Publisher = New Publisher With {.Name = CType(bookElement.Element("publisher"), String)}, _
		.PublicationDate = CType(bookElement.Element("publicationDate"), DateTime), _
		.Price = CType(bookElement.Element("price"), Decimal), _
		.Isbn = CType(bookElement.Element("isbn"), String), _
		.Notes = CType(bookElement.Element("notes"), String), _
		.Summary = CType(bookElement.Element("summary"), String), _
		.Authors = GetAuthors(bookElement), _
		.Reviews = GetReviews(bookElement) _
		}

			' print out the results
		ObjectDumper.Write(books)
	End Sub

	Function GetAuthors(ByVal bookElement As XElement) As IEnumerable(Of Author)
		Return (From authorElement In bookElement.Descendants("author") _
		 Select New Author With {.FirstName = CType(authorElement.Element("firstName"), String), .LastName = CType(authorElement.Element("lastName"), String)}).ToList()
	End Function

	Function GetReviews(ByVal bookElement As XElement) As IEnumerable(Of Review)
		Return (From reviewElement In bookElement.Descendants("review") _
		Select New Review With { _
		.User = New User With { _
		.Name = CType(reviewElement.Element("user"), String) _
		}, _
		.Rating = CType(reviewElement.Element("rating"), Integer), _
		.Comments = CType(reviewElement.Element("comments"), String) _
		}).ToList()
	End Function
End Module
