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
    public static SqlBoolean fn_RegExIsMatch(SqlString inputStr, SqlString regExStr)
    {
        if (inputStr.IsNull || regExStr.IsNull)
        {
            return SqlBoolean.Null;
        }
        else
        {
            return (SqlBoolean)Regex.IsMatch(inputStr.Value, regExStr.Value, RegexOptions.CultureInvariant);
        }
    }

    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_RegExMatch(SqlString inputStr, SqlString regExStr)
    {
        if (inputStr.IsNull || regExStr.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            return (SqlString)Regex.Match(inputStr.Value, regExStr.Value, RegexOptions.CultureInvariant).Value;
        }
    }

    [SqlFunction(IsDeterministic = true, FillRowMethodName = "ArrSplitFillRow",
                 DataAccess = DataAccessKind.None, TableDefinition = "pos INT, element NVARCHAR(max)")]
    public static IEnumerable fn_RegExMatches(SqlString inputStr, SqlString regExStr)
    {
        List<row_item> MatchesString = new List<row_item>();

        if (inputStr.IsNull || regExStr.IsNull)
        {
            row_item r = new row_item();
            r.item = null;
            r.pos = 1;
        }
        else
        {
            MatchCollection matchCol = Regex.Matches(inputStr.Value, regExStr.Value, RegexOptions.CultureInvariant);
            int i = 1;
            foreach (Match m in matchCol)
            {
                row_item r = new row_item();
                r.item = m.Value;
                r.pos = i;
                MatchesString.Add(r);
                ++i;
            }
        }
        return MatchesString;
    }

    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_RegExMatchGroups(SqlString inputStr, SqlString regExStr, SqlInt32 groupId)
    {
        if (inputStr.IsNull || regExStr.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            return (SqlString)Regex.Match(inputStr.Value, regExStr.Value, RegexOptions.CultureInvariant).Groups[groupId.Value].Value;
        }
    }

    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_RegExReplace(SqlString input, SqlString pattern, SqlString replacement)
    {
        if (input.IsNull || pattern.IsNull || replacement.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            return (SqlString)Regex.Replace(input.Value, pattern.Value, replacement.Value);
        }
    }
}
