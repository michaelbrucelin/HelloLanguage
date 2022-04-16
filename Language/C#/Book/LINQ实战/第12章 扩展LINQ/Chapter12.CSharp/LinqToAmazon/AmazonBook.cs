using System;
using System.Collections.Generic;

namespace LinqInAction.Chapter12.LinqToAmazon
{
    public enum BookCondition { All, New, Used, Refurbished, Collectible }

    public class AmazonBook
    {
        public IList<String> Authors { get; set; }
        public BookCondition Condition { get; set; }
        public String Isbn { get; set; }
        public UInt32 PageCount { get; set; }
        public String Publisher { get; set; }
        public Decimal Price { get; set; }
        public String Title { get; set; }
        public UInt32 Year { get; set; }
    }
}