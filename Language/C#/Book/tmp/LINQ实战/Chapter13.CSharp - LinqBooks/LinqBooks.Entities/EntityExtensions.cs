using System;

namespace LinqBooks.Entities
{
  public partial class Author
  {
    public String FullName
    {
      get { return LastName.ToUpper() + " " + FirstName; }
    }
  }
}