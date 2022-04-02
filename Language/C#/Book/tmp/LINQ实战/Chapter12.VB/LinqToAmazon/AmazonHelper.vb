Imports System.Web
Imports System.Globalization
Imports AmazonCommon

NotInheritable Class AmazonHelper
  Private Sub New()
  End Sub

  Friend Shared Function BuildUrl(ByVal criteria As AmazonBookQueryCriteria) As String
    If criteria Is Nothing Then
      Throw New ArgumentNullException("criteria")
    End If

    Dim signHelper = New SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com")
    Dim parameters = New Dictionary(Of String, String)()
    parameters("Service") = Amazon.ServiceName
    parameters("Version") = Amazon.ServiceVersion
    parameters("Operation") = "ItemSearch"
    parameters("SearchIndex") = "Books"
    parameters("ResponseGroup") = "Medium"

    If Not [String].IsNullOrEmpty(criteria.Title) Then
      parameters("Title") = criteria.Title
    End If
    If Not [String].IsNullOrEmpty(criteria.Publisher) Then
      parameters("Publisher") = criteria.Publisher
    End If
    If criteria.Condition.HasValue Then
      parameters("Condition") = criteria.Condition.ToString()
    End If
    If criteria.MaximumPrice.HasValue Then
      parameters("MaximumPrice") = (criteria.MaximumPrice * 100).Value.ToString(CultureInfo.InvariantCulture)
    End If

    Dim url = signHelper.Sign(parameters)
    Return url
  End Function

  Friend Shared Function PerformWebQuery(ByVal url As String) As IEnumerable(Of AmazonBook)
    ' Execute query
    Dim booksDoc As XElement = XElement.Load(url)

    ' Parse results
    Dim ns As XNamespace = Amazon.AmazonNS
    Dim books As IEnumerable(Of AmazonBook) = _
      From book In booksDoc.Descendants(ns + "Item") _
      Let attributes = book.Element(ns + "ItemAttributes") _
      Let price = attributes.Element(ns + "ListPrice").Element(ns + "Amount").Value _
      Let isbn = attributes.Element(ns + "ISBN") _
      Let asin = book.Element(ns + "ASIN") _
      Select New AmazonBook With _
           { _
             .Title = attributes.Element(ns + "Title").Value, _
             .Isbn = If(Not isbn Is Nothing, isbn.Value, asin.Value), _
             .PageCount = UInt32.Parse(attributes.Element(ns + "NumberOfPages").Value), _
             .Price = If(Not price Is Nothing, Decimal.Parse(price) / 100, 0), _
             .Publisher = attributes.Element(ns + "Publisher").Value, _
             .Year = UInt32.Parse(CType(attributes.Element(ns + "PublicationDate").Value, String).Substring(0, 4)), _
             .Authors = ( _
                From author In book.Descendants(ns + "Author") _
                Select CType(author.Value, String) _
              ).ToList() _
           }

    Return books
  End Function
End Class