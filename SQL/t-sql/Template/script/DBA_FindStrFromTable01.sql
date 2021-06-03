-- 在某张表中查找某个字符串
-- 链接：https://www.mssqltips.com/sqlservertip/1522/searching-and-finding-a-string-value-in-all-columns-in-a-sql-server-table/

-- 1. 非游标
USE master
GO

CREATE PROCEDURE dbo.sp_FindStringInTable @stringToFind VARCHAR(100), @schema sysname, @table sysname
AS

BEGIN TRY
    DECLARE @sqlCommand varchar(max)

    SET @sqlCommand = 'SELECT * FROM [' + @schema + '].[' + @table + '] WHERE '
    SELECT @sqlCommand = @sqlCommand + '[' + COLUMN_NAME + '] LIKE ''' + @stringToFind + ''' OR '
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE     TABLE_SCHEMA = @schema
          AND TABLE_NAME = @table
          AND DATA_TYPE IN ('char','nchar','ntext','nvarchar','text','varchar')

    SET @sqlCommand = left(@sqlCommand,len(@sqlCommand)-3)
    EXEC (@sqlCommand)
    PRINT @sqlCommand
END TRY

BEGIN CATCH
    PRINT 'There was an error. Check to make sure object exists.'
    PRINT error_message()
END CATCH
