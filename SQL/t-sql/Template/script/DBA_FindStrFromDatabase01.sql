-- 在整个数据库所有表中查找某个字符串，自己编写

use testdb;
go

--定义需要查找的关键字。在搜索中，使用模糊搜索：LIKE '%@key_find%'
--这里假设查找的是找字符串"1234567890"
declare @key_find nvarchar(max) = '1234567890';
declare @tableName nvarchar(max);
declare @SQLText nvarchar(max) = '';

--使用游标Cursor_Table，遍历所有表
declare Cursor_Table cursor fast_forward for
select TABLE_NAME from INFORMATION_SCHEMA.TABLES
where TABLE_TYPE = 'BASE TABLE'
      --and TABLE_NAME like '%hrm%'
      and TABLE_NAME not like 'formtable_main_%' and TABLE_NAME not like '%workflow%' and TABLE_NAME not like '%hrm%'

open Cursor_Table;

fetch next from Cursor_Table into @tableName;
while(@@fetch_status = 0)
begin
    --在每一个表中，用游标Cursor_Column，遍历所有字段。注意，只遍历字符串类型的字段（列）
    declare Cursor_Column cursor fast_forward for
    select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS
    where TABLE_NAME = @tableName and DATA_TYPE in ('char','nchar','varchar','nvarchar','text','ntext')

    open Cursor_Column;
    declare @columnName nvarchar(max);
    fetch next from Cursor_Column into @columnName;
    while(@@fetch_status = 0)
    begin
        --逐个字段进行搜索，并输出找到的信息。
        set @SQLText = '';
        set @SQLText = 'IF(EXISTS(SELECT * FROM [' + @tableName + '] WHERE [' + @columnName + '] LIKE ''%' + @key_find + '%''))
                        BEGIN
                            DECLARE @CurrentTableCount bigint = (SELECT COUNT(*) From [' + @tableName + '] WHERE [' + @columnName + '] LIKE ''%' + @key_find + '%'');
                            PRINT ''Find : Table [' + @tableName + '], Column [' + @columnName + '], Row Count:'' + CAST( @CurrentTableCount AS NVARCHAR(MAX) ) + ''.'';
                        END';
        exec(@SQLText);
        fetch next from Cursor_Column into @columnName
    end

    close Cursor_Column;
    deallocate Cursor_Column;
    fetch next from Cursor_Table into @tableName;
end

close Cursor_Table
deallocate Cursor_Table
