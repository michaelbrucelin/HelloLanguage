using System;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

static class HelloLinqToSql
{
  [Table(Name = "Contacts")]
  class Contact
  {
    [Column(IsPrimaryKey=true)]
    public int ContactID { get; set; }
    [Column(Name="ContactName")]
    public string Name { get; set; }
    [Column]
    public string City { get; set; }
  }

  static void Main()
  {
    // Get access to the database
    string path = System.IO.Path.GetFullPath(@"..\..\..\..\Data\northwnd.mdf");
    DataContext db = new DataContext(path);

    // Query for contacts from Paris
    var contacts =
      from contact in db.GetTable<Contact>()
      where contact.City == "Paris"
      select contact;

    // Display the list of matching contacts
    foreach (var contact in contacts)
      Console.WriteLine("Bonjour " + contact.Name);
  }
}