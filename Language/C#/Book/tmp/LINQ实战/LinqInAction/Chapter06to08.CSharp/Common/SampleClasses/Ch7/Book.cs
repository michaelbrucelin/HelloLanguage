using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch7
{
  /// <summary>
  /// Book definition used in listing 7.6
  /// </summary>
  public class Book
  {
    public Guid BookId { get; set; }
    public String Isbn { get; set; }
    public string Notes { get; set; }
    public Int32 PageCount { get; set; }
    public Decimal Price { get; set; }
    public DateTime PublicationDate { get; set; }
    public String Summary { get; set; }
    public String Title { get; set; }
    public Guid SubjectId { get; set; }
    public Guid PublisherId { get; set; }

    public override String ToString()
    {
      return Title;
    }
  }
}