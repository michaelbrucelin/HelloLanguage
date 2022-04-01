using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LinqBooks.ImportFromAmazon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetFullPath(@"..\..\..\LinqBooks.Web\App_Data\"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ImportForm());
        }
    }
}
