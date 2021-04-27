-- 虚拟数字辅助表（Virtual Auxiliary Table of Numbers）
-- 通常，建议在数据库中保存这样一个永久的表，并填充尽可能多的数字，然后在需要时查询它。
-- definition of GetNums function, SQL Server 2012 version

USE [TempDatabase]
GO
/****** Object:  UserDefinedFunction [dbo].[GetNums]    Script Date: 2021/4/9 11:09:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[GetNums](@low AS BIGINT, @high AS BIGINT) RETURNS TABLE
AS
RETURN
    WITH
        L0   AS (SELECT c FROM (VALUES(1),(1)) AS D(c)),
        L1   AS (SELECT 1 AS c FROM L0 AS A CROSS JOIN L0 AS B),
        L2   AS (SELECT 1 AS c FROM L1 AS A CROSS JOIN L1 AS B),
        L3   AS (SELECT 1 AS c FROM L2 AS A CROSS JOIN L2 AS B),
        L4   AS (SELECT 1 AS c FROM L3 AS A CROSS JOIN L3 AS B),
        L5   AS (SELECT 1 AS c FROM L4 AS A CROSS JOIN L4 AS B),
        Nums AS (SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS rownum
                 FROM L5)
SELECT @low + rownum - 1 AS n
FROM Nums
ORDER BY rownum
OFFSET 0 ROWS FETCH FIRST @high - @low + 1 ROWS ONLY;