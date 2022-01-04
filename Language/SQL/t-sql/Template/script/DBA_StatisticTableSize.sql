-- 统计每张表占用的物理空间
-- 另见DBA_StatisticTableRecordCnt.sql

create table #temp(name nvarchar(128), rows varchar(50), reserved varchar(50),
                   data varchar(50), index_size varchar(50), unused varchar(50)
)

declare @id nvarchar(128)
declare c cursor for
select '[' + sc.name + '].[' + s.name + ']'
FROM sysobjects as s
INNER JOIN sys.schemas sc ON s.uid = sc.schema_id
where s.xtype='U'

open c
fetch c into @id
while @@fetch_status = 0
begin
    insert into #temp exec sp_spaceused @id
    fetch c into @id
end

close c
deallocate c

select * from #temp
order by convert(int, substring(data, 1, len(data)-3)) desc

drop table #temp
