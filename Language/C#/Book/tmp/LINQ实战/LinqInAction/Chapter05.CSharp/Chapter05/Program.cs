using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace LinqInAction.Chapter05
{
  class Program
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