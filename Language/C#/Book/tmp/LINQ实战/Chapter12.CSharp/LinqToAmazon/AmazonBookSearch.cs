#region Imports

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

#endregion Imports
  
namespace LinqInAction.Chapter12.LinqToAmazon
{
  public class AmazonBookSearch : IEnumerable<AmazonBook>
  {
    private AmazonBookQueryCriteria _Criteria;

    #region Query operators

    public AmazonBookSearch Where(
      Expression<Func<AmazonBook, Boolean>> predicate)
    {
      _Criteria = new AmazonBookExpressionVisitor().ProcessExpression(predicate);
      return this;
    }

    public AmazonBookSearch Select<TResult>(
      Expression<Func<AmazonBook, TResult>> selector)
    {
      return this;
    }

    #endregion Query operators

    #region IEnumerable<T> Members

    IEnumerator<AmazonBook> IEnumerable<AmazonBook>.GetEnumerator()
    {
      return (IEnumerator<AmazonBook>)((IEnumerable)this).GetEnumerator();
    }

    #endregion IEnumerable Members

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
      // Execute query
      String url = AmazonHelper.BuildUrl(_Criteria);
      IEnumerable<AmazonBook> books = AmazonHelper.PerformWebQuery(url);

      return books.GetEnumerator();
    }

    #endregion IEnumerable Members
  }
}