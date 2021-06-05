-- 在整个数据库所有表中查找某个字符串
-- 链接：网上某人写的

USE [数据库名称];

--1.定义需要查找的关键字。在搜索中，使用模糊搜索：LIKE '%@key_find%'
DECLARE @key_find NVARCHAR(MAX) = '123';--假设是找字符串"123"

--2.用游标Cursor_Table，遍历所有表
DECLARE Cursor_Table CURSOR FOR
    SELECT name from sysobjects WHERE xtype = 'u' AND name <> 'dtproperties';
OPEN Cursor_Table;
DECLARE @tableName NVARCHAR(MAX);
FETCH NEXT from Cursor_Table INTO @tableName;
WHILE @@fetch_status = 0
BEGIN
    DECLARE @tempSQLText NVARCHAR(MAX) = '';

    --3.在表中，用游标columnCursor，遍历所有字段。注意，只遍历字符串类型的字段（列）
    DECLARE columnCursor CURSOR FOR
        SELECT Name FROM SysColumns
        WHERE ID = Object_Id( @tableName ) and
                                              (
                                               xtype = 35 or --text
                                               xtype = 99 or --ntext
                                               xtype = 167 or --varchar
                                               xtype = 175 or --char
                                               xtype = 231 or --nvarchar
                                               xtype = 239 or --nchar
                                               xtype = 241 --xml
                                              )
    OPEN columnCursor;
    DECLARE @columnName NVARCHAR(MAX);
    FETCH NEXT from columnCursor INTO @columnName;
    WHILE @@fetch_status = 0
    BEGIN
        --4.在表的字段中，对每一行进行模糊搜索，并输出找到的信息。
        DECLARE @DynamicSQLText NVARCHAR(MAX) = 'IF ( EXISTS ( SELECT * FROM [' + @tableName + '] WHERE [' + @columnName + '] LIKE ''%' + @key_find + '%'' ) ) BEGIN DECLARE @CurrentTableCount Bigint = ( SELECT COUNT(*) From [' + @tableName + '] ); PRINT ''Find : Table [' + @tableName + '], Column [' + @columnName + '], Row Count:'' + CAST( @CurrentTableCount AS NVARCHAR(MAX) ) + ''.'';  END';
        EXEC( @DynamicSQLText );
        FETCH NEXT from columnCursor INTO @columnName
    END
    EXEC(@tempSQLText);
    CLOSE columnCursor;
    DEALLOCATE columnCursor;
    FETCH NEXT from Cursor_Table INTO @tableName;
END
CLOSE Cursor_Table;
DEALLOCATE Cursor_Table;
