-- 在整个数据库所有表中查找某个字符串
-- 链接：https://solutioncenter.apexsql.com/quickly-search-for-sql-database-data-and-objects-in-ssms/

--modify the variable, specify the text to search for SET @SearchText = 'John';
DECLARE @SearchText varchar(200), @Table varchar(100), @TableID int, @ColumnName varchar(100), @String varchar(1000);

--list of tables in the current database. Type = 'U' = tables(user-defined) OPEN CursorSearch;
DECLARE CursorSearch CURSOR FOR
    SELECT name, object_id FROM sys.objects WHERE type = 'U';

OPEN CursorSearch;
FETCH NEXT FROM CursorSearch INTO @Table, @TableID;
WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE CursorColumns CURSOR FOR
    SELECT name FROM sys.columns WHERE object_id = @TableID AND system_type_id IN(167, 175, 231, 239);
    -- the columns that can contain textual data
    -- 167 = varchar; 175 = char; 231 = nvarchar; 239 = nchar       

    OPEN CursorColumns;
    FETCH NEXT FROM CursorColumns INTO @ColumnName;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        SET @String = 'IF EXISTS (SELECT * FROM ' + @Table + ' WHERE ' + @ColumnName + ' LIKE ''%' + @SearchText
                      + '%'') PRINT ''' + @Table + ', ' + @ColumnName + '''';
        EXECUTE (@String);
        FETCH NEXT FROM CursorColumns INTO @ColumnName;
    END;

    CLOSE CursorColumns;
    DEALLOCATE CursorColumns;

    FETCH NEXT FROM CursorSearch INTO @Table, @TableID;
END;

CLOSE CursorSearch;
DEALLOCATE CursorSearch;
