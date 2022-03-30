using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqInAction.Chapter12.LinqToAmazon
{
  class Program
  {
    static void Main(string[] args)
    {
      #region Test AmazonBookSearch

      Console.WriteLine("-= Testing AmazonBookSearch =-");
      Console.WriteLine();

      var search =
        from book in new AmazonBookSearch()
        where
          book.Title.Contains("ajax") &&
          (book.Publisher == "Manning") &&
          (book.Price <= 25) &&
          (book.Condition == BookCondition.New)
        select book;

      // Execute the LINQ to Amazon query
      var books = search.ToList();
      
      ObjectDumper.Write(books, 1);

      Console.WriteLine();
      Console.WriteLine("-= Using LINQ to Objects on the results =-");
      Console.WriteLine();

      // Pure LINQ to Objects code, without any call to Amazon
      var groups =
        from book in books
        group book by book.Year into years
        orderby years.Key descending
        select new {
          Year = years.Key,
          Books =
            from book in years
            select new { book.Title, book.Authors }
        };
      foreach (var group in groups)
      {
        Console.WriteLine("Published in " + group.Year);
        foreach (var book in group.Books)
        {
          Console.Write("  ");
          ObjectDumper.Write(book);
        }
        Console.WriteLine();
      }

      #endregion Test AmazonBookSearch

      Console.WriteLine();

      #region Test AmazonBookQueryProvider

      Console.WriteLine("-= Testing AmazonBookQueryProvider =-");
      Console.WriteLine();
      
      var provider = new AmazonBookQueryProvider();
      var queryable = new Query<AmazonBook>(provider);
      var query =
        from book in queryable
        where
          book.Title.Contains("ajax") &&
          (book.Publisher == "Manning") &&
          (book.Price <= 25) &&
          (book.Condition == BookCondition.New)
        select book;

      ObjectDumper.Write(query, 1);
      
      Console.WriteLine();
      Console.WriteLine("URL used: " + query.ToString());

      #endregion Test AmazonBookQueryProvider

      #region Expression tree

      // For information, here is the expression tree matching the query above
      //var bookParam = Expression.Parameter(typeof(AmazonBook), "book");
      //var expressionTree =
      //  Expression.Lambda<Func<AmazonBook, Boolean>>(
      //    Expression.AndAlso(
      //      Expression.AndAlso(
      //        Expression.AndAlso(
      //          Expression.Call(
      //            Expression.Property(bookParam, typeof(AmazonBook).GetProperty("Title")),
      //            typeof(String).GetMethod("Contains"),
      //            new Expression[] { Expression.Constant("ajax", typeof(String)) }
      //          ),
      //          Expression.Equal(
      //            Expression.Property(bookParam, typeof(AmazonBook).GetProperty("Publisher")),
      //            Expression.Constant("Manning", typeof(String)),
      //            false,
      //            typeof(String).GetMethod("op_Equality")
      //          )
      //        ),
      //        Expression.LessThanOrEqual(
      //          Expression.Property(bookParam, typeof(AmazonBook).GetProperty("Price")),
      //          Expression.Constant(25M, typeof(Decimal))
      //        )
      //      ),
      //      Expression.Equal(
      //        Expression.Convert(
      //          Expression.Property(bookParam, typeof(AmazonBook).GetProperty("Condition")),
      //          typeof(int)
      //        ),
      //        Expression.Constant(1, typeof(int))
      //      )
      //    ),
      //    new ParameterExpression[] { bookParam }
      //  );

      #endregion Expression tree
    }
  }
}