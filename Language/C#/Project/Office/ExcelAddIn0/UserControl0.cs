using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn0
{
    public partial class UserControl0 : UserControl
    {
        public UserControl0()
        {
            InitializeComponent();
        }

        public Excel.Application ExcelApp;

        private void UserControl0_Load(object sender, EventArgs e)
        {
            ExcelApp = Globals.ThisAddIn.Application;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Excel.Range range = ExcelApp.Selection;
            txtRange.Text = range.Address;
            txtShow.Text = ExcelApp.ActiveCell.Value.ToString();
        }
    }
}
