-- 配合DBA_BackupSomeTables2.sql使用的一些监控语句
-- 1. 源数据库还有多少张表
select COUNT(*) as cnt from DB_SOURCE.INFORMATION_SCHEMA.TABLES with(nolock)
where TABLE_CATALOG = 'DB_SOURCE' and TABLE_TYPE = 'BASE TABLE'
      and TABLE_NAME like '%[_]2020[0-9][0-9]'

-- 2. 目标数据库有多少张表
select COUNT(*) as cnt from DB_TARGET_2020.INFORMATION_SCHEMA.TABLES with(nolock)

-- 3. 最近操作的3张表
select top (3) name, create_date, modify_date from DB_TARGET_2020.sys.tables with(nolock) order by create_date desc

-- 4. 当前正在迁移的表的迁移进度
-- 当提示表不存在时，是因为正在执行收缩数据库
declare @sql as nvarchar(max), @table as nvarchar(255)
select top (1) @table = name from DB_TARGET_2020.sys.tables order by create_date desc
set @sql = N'select '''+@table+N''' as cur_tb, COUNT(*) as cnt from DB_SOURCE.dbo.'+@table+N' with(nolock)'
exec sp_executesql @stmt = @sql
