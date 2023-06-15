using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            lblTip.Text = $"提示{Environment.NewLine}";
            lblTip.Text += $"1. 工资表数据文件必须是.xlsx或.xls文件，不可以是.xlsb文件；{Environment.NewLine}";
        }

        private static readonly Dictionary<string, string> colmap = new Dictionary<string, string>() {
            { "实发工资", "实发工资" }, { "基本工资", "基本工资" }, { "绩效奖金", "绩效奖金" }, { "加班工资", "加班工资" },
            { "月度满勤", "月度满勤奖" }, { "年度满勤", "年度满勤奖" }, { "车补", "车补" }, { "餐补", "餐补" },
            { "保险补贴", "保险补贴" }, { "公积金补贴", "公积金补贴" }, { "补发", "补发" }, { "绩效扣款", "绩效扣款" }, { "考勤扣款", "考勤扣款" },
            { "其他扣款", "其他扣款" }, { "公司垫付款", "公司垫付款" }, { "应发工资", "应发工资" },
            { "养老（公司）", "养老保险(公司)" }, { "医疗（公司）", "医疗保险(公司)" }, { "生育（公司）", "生育保险(公司)" }, { "失业（公司）", "失业保险(公司)" },
            { "工伤（公司）", "工伤保险(公司)" }, { "补充医疗（公司）", "补充医疗" }, { "补充工伤（公司）", "补充工伤" }, { "大病保险（公司）", "大病保险(公司)" },
            { "采暖（公司）", "采暖(公司)" }, { "公积金（公司）", "住房公积金(公司)" }, { "合计（公司）", "合计(公司)" },
            { "养老（个人）", "养老保险(个人)" }, { "医疗（个人）", "医疗保险(个人)" }, { "生育（个人）", "生育保险(个人)" }, { "失业（个人）", "失业保险(个人)" },
            { "工伤（个人）", "工伤保险(个人)" }, { "采暖（个人）", "采暖(个人)" }, { "大病保险（个人）", "大病保险(个人)" },
            { "公积金（个人）", "住房公积金(个人)" }, { "合计（个人）", "合计(个人)" }, { "个人所得税", "个人所得税" }, { "总计", "总计" }, { "备注", "备注" } };

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel|*.xlsx;*.xls"
            };

            if (ofd.ShowDialog() == DialogResult.OK) filePath = ofd.FileName;
            txtSrcPath.Text = filePath.Length > 0 ? filePath : "请选择工资表数据文件或者将工资表数据文件拖放到此处！";
        }

        private void BtnBrowse2_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel|*.xlsx;*.xls"
            };

            if (ofd.ShowDialog() == DialogResult.OK) filePath = ofd.FileName;
            txtTgtPath.Text = filePath.Length > 0 ? filePath : "请选择工资表导入模板或者将工资表导入模板拖放到此处！";
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtSrcPath.Text))
            {
                MessageBox.Show("请先选择工资表数据文件！");
                return;
            }

            if (!File.Exists(txtTgtPath.Text))
            {
                MessageBox.Show("请先选择工资表导入模板！");
                return;
            }

            DataTable dtSrc = UtilsNPOI.ReadExcel(txtSrcPath.Text, "导入OA");
            Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
            for (int r = 0; r < dtSrc.Rows.Count; r++)
            {
                string key = dtSrc.Rows[r]["员工编号"].ToString();
                dic.Add(key, new Dictionary<string, string>());
                for (int c = 0; c < dtSrc.Columns.Count; c++)
                {
                    dic[key].Add(dtSrc.Columns[c].ColumnName, dtSrc.Rows[r][c].ToString());
                }
            }

            DataTable dtTgt = UtilsNPOI.ReadExcel(txtTgtPath.Text, "CompensationTarget");
            for (int r = 0; r < dtTgt.Rows.Count; r++)
            {
                string key = dtTgt.Rows[r]["员工编号"].ToString();
                if (dic.ContainsKey(key))
                {
                    for (int c = 3; c < dtTgt.Columns.Count; c++)  // 前3列为：ID 姓名 员工编号
                    {
                        string col = colmap[dtTgt.Columns[c].ColumnName];
                        if (dic[key].ContainsKey(col)) dtTgt.Rows[r][c] = dic[key][col];
                    }
                }
            }

            string filename = Path.Combine(Path.GetDirectoryName(txtSrcPath.Text), $"CompensationTarget-{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls");
            UtilsNPOI.WriteExcel(dtTgt, filename, "CompensationTarget");

            MessageBox.Show("Done");
        }

        private void txtSrcPath_DragEnter(object sender, DragEventArgs e)
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

        private void txtSrcPath_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            TextBox senderTextbox = (TextBox)sender;
            if (Path.GetExtension(path) == ".xlsx" || Path.GetExtension(path) == ".xls")
                senderTextbox.Text = path;
            else
                senderTextbox.Text = string.Empty;
            senderTextbox.Cursor = Cursors.IBeam;
        }

        private void txtTgtPath_DragEnter(object sender, DragEventArgs e)
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

        private void txtTgtPath_DragDrop(object sender, DragEventArgs e)
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
