using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsCodeGenerator
    {
        public static string Generator(string connstr, string table, string namespace0)
        {
            List<CodeGenColumnInfo> columnInfos = GetCodeGenColumnsInfo(connstr, table);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + namespace0);
            sb.AppendLine("{");
            sb.AppendLine("    public static class TableModel" + table);
            sb.AppendLine("    {");
            foreach (CodeGenColumnInfo item in columnInfos)
            {
                sb.AppendLine($"        public {GetCSharpDataType(item.DataType, item.IsNullable)} {GetProperName(item.ColumnName)} {{ get; set; }}" + Environment.NewLine);
            }
            sb.Remove(sb.Length - 2, 2);  //去掉以后一个\r\n
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        public static string Generator2(string connstr, string table, string namespace0)
        {
            List<CodeGenColumnInfo> columnInfos = GetCodeGenColumnsInfo(connstr, table);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + namespace0);
            sb.AppendLine("{");
            sb.AppendLine("    public static class TableModel" + table);
            sb.AppendLine("    {");
            foreach (CodeGenColumnInfo item in columnInfos)
            {
                sb.AppendLine($"        public {GetCSharpDataType2(item.DataType, item.IsNullable)} {GetProperName(item.ColumnName)} {{ get; set; }}" + Environment.NewLine);
            }
            sb.Remove(sb.Length - 2, 2);  //去掉以后一个\r\n
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private static List<CodeGenColumnInfo> GetCodeGenColumnsInfo(string connStr, string table)
        {
            List<CodeGenColumnInfo> columnInfos = new List<CodeGenColumnInfo>();

            string sql = "select COLUMN_NAME, DATA_TYPE, IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @table";
            SqlParameter[] pms = new SqlParameter[1];
            pms[0] = new SqlParameter("@table", table);

            using (SqlDataReader reader = MyUtilsSqlServer.ExecuteReader(connStr, CommandType.Text, sql, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        columnInfos.Add(new CodeGenColumnInfo()
                        {
                            ColumnName = reader.GetString(0),
                            DataType = reader.GetString(1),
                            IsNullable = reader.GetString(2)
                        });
                    }
                }
            }

            return columnInfos;
        }

        //改为首字母大写
        private static string GetProperName(string columnName)
        {
            return char.ToUpper(columnName[0]) + columnName.Substring(1);
        }

        //将SQL Server数据类型转为C#数据类型
        private static string GetCSharpDataType(string sqlDataType, string isNullable)
        {
            Type csharpType = null;

            switch (sqlDataType)
            {
                case "int":
                    csharpType = typeof(int);
                    break;
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    csharpType = typeof(string);
                    break;
                case "decimal":
                case "money":
                case "numeric":
                case "smallmoney":
                    csharpType = typeof(decimal);
                    break;
                case "float":
                    csharpType = typeof(double);
                    break;
                case "bigint":
                    csharpType = typeof(long);
                    break;
                case "bit":
                    csharpType = typeof(bool);
                    break;
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    csharpType = typeof(DateTime);
                    break;
                case "datetimeoffset":
                    csharpType = typeof(DateTimeOffset);
                    break;
                case "tinyint":
                    csharpType = typeof(byte);
                    break;
                case "binary":
                case "filestream":
                case "image":
                case "rowversion":
                case "timestamp":
                case "varbinary":
                    csharpType = typeof(byte[]);
                    break;
                case "smallint":
                    csharpType = typeof(short);
                    break;
                case "real":
                    csharpType = typeof(Single);
                    break;
                case "time":
                    csharpType = typeof(TimeSpan);
                    break;
                case "uniqueidentifier":
                    csharpType = typeof(Guid);
                    break;
                //case "geography":
                //    csharpType = typeof(Microsoft.SqlServer.Types.SqlGeography);
                //    break;
                //case "geometry":
                //    csharpType = typeof(Microsoft.SqlServer.Types.SqlGeometry);
                //    break;
                //case "hierarchyid":
                //    csharpType = typeof(Microsoft.SqlServer.Types.SqlHierarchyId);
                //    break;
                case "sql_variant":
                    csharpType = typeof(object);
                    break;

                default:
                    csharpType = typeof(object);
                    break;
            }

            if (isNullable.ToUpper() == "YES" && csharpType.IsValueType)
            {
                return csharpType.ToString() + "?";
            }
            return csharpType.ToString();
        }

        private static string GetCSharpDataType2(string sqlDataType, string isNullable)
        {
            var typeinfo = new { typeType = typeof(object), typeString = "object" };

            switch (sqlDataType)
            {
                case "int":
                    typeinfo = new { typeType = typeof(int), typeString = "int" };
                    break;
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    typeinfo = new { typeType = typeof(string), typeString = "string" };
                    break;
                case "decimal":
                case "money":
                case "numeric":
                case "smallmoney":
                    typeinfo = new { typeType = typeof(decimal), typeString = "decimal" };
                    break;
                case "float":
                    typeinfo = new { typeType = typeof(double), typeString = "double" };
                    break;
                case "bigint":
                    typeinfo = new { typeType = typeof(long), typeString = "long" };
                    break;
                case "bit":
                    typeinfo = new { typeType = typeof(bool), typeString = "bool" };
                    break;
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    typeinfo = new { typeType = typeof(DateTime), typeString = "DateTime" };
                    break;
                case "datetimeoffset":
                    typeinfo = new { typeType = typeof(DateTimeOffset), typeString = "DateTimeOffset" };
                    break;
                case "tinyint":
                    typeinfo = new { typeType = typeof(byte), typeString = "byte" };
                    break;
                case "binary":
                case "filestream":
                case "image":
                case "rowversion":
                case "timestamp":
                case "varbinary":
                    typeinfo = new { typeType = typeof(byte[]), typeString = "byte[]" };
                    break;
                case "smallint":
                    typeinfo = new { typeType = typeof(short), typeString = "short" };
                    break;
                case "real":
                    typeinfo = new { typeType = typeof(Single), typeString = "Single" };
                    break;
                case "time":
                    typeinfo = new { typeType = typeof(TimeSpan), typeString = "TimeSpan" };
                    break;
                case "uniqueidentifier":
                    typeinfo = new { typeType = typeof(Guid), typeString = "Guid" };
                    break;
                //case "geography":
                //    csharpType = typeof(Microsoft.SqlServer.Types.SqlGeography);
                //    break;
                //case "geometry":
                //    csharpType = typeof(Microsoft.SqlServer.Types.SqlGeometry);
                //    break;
                //case "hierarchyid":
                //    csharpType = typeof(Microsoft.SqlServer.Types.SqlHierarchyId);
                //    break;
                case "sql_variant":
                    typeinfo = new { typeType = typeof(object), typeString = "object" };
                    break;

                default:
                    typeinfo = new { typeType = typeof(object), typeString = "object" };
                    break;
            }

            if (isNullable.ToUpper() == "YES" && typeinfo.typeType.IsValueType)
            {
                return typeinfo.typeString + "?";
            }
            return typeinfo.typeString;
        }

        private static string GetCSharpDataType0(string sqlDataType)
        {
            //按照数据类型的首字母排序，没有进行优化
            switch (sqlDataType)
            {
                case "bit":
                    return "bool";
                case "tinyint":
                    return "byte";
                case "binary":
                case "filestream":
                case "image":
                case "rowversion":
                case "timestamp":
                case "varbinary":
                    return "byte[]";
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    return "DateTime";
                case "datetimeoffset":
                    return "DateTimeOffset";
                case "decimal":
                case "money":
                case "numeric":
                case "smallmoney":
                    return "decimal";
                case "float":
                    return "double";
                case "uniqueidentifier":
                    return "Guid";
                case "int":
                    return "int";
                case "bigint":
                    return "long";
                case "geography":
                    return "Microsoft.SqlServer.Types.SqlGeography";
                case "geometry":
                    return "Microsoft.SqlServer.Types.SqlGeometry";
                case "hierarchyid":
                    return "Microsoft.SqlServer.Types.SqlHierarchyId";
                case "sql_variant":
                    return "object";
                case "smallint":
                    return "short";
                case "real":
                    return "Single";
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "string";
                case "time":
                    return "TimeSpan";
                default:
                    return "object";
            }
        }
    }

    internal class CodeGenColumnInfo
    {
        public string ColumnName { get; set; }

        public string DataType { get; set; }

        public string IsNullable { get; set; }
    }
}
