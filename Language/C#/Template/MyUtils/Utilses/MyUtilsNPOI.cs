using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.Streaming;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp0
{
    public static class MyUtilsNPOI
    {
        #region 读取Excel
        public enum ExcelColumnDataType { AllString, ActualDataType };

        /// <summary>
        /// 所有列按照字符串获取值
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static DataTable ReadExcel(string file)
        {
            return ReadExcel(file, 0);
        }

        public static DataTable ReadExcel(string file, string sheetName)
        {
            IWorkbook wb;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                if (Path.GetExtension(file).ToLower() == ".xlsx")
                {
                    wb = new XSSFWorkbook(fs);
                }
                else if (Path.GetExtension(file).ToLower() == ".xls")
                {
                    wb = new HSSFWorkbook(fs);
                }
                else
                {
                    return null;
                }
            }

            ISheet sheet = wb.GetSheet(sheetName);

            return ISheet2DataTable(sheet);
        }

        public static DataTable ReadExcel(string file, int sheetIndex)
        {
            IWorkbook wb;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                if (Path.GetExtension(file).ToLower() == ".xlsx")
                {
                    wb = new XSSFWorkbook(fs);
                }
                else if (Path.GetExtension(file).ToLower() == ".xls")
                {
                    wb = new HSSFWorkbook(fs);
                }
                else
                {
                    return null;
                }
            }

            ISheet sheet = wb.GetSheetAt(sheetIndex);

            return ISheet2DataTable(sheet);
        }

        private static DataTable ISheet2DataTable(ISheet sheet)
        {
            DataTable dt = new DataTable();

            // 获取标题
            IRow header = sheet.GetRow(sheet.FirstRowNum);
            // 获取列的数量，也可以遍历所有行，取最大的列数，这里就不展开了
            int colA = header.FirstCellNum;
            int colZ = header.LastCellNum;
            for (int i = colA; i < colZ; i++)
            {
                dt.Columns.Add(header.GetCell(i).StringCellValue, typeof(string));
            }

            // 获取数据
            IRow row;
            for (int rowIndex = sheet.FirstRowNum + 1; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                if ((row = sheet.GetRow(rowIndex)) != null)  // null is when the row only contains empty cells
                {
                    // 这种用法，兼容性较高，例如第一行（标题）只有5列，第三行有6列时会只读取第三行的前5列，不会报错
                    DataRow dr = dt.NewRow();
                    int i = 0;
                    for (int colIndex = colA; colIndex < colZ; colIndex++)
                    {
                        dr[i] = row.GetCell(colIndex).StringCellValue;
                        i++;
                    }
                    dt.Rows.Add(dr);
                    // 这种用法，当表格不规范，例如第一行只有5列（标题），第三行有6列时会报错
                    // dt.Rows.Add(row.Cells.ToArray());
                }
            }

            return dt;
        }

        /// <summary>
        /// 获取excel列真实的数据类型
        /// 但是没有完善，如果需要在生产环境中使用，需要继续完善
        /// 不建议在生产环境中使用，因为excel源可能的问题太多，如果需要真实的数据类型，可以考虑按照string导入后，在DataTable中处理
        /// </summary>
        /// <param name="file"></param>
        /// <param name="excelColumnDataType"></param>
        /// <returns></returns>
        public static DataTable ReadExcel2(string file, ExcelColumnDataType excelColumnDataType)
        {
            return ReadExcel2(file, 0, excelColumnDataType);
        }

        public static DataTable ReadExcel2(string file, string sheetName, ExcelColumnDataType excelColumnDataType)
        {
            IWorkbook workbook;
            string fileExtension = Path.GetExtension(file).ToLower();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                // XSSFWorkbook适用xlsx格式，HSSFWorkbook适用xls格式
                if (fileExtension == ".xlsx")
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (fileExtension == ".xls")
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else
                {
                    return null;
                }
            }

            ISheet sheet = workbook.GetSheet(sheetName);

            return ISheet2DataTable2(sheet, excelColumnDataType);
        }

        public static DataTable ReadExcel2(string file, int sheetIndex, ExcelColumnDataType excelColumnDataType)
        {
            IWorkbook workbook;
            string fileExtension = Path.GetExtension(file).ToLower();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                // XSSFWorkbook适用xlsx格式，HSSFWorkbook适用xls格式
                if (fileExtension == ".xlsx")
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (fileExtension == ".xls")
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else
                {
                    return null;
                }
            }

            ISheet sheet = workbook.GetSheetAt(sheetIndex);

            return ISheet2DataTable2(sheet, excelColumnDataType);
        }

        private static DataTable ISheet2DataTable2(ISheet sheet, ExcelColumnDataType excelColumnDataType)
        {
            DataTable dt = new DataTable();

            // 表头及列的数据类型
            IRow header = sheet.GetRow(sheet.FirstRowNum);
            int colcnt = 0;  // List<int> columns = new List<int>();
            if (excelColumnDataType == ExcelColumnDataType.AllString)
            {
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = ReadExcelCellValue(header.GetCell(i));
                    if (obj == null || obj.ToString().Length == 0)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    }
                    colcnt++;  // columns.Add(i);
                }
            }
            else if (excelColumnDataType == ExcelColumnDataType.ActualDataType)
            {
                IRow firstrow = sheet.GetRow(sheet.FirstRowNum + 1);
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = ReadExcelCellValue(header.GetCell(i));
                    if (obj == null || obj.ToString().Length == 0)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString(), ReadExcelCellDataType(firstrow.GetCell(i))));
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn(obj.ToString(), ReadExcelCellDataType(firstrow.GetCell(i))));
                    }
                    colcnt++;  // columns.Add(i);
                }
            }
            else
            {
                return null;
            }

            // 获取数据
            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                if (sheet.GetRow(i) == null) continue;

                DataRow dr = dt.NewRow();
                bool hasValue = false;
                for (int j = 0; j < colcnt; j++)  // foreach (int j in columns)
                {
                    if (sheet.GetRow(i).GetCell(j) != null)  // 判断非空行 非空格
                    {
                        dr[j] = ReadExcelCellValue(sheet.GetRow(i).GetCell(j));
                        if (dr[j] != null && dr[j].ToString().Length > 0)
                        {
                            hasValue = true;
                        }
                    }
                }
                if (hasValue)
                {
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        /// <summary>
        /// 读取Cell中的值；公式没有错的时候，取公式计算的值，公式有错的时候，使用公式
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object ReadExcelCellValue(ICell cell)
        {
            if (cell == null) return null;

            switch (cell.CellType)
            {
                case CellType.Blank:
                    return null;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Numeric:
                    return cell.NumericCellValue;
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Error:
                    return cell.ErrorCellValue;
                case CellType.Formula:
                    try
                    {
                        return cell.NumericCellValue;
                    }
                    catch
                    {
                        try
                        {
                            return cell.StringCellValue;
                        }
                        catch
                        {
                            return "=" + cell.CellFormula;
                        }
                    }
                default:
                    try
                    {
                        return cell.StringCellValue;
                    }
                    catch
                    {
                        return cell.ErrorCellValue;
                    }
            }
        }

        /// <summary>
        /// 读取Cell中的值的数据类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static Type ReadExcelCellDataType(ICell cell)
        {
            if (cell == null) return null;

            switch (cell.CellType)
            {
                case CellType.Blank:
                    return typeof(string);  // return null;
                case CellType.Boolean:
                    return typeof(bool);
                case CellType.Numeric:
                    return typeof(decimal);
                case CellType.String:
                    return typeof(string);
                case CellType.Error:
                    return typeof(string);
                case CellType.Formula:
                    return typeof(string);
                default:
                    return typeof(string);
            }
        }
        #endregion

        #region 导出Excel
        #region DataTable与DataSet导出Excel
        public static void WriteExcel(DataTable dt, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            string sheetName = string.IsNullOrEmpty(dt.TableName) ? "Sheet1" : dt.TableName;
            WriteExcel(dt, file, sheetName, cellType);
        }

        public static void WriteExcel(DataTable dt, string file, string sheetName, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            // 创建workbook
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported.");
            }

            // 创建sheet
            AddExcelSheet(dt, ref workbook, sheetName, cellType);

            //保存为Excel文件
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
                // fs.Flush();
                // fs.Close();
            }

            /* 下面是老代码，不确认为什么要额外套一层MemoryStream
            using (MemoryStream stream = new MemoryStream())
            {
                workbook.Write(stream);
                byte[] buffer = stream.ToArray();

                // 保存为Excel文件  
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
            */
        }

        public static void WriteExcel(DataSet ds, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            string[] sheetNames = new string[ds.Tables.Count];
            string sheetName;
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                sheetName = string.IsNullOrEmpty(ds.Tables[i].TableName) ? "Sheet" + (i + 1).ToString() : ds.Tables[i].TableName;
                sheetNames[i] = sheetName;
            }

            WriteExcel(ds, file, sheetNames, cellType);
        }

        public static void WriteExcel(DataSet ds, string file, string[] sheetNames, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            // 创建workbook
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported.");
            }

            // 创建sheet
            if (sheetNames.Length >= ds.Tables.Count)
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    AddExcelSheet(ds.Tables[i], ref workbook, sheetNames[i], cellType);
                }
            }
            else
            {
                for (int i = 0; i < sheetNames.Length; i++)
                {
                    AddExcelSheet(ds.Tables[i], ref workbook, sheetNames[i], cellType);
                }
                string sheetName;
                for (int i = sheetNames.Length; i < ds.Tables.Count; i++)
                {
                    sheetName = string.IsNullOrEmpty(ds.Tables[i].TableName) ? "Sheet" + (i + 1).ToString() : ds.Tables[i].TableName;
                    AddExcelSheet(ds.Tables[i], ref workbook, sheetName, cellType);
                }
            }

            // 保存为Excel文件
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
                // fs.Flush();
                // fs.Close();
            }
        }

        public static void WriteExcel(DataTable[] dts, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            DataSet ds = new DataSet();
            for (int i = 0; i < dts.Length; i++)
            {
                // 如果不Copy一份，原DataTable可能已经属于另外一个DataSet了
                ds.Tables.Add(dts[i].Copy());
            }

            WriteExcel(ds, file, cellType);
        }

        public static void WriteExcel(DataTable[] dts, string file, string[] sheetNames, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            DataSet ds = new DataSet();
            for (int i = 0; i < dts.Length; i++)
            {
                // 如果不Copy一份，原DataTable可能已经属于另外一个DataSet了
                ds.Tables.Add(dts[i].Copy());
            }

            WriteExcel(ds, file, sheetNames, cellType);
        }

        public enum ExcelCellType { AllValue, ValueOrFormula };  // 确认当cell中的值以等号开头时，是以值的形式导出，还是以公式的形式导出

        private static ISheet AddExcelSheet(DataTable dt, ref IWorkbook workbook, string sheetName, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);

            // 不确认ICreationHelper这个对象是做什么用的，暂时没有启用
            // ICreationHelper chelper = workbook.GetCreationHelper();

            // 表头
            IRow head = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = head.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
                // cell.SetCellValue(chelper.CreateRichTextString(dt.Columns[i].ColumnName));
            }

            // 数据
            if (cellType == ExcelCellType.ValueOrFormula)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                        // cell.SetCellValue(chelper.CreateRichTextString(dt.Rows[i][j].ToString()));

                        if (dt.Rows[i][j].ToString().StartsWith("="))
                        {
                            cell.SetCellFormula(dt.Rows[i][j].ToString().Substring(1, dt.Rows[i][j].ToString().Length - 1));
                        }
                        else
                        {
                            cell.SetCellType(CellType.String);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                        // cell.SetCellValue(chelper.CreateRichTextString(dt.Rows[i][j].ToString()));

                        cell.SetCellType(CellType.String);
                    }
                }
            }

            return sheet;
        }

        /// <summary>
        /// 大容量数据导出
        /// 一般用不到，但是如果需要导出海量数据，导出时占用内存和CPU高，甚至直接内存溢出，可以使用这种方式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file"></param>
        /// <param name="cellType"></param>
        public static void WriteExcel2(DataTable dt, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            string sheetName = string.IsNullOrEmpty(dt.TableName) ? "Sheet1" : dt.TableName;
            WriteExcel2(dt, file, sheetName, cellType);
        }

        public static void WriteExcel2(DataTable dt, string file, string sheetName, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            // 创建workbook
            XSSFWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported.");
            }

            // SXSSFWorkbook类的构造函数参数为一个int类型，在这里表示一个阈值。
            // 比如设置阈值为100，通过创建的对象读取数据，每当内存中的对象数量达到100这个阈值，就会生成一个临时文件，以临时文件存储，实现分段读写。
            SXSSFWorkbook sswk = new SXSSFWorkbook(workbook, 500);
            // 创建sheet
            AddExcelSheet2(dt, ref sswk, sheetName, cellType);

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                sswk.Write(fs);
                // fs.Flush();
                // fs.Close();
            }
        }

        public static void WriteExcel2(DataSet ds, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            string[] sheetNames = new string[ds.Tables.Count];
            string sheetName;
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                sheetName = string.IsNullOrEmpty(ds.Tables[i].TableName) ? "Sheet" + (i + 1).ToString() : ds.Tables[i].TableName;
                sheetNames[i] = sheetName;
            }

            WriteExcel2(ds, file, sheetNames, cellType);
        }

        public static void WriteExcel2(DataSet ds, string file, string[] sheetNames, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            // 创建workbook
            XSSFWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported.");
            }

            SXSSFWorkbook sswk = new SXSSFWorkbook(workbook, 500);
            // 创建sheet
            if (sheetNames.Length >= ds.Tables.Count)
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    AddExcelSheet2(ds.Tables[i], ref sswk, sheetNames[i], cellType);
                }
            }
            else
            {
                for (int i = 0; i < sheetNames.Length; i++)
                {
                    AddExcelSheet2(ds.Tables[i], ref sswk, sheetNames[i], cellType);
                }
                string sheetName;
                for (int i = sheetNames.Length; i < ds.Tables.Count; i++)
                {
                    sheetName = string.IsNullOrEmpty(ds.Tables[i].TableName) ? "Sheet" + (i + 1).ToString() : ds.Tables[i].TableName;
                    AddExcelSheet2(ds.Tables[i], ref sswk, sheetName, cellType);
                }
            }

            // 保存为Excel文件
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                sswk.Write(fs);
                // fs.Flush();
                // fs.Close();
            }
        }

        public static void WriteExcel2(DataTable[] dts, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            DataSet ds = new DataSet();
            for (int i = 0; i < dts.Length; i++)
            {
                // 如果不Copy一份，原DataTable可能已经属于另外一个DataSet了
                ds.Tables.Add(dts[i].Copy());
            }

            WriteExcel2(ds, file, cellType);
        }

        public static void WriteExcel2(DataTable[] dts, string file, string[] sheetNames, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            DataSet ds = new DataSet();
            for (int i = 0; i < dts.Length; i++)
            {
                // 如果不Copy一份，原DataTable可能已经属于另外一个DataSet了
                ds.Tables.Add(dts[i].Copy());
            }

            WriteExcel2(ds, file, sheetNames, cellType);
        }

        private static ISheet AddExcelSheet2(DataTable dt, ref SXSSFWorkbook sswk, string sheetName, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            ISheet sheet = sswk.CreateSheet(sheetName);

            // 表头
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            // 数据
            if (cellType == ExcelCellType.ValueOrFormula)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());

                        if (dt.Rows[i][j].ToString().StartsWith("="))
                        {
                            cell.SetCellFormula(dt.Rows[i][j].ToString().Substring(1, dt.Rows[i][j].ToString().Length - 1));
                        }
                        else
                        {
                            cell.SetCellType(CellType.String);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());

                        cell.SetCellType(CellType.String);
                    }
                }
            }

            return sheet;
        }
        #endregion

        #region DataGridView导出Excel
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
                        if (dgvcell.FormattedValue != null)
                            cell.SetCellValue(dgvcell.FormattedValue.ToString());
                        else if (dgvcell.Value != null)
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
                        if (dgvcell.FormattedValue != null)
                            cell.SetCellValue(dgvcell.FormattedValue.ToString());
                        else if (dgvcell.Value != null)
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
        #endregion
        #endregion
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
