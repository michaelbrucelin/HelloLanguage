Imports System.Xml.Linq
Imports System.Data.Linq
Imports LinqInAction.LinqToSql
Imports AmazonCommon

Module Module1
  Sub Main()

    Dim signHelper = New SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com")
    Dim parameters = New Dictionary(Of String, String)()
    parameters("Service") = Amazon.ServiceName
    parameters("Version") = Amazon.ServiceVersion
    parameters("Operation") = "ItemLookup"
    parameters("ItemId") = "0735621632"
    parameters("ResponseGroup") = "Reviews"
    Dim requestUrl = signHelper.Sign(parameters)

    Dim ns As XNamespace = Amazon.AmazonNS
    Dim ctx As LinqInActionDataContext = New LinqInActionDataContext()

    Dim amazonReviews As XElement = XElement.Load(requestUrl)

    Dim results = From bookElement In amazonReviews.Element(ns + "Items").Elements(ns + "Item") _
    Join book In ctx.Books On CType(bookElement.Element(ns + "ASIN"), String) Equals book.Isbn.Trim() _
    Select New With { _
     .Title = book.Title, _
     .Reviews = _
     From reviewElement In bookElement.Descendants(ns + "Review") _
     Order By CType(reviewElement.Element(ns + "Rating"), Integer) Descending _
     Select New Review With { _
     .Rating = CType(reviewElement.Element(ns + "Rating"), Integer), _
     .Comments = CType(reviewElement.Element(ns + "Content"), String) _
     } _
     }

    Dim seperator As String = "--------------------------"
    For Each item In results
      Console.WriteLine("Book: " + item.Title)
      For Each review In item.Reviews
        Console.WriteLine(seperator + "\r\nRating: " + review.Rating + "\r\n" + seperator + "\r\n" + review.Comments)
      Next
    Next
  End Sub

End Module
