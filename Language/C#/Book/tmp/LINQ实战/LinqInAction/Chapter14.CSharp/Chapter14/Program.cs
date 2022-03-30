using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LinqInAction.Chapter14
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath(@"..\..\..\..\Data\"));
      Application.EnableVisualStyles();
      Application.Run(new FormMain());
    }
  }
}