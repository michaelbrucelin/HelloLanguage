using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinqInAction.Chapter06to08.Common.SampleClasses.Ch8;

namespace LinqInAction.Chapter06to08.Common.CodeSamples
{
  public partial class EditingForm : Form
  {
    public EditingForm()
    {
      InitializeComponent();
    }

    private void EditingForm_Load(object sender, EventArgs e)
    {
      Ch8DataContext context = new Ch8DataContext();
      var query = from p in context.Publishers
                  select p;
      this.publisherBindingSource.DataSource = query.ToList();

    }
  }
}
