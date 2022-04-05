#region Imports

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using AmazonCommon;

#endregion Imports

namespace LinqInAction.Chapter12.LinqToAmazon
{
  static class AmazonHelper
  {
    static internal String BuildUrl(AmazonBookQueryCriteria criteria)
    {
      if (criteria == null)
        throw new ArgumentNullException("criteria");

      var signHelper = new SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com");
      var parameters = new Dictionary<String, String>() {
        { "Service", Amazon.ServiceName},
        { "Version", Amazon.ServiceVersion },
        { "Operation", "ItemSearch" },
        { "SearchIndex", "Books" },
        { "ResponseGroup", "Medium" }
      };

      if (!String.IsNullOrEmpty(criteria.Title))
        parameters["Title"] = criteria.Title;
      if (!String.IsNullOrEmpty(criteria.Publisher))
        parameters["Publisher="] = criteria.Publisher;
      if (criteria.Condition.HasValue)
        parameters["Condition="] = criteria.Condition.ToString();
      if (criteria.MaximumPrice.HasValue)
        parameters["MaximumPrice"] = (criteria.MaximumPrice * 100).Value.ToString(CultureInfo.InvariantCulture);

      String url = signHelper.Sign(parameters);
      return url;
    }

    static internal IEnumerable<AmazonBook> PerformWebQuery(String url)
    {
      // Execute query
      XElement booksDoc = XElement.Load(url);

      // Parse results
      XNamespace ns = Amazon.AmazonNS;
      IEnumerable<AmazonBook> books =
        from book in booksDoc.Descendants(ns + "Item")
        let attributes = book.Element(ns + "ItemAttributes")
        let price = attributes.Element(ns + "ListPrice").Element(ns + "Amount").Value
        let isbn = attributes.Element(ns + "ISBN")
        let asin = book.Element(ns + "ASIN")
        select new AmazonBook
           {
             Title = attributes.Element(ns + "Title").Value,
             Isbn = (isbn ?? asin).Value,
             PageCount = UInt32.Parse(attributes.Element(ns + "NumberOfPages").Value),
             Price = price != null ? Decimal.Parse(price) / 100 : 0,
             Publisher = attributes.Element(ns + "Publisher").Value,
             Year = UInt32.Parse(
               ((String)attributes.Element(ns + "PublicationDate").Value).Substring(0, 4)),
             Authors = (
               from author in book.Descendants(ns + "Author")
               select (String)author.Value
             ).ToList()
           };

      return books;
    }
  }
}