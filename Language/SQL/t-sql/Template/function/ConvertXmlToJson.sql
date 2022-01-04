-- 将xml转为json

USE [test]
GO
/****** Object:  UserDefinedFunction [dbo].[ConvertXmlToJson]    Script Date: 2021/5/7 13:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[ConvertXmlToJson](@XmlData XML)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @result as NVARCHAR(MAX)

    SELECT @result = STUFF((SELECT *
                            FROM (SELECT ',{' + STUFF((SELECT ',"' + COALESCE(b.c.value('local-name(.)', 'NVARCHAR(MAX)'), '') + '":"' + b.c.value('text()[1]', 'NVARCHAR(MAX)') + '"'
                                                       FROM x.a.nodes('*') as b(c)
                                                       FOR XML PATH(''), TYPE).value('(./text())[1]','NVARCHAR(MAX)'), 1, 1, '')
                                         + '}'
                                  FROM @XmlData.nodes('/root/*') x(a)) as JSON(theLine)
                            FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

    RETURN @result
END


/* 测试代码
declare @xml xml
set @xml=(select top(32) TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME, DATA_TYPE
          from INFORMATION_SCHEMA.COLUMNS for xml path('column'), root)
select dbo.ConvertXmlToJson(@xml)
*/
