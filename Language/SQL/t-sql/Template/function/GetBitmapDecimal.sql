-- 将十进制位图转换成对应的权限十进制值

USE [test]
GO
/****** Object:  UserDefinedFunction [dbo].[GetBitmapDecimal]    Script Date: 2021/5/7 11:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[GetBitmapDecimal](@input bigint)

RETURNS varchar(max)
AS
BEGIN
    declare @result as varchar(max)
    --将十进制位图转换成对应的权限十进制值
    --例如十进制23对应的二进制位10111，对应的二进制权限为10000，00100，00010，00001
    --所以最终对应的十进制权限值为4，2，1，0
    declare @inputBin as varchar(max)
    select @inputBin = [dbo].[ConvertToBase](@input, 2)

    declare @binLen as int
    select @binLen = LEN(@inputBin)

    ;with c0 as(
    select a.n, SUBSTRING(@inputBin, n, 1) as val, @binLen-a.n as pow
    from dbo.GetNums(1, @binLen) as a
    ), c1(res) as(
    select CONVERT(varchar(max), pow)+',' as [text()]
    from c0 where val=1 order by pow for xml path('')
    )

    select @result = SUBSTRING(res, 1, LEN(res)-1) from c1

    return @result
END

-- 测试执行
-- select dbo.GetBitmapDecimal(23)  -- 0,1,2,4