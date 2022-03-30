using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Xml.Linq;
using System.Data.Linq;

namespace Chapter11.WinForms {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.Run(new ImportForm());
		}
	}
}