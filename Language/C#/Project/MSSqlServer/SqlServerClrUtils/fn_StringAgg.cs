using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Server;

[Serializable]
[SqlUserDefinedAggregate(
           Format.UserDefined,              // user-defined serialization                     使用UserDefined序列化格式
           IsInvariantToDuplicates = false, // duplicates make difference for the result      重复的数据可以改变结果
           IsInvariantToNulls = true,       // don't care about NULLs                         不关心NULL值
           IsInvariantToOrder = false,      // whether order makes difference                 聚合与顺序有关
           IsNullIfEmpty = false,           // do not yield a NULL for a set of zero strings  如果字符串为空，是否返回NULL
           MaxByteSize = 8000)]             // maximum size in bytes of persisted value       持久值的最大字节数
public struct fn_StringAgg : IBinarySerialize
{

    private StringBuilder sb;
    private bool firstConcat;

    public void Init()
    {
        this.sb = new StringBuilder();
        this.firstConcat = true;
    }

    public void Accumulate(SqlString s)
    {
        // simply skip Nulls approach  如果为NULL则直接跳过
        if (s.IsNull)
        {
            return;
        }
        if (this.firstConcat)
        {
            this.sb.Append(s.Value);
            this.firstConcat = false;
        }
        else
        {
            this.sb.Append(",");
            this.sb.Append(s.Value);
        }
    }

    public void Merge(fn_StringAgg Group)
    {
        this.sb.Append(Group.sb);
    }

    public SqlString Terminate()
    {
        return new SqlString(this.sb.ToString());
    }

    #region Implement interface IBinarySerialize
    public void Read(BinaryReader r)
    {
        sb = new StringBuilder(r.ReadString());
    }

    public void Write(BinaryWriter w)
    {
        // check we don't go over 8000 bytes, simply return first 8000 bytes  如果超过8000个字节，则直接返回前8000个字节
        //if (this.sb.Length > 4000)
        //{
        //    w.Write(this.sb.ToString().Substring(0, 4000));
        //}
        //else
        //{
        //    w.Write(this.sb.ToString());
        //}
        w.Write(this.sb.ToString());
    }
    #endregion
}
