-- 通过链接服务器迁移视图
declare @sql as nvarchar(max), @viewname as nvarchar(256), @definition as nvarchar(max)
declare c cursor fast_forward for
select TABLE_NAME, TRIM(VIEW_DEFINITION) as VIEW_DEFINITION
from [RemoteServer].[RemoteDatabase].[INFORMATION_SCHEMA].[VIEWS]
where TABLE_NAME like 'vw%' and VIEW_DEFINITION not like '%formtable[_]main[_][0-9]%'
order by TABLE_NAME

open c
fetch next from c into @viewname, @definition

while(@@fetch_status = 0)
begin
    if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'VIEW' and TABLE_NAME = @viewname)
    begin
        set @sql = @definition
    end
    else
    begin
        set @sql = 'print '''+@viewname+' already exists.'''
    end

    exec(@sql)
    fetch next from c into @viewname, @definition
end

close c
deallocate c
