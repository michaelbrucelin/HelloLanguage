using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace LinqInAction.Chapter04.Win
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private void lnkFormStrings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      new FormStrings().Show();
    }

    private void lnkFormBooks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      new FormBooks().Show();
    }
  }
}