-- 此脚本用于将数据库中部分表从一个数据库迁移到另一个数据库
-- 这里演示将源数据库中2020年的表迁移到另一个数据库

create database [DB_TARGET_2020] CONTAINMENT = NONE
    on primary ( name = N'DB_TARGET_2020', filename = N'E:\Database\SQL SERVER DATA\DB_TARGET_2020.mdf' , size = 102400KB , filegrowth = 102400KB )
    log on ( name = N'DB_TARGET_2020_log', filename = N'E:\Database\SQL SERVER DATA\DB_TARGET_2020_log.ldf' , size = 1024KB , filegrowth = 102400KB )
go
alter database [DB_TARGET_2020] set recovery simple with no_wait
go

use DB_SOURCE  -- 源数据库
go

declare @movecnt as int = 0
declare @shrinkcnt as int = 32         -- 每迁移多少张表，收缩一次源数据库
declare @sql_c_table as nvarchar(max)
declare @sql_d_index as nvarchar(max)
declare @sql_mv_data as nvarchar(max)
declare @sql_d_table as nvarchar(max)

declare @db_src as nvarchar(255), @schema_src as nvarchar(255), @table_src as nvarchar(255)
declare c cursor fast_forward for
select TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME
from DB_SOURCE.INFORMATION_SCHEMA.TABLES
where TABLE_CATALOG = 'DB_SOURCE' and TABLE_TYPE = 'BASE TABLE'
      and TABLE_NAME like '%[_]2020[0-9][0-9]'
order by TABLE_NAME

open c
fetch next from c into @db_src, @schema_src, @table_src

while(@@fetch_status = 0)
begin
    select @sql_c_table = N'', @sql_d_index = N'', @sql_mv_data = N'', @sql_d_table = N''

    -- 创建目标表
    set @sql_c_table = N'select * into [DB_TARGET_2020].[dbo].['+@table_src+N']
                         from ['+@db_src+N'].['+@schema_src+N'].['+@table_src+N'] where 1 = 2'
    exec sp_executesql @stmt = @sql_c_table

    -- 删除索引
    -- 先删除表中的全部索引，注意，此脚本为了加速删除数据，删除了源表的索引，但是没有在新表中创建相同的索引
    select @sql_d_index = (
    select 'drop index [' + ix.name + '] on [DB_SOURCE].[' + OBJECT_SCHEMA_NAME(ix.object_id) + '].[' + OBJECT_NAME(ix.object_id) + ']; '
    from DB_SOURCE.sys.indexes as ix
    inner join DB_SOURCE.sys.objects as tb on tb.object_id = ix.object_id
    --where ix.name is not null and tb.name like '%[_]2020[0-9][0-9]'
    where ix.name is not null
          and SCHEMA_NAME(tb.schema_id) = @schema_src and tb.name = @table_src
    for xml path('')
    )
    exec sp_executesql @sql_d_index

    -- 迁移数据
    -- 以10W条为一批次进行删除
    set @sql_mv_data = N'
    while(1=1)
    begin
        begin tran
            delete top (100000) from ['+@db_src+N'].['+@schema_src+N'].['+@table_src+N']
            output deleted.* into [DB_TARGET_2020].['+@schema_src+N'].['+@table_src+N']
            if @@rowcount < 100000
            begin
                commit tran
                break;
            end
        commit tran
    end'
    exec sp_executesql @sql_mv_data

    -- 删除源表
    set @sql_d_table = N'
    if (not EXISTS(select * from ['+@db_src+N'].['+@schema_src+N'].['+@table_src+N']))
    begin
        drop table ['+@db_src+N'].['+@schema_src+N'].['+@table_src+N']
    end'
    exec sp_executesql @sql_d_table

    -- 收缩数据库
    set @movecnt = @movecnt + 1
    if(@movecnt = @shrinkcnt)
    begin
        -- DBCC SHRINKFILE (N'DB_SOURCE' , 0, TRUNCATEONLY)
        DBCC SHRINKDATABASE (N'DB_SOURCE', 10);
        set @movecnt = 0
    end
    fetch next from c into @db_src, @schema_src, @table_src
end

close c
deallocate c

-- DBCC SHRINKFILE (N'DB_SOURCE' , 0, TRUNCATEONLY)
DBCC SHRINKDATABASE (N'DB_SOURCE', 10);
