using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using LinqInAction.LinqBooks.Common;

namespace LinqInAction.Chapter04.Win
{
  public partial class FormBooks : Form
  {
    public FormBooks()
    {
      InitializeComponent();
    }

    private void FormBooks_Load(object sender, EventArgs e)
    {
      var query =
        from book in SampleData.Books
        where book.Title.Length > 10
        orderby book.Price
        select new { Book=book.Title, book.Price };

      dataGridView1.DataSource = query.ToList();
    }
  }
}