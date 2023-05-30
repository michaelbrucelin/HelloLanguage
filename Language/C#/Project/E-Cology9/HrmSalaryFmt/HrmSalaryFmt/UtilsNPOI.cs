using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmSalaryFmt
{
    public static class UtilsNPOI
    {
        public static DataTable ReadExcel_NPOI(string file, string sheetName)
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

            return ISheet2DataTable(sheet);
        }

        private static DataTable ISheet2DataTable(ISheet sheet)
        {
            DataTable dt = new DataTable();

            // 表头及列的数据类型
            IRow header = sheet.GetRow(sheet.FirstRowNum);
            List<int> columns = new List<int>();

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


            // 获取数据
            for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
            {
                DataRow dr = dt.NewRow();
                bool hasValue = false;
                foreach (int j in columns)
                {
                    // 判断非空行 非空格
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

        /// <summary>
        /// NPOI 读取Cell中的值；公式没有错的时候，取公式计算的值，公式有错的时候，使用公式
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
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

        /// <summary>
        /// NPOI 读取Cell中的值的数据类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static Type ReadExcelCellDataType_NPOI(ICell cell)
        {
            if (cell == null)
            {
                return null;
            }
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return typeof(string);
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

        public static void WriteExcel_NPOI(DataTable dt, string file, string sheetName)
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
                // return;
            }

            // 创建sheet
            AddExcelSheet_NPOI(dt, ref workbook, sheetName);

            // 保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
                // fs.Flush();
                // fs.Close();
            }
        }

        private static ISheet AddExcelSheet_NPOI(DataTable dt, ref IWorkbook workbook, string sheetName)
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

            return sheet;
        }
    }
}
