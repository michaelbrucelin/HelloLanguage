using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LinqInAction.Chapter04.Win
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.Run(new FormMain());
    }
  }
}