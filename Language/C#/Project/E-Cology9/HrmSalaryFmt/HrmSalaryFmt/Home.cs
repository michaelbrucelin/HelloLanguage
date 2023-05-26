using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrmSalaryFmt
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel|*.xlsx;*.xls"
            };

            if (ofd.ShowDialog() == DialogResult.OK) filePath = ofd.FileName;
            txtPath.Text = filePath.Length > 0 ? filePath : "请选择工资表文件或者将工资表文件拖放到此处！";
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtPath.Text))
            {
                MessageBox.Show("请先选择工资表文件！");
                return;
            }

            DataTable data = UtilsNPOI.ReadExcel_NPOI(txtPath.Text, "导入OA");
            MessageBox.Show("Test");
        }

        private void txtPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                TextBox senderTextbox = (TextBox)sender;
                senderTextbox.Cursor = Cursors.Arrow;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtPath_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            TextBox senderTextbox = (TextBox)sender;
            if (Path.GetExtension(path) == ".xlsx" || Path.GetExtension(path) == ".xls")
                senderTextbox.Text = path;
            else
                senderTextbox.Text = string.Empty;
            senderTextbox.Cursor = Cursors.IBeam;
        }
    }
}
