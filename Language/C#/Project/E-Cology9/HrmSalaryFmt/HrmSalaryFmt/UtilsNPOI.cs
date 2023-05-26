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

        private static DataTable ISheet2DataTable(ISheet sheet)
        {
            DataTable dt = new DataTable();

            // 获取标题
            IRow header = sheet.GetRow(sheet.FirstRowNum);

            // 获取列的数量，也可以遍历所有行，取最大的列数，这里就不展开了
            int colA = header.FirstCellNum;
            int colZ = header.LastCellNum;
            for (int i = colA; i < colZ; i++)
                dt.Columns.Add(header.GetCell(i).StringCellValue, typeof(string));

            // 获取数据
            IRow row;
            for (int rowIndex = sheet.FirstRowNum + 1; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                if ((row = sheet.GetRow(rowIndex)) != null)  //null is when the row only contains empty cells
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
    }
}
