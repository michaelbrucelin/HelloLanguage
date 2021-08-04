using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Server;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SqlUserDefinedAggregate(
           Format.Native,                   // use native serialization                   使用Native序列化格式
           IsInvariantToDuplicates = false, // duplicates make difference for the result  重复数据可以改变结果
           IsInvariantToNulls = true,       // don't care about NULLs                     不在乎NULLs
           IsInvariantToOrder = false)]     // whether order makes difference             聚合与顺序无关
public struct fn_ProductAgg
{
    private SqlInt64 si;

    public void Init()
    {
        si = 1;
    }

    public void Accumulate(SqlInt64 v)
    {
        // Null input = Null output approach  如果输入为Null，则输出Null
        if (v.IsNull || si.IsNull)
        {
            si = SqlInt64.Null;
            return;
        }
        // to prevent an exception in next if  防止在下一个if中出现异常
        if (v == 0 || si == 0)
        {
            si = 0;
            return;
        }
        // stop before we reach max value  达到最大值之前停止
        if (Math.Abs(v.Value) <= SqlInt64.MaxValue / Math.Abs(si.Value))
        {
            si = si * v;
        }
        else
        {
            // if we reach too big value, return 0  如果达到一个太大的值，则返回0
            si = 0;
        }

    }

    public void Merge(fn_ProductAgg Group)
    {
        Accumulate(Group.Terminate());
    }

    public SqlInt64 Terminate()
    {
        return (si);
    }
}
