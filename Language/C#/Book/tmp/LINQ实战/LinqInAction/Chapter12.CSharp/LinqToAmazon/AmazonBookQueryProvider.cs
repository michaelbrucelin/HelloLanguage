using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqInAction.Chapter12.LinqToAmazon
{
  public class AmazonBookQueryProvider : QueryProvider
  {
    public override String GetQueryText(Expression expression)
    {
      AmazonBookQueryCriteria criteria;

      // Retrieve criteria
      criteria = new AmazonBookExpressionVisitor().ProcessExpression(expression);

      // Generate URL
      String url = AmazonHelper.BuildUrl(criteria);

      return url;
    }

    public override object Execute(Expression expression)
    {
      String url = GetQueryText(expression);
      IEnumerable<AmazonBook> results = AmazonHelper.PerformWebQuery(url);
      return results;
    }
  }
}