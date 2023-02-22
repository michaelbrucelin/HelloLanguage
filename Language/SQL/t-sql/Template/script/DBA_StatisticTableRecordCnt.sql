-- 统计每张表的数据条数

--1、使用系统视图sys.sysindexes
select o.[name], i.rowcnt
from sys.sysobjects as o
inner join sys.sysindexes as i on i.id = o.id
where o.xtype = 'U' and i.indid < 2
order by i.rowcnt desc

--2、使用系统视图sys.partitions
--他人推荐的，看执行计划确实比上面的快，但是没怎么用过
select o.[name], p.rows as rowcnt
from sys.sysobjects as o
inner join sys.partitions as p on p.object_id = o.id
where o.xtype = 'U' and p.index_id < 2
order by p.rows desc

--3、使用系统视图sys.dm_db_partition_stats
--这个不仅仅会查出数据库中每张表的数据条数，还会查出占用磁盘空间，未使用的磁盘等信息
;with c0 as(
select s.[name] as [schema_name], o.[type], o.[name] as obj_name
       , SUM(p.used_page_count * 8.0 / 1024) as used_size_mb
       , SUM(case when (p.index_id <= 1)
                  then (p.in_row_data_page_count + p.lob_used_page_count + p.row_overflow_used_page_count)
                  else  p.lob_used_page_count + p.row_overflow_used_page_count
             end) * 8.0 / 1024 as data_size_mb
       , SUM(case when (p.index_id <= 1) then row_count else 0 end) as row_count
from sys.dm_db_partition_stats as p
inner join sys.objects as o on p.[object_id] = o.[object_id]
inner join sys.schemas as s on s.[schema_id] = o.[schema_id]
where o.[type] in ('V', 'U', 'S')
group by s.[name], o.[type], o.[name]
)
select [schema_name], [type], obj_name, row_count
       , CAST(used_size_mb as decimal(18, 2)) as used_size_mb
       , CAST(data_size_mb as decimal(18, 2)) as data_size_mb
from c0
order by row_count desc;

--4、使用系统存储过程sp_MSforeachtable
--这个不仅仅会查出数据库中每张表的数据条数，还会查出占用磁盘空间，索引占用磁盘，未使用的磁盘等信息
create table #temp([name] nvarchar(255), [rows] int, reserved varchar(64), [data] varchar(64)
                   , index_size varchar(64), unused varchar(64))
exec sp_MSforeachtable 'insert into #temp EXEC sp_spaceused ''?'' '

select * from #temp order by [rows] desc
drop table #temp
