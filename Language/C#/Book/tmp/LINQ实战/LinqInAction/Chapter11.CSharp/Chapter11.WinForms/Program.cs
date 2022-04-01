using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Chapter11.WinForms
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
            Application.Run(new ImportForm());
        }
    }
}