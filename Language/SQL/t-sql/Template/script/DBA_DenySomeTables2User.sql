--取消某一用户的对某些表的访问权限
declare @sql as nvarchar(max), @table as nvarchar(max), @user as nvarchar(max) = 'user4dev'

declare c cursor fast_forward for
select TABLE_SCHEMA+'.'+TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_NAME like '%salary%'
open c
fetch next from c into @table
while(@@fetch_status = 0)
begin
    set @sql = 'DENY INSERT, VIEW DEFINITION, VIEW CHANGE TRACKING, UNMASK, ALTER, UPDATE, TAKE OWNERSHIP, CONTROL, DELETE, SELECT, REFERENCES ON '+@table+' TO '+@user
    exec sp_executesql @sql

    fetch next from c into @table
end

close c
deallocate c
