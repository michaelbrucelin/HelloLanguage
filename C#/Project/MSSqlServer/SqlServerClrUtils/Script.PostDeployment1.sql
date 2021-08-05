/*
后期部署脚本模板							
--------------------------------------------------------------------------------------
-- 此文件包含将附加到生成脚本中的 SQL 语句。
-- 使用 SQLCMD 语法将文件包含到后期部署脚本中。
-- 示例:      :r .\myfile.sql
-- 使用 SQLCMD 语法引用后期部署脚本中的变量。
-- 示例:      :setvar TableName MyTable
--               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/

/*
SET NOCOUNT ON;
USE master;
EXEC sp_configure 'clr enabled', 1;
RECONFIGURE WITH OVERRIDE;
GO

USE test;
GO

--DROP依赖于当前程序集的函数，为卸载程序集做准备
declare @func as nvarchar(255), @sql as nvarchar(max)
declare c cursor fast_forward for
select assembly_method from sys.assembly_modules
where assembly_id = (select assembly_id
                     from sys.assemblies
                     where name = 'CLRUtilities')
open c
fetch next from c into @func
while(@@fetch_status = 0)
begin
    set @sql = N'drop function '+@func+N';'
    exec sp_executesql @stmt = @sql
    fetch next from c into @func
end
close c
deallocate c
GO
--DROP依赖于当前程序集的聚合函数，为卸载程序集做准备
IF OBJECT_ID('dbo.fn_StringAgg') IS NOT NULL BEGIN DROP AGGREGATE dbo.fn_StringAgg END;
IF OBJECT_ID('dbo.fn_ProductAgg') IS NOT NULL BEGIN DROP AGGREGATE dbo.fn_ProductAgg END;
GO
--卸载当前的程序集
IF EXISTS(select * from sys.assemblies where name = 'CLRUtilities')
BEGIN DROP ASSEMBLY CLRUtilities END;
GO

--创建程序集
CREATE ASSEMBLY CLRUtilities
FROM 'D:\SqlServerClrUtils.dll'
WITH PERMISSION_SET = SAFE;
GO

/*
--如果数据库版本为：SQL Server 2017 (14.x) +，需要先执行下面脚本
declare @hash as binary(64)
set @hash = (select HASHBYTES('SHA2_512', (select * from OPENROWSET (BULK 'D:\SqlServerClrUtils.dll', SINGLE_BLOB) as [Data])))
exec sp_add_trusted_assembly @hash, N'Name: CLRUtilities, By: MichaelBrucelin, CreateDate: 20210624'
--exec sp_drop_trusted_assembly @hash

select * from sys.trusted_assemblies  -- 查询数据库信任的程序集
*/

--实现clr正则表达式验证模式匹配
IF OBJECT_ID('dbo.fn_RegExIsMatch') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_RegExIsMatch END;
GO
CREATE FUNCTION dbo.fn_RegExIsMatch(@inpstr AS NVARCHAR(MAX), @regexstr AS NVARCHAR(MAX)) 
RETURNS BIT
WITH RETURNS NULL ON NULL INPUT
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_RegExIsMatch;
GO

--实现clr正则表达式提取模式匹配
IF OBJECT_ID('dbo.fn_RegExMatch') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_RegExMatch END;
GO
CREATE FUNCTION dbo.fn_RegExMatch(@inpstr AS NVARCHAR(MAX), @regexstr AS NVARCHAR(MAX)) 
RETURNS NVARCHAR(MAX)
WITH RETURNS NULL ON NULL INPUT
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_RegExMatch;
GO

--实现clr正则表达式提取模式匹配——组
IF OBJECT_ID('dbo.fn_RegExMatchGroups') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_RegExMatchGroups END;
GO
CREATE FUNCTION dbo.fn_RegExMatchGroups(@inpstr AS NVARCHAR(MAX), @regexstr AS NVARCHAR(MAX), @groupid AS INT) 
RETURNS NVARCHAR(MAX)
WITH RETURNS NULL ON NULL INPUT
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_RegExMatchGroups;
GO

