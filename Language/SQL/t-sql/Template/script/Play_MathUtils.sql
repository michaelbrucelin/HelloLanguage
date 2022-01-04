-- 阶乘、排列、组合  函数实现

USE [library]
GO
/****** Object:  UserDefinedFunction [dbo].[math_Combination]    Script Date: 2015/6/24 11:43:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <lgw>
-- Create date: <2015-06-24>
-- Description: <Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[math_Combination](@m int,@n int)

RETURNS bigint
AS
BEGIN
    declare @result as bigint = 1;
    if(@m > @n)
    begin
        set @result = dbo.math_Permutation(@m,@n)/dbo.math_Factorial(@n)
    end

    return @result;
END
-- =============================================
GO
-- =============================================

USE [library]
GO
/****** Object:  UserDefinedFunction [dbo].[math_Factorial]    Script Date: 2015/6/24 11:43:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <lgw>
-- Create date: <2015-06-24>
-- Description: <Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[math_Factorial](@n int)

RETURNS bigint
AS
BEGIN
    declare @result as bigint = 1;
    while(@n > 1)
    begin
        set @result = @result * @n;
        set @n = @n - 1;
    end

    return @result;
END
-- =============================================
GO
-- =============================================
USE [library]
GO
/****** Object:  UserDefinedFunction [dbo].[math_Permutation]    Script Date: 2015/6/24 11:43:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <lgw>
-- Create date: <2015-06-24>
-- Description: <Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[math_Permutation](@m int,@n int)

RETURNS bigint
AS
BEGIN
    declare @result as bigint = 1;
    if(@m > @n)
    begin
        set @result = dbo.math_Factorial(@m)/dbo.math_Factorial(@m-@n)
    end
return @result;
END
