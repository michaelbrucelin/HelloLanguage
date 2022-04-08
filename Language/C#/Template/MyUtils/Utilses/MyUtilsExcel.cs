using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.FileIO;
using NPOI.XSSF.Streaming;
using WindowsFormsApp0.Ecology7;

namespace WindowsFormsApp0
{
    public static class MyUtilsExcel
    {
        public enum ExcelColumnDataType { AllString, ActualDataType };
        //NPOI excel读取
        //所有列按照字符串获取值
        public static DataTable ReadExcel_NPOI(string file)
        {
            return ReadExcel_NPOI(file, 0);
        }

        public static DataTable ReadExcel_NPOI(string file, string sheetName)
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

        public static DataTable ReadExcel_NPOI(string file, int sheetIndex)
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

            //获取标题
            IRow header = sheet.GetRow(sheet.FirstRowNum);
            //获取列的数量，也可以遍历所有行，取最大的列数，这里就不展开了
            int colA = header.FirstCellNum;
            int colZ = header.LastCellNum;
            for (int i = colA; i < colZ; i++)
            {
                dt.Columns.Add(header.GetCell(i).StringCellValue, typeof(string));
            }

            //获取数据
            IRow row;
            for (int rowIndex = sheet.FirstRowNum + 1; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                if ((row = sheet.GetRow(rowIndex)) != null) //null is when the row only contains empty cells 
                {
                    //这种用法，兼容性较高，例如第一行（标题）只有5列，第三行有6列时会只读取第三行的前5列，不会报错
                    DataRow dr = dt.NewRow();
                    int i = 0;
                    for (int colIndex = colA; colIndex < colZ; colIndex++)
                    {
                        dr[i] = row.GetCell(colIndex).StringCellValue;
                        i++;
                    }
                    dt.Rows.Add(dr);
                    //这种用法，当表格不规范，例如第一行只有5列（标题），第三行有6列时会报错
                    //dt.Rows.Add(row.Cells.ToArray());
                }
            }

            return dt;
        }

        //NPOI excel读取
        //获取excel列真实的数据类型，但是没有完善，如果需要在生产环境中使用，需要继续完善
        //不建议在生产环境中使用，因为excel源可能的问题太多，如果需要真实的数据类型，可以考虑按照string导入后，在DataTable中处理
        public static DataTable ReadExcel_NPOI2(string file, ExcelColumnDataType excelColumnDataType)
        {
            return ReadExcel_NPOI2(file, 0, excelColumnDataType);
        }

