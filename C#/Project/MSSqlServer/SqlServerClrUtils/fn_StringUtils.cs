using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_Trim(SqlString input, SqlChars trim)
    {
        if (input.IsNull || trim.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            return (SqlString)input.Value.Trim(trim.Value);
        }
    }

    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_TrimStart(SqlString input, SqlChars trim)
    {
        if (input.IsNull || trim.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            return (SqlString)input.Value.TrimStart(trim.Value);
        }
    }

    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_TrimEnd(SqlString input, SqlChars trim)
    {
        if (input.IsNull || trim.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            return (SqlString)input.Value.TrimEnd(trim.Value);
        }
    }

    //拆分字符串数据并返回表,，为了兼容跟以前的引用，已经完全被fn_SplitByFlag所替代
    //FillRowMethodName = "ArrSplitFillRow"
    [SqlFunction(FillRowMethodName = "ArrSplitFillRow",
     DataAccess = DataAccessKind.None,
     TableDefinition = "pos INT, element NVARCHAR(max) ")]
    public static IEnumerable fn_SplitCLR(SqlString inpStr, SqlString charSeparator)
    {
        string locStr;
        string[] splitStr;
        char[] locSeparator = new char[1];
        locSeparator[0] = (char)charSeparator.Value[0];
        if (inpStr.IsNull)
        {
            locStr = "";
        }
        else
        {
            locStr = inpStr.Value;
        }
        splitStr = locStr.Split(locSeparator, StringSplitOptions.RemoveEmptyEntries);
        //locStr.Split(charSeparator.ToString()[0]);
        List<row_item> SplitString = new List<row_item>();
        int i = 1;
        foreach (string s in splitStr)
        {
            row_item r = new row_item();
            r.item = s;
            r.pos = i;
            SplitString.Add(r);
            ++i;
        }
        return SplitString;
    }

    //根据分隔符拆分字符串数据并返回表
    //FillRowMethodName = "ArrSplitFillRow"
    [SqlFunction(FillRowMethodName = "ArrSplitFillRow",
     DataAccess = DataAccessKind.None,
     TableDefinition = "pos INT, element NVARCHAR(max) ")]
    public static IEnumerable fn_SplitByFlag(SqlString input, SqlString charSeparator, SqlBoolean multiChars)
    {
        string inputStr;
        string[] splitStr;
        char[] separators;
        if (multiChars.IsTrue)
        {
            separators = charSeparator.Value.ToCharArray();
        }
        else
        {
            separators = new char[1] { (char)charSeparator.Value[0] };
            //separators[0] = (char)charSeparator.Value[0];
        }

        if (input.IsNull)
        {
            inputStr = "";
        }
        else
        {
            inputStr = input.Value;
        }

        splitStr = inputStr.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        //locStr.Split(charSeparator.ToString()[0]);
        List<row_item> SplitString = new List<row_item>();
        int index = 1;
        foreach (string s in splitStr)
        {
            row_item r = new row_item();
            r.item = s;
            r.pos = index;
            SplitString.Add(r);
            ++index;
        }
        return SplitString;
    }

    //根据长度拆分字符串数据并返回表
    //FillRowMethodName = "ArrSplitFillRow"
    [SqlFunction(FillRowMethodName = "ArrSplitFillRow",
     DataAccess = DataAccessKind.None,
     TableDefinition = "pos INT, element NVARCHAR(max)")]
    public static IEnumerable fn_SplitByChunk(SqlString input, SqlInt32 chunkSize, SqlBoolean keep)
    {
        string inputStr;
        string[] splitStr;
        int inputChunk = chunkSize.Value;

        if (input.IsNull)
        {
            inputStr = "";
        }
        else
        {
            inputStr = input.Value;
        }

        if (keep.IsTrue)
        {
            int cnt = (int)Math.Ceiling(inputStr.Length * 1.0 / inputChunk);
            splitStr = Enumerable.Range(0, cnt)
                .Select(i => inputStr.Substring(inputChunk * i, Math.Min(inputChunk, inputStr.Length - inputChunk * i)))
                .ToArray();
        }
        else
        {
            splitStr = Enumerable.Range(0, inputStr.Length / inputChunk)
                .Select(i => inputStr.Substring(inputChunk * i, inputChunk))
                .ToArray();
        }

        //locStr.Split(charSeparator.ToString()[0]);
        List<row_item> SplitString = new List<row_item>();
        int index = 1;
        foreach (string s in splitStr)
        {
            row_item r = new row_item();
            r.item = s;
            r.pos = index;
            SplitString.Add(r);
            ++index;
        }
        return SplitString;
    }

    // 多次字符串替换，替换关系为指定分隔符分隔的字符串
    // sql server调用时fn_MapReplace(",", ":", "a:X,b:Y,ww:ZZ")，就会将字符串中的a替换为X，b替换为Y，ww替换为ZZ
    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.None)]
    public static SqlString fn_MapReplace(SqlString input, SqlString split1, SqlString split2, SqlString map)
    {
        if (input.IsNull || split1.IsNull || split2.IsNull || map.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            string[] maps = map.Value.Split(new char[] { (char)split1.Value[0] }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder(input.Value);

            char split02 = (char)split2.Value[0];
            for (int i = 0; i < maps.Length; i++)
            {
                sb.Replace(maps[i].Substring(0, maps[i].IndexOf(split02)), maps[i].Substring(maps[i].IndexOf(split02) + 1));
            }

            return (SqlString)sb.ToString();
        }
    }

    // 多次字符串替换，替换关系为临时表的数据，临时表必须包含列src与tar
    [SqlFunction(IsDeterministic = true, DataAccess = DataAccessKind.Read)]
    public static SqlString fn_MapReplace2(SqlString input, SqlString table)
    {
        if (input.IsNull || table.IsNull)
        {
            return SqlString.Null;
        }
        else
        {
            List<string[]> maps = new List<string[]>();
            using (SqlConnection conn = new SqlConnection("Context Connection = true;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"select src, tar from {table.Value}", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            maps.Add(new string[] { reader.GetString(0), reader.GetString(1) });
                        }
                    }
                }
            }

            StringBuilder sb = new StringBuilder(input.Value);

            for (int i = 0; i < maps.Count; i++)
            {
                sb.Replace(maps[i][0], maps[i][1]);
            }

            return (SqlString)sb.ToString();
        }
    }

    /// <summary>
    /// Returns the number of steps required to transform the source string
    /// into the target string.
    /// 比较两个字符串的相似度
    /// </summary>
    public static SqlInt32 CalLevenshteinDistance(string source, string target)
    {
        if ((source == null) || (target == null)) { return 0; }
        if ((source.Length == 0) || (target.Length == 0)) { return 0; }
        if (source == target) { return source.Length; }

        int sourceWordCount = source.Length;
        int targetWordCount = target.Length;

        // Step 1
        if (sourceWordCount == 0) { return targetWordCount; }
        if (targetWordCount == 0) { return sourceWordCount; }

        int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

        // Step 2
        for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
        for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

        for (int i = 1; i <= sourceWordCount; i++)
        {
            for (int j = 1; j <= targetWordCount; j++)
            {
                // Step 3
                int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                // Step 4
                distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
            }
        }

        return distance[sourceWordCount, targetWordCount];
    }

    /// <summary>
    /// Calculate percentage similarity of two strings
    /// <param name="source">Source String to Compare with</param>
    /// <param name="target">Targeted String to Compare</param>
    /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
    /// 比较两个字符串的相似度
    /// </summary>
    public static SqlDouble CalLevenshteinSimilarity(string source, string target)
    {
        if ((source == null) || (target == null)) { return 0.0; }
        if ((source.Length == 0) || (target.Length == 0)) { return 0.0; }
        if (source == target) { return 1.0; }

        int stepsToSame = (int)CalLevenshteinDistance(source, target);

        return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
    }
}
