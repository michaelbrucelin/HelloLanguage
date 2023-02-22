-- 查询表结构的创建以及最近一次更改时间
select [name], create_date, modify_date from sys.objects order by modify_date desc

-- 查询表最近一次数据更新时间（依赖索引）
select OBJECT_NAME(OBJECT_ID) as [table], last_user_update
from sys.dm_db_index_usage_stats
where     database_id = DB_ID('DBNAME')
      -- and OBJECT_ID = OBJECT_ID('TABLENAME')
order by [table]
