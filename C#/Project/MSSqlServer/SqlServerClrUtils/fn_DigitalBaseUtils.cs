using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_DecimalTo(SqlInt32 input, SqlInt32 baseto)
    {
        if (input.IsNull || baseto.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            if (baseto.Value == 2 || baseto.Value == 8 || baseto.Value == 16)
            {
                return (SqlString)Convert.ToString(input.Value, baseto.Value);
            }
            else
            {
                return SqlString.Null;
            }
        }
    }

    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlInt32 fn_DecimalFrom(SqlString input, SqlInt32 basefrom)
    {
        if (input.IsNull || basefrom.IsNull)
        {
            return SqlInt32.Null;
        }
        else
        {
            if (basefrom.Value == 2 || basefrom.Value == 8 || basefrom.Value == 16)
            {
                return (SqlInt32)Convert.ToInt32(input.Value, basefrom.Value);
            }
            else
            {
                return SqlInt32.Null;
            }
        }
    }
}
