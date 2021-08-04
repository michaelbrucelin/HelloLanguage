using System;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddIn0
{
    public partial class ExcelAddIn0Form0 : Form
    {
        public ExcelAddIn0Form0()
        {
            InitializeComponent();
        }

        public ExcelAddIn0Form0(Excel.Range range)
        {
            this.Range = range;
            InitializeComponent();
        }

        public Excel.Application ExcelApp;
        public Excel.Range Range;

        private void ExcelAddIn0Form0_Load(object sender, EventArgs e)
        {
            ExcelApp = Globals.ThisAddIn.Application;

            DataTable dt = new DataTable();
            for (int i = 0; i < Range.Columns.Count; i++)
            {
                dt.Columns.Add("F" + (i + 1).ToString());
            }

            for (int i = 0; i < Range.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                //Excel range的下标从1开始，不是从0开始
                for (int j = 0; j < Range.Columns.Count; j++)
                {
                    dr[j] = Range[i + 1, j + 1].Value;
                }

                dt.Rows.Add(dr);
            }

            dgv1.DataSource = dt;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Excel.Range range = ExcelApp.ActiveSheet.Range[txtRange.Text];

            DataTable dt = new DataTable();
            for (int i = 0; i < range.Columns.Count; i++)
            {
                dt.Columns.Add("F" + (i + 1).ToString());
            }

            for (int i = 0; i < range.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                //Excel range的下标从1开始，不是从0开始
                for (int j = 0; j < range.Columns.Count; j++)
                {
                    dr[j] = range[i + 1, j + 1].Value;
                }

                dt.Rows.Add(dr);
            }

            dgv1.DataSource = dt;
        }
    }
}