--实现clr正则表达式提取模式匹配
IF OBJECT_ID('dbo.fn_RegExMatches') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_RegExMatches END;
GO
CREATE FUNCTION dbo.fn_RegExMatches(@inpstr AS NVARCHAR(MAX), @regexstr AS NVARCHAR(MAX)) 
RETURNS TABLE(pos INT, element NVARCHAR(MAX))
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_RegExMatches;
GO

--实现clr正则表达式替换
IF OBJECT_ID('dbo.fn_RegExReplace') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_RegExReplace END;
GO
CREATE FUNCTION dbo.fn_RegExReplace(@input AS NVARCHAR(MAX), @pattern AS NVARCHAR(MAX), @replacement AS NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
WITH RETURNS NULL ON NULL INPUT 
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_RegExReplace;
GO

--实现clr TrimStart
IF OBJECT_ID('dbo.fn_TrimStart') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_TrimStart END;
GO
CREATE FUNCTION dbo.fn_TrimStart(@input AS NVARCHAR(MAX), @trim AS NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
WITH RETURNS NULL ON NULL INPUT 
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_TrimStart;
GO

--实现clr TrimEnd
IF OBJECT_ID('dbo.fn_TrimEnd') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_TrimEnd END;
GO
CREATE FUNCTION dbo.fn_TrimEnd(@input AS NVARCHAR(MAX), @trim AS NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
WITH RETURNS NULL ON NULL INPUT 
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_TrimEnd;
GO

--实现clr Trim
IF OBJECT_ID('dbo.fn_Trim') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_Trim END;
GO
CREATE FUNCTION dbo.fn_Trim(@input AS NVARCHAR(MAX), @trim AS NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
WITH RETURNS NULL ON NULL INPUT 
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_Trim;
GO

--实现clr Split，为了兼容以前程序中已有的引用，已经完全被fn_SplitByFlag所替代
IF OBJECT_ID('dbo.fn_SplitCLR') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_SplitCLR END;
GO
CREATE FUNCTION dbo.fn_SplitCLR(@string AS NVARCHAR(MAX), @separator AS NCHAR(1)) 
RETURNS TABLE(pos INT, element NVARCHAR(MAX))
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_SplitCLR;
GO

--实现clr Split，通过指定的分隔符split
IF OBJECT_ID('dbo.fn_SplitByFlag') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_SplitByFlag END;
GO
CREATE FUNCTION dbo.fn_SplitByFlag(@string AS NVARCHAR(MAX), @separator AS NVARCHAR(255), @multiSep AS BIT) 
RETURNS TABLE(pos INT, element NVARCHAR(MAX))
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_SplitByFlag;
GO

--实现clr Split，通过指定的长度split
IF OBJECT_ID('dbo.fn_SplitByChunk') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_SplitByChunk END;
GO
CREATE FUNCTION dbo.fn_SplitByChunk(@string AS NVARCHAR(MAX), @chunkSize AS INT, @keep AS BIT) 
RETURNS TABLE(pos INT, element NVARCHAR(MAX))
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_SplitByChunk;
GO

--实现随机字符串
--sql server调用时可以使用ABS(CHECKSUM(NEWID()))或CHECKSUM(NEWID())作为seed参数传入
IF OBJECT_ID('dbo.fn_RandomStr') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_RandomStr END;
GO
CREATE FUNCTION dbo.fn_RandomStr(@seed AS INT, @chars AS NVARCHAR(MAX), @length AS INT)
RETURNS NVARCHAR(MAX)
WITH RETURNS NULL ON NULL INPUT 
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_RandomStr;
GO

--实现随机整型
--sql server调用时可以使用ABS(CHECKSUM(NEWID()))或CHECKSUM(NEWID())作为seed参数传入
IF OBJECT_ID('dbo.fn_RandomInt') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_RandomInt END;
GO
CREATE FUNCTION dbo.fn_RandomInt(@seed AS INT, @minValue AS INT, @maxValue AS INT)
RETURNS INT
WITH RETURNS NULL ON NULL INPUT 
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_RandomInt;
GO

--实现在指定的字符串列表中随机出一项
--sql server调用时可以使用ABS(CHECKSUM(NEWID()))或CHECKSUM(NEWID())作为seed参数传入
IF OBJECT_ID('dbo.fn_RandomItem') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_RandomItem END;
GO
CREATE FUNCTION dbo.fn_RandomItem(@seed AS INT, @input AS NVARCHAR(MAX), @separator AS NVARCHAR(255))
RETURNS NVARCHAR(MAX)
WITH RETURNS NULL ON NULL INPUT 
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_RandomItem;
GO

--将传入的指定表的指定列，随机返回其中的一行（通常用于随机返回唯一主键，就相当于随机行了）
--sql server调用时可以使用ABS(CHECKSUM(NEWID()))或CHECKSUM(NEWID())作为seed参数传入
IF OBJECT_ID('dbo.fn_RandomKey') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_RandomKey END;
GO
CREATE FUNCTION dbo.fn_RandomKey(@seed AS INT, @table AS NVARCHAR(MAX), @column AS NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
WITH RETURNS NULL ON NULL INPUT 
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_RandomKey;
GO

--多次字符串替换，替换关系为指定分隔符分隔的字符串
--sql server调用时fn_MapReplace(",", ":", "a:X,b:Y,ww:ZZ")，就会将字符串中的a替换为X，b替换为Y，ww替换为ZZ
IF OBJECT_ID('dbo.fn_MapReplace') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_MapReplace END;
GO
CREATE FUNCTION dbo.fn_MapReplace(@input AS NVARCHAR(MAX), @split1 AS NCHAR(1), @split2 AS NCHAR(1), @map AS NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_MapReplace;
GO

--多次字符串替换，替换关系为临时表的数据，临时表必须包含列src与tar
IF OBJECT_ID('dbo.fn_MapReplace2') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_MapReplace2 END;
GO
CREATE FUNCTION dbo.fn_MapReplace2(@input AS NVARCHAR(MAX), @table AS NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_MapReplace2;
GO

--实现聚合，拼接字符串
IF OBJECT_ID('dbo.fn_StringAgg') IS NOT NULL BEGIN DROP AGGREGATE dbo.fn_StringAgg END;
GO
CREATE AGGREGATE dbo.fn_StringAgg(@input AS NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
EXTERNAL NAME CLRUtilities.fn_StringAgg;
GO

--实现聚合，乘积
IF OBJECT_ID('dbo.fn_ProductAgg') IS NOT NULL BEGIN DROP AGGREGATE dbo.fn_ProductAgg END;
GO
CREATE AGGREGATE dbo.fn_ProductAgg(@input AS BIGINT)
RETURNS BIGINT
EXTERNAL NAME CLRUtilities.fn_ProductAgg;
GO

--将十进制数值转为2进制、8进制或16进制字符串
IF OBJECT_ID('dbo.fn_DecimalTo') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_DecimalTo END;
GO
CREATE FUNCTION dbo.fn_DecimalTo(@input AS INT, @baseto AS INT)
RETURNS NVARCHAR(MAX)
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_DecimalTo;
GO

--将2进制、8进制或16进制字符串转为十进制数值
IF OBJECT_ID('dbo.fn_DecimalFrom') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_DecimalFrom END;
GO
CREATE FUNCTION dbo.fn_DecimalFrom(@input AS NVARCHAR(MAX), @basefrom AS INT)
RETURNS INT
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.fn_DecimalFrom;
GO

--计算两个字符串的Levenshtein相似度
IF OBJECT_ID('dbo.fn_CalLevenshteinSimilarity') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_CalLevenshteinSimilarity END;
GO
CREATE FUNCTION dbo.fn_CalLevenshteinSimilarity(@str1 AS NVARCHAR(MAX), @str2 AS NVARCHAR(MAX))
RETURNS FLOAT
WITH RETURNS NULL ON NULL INPUT
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.CalLevenshteinSimilarity;
GO

--计算两个字符串的Levenshtein距离
IF OBJECT_ID('dbo.fn_CalLevenshteinDistance') IS NOT NULL BEGIN DROP FUNCTION dbo.fn_CalLevenshteinDistance END;
GO
CREATE FUNCTION dbo.fn_CalLevenshteinDistance(@str1 AS NVARCHAR(MAX), @str2 AS NVARCHAR(MAX))
RETURNS INT
WITH RETURNS NULL ON NULL INPUT
EXTERNAL NAME CLRUtilities.UserDefinedFunctions.CalLevenshteinDistance;
GO

*/