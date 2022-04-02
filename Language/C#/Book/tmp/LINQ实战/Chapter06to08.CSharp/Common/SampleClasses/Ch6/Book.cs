using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;

namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch6.Unmapped
{
  /// <summary>
  /// Book definition used in listing 6.1
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

    public static IEnumerable<Book> GetBooks()
    {
      List<Book> books = new List<Book>();
      using (SqlConnection connection = new SqlConnection(LinqInAction.Chapter06to08.Common.Properties.Settings.Default.liaConnectionString))
      {
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT ID, Isbn, Notes, PageCount, Price, PubDate, Publisher, Subject, Summary, Title FROM dbo.Book";
        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            Book newBook = new Book();
            if (!reader.IsDBNull(0)) { newBook.BookId = reader.GetGuid(0); }
            if (!reader.IsDBNull(1)) { newBook.Isbn = reader.GetString(1); }
            if (!reader.IsDBNull(2)) { newBook.Notes = reader.GetString(2); }
            if (!reader.IsDBNull(3)) { newBook.PageCount = reader.GetInt32(3); }
            if (!reader.IsDBNull(4)) { newBook.Price = reader.GetDecimal(4); }
            if (!reader.IsDBNull(5)) { newBook.PublicationDate = reader.GetDateTime(5); }
            if (!reader.IsDBNull(6)) { newBook.PublisherId = reader.GetGuid(6); }
            if (!reader.IsDBNull(7)) { newBook.SubjectId = reader.GetGuid(7); }
            if (!reader.IsDBNull(8)) { newBook.Summary = reader.GetString(8); }
            if (!reader.IsDBNull(9)) { newBook.Title = reader.GetString(9); }
            books.Add(newBook);
          }
        }
      }
      return books;
    }

  }
}

namespace LinqInAction.Chapter06to08.Common.SampleClasses.Ch6
{
  /// <summary>
  /// Book definition with LINQ attributes from listing 6.2
  /// </summary>
  [Table]
  public class Book
  {
    [Column(Name = "ID", IsPrimaryKey = true)]
    public Guid BookId { get; set; }
    [Column]
    public String Isbn { get; set; }
    [Column(CanBeNull = true)]
    public string Notes { get; set; }
    [Column]
    public Int32 PageCount { get; set; }
    [Column]
    public Decimal Price { get; set; }
    [Column(Name = "PubDate")]
    public DateTime PublicationDate { get; set; }
    [Column(CanBeNull = true)]
    public String Summary { get; set; }
    [Column]
    public String Title { get; set; }
    [Column(Name = "Subject")]
    public Guid SubjectId { get; set; }
    [Column(Name = "Publisher")]
    public Guid PublisherId { get; set; }
    public override String ToString()
    {
      return Title;
    }
  }
}