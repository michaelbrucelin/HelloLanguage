-- 动态执行sql语句

/*
1、exec(@sql)            --exec()支持正则和Unicode字符串作为输入
2、exec sp_executesql    --sp_executesql只支持Unicode字符串作为输入
    @stmt = @sql,
    @params = N'@paraInSql as DATATYPE [OUTPUT]',  
    @paraInSql = @paraExeValue [OUTPUT]

--@stmt = @sql,             
--类似于存储过程的主体，可以引用输入和输出参数。这部分通常动态构造。
--@params = N'@paraInSql as DATATYPE',
--类似于存储过程头，语法与存储过程头一模一样，定义输入输出参数，可以指定默认值。这部分也可以动态构造。
--@paraInSql = @paraExeValue [OUTPUT] 
--类似于存储过程调用，可以为输入输出参数赋值。

ADO.NET中的带参数的sql语句都是通过exec sp_executesql执行的，exec(@sql)才是真正的动态执行sql语句，但是不安全，可以通过限制字符串的长度、动态执行之前替换掉DROP、DELETE、GRANT等敏感的关键字，降低操作用户的权限等方式提高安全性，但是都做不到绝对安全；
*/

-- 示例
declare @sql as nvarchar(max), @countryCode as nvarchar(30), @resultOutside as int

set @countryCode = N'880'
set @sql = N'if(exists(select 1 from dbo.country_'+@countryCode+
           N' group by number having COUNT(1) > @cnt))
              begin set @resultInsideOut = 1 end else begin set @resultOut = 0 end'

exec sp_executesql @stmt = @sql,
   @params = N'@cnt as int, @resultInsideOut as int output',
   @cnt = 1, @resultInsideOut = @resultOutside output

select @result
