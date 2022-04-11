// The code in this file comes from Matt Warren's series of blog posts on how to build a LINQ provider
// http://blogs.msdn.com/mattwar/archive/2007/08/09/linq-building-an-iqueryable-provider-part-i.aspx

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace LinqInAction.Chapter12.LinqToAmazon
{
  public abstract class QueryProvider : IQueryProvider
  {
    protected QueryProvider()
    {
    }

    IQueryable<S> IQueryProvider.CreateQuery<S>(Expression expression)
    {
      return new Query<S>(this, expression);
    }

    IQueryable IQueryProvider.CreateQuery(Expression expression)
    {
      Type elementType = TypeSystem.GetElementType(expression.Type);
      try
      {
        return (IQueryable)Activator.CreateInstance(typeof(Query<>).MakeGenericType(elementType), new object[] { this, expression });
      }
      catch (TargetInvocationException tie)
      {
        throw tie.InnerException;
      }
    }

    S IQueryProvider.Execute<S>(Expression expression)
    {
      return (S)this.Execute(expression);
    }

    object IQueryProvider.Execute(Expression expression)
    {
      return this.Execute(expression);
    }

    public abstract string GetQueryText(Expression expression);
    public abstract object Execute(Expression expression);
  }
}