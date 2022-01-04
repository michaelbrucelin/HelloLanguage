using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    //private static readonly Random random = new Random();

    //在没有添加seed参数前，在sql server中将查询的结果写入临时表，再次使用的时候就不再随机，不确认是为什么
    //select fn_RandomStr('0123456789', 12) into #temp，执行了这个语句之后，函数就失效了，只返回第一个参数的第一个字符，这里就是返回0
    //sql server调用时可以使用ABS(CHECKSUM(NEWID()))或CHECKSUM(NEWID())作为seed参数传入
    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_RandomStr(SqlInt32 seed, SqlString chars, SqlInt32 length)
    {
        Random random = new Random(seed.Value);

        if (chars.IsNull || length.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            return (SqlString)new string(Enumerable.Repeat(chars.Value, length.Value)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    //在没有添加seed参数前，在sql server中调用反复执行多次，仍然每次都是一个值，不确认是什么原因导致的
    //sql server调用时可以使用ABS(CHECKSUM(NEWID()))或CHECKSUM(NEWID())作为seed参数传入
    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlInt32 fn_RandomInt(SqlInt32 seed, SqlInt32 minValue, SqlInt32 maxValue)
    {
        Random random = new Random(seed.Value);

        if (minValue.IsNull || maxValue.IsNull)
        {
            return SqlInt32.Null;
        }
        else
        {
            return (SqlInt32)random.Next(minValue.Value, maxValue.Value);
        }
    }

    //将传入的字符串按指定的分隔符拆分为列表，随机返回其中的一项
    //sql server调用时可以使用ABS(CHECKSUM(NEWID()))或CHECKSUM(NEWID())作为seed参数传入
    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_RandomItem(SqlInt32 seed, SqlString input, SqlString spliter)
    {
        Random random = new Random(seed.Value);

        if (input.IsNull || spliter.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            string[] arr = input.Value.Split(spliter.Value.ToCharArray());
            return (SqlString)arr[random.Next(0, arr.Length)];
        }
    }

    //将传入的指定表的指定列，随机返回其中的一行（通常用于随机返回唯一主键，就相当于随机行了）
    //sql server调用时可以使用ABS(CHECKSUM(NEWID()))或CHECKSUM(NEWID())作为seed参数传入
    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.Read)]
    public static SqlString fn_RandomKey(SqlInt32 seed, SqlString table, SqlString column)
    {
        string rslt = string.Empty;

        if (table.IsNull || column.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            using (SqlConnection conn = new SqlConnection("Context Connection = true;"))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"select COUNT(*) from {table.Value}";
                    int total = (int)cmd.ExecuteScalar();

                    Random random = new Random(seed.Value);
                    int r = random.Next(1, total + 1);

                    cmd.CommandText = $"select top ({r}) {column.Value} from {table.Value}";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        int i = 1;
                        while (reader.Read())
                        {
                            if (i == r)
                            {
                                rslt = reader[0].ToString();
                            }
                            i++;
                        }
                    }
                }
            }

            return (SqlString)(rslt.Length == 0 ? SqlString.Null : rslt);
        }
    }
}
