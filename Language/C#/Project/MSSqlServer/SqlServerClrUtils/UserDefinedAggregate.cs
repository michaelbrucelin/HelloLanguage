using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct UserDefinedAggregate
{
    public void Init()
    {
        // Init方法用于初始化计算，查询处理器每聚合一个组都会调用一次该方法。
    }

    public void Accumulate(SqlString Value)
    {
        // 此方法用于累积聚合值。引擎将为正在被聚合的组中的每个值（即每一行）调用一次该方法。
        // 此方法需要一个输入参数，且该参数的数据类型必须对应聚合列的本机SQL Server数据类型。
        // 输入的参数的数据类型可以是CLR UDT。
    }

    public void Merge (UserDefinedAggregate Group)
    {
        // 此方法使用一个类型为该聚合类的输入参数，用于合并一个聚合的多个局部计算的值。
    }

    public SqlString Terminate ()
    {
        // 此方法用于完成聚合并返回结果
        return new SqlString (string.Empty);
    }

    // 这是占位符成员字段
    public int _var1;
}