        public static DataTable ReadExcel_NPOI2(string file, string sheetName, ExcelColumnDataType excelColumnDataType)
        {
            IWorkbook workbook;
            string fileExtension = Path.GetExtension(file).ToLower();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                //XSSFWorkbook适用xlsx格式，HSSFWorkbook适用xls格式
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

        public static DataTable ReadExcel_NPOI2(string file, int sheetIndex, ExcelColumnDataType excelColumnDataType)
        {
            IWorkbook workbook;
            string fileExtension = Path.GetExtension(file).ToLower();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                //XSSFWorkbook适用xlsx格式，HSSFWorkbook适用xls格式
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

            //表头及列的数据类型
            IRow header = sheet.GetRow(sheet.FirstRowNum);
            List<int> columns = new List<int>();
            if (excelColumnDataType == ExcelColumnDataType.AllString)
            {
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = ReadExcelCellValue_NPOI(header.GetCell(i));
                    if (obj == null || obj.ToString().Length == 0)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    }
                    columns.Add(i);
                }
            }
            else if (excelColumnDataType == ExcelColumnDataType.ActualDataType)
            {
                IRow firstrow = sheet.GetRow(sheet.FirstRowNum + 1);
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = ReadExcelCellValue_NPOI(header.GetCell(i));
                    if (obj == null || obj.ToString().Length == 0)
                    {
                        dt.Columns.Add(new DataColumn("Columns" + i.ToString(), ReadExcelCellDataType_NPOI(firstrow.GetCell(i))));
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn(obj.ToString(), ReadExcelCellDataType_NPOI(firstrow.GetCell(i))));
                    }
                    columns.Add(i);
                }
            }
            else
            {
                return null;
            }

            //获取数据  
            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                DataRow dr = dt.NewRow();
                bool hasValue = false;
                foreach (int j in columns)
                {
                    //判断非空行 非空格
                    if (sheet.GetRow(i) != null && sheet.GetRow(i).GetCell(j) != null)
                    {
                        dr[j] = ReadExcelCellValue_NPOI(sheet.GetRow(i).GetCell(j));
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

        //NPOI 读取Cell中的值；公式没有错的时候，取公式计算的值，公式有错的时候，使用公式
        private static object ReadExcelCellValue_NPOI(ICell cell)
        {
            if (cell == null)
            {
                return null;
            }
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
                default:
                    try
                    {
                        return cell.NumericCellValue;
                    }
                    catch
                    {
                        return "=" + cell.CellFormula;
                    }
            }
        }

        //NPOI 读取Cell中的值的数据类型
        private static Type ReadExcelCellDataType_NPOI(ICell cell)
        {
            if (cell == null)
            {
                return null;
            }
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return null;
                case CellType.Boolean:
                    return typeof(bool);
                case CellType.Numeric:
                    return typeof(decimal);
                case CellType.String:
                    return typeof(string);
                case CellType.Error:
                    return typeof(string);
                case CellType.Formula:
                default:
                    return typeof(string);
            }
        }

        //NPOI excel导出
        public static void WriteExcel_NPOI(DataTable dt, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            string sheetName = string.IsNullOrEmpty(dt.TableName) ? "Sheet1" : dt.TableName;
            WriteExcel_NPOI(dt, file, sheetName, cellType);
        }

        public static void WriteExcel_NPOI(DataTable dt, string file, string sheetName, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            //创建workbook
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
                //return;
            }

            //创建sheet
            AddExcelSheet_NPOI(dt, ref workbook, sheetName, cellType);

            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
                //fs.Flush();
                //fs.Close();
            }

            //下面是老代码，不确认为什么要额外套一层MemoryStream
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    workbook.Write(stream);
            //    byte[] buffer = stream.ToArray();

            //    //保存为Excel文件  
            //    using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            //    {
            //        fs.Write(buffer, 0, buffer.Length);
            //        fs.Flush();
            //        fs.Close();
            //    }
            //}
        }

        public static void WriteExcel_NPOI(DataSet ds, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            string[] sheetNames = new string[ds.Tables.Count];
            string sheetName;
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                sheetName = string.IsNullOrEmpty(ds.Tables[i].TableName) ? "Sheet" + (i + 1).ToString() : ds.Tables[i].TableName;
                sheetNames[i] = sheetName;
            }

            WriteExcel_NPOI(ds, file, sheetNames, cellType);
        }

        public static void WriteExcel_NPOI(DataSet ds, string file, string[] sheetNames, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            //创建workbook
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
                //return;
            }

            //创建sheet
            if (sheetNames.Length >= ds.Tables.Count)
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    AddExcelSheet_NPOI(ds.Tables[i], ref workbook, sheetNames[i], cellType);
                }
            }
            else
            {
                for (int i = 0; i < sheetNames.Length; i++)
                {
                    AddExcelSheet_NPOI(ds.Tables[i], ref workbook, sheetNames[i], cellType);
                }
                string sheetName;
                for (int i = sheetNames.Length; i < ds.Tables.Count; i++)
                {
                    sheetName = string.IsNullOrEmpty(ds.Tables[i].TableName) ? "Sheet" + (i + 1).ToString() : ds.Tables[i].TableName;
                    AddExcelSheet_NPOI(ds.Tables[i], ref workbook, sheetName, cellType);
                }
            }

            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
                //fs.Flush();
                //fs.Close();
            }
        }

        public static void WriteExcel_NPOI(DataTable[] dts, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            DataSet ds = new DataSet();
            for (int i = 0; i < dts.Length; i++)
            {
                //如果不Copy一份，原DataTable可能已经属于另外一个DataSet了
                ds.Tables.Add(dts[i].Copy());
            }

            WriteExcel_NPOI(ds, file, cellType);
        }

        public static void WriteExcel_NPOI(DataTable[] dts, string file, string[] sheetNames, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            DataSet ds = new DataSet();
            for (int i = 0; i < dts.Length; i++)
            {
                //如果不Copy一份，原DataTable可能已经属于另外一个DataSet了
                ds.Tables.Add(dts[i].Copy());
            }

            WriteExcel_NPOI(ds, file, sheetNames, cellType);
        }

        public enum ExcelCellType { AllValue, ValueOrFormula };  //确认当cell中的值以等号开头时，是以值的形式导出，还是以公式的形式导出
        private static ISheet AddExcelSheet_NPOI(DataTable dt, ref IWorkbook workbook, string sheetName, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);

            //不确认ICreationHelper这个对象是做什么用的，暂时没有启用
            //ICreationHelper chelper = workbook.GetCreationHelper();

            //表头
            IRow head = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = head.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
                //cell.SetCellValue(chelper.CreateRichTextString(dt.Columns[i].ColumnName));
            }

            //数据
            if (cellType == ExcelCellType.ValueOrFormula)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                        //cell.SetCellValue(chelper.CreateRichTextString(dt.Rows[i][j].ToString()));

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
                        //cell.SetCellValue(chelper.CreateRichTextString(dt.Rows[i][j].ToString()));

                        cell.SetCellType(CellType.String);
                    }
                }
            }

            return sheet;
        }

        //NPOI excel导出，大容量数据导出
        //一般用不到，但是如果需要导出海量数据，导出时占用内存和CPU高，甚至直接内存溢出，可以使用这种方式
        public static void WriteExcel_NPOI2(DataTable dt, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            string sheetName = string.IsNullOrEmpty(dt.TableName) ? "Sheet1" : dt.TableName;
            WriteExcel_NPOI2(dt, file, sheetName, cellType);
        }

        public static void WriteExcel_NPOI2(DataTable dt, string file, string sheetName, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            //创建workbook
            XSSFWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported.");
                //return;
            }

            //SXSSFWorkbook类的构造函数参数为一个int类型，在这里表示一个阈值。
            //比如设置阈值为100，通过创建的对象读取数据，每当内存中的对象数量达到100这个阈值，就会生成一个临时文件，以临时文件存储，实现分段读写。
            SXSSFWorkbook sswk = new SXSSFWorkbook(workbook, 500);
            //创建sheet
            AddExcelSheet_NPOI2(dt, ref sswk, sheetName, cellType);

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                sswk.Write(fs);
                //fs.Flush();
                //fs.Close();
            }
        }

        public static void WriteExcel_NPOI2(DataSet ds, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            string[] sheetNames = new string[ds.Tables.Count];
            string sheetName;
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                sheetName = string.IsNullOrEmpty(ds.Tables[i].TableName) ? "Sheet" + (i + 1).ToString() : ds.Tables[i].TableName;
                sheetNames[i] = sheetName;
            }

            WriteExcel_NPOI2(ds, file, sheetNames, cellType);
        }

        public static void WriteExcel_NPOI2(DataSet ds, string file, string[] sheetNames, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            //创建workbook
            XSSFWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported.");
                //return;
            }

            SXSSFWorkbook sswk = new SXSSFWorkbook(workbook, 500);
            //创建sheet
            if (sheetNames.Length >= ds.Tables.Count)
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    AddExcelSheet_NPOI2(ds.Tables[i], ref sswk, sheetNames[i], cellType);
                }
            }
            else
            {
                for (int i = 0; i < sheetNames.Length; i++)
                {
                    AddExcelSheet_NPOI2(ds.Tables[i], ref sswk, sheetNames[i], cellType);
                }
                string sheetName;
                for (int i = sheetNames.Length; i < ds.Tables.Count; i++)
                {
                    sheetName = string.IsNullOrEmpty(ds.Tables[i].TableName) ? "Sheet" + (i + 1).ToString() : ds.Tables[i].TableName;
                    AddExcelSheet_NPOI2(ds.Tables[i], ref sswk, sheetName, cellType);
                }
            }

            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                sswk.Write(fs);
                //fs.Flush();
                //fs.Close();
            }
        }

        public static void WriteExcel_NPOI2(DataTable[] dts, string file, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            DataSet ds = new DataSet();
            for (int i = 0; i < dts.Length; i++)
            {
                //如果不Copy一份，原DataTable可能已经属于另外一个DataSet了
                ds.Tables.Add(dts[i].Copy());
            }

            WriteExcel_NPOI2(ds, file, cellType);
        }

        public static void WriteExcel_NPOI2(DataTable[] dts, string file, string[] sheetNames, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            DataSet ds = new DataSet();
            for (int i = 0; i < dts.Length; i++)
            {
                //如果不Copy一份，原DataTable可能已经属于另外一个DataSet了
                ds.Tables.Add(dts[i].Copy());
            }

            WriteExcel_NPOI2(ds, file, sheetNames, cellType);
        }

        private static ISheet AddExcelSheet_NPOI2(DataTable dt, ref SXSSFWorkbook sswk, string sheetName, ExcelCellType cellType = ExcelCellType.AllValue)
        {
            ISheet sheet = sswk.CreateSheet(sheetName);

            //表头
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据
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

        //OLEDB excel读取
        public static DataTable ReadExcel_OLEDB(string file, bool hasTitle = true)
        {
            DataTable dt = new DataTable();

            string connStr, sheetName;
            if (Path.GetExtension(file).ToLower() == ".xlsx")
            {
                connStr = string.Format("Provider=Microsoft.Ace.OLEDB.12.0;Extended Properties=\"Excel 12.0;HDR={0};IMEX=1;\";data source={1};", (hasTitle ? "Yes" : "NO"), file);
            }
            else if (Path.GetExtension(file).ToLower() == ".xls")
            {
                connStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0;HDR={0};IMEX=1;\";data source={1};", (hasTitle ? "Yes" : "NO"), file);
            }
            else
            {
                return null;
            }

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                sheetName = schemaTable.Rows[0][2].ToString().Trim();

                string sql = "SELECT * FROM [" + sheetName + "]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn))
                {
                    adapter.Fill(dt);
                }

            }

            return dt;
        }

        //OLEDB excel读取，reader
        public static OleDbDataReader ReadExcel_OLEDB_Reader(string file, bool hasTitle = true)
        {
            DataTable dt = new DataTable();

            string connStr, sheetName;
            if (Path.GetExtension(file).ToLower() == ".xlsx")
            {
                connStr = string.Format("Provider=Microsoft.Ace.OLEDB.12.0;Extended Properties=\"Excel 12.0;HDR={0};IMEX=1;\";data source={1};", (hasTitle ? "Yes" : "NO"), file);
            }
            else if (Path.GetExtension(file).ToLower() == ".xls")
            {
                connStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0;HDR={0};IMEX=1;\";data source={1};", (hasTitle ? "Yes" : "NO"), file);
            }
            else
            {
                return null;
            }

            //由于SqlDataReader是面对连接的，所以SQLConnection不能Close，这里猜测OleDb是一样的，故没有写在using中，但是并不确认
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            sheetName = schemaTable.Rows[0][2].ToString().Trim();

            string sql = "SELECT * FROM [" + sheetName + "]";
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //使用方法
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //    {
                //        Console.WriteLine("col0:{0}\tcol1:{1}\t", reader.GetValue(0), reader.GetValue(1));
                //    }
                //}
            }

        }

        //OLEDB excel导出
        public static void WriteExcel_OLEDB(DataTable dt, string file)
        {
            string connStr;
            if (Path.GetExtension(file).ToLower() == ".xlsx")
            {
                connStr = string.Format("Provider=Microsoft.Ace.OLEDB.12.0;Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=3;\";data source={0};", file);
            }
            else if (Path.GetExtension(file).ToLower() == ".xls")
            {
                connStr = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=3;\";data source={0};", file);
            }
            else
            {
                return;
            }

            //获取表名
            string sheetName = "MySheet";
            if (dt.TableName.Length > 0)
            {
                sheetName = dt.TableName;
            }
            //获取列名
            string[] colsCreateArray = new string[dt.Columns.Count];
            string[] colsInsertArray = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                colsCreateArray[i] = dt.Columns[i].ColumnName + " varchar";
                colsInsertArray[i] = dt.Columns[i].ColumnName;
            }
            string colCreateStr = string.Join(",", colsCreateArray);
            string colInsertStr = string.Join(",", colsInsertArray);

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    //创建sheet，写入列头
                    cmd.CommandText = "create table [" + sheetName + "](" + colCreateStr + ")";
                    cmd.ExecuteNonQuery();

                    //拼接insert语句
                    string[] valArray = new string[dt.Columns.Count];
                    string valStr = string.Empty;
                    //写入数据
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            valArray[j] = "'" + dt.Rows[i][j].ToString() + "'";
                        }
                        valStr = string.Join(",", valArray);

                        cmd.CommandText = "insert into [" + sheetName + "](" + colInsertStr + ") VALUES(" + valStr + ");";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        //COM excel读取，单线程读取，比较慢
        public static DataTable ReadExcel_COM_SingleThread(string file)
        {
            DataTable dt = new DataTable();
            Excel.Application app = new Excel.Application();
            Excel.Workbooks books = app.Workbooks;
            Excel.Worksheet sheet;
            object oMissiong = Missing.Value;

            try
            {
                //建立Excel对象
                books.Open(file, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                //获取第一个sheet
                sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                if (sheet == null)
                {
                    return null;
                }

                dt.TableName = sheet.Name;

                for (int i = 1; i <= sheet.UsedRange.Rows.Count; i++)
                {
                    if (i == 1)
                    {
                        //读取列头
                        for (int j = 1; j <= sheet.UsedRange.Columns.Count; j++)
                        {
                            Excel.Range range = sheet.Range[app.Cells[i, j], app.Cells[i, j]];
                            range.Select();

                            string colName = app.ActiveCell.Text.ToString();
                            //判断是否存在重复列名
                            if (dt.Columns.Contains(colName))
                            {
                                dt.Columns.Add(colName + "_1");
                            }
                            else
                            {
                                dt.Columns.Add(colName);
                            }
                        }
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 1; j <= sheet.UsedRange.Columns.Count; j++)
                        {
                            Excel.Range range = sheet.Range[app.Cells[i, j], app.Cells[i, j]];
                            range.Select();
                            dr[j - 1] = app.ActiveCell.Text.ToString();
                        }
                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                books.Close();
                Marshal.ReleaseComObject(books);
                books = null;
                app.Workbooks.Close();
                app.Quit();
                Marshal.ReleaseComObject(app);
                app = null;
                Process[] procs = Process.GetProcessesByName("excel");
                foreach (Process pro in procs)
                {
                    //没有更好的方法,只有杀掉进程
                    pro.Kill();
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        //COM excel读取，多线程读取（1 主线程、4 副线程），比较快
        public static DataTable ReadExcel_COM_MultiThread(string file)
        {
            DataTable dt = new DataTable();
            Excel.Application app = new Excel.Application();
            Excel.Workbooks books = app.Workbooks;
            Excel.Worksheet sheet;
            object oMissiong = Missing.Value;

            try
            {
                //建立Excel对象
                books.Open(file, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                //获取第一个sheet
                sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
                if (sheet == null)
                {
                    return null;
                }

                dt.TableName = sheet.Name;

                string cellContent;
                int iRowCount = sheet.UsedRange.Rows.Count;
                int iColCount = sheet.UsedRange.Columns.Count;
                Excel.Range range;

                //负责列头Start
                DataColumn dc;
                int ColumnID = 1;
                range = (Excel.Range)sheet.Cells[1, 1];
                while (iColCount >= ColumnID)
                {
                    dc = new DataColumn();
                    dc.DataType = Type.GetType("System.String");
                    string newColumnName = range.Text.ToString().Trim();
                    if (newColumnName.Length == 0)
                    {
                        newColumnName = "_1";
                    }
                    //判断列名是否重复
                    for (int i = 1; i < ColumnID; i++)
                    {
                        if (dt.Columns[i - 1].ColumnName == newColumnName)
                        {
                            newColumnName = newColumnName + "_1";
                        }
                    }
                    dc.ColumnName = newColumnName;
                    dt.Columns.Add(dc);
                    range = (Excel.Range)sheet.Cells[1, ++ColumnID];
                }
                //End

                //数据大于500条，使用多进程进行读取数据
                if (iRowCount - 1 > 500)
                {
                    //开始多线程读取数据
                    //新建线程
                    int b2 = (iRowCount - 1) / 10;
                    DataTable dt1 = new DataTable("dt1");
                    dt1 = dt.Clone();
                    WorkSheetOptions sheet1thread = new WorkSheetOptions(sheet, iColCount, 2, b2 + 1, dt1);
                    Thread othread1 = new Thread(new ThreadStart(sheet1thread.SheetToDataTable));
                    othread1.Start();                  //启动线程
                    //阻塞 1 毫秒，保证第一个读取 dt1
                    Thread.Sleep(1);

                    DataTable dt2 = new DataTable("dt2");
                    dt2 = dt.Clone();
                    WorkSheetOptions sheet2thread = new WorkSheetOptions(sheet, iColCount, b2 + 2, b2 * 2 + 1, dt2);
                    Thread othread2 = new Thread(new ThreadStart(sheet2thread.SheetToDataTable));
                    othread2.Start();

                    DataTable dt3 = new DataTable("dt3");
                    dt3 = dt.Clone();
                    WorkSheetOptions sheet3thread = new WorkSheetOptions(sheet, iColCount, b2 * 2 + 2, b2 * 3 + 1, dt3);
                    Thread othread3 = new Thread(new ThreadStart(sheet3thread.SheetToDataTable));
                    othread3.Start();

                    DataTable dt4 = new DataTable("dt4");
                    dt4 = dt.Clone();
                    WorkSheetOptions sheet4thread = new WorkSheetOptions(sheet, iColCount, b2 * 3 + 2, b2 * 4 + 1, dt4);
                    Thread othread4 = new Thread(new ThreadStart(sheet4thread.SheetToDataTable));
                    othread4.Start();

                    //主线程读取剩余数据
                    for (int iRow = b2 * 4 + 2; iRow <= iRowCount; iRow++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int iCol = 1; iCol <= iColCount; iCol++)
                        {
                            range = (Excel.Range)sheet.Cells[iRow, iCol];
                            cellContent = (range.Value2 == null) ? "" : range.Text.ToString();
                            dr[iCol - 1] = cellContent;
                        }
                        dt.Rows.Add(dr);
                    }

                    othread1.Join();
                    othread2.Join();
                    othread3.Join();
                    othread4.Join();

                    //将多个线程读取出来的数据追加至 dt1 后面
                    foreach (DataRow dr in dt2.Rows)
                    {
                        dt1.Rows.Add(dr.ItemArray);
                    }
                    dt2.Clear();
                    dt2.Dispose();

                    foreach (DataRow dr in dt3.Rows)
                    {
                        dt1.Rows.Add(dr.ItemArray);
                    }
                    dt3.Clear();
                    dt3.Dispose();

                    foreach (DataRow dr in dt4.Rows)
                    {
                        dt1.Rows.Add(dr.ItemArray);
                    }
                    dt4.Clear();
                    dt4.Dispose();

                    foreach (DataRow dr in dt.Rows)
                    {
                        dt1.Rows.Add(dr.ItemArray);
                    }
                    dt.Clear();
                    dt.Dispose();

                    return dt1;
                }
                else
                {
                    for (int iRow = 2; iRow <= iRowCount; iRow++)
                    {
                        DataRow dr = dt.NewRow();
                        for (int iCol = 1; iCol <= iColCount; iCol++)
                        {
                            range = (Excel.Range)sheet.Cells[iRow, iCol];
                            cellContent = (range.Value2 == null) ? "" : range.Text.ToString();
                            dr[iCol - 1] = cellContent;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                //将数据读入到DataTable中——End
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                books.Close();
                Marshal.ReleaseComObject(books);
                books = null;
                app.Workbooks.Close();
                app.Quit();
                Marshal.ReleaseComObject(app);
                app = null;
                Process[] procs = Process.GetProcessesByName("excel");
                foreach (Process pro in procs)
                {
                    //没有更好的方法,只有杀掉进程
                    pro.Kill();
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        //COM excel导出，按单元格（cell）导出
        public static void WriteExcel_COM_Cell(DataSet ds, string file)
        {
            //建立一个Excel进程
            Excel.Application app = new Excel.Application();
            Excel.Workbook book = null;
            Excel.Worksheet sheet;
            Excel.Range range;
            object oMissiong = Missing.Value;

            try
            {
                book = app.Workbooks.Add(oMissiong);
                app.DisplayAlerts = false;//不显示警告  

                for (int k = 0; k < ds.Tables.Count; k++)
                {
                    sheet = (Excel.Worksheet)book.Worksheets.Add(oMissiong, oMissiong, oMissiong, oMissiong);
                    if (ds.Tables[k] != null)
                    {
                        sheet.Name = ds.Tables[k].TableName;
                        //写入标题  
                        for (int i = 0; i < ds.Tables[k].Columns.Count; i++)
                        {
                            sheet.Cells[1, i + 1] = ds.Tables[k].Columns[i].ColumnName;
                            range = (Excel.Range)sheet.Cells[1, i + 1];
                            range.RowHeight = 15;             //行高
                            //range.EntireRow.AutoFit();      //自动调整行高
                            range.Interior.ColorIndex = 15;   //设置颜色
                            range.Font.Bold = true;
                            range.NumberFormatLocal = "@";    //文本格式  
                            range.EntireColumn.AutoFit();     //自动调整列宽  
                            // range.WrapText = true;         //文本自动换行    
                        }
                        //写入数值  
                        for (int r = 0; r < ds.Tables[k].Rows.Count; r++)
                        {
                            for (int i = 0; i < ds.Tables[k].Columns.Count; i++)
                            {
                                sheet.Cells[r + 2, i + 1] = ds.Tables[k].Rows[r][i];
                                //Range myrange = worksheetData.get_Range(worksheetData.Cells[r + 2, i + 1], worksheetData.Cells[r + 3, i + 2]);  
                                //myrange.NumberFormatLocal = "@";//文本格式  
                            }
                        }
                    }
                    sheet.Columns.EntireColumn.AutoFit();
                    book.Saved = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                book.SaveCopyAs(file);
                book.Close(false, oMissiong, oMissiong);
                app.Quit();
                GC.Collect();
            }
        }

        //COM excel导出，按范围（range）导出
        public static void WriteExcel_COM_Range(DataTable dt, string file)
        {
            //建立一个Excel进程
            Excel.Application app = new Excel.Application();
            Excel.Workbook book = null;
            Excel.Worksheet sheet;
            Excel.Range range;
            object oMissiong = Missing.Value;

            try
            {
                book = app.Workbooks.Add(oMissiong);
                app.DisplayAlerts = false;//不显示警告  
                sheet = (Excel.Worksheet)book.Worksheets.Add(oMissiong, oMissiong, oMissiong, oMissiong);

                if (dt != null)
                {
                    if (dt.TableName.Length > 0)
                    {
                        sheet.Name = dt.TableName;
                    }
                    int rowCount = dt.Rows.Count;//不包括字段名 
                    int colCount = dt.Columns.Count;
                    int colIndex = 0;
                    //写入标题  
                    foreach (DataColumn col in dt.Columns)
                    {
                        colIndex++;
                        //appExcel.Cells[1, colIndex] = col.ColumnName;
                        sheet.Cells[1, colIndex] = col.ColumnName;
                        range = (Excel.Range)sheet.Cells[1, colIndex];
                        range.RowHeight = 15;             //行高
                        //range.EntireRow.AutoFit();      //自动调整行高
                        range.Interior.ColorIndex = 15;   //设置颜色
                        //range.Font.Size = 10;           //字体大小
                        range.Font.Bold = true;           //加粗
                        range.NumberFormatLocal = "@";    //文本格式  
                        range.EntireColumn.AutoFit();     //自动调整列宽  
                        // range.WrapText = true;         //文本自动换行    
                        //range.ColumnWidth = 25;         //列宽
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;    //居中
                    }

                    object[,] objData = new object[rowCount, colCount];

                    //范围
                    for (int r = 0; r < rowCount; r++)
                    {
                        for (int c = 0; c < colCount; c++)
                        {
                            objData[r, c] = dt.Rows[r][c];
                        }
                    }

                    // 写入Excel
                    range = sheet.Range[app.Cells[2, 1], app.Cells[rowCount + 1, colCount]];
                    range.Value2 = objData;
                    //worksheetData.get_Range(appExcel.Cells[2, 1], appExcel.Cells[rowNumber + 1, 1]).NumberFormat = "yyyy-m-d h:mm"; 

                }
                sheet.Columns.EntireColumn.AutoFit();
                book.Saved = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                book.SaveCopyAs(file);
                book.Close(false, oMissiong, oMissiong);
                app.Quit();
                GC.Collect();
            }
        }

        public static DataTable ReadCsv_VB(string file, bool hasTitle = true, params string[] delimiters)
        {
            DataTable dt = new DataTable();

            using (TextFieldParser parser = new TextFieldParser(file))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(delimiters);

                int r = 1;
                if (hasTitle == true)
                {
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (r == 1)
                        {
                            foreach (string field in fields)
                            {
                                dt.Columns.Add(field);
                            }
                        }
                        else
                        {
                            dt.Rows.Add(fields);
                        }

                        r++;
                    }
                }
                else
                {
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (r == 1)
                        {
                            for (int i = 0; i < fields.Length; i++)
                            {
                                dt.Columns.Add("F" + (i + 1).ToString());
                            }

                            dt.Rows.Add(fields);
                        }
                        else
                        {
                            dt.Rows.Add(fields);
                        }

                        r++;
                    }
                }
            }

            return dt;
        }

        public static DataTable ReadCsv_VB(string file, bool hasTitle = true)
        {
            string[] delimiters = new string[] { "," };

            return ReadCsv_VB(file, hasTitle, delimiters);
        }

        //csv写入
        //参考：https://stackoverflow.com/questions/4959722/c-sharp-datatable-to-csv
        public static void WriteCsv_IO(DataTable dt, string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                writer.WriteLine(string.Join(",", columnNames));

                foreach (DataRow row in dt.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                    writer.WriteLine(string.Join(",", fields));
                }
            }
        }
    }

    public class WorkSheetOptions
    {
        Excel.Worksheet worksheet;
        int iColCount, start, end;
        DataTable dt;

        public WorkSheetOptions(Excel.Worksheet worksheet, int iColCount, int start, int end, System.Data.DataTable dt)
        {
            this.worksheet = worksheet;
            this.iColCount = iColCount;
            this.start = start;
            this.end = end;
            this.dt = dt;
        }

        public void SheetToDataTable()
        {
            string cellContent;
            Excel.Range range;
            for (int iRow = start; iRow <= end; iRow++)
            {
                System.Data.DataRow dr = dt.NewRow();
                for (int iCol = 1; iCol <= iColCount; iCol++)
                {
                    range = (Excel.Range)worksheet.Cells[iRow, iCol];
                    cellContent = (range.Value2 == null) ? "" : range.Text.ToString();
                    dr[iCol - 1] = cellContent;
                }
                dt.Rows.Add(dr);
            }
        }
    }
}
