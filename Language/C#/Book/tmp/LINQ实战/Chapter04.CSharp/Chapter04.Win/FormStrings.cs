using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LinqInAction.Chapter04.Win
{
  public partial class FormStrings : Form
  {
    public FormStrings()
    {
      InitializeComponent();
    }

    private void FormStrings_Load(object sender, EventArgs e)
    {
      String[] books = { "Funny Stories", "All your base are belong to us",
        "LINQ rules", "C# on Rails", "Bonjour mon Amour" };

      var query =
        from book in books
        where book.Length > 10
        orderby book
        select new { Book=book.ToUpper() };

      dataGridView1.DataSource = query.ToList();
    }
  }
}