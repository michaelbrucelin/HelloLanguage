using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Xml.Linq;
using AmazonCommon;
using LinqInAction.LinqToSql;

namespace Chapter11.MixXmlAndRelationalData
{
    class Program
    {
        static void Main(string[] args)
        {

            var signHelper = new SignedRequestHelper(Amazon.AccessKey, Amazon.SecretKey, "ecs.amazonaws.com");
            var parameters = new Dictionary<String, String>() {
        { "Service", Amazon.ServiceName},
        { "Version", Amazon.ServiceVersion },
        { "Operation", "ItemLookup" },
        { "ItemId", "0735621632" },
        { "ResponseGroup", "Reviews" }
      };
            string requestUrl = signHelper.Sign(parameters);
            XNamespace ns = Amazon.AmazonNS;
            LinqInActionDataContext ctx = new LinqInActionDataContext();

            XElement amazonReviews = XElement.Load(requestUrl);

            var results =
              from bookElement in amazonReviews.Element(ns + "Items").Elements(ns + "Item")
              join book in ctx.Books on (string)bookElement.Element(ns + "ASIN") equals book.Isbn.Trim()
              select new
              {
                  Title = book.Title,
                  Reviews =
          from reviewElement in bookElement.Descendants(ns + "Review")
          orderby (int)reviewElement.Element(ns + "Rating") descending
          select new Review
          {
              Rating = (int)reviewElement.Element(ns + "Rating"),
              Comments = (string)reviewElement.Element(ns + "Content")
          }
              };

            string seperator = "--------------------------";
            foreach (var item in results)
            {
                Console.WriteLine("Book: " + item.Title);
                foreach (var review in item.Reviews)
                {
                    Console.WriteLine(seperator + "\r\nRating: " + review.Rating + "\r\n" + seperator + "\r\n" + review.Comments);
                }
            }
        }
    }
}