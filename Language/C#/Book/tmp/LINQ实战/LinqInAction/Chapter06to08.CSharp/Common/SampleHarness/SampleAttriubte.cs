using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqInAction.Chapter06to08.Common.SampleHarness
{
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
  class SampleAttribute : Attribute
  {
    int _Chapter;
    int _Listing;
    string _Description;

    public SampleAttribute(int chapter, int listingNumber, string description)
    {
      this._Chapter = chapter;
      this._Listing = listingNumber;
      this._Description = description;
    }

    public int Chapter
    {
      get { return this._Chapter; }
    }

    public int ListingNumber
    {
      get { return this._Listing; }
    }

    public string Description
    {
      get { return this._Description; }
    }
  }
}