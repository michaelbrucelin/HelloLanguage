using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp0
{
    public static class MyUtilsNPOI
    {
        /// <summary>
        /// 将DataGridView中的数据导出到Excel
        /// 1. 不导出隐藏的行与列
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="file"></param>
        public static void WriteExcel(DataGridView dgv, string file)
        {
            List<(string name, string headertext, int displayid)> _columns = new List<(string, string, int)>();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (!dgv.Columns[i].Visible) continue;
                _columns.Add((dgv.Columns[i].Name, dgv.Columns[i].HeaderText, dgv.Columns[i].DisplayIndex));
            }

            var columns = _columns.OrderBy(item => item.displayid).Select(item => (item.name, item.headertext)).ToList();
            WriteExcel(dgv, columns, file);
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel
        /// 1. 只导出指定的列
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="colnames">需要导出的列</param>
        /// <param name="file"></param>
        public static void WriteExcel(DataGridView dgv, string[] colnames, string file)
        {
            List<(string name, string headertext, int displayid)> _columns = new List<(string, string, int)>();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (colnames.Contains(dgv.Columns[i].Name))
                    _columns.Add((dgv.Columns[i].Name, dgv.Columns[i].HeaderText, dgv.Columns[i].DisplayIndex));
            }

            var columns = _columns.OrderBy(item => item.displayid).Select(item => (item.name, item.headertext)).ToList();
            WriteExcel(dgv, columns, file);
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel
        /// 1. 只导出指定的列
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="columns">需要导出的列的信息</param>
        /// <param name="file"></param>
        private static void WriteExcel(DataGridView dgv, IList<(string name, string headertext)> columns, string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");

                IRow header = sheet.CreateRow(0);
                int colcnt = 0;
                for (int i = 0; i < columns.Count; i++)
                    header.CreateCell(colcnt++).SetCellValue(columns[i].headertext);

                int rowcnt = 1;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (!dgv.Rows[i].Visible) continue;

                    IRow row = sheet.CreateRow(rowcnt++);
                    int colid = 0;
                    foreach (var col in columns)
                    {
                        if (dgv.Rows[i].Cells[col.name].Value != null)
                            row.CreateCell(colid++).SetCellValue(dgv.Rows[i].Cells[col.name].Value.ToString());
                    }
                }

                workbook.Write(fs);
            }
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel
        /// 1. 不导出隐藏的行与列
        /// 2. 导出DataGridView的如下格式
        ///     2.1 单元格的背景色
        ///     2.2 字体、颜色、粗体、斜体、下划线、删除线
        /// 3. 单元格带有边框
        /// 4. 锁定首行并自动添加筛选
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="file"></param>
        public static void WriteExcelWithStyle(DataGridView dgv, string file)
        {
            List<(string name, string headertext, int displayid)> _columns = new List<(string, string, int)>();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (!dgv.Columns[i].Visible) continue;
                _columns.Add((dgv.Columns[i].Name, dgv.Columns[i].HeaderText, dgv.Columns[i].DisplayIndex));
            }

            var columns = _columns.OrderBy(item => item.displayid).Select(item => (item.name, item.headertext)).ToList();
            WriteExcelWithStyle(dgv, columns, file);
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel
        /// 1. 只导出指定的列
        /// 2. 导出DataGridView的如下格式
        ///     2.1 单元格的背景色
        ///     2.2 字体、颜色、粗体、斜体、下划线、删除线
        /// 3. 单元格带有边框
        /// 4. 锁定首行并自动添加筛选
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="colnames">需要导出的列</param>
        /// <param name="file"></param>
        public static void WriteExcelWithStyle(DataGridView dgv, string[] colnames, string file)
        {
            List<(string name, string headertext, int displayid)> _columns = new List<(string, string, int)>();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (colnames.Contains(dgv.Columns[i].Name))
                    _columns.Add((dgv.Columns[i].Name, dgv.Columns[i].HeaderText, dgv.Columns[i].DisplayIndex));
            }

            var columns = _columns.OrderBy(item => item.displayid).Select(item => (item.name, item.headertext)).ToList();
            WriteExcelWithStyle(dgv, columns, file);
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel
        /// 1. 只导出指定的列
        /// 2. 导出DataGridView的如下格式
        ///     2.1 单元格的背景色
        ///     2.2 字体、颜色、粗体、斜体、下划线、删除线
        /// 3. 单元格带有边框
        /// 4. 锁定首行并自动添加筛选
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="columns">需要导出的列的信息</param>
        /// <param name="file"></param>
        private static void WriteExcelWithStyle(DataGridView dgv, IList<(string name, string headertext)> columns, string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");

                #region 表头
                // 表头样式
                XSSFCellStyle headerstyle = (XSSFCellStyle)workbook.CreateCellStyle();
                // 单元格边框
                headerstyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                headerstyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                headerstyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                headerstyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                // 字体
                XSSFFont headerfont = (XSSFFont)workbook.CreateFont();
                headerstyle.SetFont(headerfont);
                headerfont.FontName = "微软雅黑";
                headerfont.IsBold = true;

                // 创建表头
                IRow header = sheet.CreateRow(0);
                int colcnt = 0;
                for (int i = 0; i < columns.Count; i++)
                {
                    ICell headercell = header.CreateCell(colcnt++);
                    headercell.SetCellValue(columns[i].headertext);
                    headercell.CellStyle = headerstyle;
                }
                #endregion

                #region 数据
                int rowcnt = 1;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (!dgv.Rows[i].Visible) continue;

                    IRow row = sheet.CreateRow(rowcnt++);
                    int colid = 0;
                    foreach (var col in columns)
                    {
                        DataGridViewCell dgvcell = dgv.Rows[i].Cells[col.name];

                        XSSFCellStyle style = (XSSFCellStyle)workbook.CreateCellStyle();
                        // 单元格边框
                        style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                        style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                        style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                        style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;

                        // 单元格背景色
                        style.FillPattern = FillPattern.SolidForeground;
                        if (dgvcell.Style.BackColor.IsEmpty)
                            style.SetFillForegroundColor(new XSSFColor(new byte[] { 255, 255, 255 }));
                        else
                            style.SetFillForegroundColor(new XSSFColor(new byte[] { dgvcell.Style.BackColor.R, dgvcell.Style.BackColor.G, dgvcell.Style.BackColor.B }));

                        // 字体
                        XSSFFont font = (XSSFFont)workbook.CreateFont();
                        style.SetFont(font);
                        font.SetColor(new XSSFColor(new byte[] { dgvcell.Style.ForeColor.R, dgvcell.Style.ForeColor.G, dgvcell.Style.ForeColor.B }));
                        if (dgvcell.Style.Font != null)
                        {
                            font.FontName = dgvcell.Style.Font.FontFamily.Name;
                            font.IsBold = dgvcell.Style.Font.Bold;
                            font.IsItalic = dgvcell.Style.Font.Italic;
                            font.Underline = dgvcell.Style.Font.Underline ? FontUnderlineType.Single : FontUnderlineType.None;
                            font.IsStrikeout = dgvcell.Style.Font.Strikeout;
                        }
                        else
                        {
                            font.FontName = dgvcell.InheritedStyle.Font.FontFamily.Name;
                            font.IsBold = dgvcell.InheritedStyle.Font.Bold;
                            font.IsItalic = dgvcell.InheritedStyle.Font.Italic;
                            font.Underline = dgvcell.InheritedStyle.Font.Underline ? FontUnderlineType.Single : FontUnderlineType.None;
                            font.IsStrikeout = dgvcell.InheritedStyle.Font.Strikeout;
                        }

                        ICell cell = row.CreateCell(colid++);
                        if (dgvcell.Value != null)
                            cell.SetCellValue(dgvcell.Value.ToString());
                        cell.CellStyle = style;
                    }
                }
                #endregion

                sheet.CreateFreezePane(0, 1);                                    // 锁定首行
                // sheet.SetAutoFilter(new CellRangeAddress(0, rowcnt - 1, 0, colcnt - 1));
                sheet.SetAutoFilter(new CellRangeAddress(0, 0, 0, colcnt - 1));  // 筛选

                workbook.Write(fs);
            }
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel
        /// 1. 不导出隐藏的行与列
        /// 2. 导出DataGridView的如下格式
        ///     2.1 单元格的背景色
        ///     2.2 字体、颜色、粗体、斜体、下划线、删除线
        /// 3. 单元格带有边框
        /// 4. 锁定首行并自动添加筛选
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="file"></param>
        public static void WriteExcelWithStyle2(DataGridView dgv, string file)
        {
            List<(string name, string headertext, int displayid)> _columns = new List<(string, string, int)>();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (!dgv.Columns[i].Visible) continue;
                _columns.Add((dgv.Columns[i].Name, dgv.Columns[i].HeaderText, dgv.Columns[i].DisplayIndex));
            }

            var columns = _columns.OrderBy(item => item.displayid).Select(item => (item.name, item.headertext)).ToList();
            WriteExcelWithStyle2(dgv, columns, file);
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel
        /// 1. 只导出指定的列
        /// 2. 导出DataGridView的如下格式
        ///     2.1 单元格的背景色
        ///     2.2 字体、颜色、粗体、斜体、下划线、删除线
        /// 3. 单元格带有边框
        /// 4. 锁定首行并自动添加筛选
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="colnames">需要导出的列</param>
        /// <param name="file"></param>
        public static void WriteExcelWithStyle2(DataGridView dgv, string[] colnames, string file)
        {
            List<(string name, string headertext, int displayid)> _columns = new List<(string, string, int)>();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (colnames.Contains(dgv.Columns[i].Name))
                    _columns.Add((dgv.Columns[i].Name, dgv.Columns[i].HeaderText, dgv.Columns[i].DisplayIndex));
            }

            var columns = _columns.OrderBy(item => item.displayid).Select(item => (item.name, item.headertext)).ToList();
            WriteExcelWithStyle2(dgv, columns, file);
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel
        /// 1. 只导出指定的列
        /// 2. 导出DataGridView的如下格式
        ///     2.1 单元格的背景色
        ///     2.2 字体、颜色、粗体、斜体、下划线、删除线
        /// 3. 单元格带有边框
        /// 4. 锁定首行并自动添加筛选
        /// 
        /// 对WriteExcelWithStyle进行了内存优化
        /// WriteExcelWithStyle中由于每个单元格绑定了一个样式类（XSSFCellStyle），所以会占用大量内存（测试16列256行占用1GB左右的内存）
        /// 由于现实中大量的单元格样式是一样的，所以可以从这个角度来优化这个问题，实现后测试69MB内存，与不带样式导出基本一样
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="columns">需要导出的列的信息</param>
        /// <param name="file"></param>
        private static void WriteExcelWithStyle2(DataGridView dgv, IList<(string name, string headertext)> columns, string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");

                #region 表头
                // 表头样式
                XSSFCellStyle headerstyle = (XSSFCellStyle)workbook.CreateCellStyle();
                // 单元格边框
                headerstyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                headerstyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                headerstyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                headerstyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                // 字体
                XSSFFont headerfont = (XSSFFont)workbook.CreateFont();
                headerstyle.SetFont(headerfont);
                headerfont.FontName = "微软雅黑";
                headerfont.IsBold = true;

                // 创建表头
                IRow header = sheet.CreateRow(0);
                int colcnt = 0;
                for (int i = 0; i < columns.Count; i++)
                {
                    ICell headercell = header.CreateCell(colcnt++);
                    headercell.SetCellValue(columns[i].headertext);
                    headercell.CellStyle = headerstyle;
                }
                #endregion

                #region 数据
                Dictionary<QCellStyle, XSSFCellStyle> styles = new Dictionary<QCellStyle, XSSFCellStyle>();  // 单元格样式缓存

                int rowcnt = 1;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (!dgv.Rows[i].Visible) continue;

                    IRow row = sheet.CreateRow(rowcnt++);
                    int colid = 0;
                    foreach (var col in columns)
                    {
                        DataGridViewCell dgvcell = dgv.Rows[i].Cells[col.name];

                        #region 获取单元格样式
                        QCellStyle style_key = new QCellStyle();
                        // 单元格背景色
                        if (dgvcell.Style.BackColor.IsEmpty)
                        {
                            style_key.BGColorR = dgvcell.InheritedStyle.BackColor.R;
                            style_key.BGColorG = dgvcell.InheritedStyle.BackColor.G;
                            style_key.BGColorB = dgvcell.InheritedStyle.BackColor.B;
                        }
                        else
                        {
                            style_key.BGColorR = dgvcell.Style.BackColor.R;
                            style_key.BGColorG = dgvcell.Style.BackColor.G;
                            style_key.BGColorB = dgvcell.Style.BackColor.B;
                        }

                        // 字体
                        style_key.FRColorR = dgvcell.Style.ForeColor.R;
                        style_key.FRColorG = dgvcell.Style.ForeColor.G;
                        style_key.FRColorB = dgvcell.Style.ForeColor.B;
                        if (dgvcell.Style.Font != null)
                        {
                            style_key.FontName = dgvcell.Style.Font.FontFamily.Name;
                            style_key.IsBold = dgvcell.Style.Font.Bold;
                            style_key.IsItalic = dgvcell.Style.Font.Italic;
                            style_key.IsUnderline = dgvcell.Style.Font.Underline;
                            style_key.IsStrikeout = dgvcell.Style.Font.Strikeout;
                        }
                        else
                        {
                            style_key.FontName = dgvcell.InheritedStyle.Font.FontFamily.Name;
                            style_key.IsBold = dgvcell.InheritedStyle.Font.Bold;
                            style_key.IsItalic = dgvcell.InheritedStyle.Font.Italic;
                            style_key.IsUnderline = dgvcell.InheritedStyle.Font.Underline;
                            style_key.IsStrikeout = dgvcell.InheritedStyle.Font.Strikeout;
                        }
                        #endregion

                        #region 将单元格样式放入缓存
                        if (!styles.ContainsKey(style_key))
                        {
                            XSSFCellStyle style_value = (XSSFCellStyle)workbook.CreateCellStyle();

                            // 单元格边框
                            style_value.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                            style_value.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                            style_value.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                            style_value.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;

                            // 单元格背景色
                            style_value.FillPattern = FillPattern.SolidForeground;
                            style_value.SetFillForegroundColor(new XSSFColor(new byte[] { style_key.BGColorR, style_key.BGColorG, style_key.BGColorB }));

                            // 字体
                            XSSFFont font = (XSSFFont)workbook.CreateFont();
                            style_value.SetFont(font);
                            font.SetColor(new XSSFColor(new byte[] { style_key.FRColorR, style_key.FRColorG, style_key.FRColorB }));
                            font.FontName = style_key.FontName;
                            font.IsBold = style_key.IsBold;
                            font.IsItalic = style_key.IsItalic;
                            font.Underline = style_key.IsUnderline ? FontUnderlineType.Single : FontUnderlineType.None;
                            font.IsStrikeout = style_key.IsStrikeout;

                            styles.Add(style_key, style_value);
                        }
                        #endregion

                        ICell cell = row.CreateCell(colid++);
                        if (dgvcell.Value != null)
                            cell.SetCellValue(dgvcell.Value.ToString());
                        cell.CellStyle = styles[style_key];
                    }
                }
                #endregion

                sheet.CreateFreezePane(0, 1);                                    // 锁定首行
                // sheet.SetAutoFilter(new CellRangeAddress(0, rowcnt - 1, 0, colcnt - 1));
                sheet.SetAutoFilter(new CellRangeAddress(0, 0, 0, colcnt - 1));  // 筛选

                workbook.Write(fs);
            }
        }

        public static void MyToExcel(this DataGridView dgv, string file)
        {
            WriteExcel(dgv, file);
        }

        public static void MyToExcel(this DataGridView dgv, string[] colnames, string file)
        {
            WriteExcel(dgv, colnames, file);
        }

        public static void MyToExcelWithStyle(this DataGridView dgv, string file)
        {
            WriteExcelWithStyle2(dgv, file);
        }

        public static void MyToExcelWithStyle(this DataGridView dgv, string[] colnames, string file)
        {
            WriteExcelWithStyle2(dgv, colnames, file);
        }
    }

    public struct QCellStyle
    {
        // public bool IsBGColorEmpty { get; set; }  // 不需要记录

        public byte BGColorR { get; set; }

        public byte BGColorG { get; set; }

        public byte BGColorB { get; set; }

        public byte FRColorR { get; set; }

        public byte FRColorG { get; set; }

        public byte FRColorB { get; set; }

        // public bool IsFontNull { get; set; }      // 不需要记录

        public string FontName { get; set; }

        public bool IsBold { get; set; }

        public bool IsItalic { get; set; }

        public bool IsUnderline { get; set; }

        public bool IsStrikeout { get; set; }
    }
}
