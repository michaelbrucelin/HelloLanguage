-- 备份部分表数据

create database db_tgt
go
use db_tgt
go

declare @schema as nvarchar(30), @table as nvarchar(100)
declare @sql as nvarchar(max)

declare c cursor fast_forward for
select TABLE_SCHEMA, TABLE_NAME
from [ip_src].[db_src].[INFORMATION_SCHEMA].[TABLES]
where TABLE_TYPE = 'BASE TABLE' and TABLE_NAME like '%keyword%'

open c

fetch next from c into @schema, @table

while(@@fetch_status = 0)
begin
    set @sql = N'select * into [db_tgt].[dbo].['+@table+N']
                 from [ip_src].[db_src].['+@schema+N'].['+@table+N']'
    exec sp_executesql @stmt = @sql

    fetch next from c into @schema, @table
end

close c
deallocate c
