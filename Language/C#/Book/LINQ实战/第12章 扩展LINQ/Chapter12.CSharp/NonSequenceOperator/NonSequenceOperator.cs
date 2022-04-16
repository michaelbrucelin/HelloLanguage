using System;
using System.Collections.Generic;
using System.Linq;

using LinqInAction.LinqBooks.Common;

namespace LinqInAction.Extensibility
{
    static class NonSequenceOperator
    {
        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
            this TOuter outer, IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
        {
            // Validation of arguments ignored for simplicity
            ILookup<TKey, TInner> lookup = inner.ToLookup(innerKeySelector);
            yield return resultSelector(outer, lookup[outerKeySelector(outer)]);
        }
    }
}