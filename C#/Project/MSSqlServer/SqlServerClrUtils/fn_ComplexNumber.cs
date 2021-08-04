using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native, IsByteOrdered = true)]
public struct ComplexNumberCS : INullable
{
    //用于分析(a,bi)形式值的正则表达式
    private static readonly Regex _parser = new Regex(@"\A\(\s*(?<real>\-?\d+(\.\d+)?)\s*,\s*(?<img>\-?\d+(\.\d+)?)\s*i\s*\)\Z", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

    //实数和虚数部分
    private double _real;
    private double _imaginary;

    //指定该值是否为null的内部成员
    private bool _isnull;

    //返回的与所有实例相等的null值
    private const string NULL = "<<null complex>>";
    private static readonly ComplexNumberCS NULL_INSTANCE = new ComplexNumberCS(true);

    //已知值的构造函数
    public ComplexNumberCS(double real, double imaginary)
    {
        this._real = real;
        this._imaginary = imaginary;
        this._isnull = false;
    }

    //未知值的构造函数
    public ComplexNumberCS(bool isnull)
    {
        this._isnull = isnull;
        this._real = this._imaginary = 0;
    }

    //默认的字符串表现形式
    public override string ToString()
    {
        return this._isnull ? NULL : ("(" + this._real.ToString(CultureInfo.InvariantCulture) + "," + this._imaginary.ToString(CultureInfo.InvariantCulture) + "i)");
    }

    //处理Null
    public bool IsNull
    {
        get { return this._isnull; }
    }

    public static ComplexNumberCS Null
    {
        get { return NULL_INSTANCE; }
    }

    //使用正则表达式分析输入
    public static ComplexNumberCS Parse(SqlString sqlString)
    {
        string value = sqlString.ToString();

        if (sqlString.IsNull || value == NULL)
        {
            return new ComplexNumberCS(true);
        }

        //检查如数是否匹配正则表达式模式
        Match m = _parser.Match(value);

        //如果输入的格式不正确，抛出一个异常
        if (!m.Success)
        {
            throw new ArgumentException("Invalid format for complex number. " + "Format is (n,mi) where n and m are floating point numbers in normal (not scientific) format (nnnnnn.nn).");
        }

        //如果一切顺利，分析值；
        //我们将得到两个double类型的值
        return new ComplexNumberCS(double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture), double.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture));
    }

    //分别处理实数和虚数的属性
    public double Real
    {
        get
        {
            if (this._isnull)
            {
                throw new InvalidOperationException();
            }
            return this._real;
        }
        set
        {
            this._real = value;
        }
    }

    public double Imaginary
    {
        get
        {
            if (this._isnull)
            {
                throw new InvalidOperationException();
            }
            return this._imaginary;
        }
        set
        {
            this._imaginary = value;
        }
    }

    //算术运算部分
    #region 算术运算
    //加法
    public ComplexNumberCS AddCN(ComplexNumberCS c)
    {
        //检查null值
        if (this._isnull || c._isnull)
        {
            return new ComplexNumberCS(true);
        }
        //加法
        return new ComplexNumberCS(this.Real + c.Real, this.Imaginary + c.Imaginary);
    }

    //减法
    public ComplexNumberCS SubCN(ComplexNumberCS c)
    {
        //检查null值
        if (this._isnull || c._isnull)
        {
            return new ComplexNumberCS(true);
        }
        //减法
        return new ComplexNumberCS(this.Real - c.Real, this.Imaginary - c.Imaginary);
    }

    //乘法
    public ComplexNumberCS MulCN(ComplexNumberCS c)
    {
        //检查null值
        if (this._isnull || c._isnull)
        {
            return new ComplexNumberCS(true);
        }
        //乘法
        return new ComplexNumberCS(this.Real * c.Real - this.Imaginary * c.Imaginary, this.Imaginary * c.Real + this.Real * c.Imaginary);
    }

    //除法
    public ComplexNumberCS DivCN(ComplexNumberCS c)
    {
        //检查null值
        if (this._isnull || c._isnull)
        {
            return new ComplexNumberCS(true);
        }
        //检查除数是否为0
        if (c.Real == 0 && c.Imaginary == 0)
        {
            throw new ArgumentException();
        }
        //除法
        return new ComplexNumberCS((this.Real * c.Real + this.Imaginary * c.Imaginary)
            / (c.Real * c.Real + c.Imaginary * c.Imaginary),
            (this.Imaginary * c.Real - this.Real * c.Imaginary)
            / (c.Real * c.Real + c.Imaginary * c.Imaginary));
    }
    #endregion
}

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct ComplexNumberSUM
{
    ComplexNumberCS cn;

    public void Init()
    {
        cn = ComplexNumberCS.Parse("(0, 0i)");
    }

    public void Accumulate(ComplexNumberCS Value)
    {
        cn = cn.AddCN(Value);
    }

    public void Merge(ComplexNumberSUM Group)
    {
        Accumulate(Group.Terminate());
    }

    public ComplexNumberCS Terminate()
    {
        return cn;
    }
}