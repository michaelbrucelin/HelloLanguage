using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class UserDefinedFunctions
{
    //未测试应用
    static int count = 0;

    [SqlFunction]
    public static SqlString fn_JsonValue(SqlString json, SqlString path)
    {
        try
        {
            JObject jobj = (JObject)JsonConvert.DeserializeObject(json.Value);
            JToken token = jobj.SelectToken(path.Value);

            return token.ToString();
        }
        catch
        {
            return null;
        }
    }

    [SqlFunction]
    public static SqlString fn_JsonArrayValue(SqlString json, SqlInt32 rowindex, SqlString key)
    {
        JArray jarr = (JArray)JsonConvert.DeserializeObject(json.Value);
        string rslt = jarr[rowindex.Value][key.Value].ToString();
        return new SqlString(rslt);
    }

    public static void FillRowFromJson(Object token, out SqlString path, out SqlString value, out SqlString type, out SqlBoolean hasvalues, out SqlInt32 index)
    {
        JToken item = (JToken)token;
        path = item.Path;
        type = item.Type.ToString();
        hasvalues = item.HasValues;
        value = item.ToString();
        index = count;
        count++;
    }

    [SqlFunction(FillRowMethodName = "FillRowFromJson", TableDefinition = "[path] nvarchar(4000), [value] nvarchar(max), [type] nvarchar(4000), hasvalues bit, [index] int")]
    public static IEnumerable fn_JsonTable(SqlString json, SqlString path)
    {
        ArrayList TokenCollection = new ArrayList();
        count = 0;

        try
        {
            JObject jobj = (JObject)JsonConvert.DeserializeObject(json.Value);
            IEnumerable<JToken> tokens = jobj.SelectTokens(path.Value);

            foreach (JToken token in tokens)
            {
                if (token.Type == JTokenType.Object || token.Type == JTokenType.Array)
                {
                    foreach (JToken item in token.Children<JToken>())
                    {
                        TokenCollection.Add(item);
                    }
                }
                else
                {
                    TokenCollection.Add(token);
                }
            }

            return TokenCollection;

        }
        catch
        {
            return null;
        }
    }
}
