using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqInAction.Chapter12.LinqToAmazon
{
  class AmazonBookQueryCriteria
  {
    public BookCondition? Condition { get; set; }
    public Decimal? MaximumPrice { get; set; }
    public String Publisher { get; set; }
    public String Title { get; set; }
  }
}