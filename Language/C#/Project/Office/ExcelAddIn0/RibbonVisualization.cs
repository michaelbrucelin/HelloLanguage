using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System.Drawing;

namespace ExcelAddIn0
{
    public partial class RibbonVisualization
    {
        public Excel.Application ExcelApp;

        private void RibbonVisualization_Load(object sender, RibbonUIEventArgs e)
        {
            ExcelApp = Globals.ThisAddIn.Application;
            //chkShowPane.Checked = Globals.ThisAddIn.ctp0.Visible;
            chkShowPane.Checked = true;
        }

        private void btn01_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet worksheet = ExcelApp.ActiveSheet;
            worksheet.SelectionChange += Worksheet_SelectionChange;
        }

        private void btn02_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet worksheet = ExcelApp.ActiveSheet;
            worksheet.SelectionChange -= Worksheet_SelectionChange;
        }

        private void Worksheet_SelectionChange(Excel.Range Target)
        {
            Target.Merge();
            Target.Value = Target.Cells.Count;
            Target.Interior.Color = Color.Blue;
        }

        private void group0_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            Excel.Range range = ExcelApp.Selection;

            ExcelAddIn0Form0 frm = new ExcelAddIn0Form0(range);
            frm.ShowDialog();
        }

        private void chkShowPane_Click(object sender, RibbonControlEventArgs e)
        {
            if (chkShowPane.Checked)
            {
                Globals.ThisAddIn.ctp0.Visible = true;
            }
            else
            {
                Globals.ThisAddIn.ctp0.Visible = false;
            }
        }
    }
}
